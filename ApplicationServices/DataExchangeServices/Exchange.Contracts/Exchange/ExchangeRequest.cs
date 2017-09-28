using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

using System.ServiceModel;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Exchange.Contracts
{
    /// <summary>
    /// Implements ExchangeRequest
    /// </summary>    
    [DataContract]   
    public class ExchangeRequest
    {                
        private string m_RequestID;        
        private int m_ExchangeID;        
        private int m_ProcessWorkflowID;        
        private string m_UriTemplate;        
        private string m_InputUri;        
        private ProcessingMode m_ProcessingMode;        
        private Dictionary<string, string> m_ExchangeParameters = new Dictionary<string, string>();        
        private System.Xml.XmlElement m_InputData;

        #region "Constructors"
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ExchangeRequest() 
        {
            m_RequestID = Guid.NewGuid().ToString();
        }
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
        
        [DataMember]
        public bool IsComplete { get; set; }

        /// <summary>
        /// Flag to mark a request as completed
        /// </summary>
        [DataMember]
        public string ExchangeName { get; set; }

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
        /// Gets/sets the ExchangeParameters property
        /// </summary>
        [DataMember]
        public Dictionary<string, string> ExchangeParameters
        {
            get { return m_ExchangeParameters; }
            set { m_ExchangeParameters = value; }
        }

        /// <summary>
        /// Gets or sets the result of this response
        /// </summary>
        [DataMember]
        public XmlElement InputData
        {
            get { return m_InputData; }
            set { m_InputData = value; }
        }

        [DataMember]
        public string WorkerAddress { get; set; }

        [IgnoreDataMember]
        public DataExchange DataExchange { get; set; }

        #endregion "Properties / Attributes"

        public string GetParameterValue(string parameterName)
        {
            string returnValue = null;
            parameterName = parameterName.ToUpper();
            if (m_ExchangeParameters.ContainsKey(parameterName))
            {
                returnValue = m_ExchangeParameters[parameterName];
            }

            return returnValue;
        }

        public override string ToString()
        {
            DataContractSerializer dcs = new DataContractSerializer(typeof(ExchangeRequest));

            using (MemoryStream ms = new MemoryStream())
            {
                dcs.WriteObject(ms, this);
                ms.Seek(0, SeekOrigin.Begin);

                using (StreamReader reader = new StreamReader(ms))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
