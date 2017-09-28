using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ComponentModel;

using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Exchange.Contracts
{
    /// <summary>
    /// This class Implements the EventMessage
    /// </summary>
    [DataContract]
    public class EventMessage : Message
    {               
        private AsyncEvents m_EventType = AsyncEvents.Unknown;        
        private ExchangeRequest m_ExchangeRequest = null;
        private AsyncOperationState m_OperationState = AsyncOperationState.Unknown;
        private Exception m_Exception = null;
        private bool m_Canceled;
        private int m_ProgressPercentage;
        private System.Xml.XmlElement m_InputData;
        
        ///////////////////////////////////////////////////////////////////
        #region "Constructors"
        /// <summary>
        /// Default Constructor
        /// </summary>
        public EventMessage()
        {            
        }

        public EventMessage(ExchangeRequestStartedEventArgs evt, AsyncEvents eventType)
        {
            m_ExchangeRequest = evt.ExchangeRequest;
            m_OperationState = evt.OperationState;
            m_EventType = eventType;
        }

        public EventMessage(OperationStateEventArgs evt, AsyncEvents eventType)
        {
            m_ExchangeRequest = evt.ExchangeRequest;
            m_OperationState = evt.OperationState;
            m_EventType = eventType;
        }

        public EventMessage(ProgressChangedEventArgs evt, AsyncEvents eventType)
        {
            m_ProgressPercentage = evt.ProgressPercentage;
            m_ExchangeRequest = (ExchangeRequest)evt.UserState;            
            m_EventType = eventType;
        }

        public EventMessage(ExchangeRequestCompletedEventArgs evt, AsyncEvents eventType)
        {
            m_ExchangeRequest = evt.ExchangeRequest;                   
            m_EventType = eventType;
            m_Canceled = evt.Cancelled;
            m_Exception = evt.Error;
        }       
        
        #endregion "Constructors"


        ///////////////////////////////////////////////////////////////////
        #region "Properties / Attributes"

        /// <summary>
        /// Gets/sets the EventType property
        /// </summary>
        [DataMember]
        public AsyncEvents EventType
        {
            get { return m_EventType; }
            set { m_EventType = value; }
        }

        /// <summary>
        /// Gets the ExchangeRequest property
        /// </summary>
        [DataMember]
        public ExchangeRequest ExchangeRequest
        {
            get { return m_ExchangeRequest; }
            set { m_ExchangeRequest = value; }
        }

        /// <summary>
        /// Gets the OperationState property
        /// </summary>
        [DataMember]
        public AsyncOperationState OperationState
        {
            get { return m_OperationState; }
            set { m_OperationState = value; }
        }

        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public bool Canceled
        {
            get { return m_Canceled; }
            set { m_Canceled = value; }
        }

        [DataMember]
        public int ProgressPercentage
        {
            get { return m_ProgressPercentage; }
            set { m_ProgressPercentage = value; }
        }

        [DataMember]        
        public XmlElement InputData
        {
            get { return m_InputData; }
            set { m_InputData = value; }
        }

        #endregion "Properties / Attributes"
    }
}
