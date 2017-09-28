using System;
using System.Collections.Generic;
using System.Linq;
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
    /// This class Implements the CommandRequest
    /// </summary>
    [DataContract]
    public class CommandRequest
    {
        private string m_RequestID;

        private AsyncCommands m_AsyncCommand;

        private object m_EventData;

        private int m_ExchangeID;
        private int m_ProcessWorkflowID;
        private string m_UriTemplate;
        private string m_InputUri;
        private ProcessingMode m_ProcessingMode;
        
        ///////////////////////////////////////////////////////////////////
        #region "Constructors"
        /// <summary>
        /// Default Constructor
        /// </summary>
        public CommandRequest()
        {            
        }

        /// <summary>
        /// Constructor using fields
        /// </summary>
        /// <param name="command"></param>
        public CommandRequest(AsyncCommands command)
        {
            m_AsyncCommand = command;
        }
        #endregion "Constructors"


        ///////////////////////////////////////////////////////////////////
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
        /// Gets/sets the AsyncOperationState property
        /// </summary>
        [DataMember]
        public AsyncCommands AsyncCommand
        {
            get { return m_AsyncCommand; }
            set { m_AsyncCommand = value; }
        }
        
        [DataMember]
        public object EventData
        {
            get { return m_EventData; }
            set { m_EventData = value; }
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
        #endregion "Properties / Attributes"
    }
}
