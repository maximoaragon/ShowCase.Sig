using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.IO;
using System.Xml.Serialization;

namespace Exchange.Contracts
{
    /// <summary>
    /// Implements ExchangeResponse
    /// </summary>
    [DataContract]
    public class ExchangeResponse
    {        
        private string m_RequestID;
        private int m_ExchangeID;
        private int m_ProcessWorkflowID;
        private string m_UriTemplate;
        private string m_InputUri;
        private ProcessingMode m_ProcessingMode;        
        
        private System.Xml.XmlDocument m_Result;

        #region "Constructors"
        
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ExchangeResponse() { }
        
        #endregion "Constructors"

        #region "Properties / Attributes"

        /// <summary>
        /// Gets/sets the RequestID property
        /// </summary>
        [DataMember]
        public string RequestID
        {
            get { return m_RequestID; }
            set { m_RequestID = value; }
        }

        /// <summary>
        /// Gets/sets the ExchangeID property
        /// </summary>
        [DataMember]
        public int ExchangeID
        {
            get { return m_ExchangeID; }
            set { m_ExchangeID = value; }
        }

        /// <summary>
        /// Gets/sets the UriTemplate property
        /// </summary>
        [DataMember]
        public string UriTemplate 
        {
            get { return m_UriTemplate; }
            set { m_UriTemplate = value; }
        }

        /// <summary>
        /// Gets/sets the InputUri property
        /// </summary>
        [DataMember]
        public string InputUri
        {
            get { return m_InputUri; }
            set { m_InputUri = value; }
        }

        /// <summary>
        /// Gets/sets the ProcessingMode property
        /// </summary>
        [DataMember]
        public ProcessingMode ProcessingMode
        {
            get { return m_ProcessingMode; }
            set { m_ProcessingMode = value; }
        }

        /// <summary>
        /// Gets/sets the ProcessWorkflowID property
        /// </summary>
        [DataMember]
        public int ProcessWorkflowID
        {
            get { return m_ProcessWorkflowID; }
            set { m_ProcessWorkflowID = value; }
        }
        

        /// <summary>
        /// Gets or sets the result of this response
        /// </summary>
        [DataMember]
        public System.Xml.XmlDocument Result
        {
            get { return m_Result; }
            set { m_Result = value; }
        }

        #endregion "Properties / Attributes"

        public override string ToString()
        {
            XmlSerializer xs = new XmlSerializer(typeof(ExchangeResponse));

            using (StringWriter sw = new StringWriter())
            {
                xs.Serialize(sw, this);
                return sw.ToString();
            }
        }

        /// <summary>
        /// Returns a deserialized object of Result XML. Callers must konw the type to be deresialized.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetResultObject<T>() where T : class
        {
            if (this.Result == null)
                return null;
            T result = null;

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            try
            {
                using (StringReader reader = new StringReader(this.Result.OuterXml))
                {
                    result = (T)serializer.Deserialize(reader);
                }
            }
            catch { }
            return result;
        }

        /// <summary>
        /// Parse XML into an ExchangeResponse object
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static ExchangeResponse Deserialize(System.String xml)
        {
            ExchangeResponse er = new ExchangeResponse();
            System.Xml.XmlDocument xd, xdResult;

            xd = new System.Xml.XmlDocument();
            xd.LoadXml(xml);

            System.Xml.XmlNodeList nl = xd.GetElementsByTagName("RequestID");
            if (nl.Count > 0)
                er.RequestID = nl[0].InnerXml;

            nl = xd.GetElementsByTagName("Result");
            if (nl.Count > 0) {
                xdResult = new System.Xml.XmlDocument();
                xdResult.LoadXml(nl[0].OuterXml);
                er.Result = xdResult;
            }

            return er;
        }
    }
}
