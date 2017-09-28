using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel;
using Exchange.Contracts;
using Exchange.Contracts.Services;

using ShowCaseUtil;
using System.Timers;
using System.ServiceModel.Configuration;


namespace Exchange.ClientLib
{
    /// <summary>
    /// Argument to include in a subscription callback
    /// </summary>
    public class MessageArgs
    {
        public Message message { get; set; }
        public bool Disconnected { get; set; }
    }

    /// <summary>
    /// Type of delegate to invoke subcribers.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void SubscriptionServiceCallBackEventHander(object sender, MessageArgs e);

    /// <summary>
    /// Manages subscribers clients from the PubSub service
    /// </summary>
    [CallbackBehavior(UseSynchronizationContext=false)]
    public class SubscriptionServiceManager : IDisposable, IPublishingService //, ISubscriptionServiceCallback
    {
        private const int RETRYINTERVAL = 3000;
      
        private DuplexChannelFactory<ISubscriptionService> m_ChannelFactory;
        private ISubscriptionService m_Client;
        private Subscription m_Subscription;
        private bool m_Subscribed = false;

        private static string m_endpointName = ConfigurationManager.AppSettings["SubscriptionServiceClientEndpoint"];
        private readonly static object locked = new object();
        private readonly object instanceLocked = new object();
        
        /// <summary>
        /// Time elapsed before subscriber un-subscribes from the service after calling the Subscribe method.
        /// </summary>
        public TimeSpan AutoDisconect { get; set; }
        
        /// <summary>
        /// True if subscribed with the PubSub. False otherwise
        /// </summary>
        public bool Subscribed { get {return m_Subscribed;} }
        
        /// <summary>
        /// Delegate called when a subscription callback is issued
        /// </summary>
        public event SubscriptionServiceCallBackEventHander SubscriptionServiceCallbackEvent;

        #region "Constructors"

        public SubscriptionServiceManager() : this(null, null) { }
        public SubscriptionServiceManager(Subscription subscription) : this(subscription, null) { }

        public SubscriptionServiceManager(Subscription subscription, string endpointConfigurationName)
        {
            m_Subscription = subscription;
            MakeTraceProxy(this, endpointConfigurationName);
        }

        public SubscriptionServiceManager(string endpointConfigurationName)
        {
            MakeTraceProxy(this, endpointConfigurationName);
        }

        #endregion

        private void MakeTraceProxy(object callbackinstance, string endpointConfigurationName)
        {
            InstanceContext context = new InstanceContext(callbackinstance);
            context.SynchronizationContext = new SubContext();
            
            // if no endpoint configuratino passed, it will default to the enpointname in SubscriptionServiceClientEndpoint setting

            if (!string.IsNullOrEmpty(endpointConfigurationName))
            {
                //Use endpoint specified in SubscriptionServiceClientEndpoint setting
                m_endpointName = endpointConfigurationName;
                m_ChannelFactory = new DuplexChannelFactory<ISubscriptionService>(context, m_endpointName);
            }
            else
            {
                //Use endpoint with the ISubscriptionService contract
                lock (locked)
                {
                    if (string.IsNullOrEmpty(m_endpointName))
                    {
                        ClientSection sectionGroup = ConfigurationManager.GetSection("system.serviceModel/client") as ClientSection;

                        foreach (ChannelEndpointElement endpoint in sectionGroup.Endpoints)
                        {
                            if (endpoint.Contract.EndsWith(".ISubscriptionService"))
                            {
                                //m_subEndpoint = endpoint;
                                m_endpointName = endpoint.Name;
                                break;
                            }
                        }
                        if (string.IsNullOrEmpty(m_endpointName))
                            throw new Exception("Unable to find endpoint configured for the ISubscriptionService contract.");
                    }
                }
                m_ChannelFactory = new DuplexChannelFactory<ISubscriptionService>(context, m_endpointName);
            }
            
            m_ChannelFactory.Faulted += new EventHandler(ChannelFactory_Faulted);
            
            
            m_Client = m_ChannelFactory.CreateChannel();
            ((ICommunicationObject)m_Client).Faulted += new EventHandler(ClientChannel_Faulted);
         }

        private void ChannelFactory_Faulted(object sender, EventArgs e)
        {
            try
            {
                ShowCaseUtil.Logger.Log(AppDomain.CurrentDomain.SetupInformation.ApplicationName + " SubscriptionServiceManager Channel Fault", ShowCaseUtil.LogLevel.Verbose);
                m_ChannelFactory.Abort();
            }
            finally
            {
                m_ChannelFactory = null;
                MakeTraceProxy(this, null);   
            }
        }

