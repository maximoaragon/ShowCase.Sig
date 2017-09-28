using Exchange.Contracts;
using Exchange.Contracts.Services;
using ShowCaseUtil;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Exchange.ClientLib
{
    /// <summary>
    /// Manages publisher clients from the PubSub service
    /// </summary>
    public class PublishingServiceManager : Exchange.ClientLib.PublishingServiceClient, IDisposable
    {
        private static IPublishingService m_publishingServiceChannel = null;
        private static ChannelFactory<IPublishingService> m_channelFactory = null;
        private static bool m_retry = false;
        private static readonly object locked = new object();

        public PublishingServiceManager()
        {
            ResetConnection();
        }

        /// <summary>
        /// Publishes a message
        /// </summary>
        /// <param name="message"></param>
        public void PublishMessage(Message message)
        {
            if (!ResetConnection())
                return;

            try
            {
                m_publishingServiceChannel.Publish(message);
                Logger.Log(string.Format("{0} was published ", message.GetType().Name, LogLevel.Verbose, new Dictionary<string, object>() { { "RequestName", message.RequestName }, { "RequestID",message.RequestID } }));
            }
            catch 
            {
                //Logger.Log("Error publishing a message", LogLevel.Warning, new Dictionary<string, object>() { { "Exception", ex } });
                if (m_retry)
                {
                    try
                    {
                        m_publishingServiceChannel.Publish(message);
                    }
                    catch(Exception iex)
                    {
                        Logger.Log("Error publishing a message", LogLevel.Warning, new Dictionary<string, object>() { { "Exception", iex } });
                    }
                }
            }
        }
        
        /// <summary>
        /// Closes publisher proxy and disposes internal resources
        /// </summary>
        public void Dispose()
        {
            Disconnect();
        }

        #region Private Methods

        private bool ResetConnection()
        {
            bool reset = true;
            lock(locked)
            {
                if (m_publishingServiceChannel == null || ((ICommunicationObject)m_publishingServiceChannel).State == CommunicationState.Faulted || ((ICommunicationObject)m_publishingServiceChannel).State == CommunicationState.Closed)
                {
                    try
                    {
                        m_channelFactory = new ChannelFactory<IPublishingService>(this.Endpoint.Binding, this.Endpoint.Address);
                        m_channelFactory.Faulted += ChannelFactory_Faulted;
                    
                        m_channelFactory.Open();

                        m_publishingServiceChannel = m_channelFactory.CreateChannel();
                        ((ICommunicationObject)m_publishingServiceChannel).Faulted += new EventHandler(Client_Faulted);
                        reset = true;
                    }
                    catch (Exception ex)
                    {
                        reset = false;
                        Logger.Log("Error connecting to the publisher service", LogLevel.Warning, new Dictionary<string, object>() { { "Exception", ex } });
                    }
                }
            }
            return reset;
        }

        private void ChannelFactory_Faulted(object sender, EventArgs e)
        {
            m_channelFactory.Faulted -= ChannelFactory_Faulted;
            m_channelFactory = null;
        }

        private void Client_Faulted(object sender, EventArgs e)
        {
            try
            {
                ShowCaseUtil.Logger.Log(AppDomain.CurrentDomain.SetupInformation.ApplicationName + " PublishingServiceManager Client Fault", ShowCaseUtil.LogLevel.Verbose);
                ((ICommunicationObject)m_publishingServiceChannel).Abort();
            }
            finally
            {
                m_retry = ResetConnection();
            }
        }

        private void Disconnect()
        {
            try
            {
                if (m_channelFactory != null && m_channelFactory.State != CommunicationState.Faulted)
                    m_channelFactory.Close();              
            }
            catch (Exception ex)
            {
                Logger.Log("Error closing the channel factory", LogLevel.Verbose, new Dictionary<string, object>() { { "Exception", ex } });
            }
            m_channelFactory = null;

            try
            {
                if (m_publishingServiceChannel != null && ((ICommunicationObject)m_publishingServiceChannel).State != CommunicationState.Faulted)
                    ((ICommunicationObject)m_publishingServiceChannel).Close();
            }
            catch (Exception ex)
            {
                Logger.Log("Error closing the client", LogLevel.Verbose, new Dictionary<string, object>() { { "Exception", ex } });
            }
            m_publishingServiceChannel = null;        
        }

        #endregion
    }
}