        private void ClientChannel_Faulted(object sender, EventArgs e)
        {
            try
            {
                ShowCaseUtil.Logger.Log(AppDomain.CurrentDomain.SetupInformation.ApplicationName + " SubscriptionServiceManager Client Fault", ShowCaseUtil.LogLevel.Verbose);
                ((ICommunicationObject)sender).Abort();

                Timer t = new Timer(RETRYINTERVAL);
                t.AutoReset = false;
                t.Elapsed += (s, arg) =>
                {
                    if (CanConnect())
                    {
                        t.AutoReset = false;
                        try
                        {
                            MakeTraceProxy(this, null);
                            Subscribe();
                            ShowCaseUtil.Logger.Log("Subscriber was re-connected", ShowCaseUtil.LogLevel.Verbose);
                            t.Stop();
                            t.Dispose();
                        }
                        catch (Exception ex)
                        {
                            ShowCaseUtil.Logger.Log(AppDomain.CurrentDomain.SetupInformation.ApplicationName + " SubscriptionServiceManager Client Fault - Unable to Reconnect to the PubSub", ShowCaseUtil.LogLevel.Verbose, new Dictionary<string, object>() { { "Exception", ex } });
                            //Retry in RETRYINTERVAL seconds
                            t.AutoReset = true;
                        }
                    }
                    else
                    {
                        //Retry in RETRYINTERVAL seconds
                        t.AutoReset = true;
                    }
                };
                t.Start();
            }
            catch (Exception ex)
            {
                ShowCaseUtil.Logger.Log(AppDomain.CurrentDomain.SetupInformation.ApplicationName + " Error in Subscription ServiceManager SubClientChannel_Faulted", ShowCaseUtil.LogLevel.Verbose, new Dictionary<string, object>() { { "Exception", ex } });
            }
        }

        /// <summary>
        /// Calls PubSub service to subscribe with a particular message. CreateSubscription function should be called prior this method to create a subscription.
        /// </summary>
        public void Subscribe()
        {
            if (m_Subscription == null)
                throw new Exception("A subscribe call was made without a valid subscription. Make sure the SubscriptionServiceManager class has a valid subscription before calling subscribe.");

            if (m_Client != null)
            {
                try
                {
                    ((ICommunicationObject)m_Client).Open();
                    m_Client.Subscribe(m_Subscription);
                    m_Subscribed = true;

                    if (AutoDisconect > TimeSpan.Zero)
                    {
                        SetTimer(AutoDisconect);
                    }

                    ShowCaseUtil.Logger.Log(AppDomain.CurrentDomain.SetupInformation.ApplicationName + " subscribed to " + m_Subscription.Message.ToString(), ShowCaseUtil.LogLevel.Verbose);
                }
                catch (FaultException fex)
                {
                    if (m_ChannelFactory.State == CommunicationState.Faulted)
                    {
                        m_ChannelFactory.Abort();
                    }
                }
                catch 
                {
                    //Let callers determine the LogLevel of this error
                    throw;
                    //ShowCaseUtil.Logger.Log("Error subscribing to " + Convert.ToString(m_Subscription.SubscriptionID), ShowCaseUtil.LogLevel.Error, new Dictionary<string, object>() { { "Exception", ex } });
                }
            }
        }

        /// <summary>
        /// Unsubscribe from any subscription created by this instance.
        /// </summary>
        public void UnSubscribe()
        {
            try
            {
                m_Subscribed = false;
                if (m_Subscription != null && m_Client != null)
                {
                    m_Client.UnSubscribe(m_Subscription);
                }
            }
            catch{}
        }

        /// <summary>
        /// Use to determine if the subscriber can connect to the PubSub Service
        /// </summary>
        /// <returns></returns>
        public bool CanConnect()
        {
            try
            {
                InstanceContext context = new InstanceContext(this);

                var factory = new DuplexChannelFactory<ISubscriptionService>(context, m_endpointName);
                ICommunicationObject testClient = factory.CreateChannel() as ICommunicationObject;
                
                testClient.Open(TimeSpan.FromSeconds(10));
                testClient.Close();

                return true;
            }
            catch (Exception ex)
            {
                ShowCaseUtil.Logger.Log(AppDomain.CurrentDomain.SetupInformation.ApplicationName + " Cannot connect subscriber to PubSub", ShowCaseUtil.LogLevel.Verbose, new Dictionary<string, object>() { { "Exception", ex } });
            }

            return false;
        }

        /// <summary>
        /// Creates a subscription for the message. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public Subscription CreateSubscription<T>(T message) where T : Message
        {
            Subscription sub = new Subscription();
            sub.SubscriptionID = new Guid();
            sub.Message = message;

            if (m_ChannelFactory != null && m_ChannelFactory.Endpoint.Binding is WSDualHttpBinding)
            {
                WSDualHttpBinding dhb = (WSDualHttpBinding)m_ChannelFactory.Endpoint.Binding;
                if (dhb.ClientBaseAddress != null)
                    sub.Address = dhb.ClientBaseAddress.ToString();

                if (dhb.ReliableSession.InactivityTimeout < TimeSpan.FromMinutes(30))
                    dhb.ReliableSession.InactivityTimeout = TimeSpan.FromMinutes(30);
            }
            else if (m_ChannelFactory != null && m_ChannelFactory.Endpoint.Binding is NetTcpBinding)
            {
                NetTcpBinding ntb = (NetTcpBinding)m_ChannelFactory.Endpoint.Binding;

                if (ntb.ReliableSession.InactivityTimeout < TimeSpan.FromMinutes(30))
                    ntb.ReliableSession.InactivityTimeout = TimeSpan.FromMinutes(30);
            }

            sub.SubscriptionID = Guid.NewGuid();
            m_Subscription = sub;

            return sub;
        }

        /// <summary>
        /// Subscribes to all events for the request
        /// </summary>
        /// <param name="requestID"></param>
        /// <returns></returns>
        public Subscription CreateSubscription(string requestID)
        {
            var msg = new ExchangeMessage() 
            {
                RequestID = Guid.Parse(requestID)
            };
            return CreateSubscription<ExchangeMessage>(msg);
        }

        /// <summary>
        /// Used call back subscribers
        /// </summary>
        /// <param name="message"></param>
        public void Publish(Message msg)
        {
            lock (instanceLocked)
            {
                if (SubscriptionServiceCallbackEvent != null)
                {
                    MessageArgs args = new MessageArgs() 
                    {
                        message = msg,
                        Disconnected = !m_Subscribed
                    };
                    SubscriptionServiceCallbackEvent(this, args);
                }
            }
        }

        private void SetTimer(TimeSpan time)
        {
            Timer t = new Timer(time.TotalMilliseconds);
            t.AutoReset = false;
            t.Elapsed += (s, args) => 
            {
                t.Dispose();
                UnSubscribe();
                Publish(null);
            };
            t.Start();
        }

        /// <summary>
        /// Unsubscribe and disposes internal subscriber resources. 
        /// </summary>
        public void Dispose()
        {
            bool factoryClosed = false;
            bool clientClosed = false;

            UnSubscribe();

            try
            {
                if (m_ChannelFactory != null && m_ChannelFactory.State != CommunicationState.Closed && m_ChannelFactory.State != CommunicationState.Faulted)
                {
                    m_ChannelFactory.Close();
                    m_ChannelFactory.Faulted -= new EventHandler(ChannelFactory_Faulted);
                    factoryClosed = true;
                }
            }
            catch { }   //Dispose should never error
            finally
            {
                if (!factoryClosed && m_ChannelFactory != null)
                    m_ChannelFactory.Abort();
                m_ChannelFactory = null;
            }

            try
            {
                if (m_Client != null)
                {
                    ((ICommunicationObject)m_Client).Close();
                    ((ICommunicationObject)m_Client).Faulted -= new EventHandler(ClientChannel_Faulted);
                    clientClosed = true;
                }
            }
            catch { } //Dispose should never error
            finally
            {
                if (!clientClosed && m_Client != null)
                {
                    ((ICommunicationObject)m_Client).Abort();
                }
                m_Client = null;
            }
        }
    }

    internal class SubContext : System.Threading.SynchronizationContext
    {
        private System.Security.Principal.IPrincipal m_claim = null;

        public SubContext()
        {
            m_claim = System.Threading.Thread.CurrentPrincipal;
        }

        public override void Post(System.Threading.SendOrPostCallback d, object state)
        {
            if (m_claim != null)
                System.Threading.Thread.CurrentPrincipal = m_claim;

            d(state);
        }
    }
}
