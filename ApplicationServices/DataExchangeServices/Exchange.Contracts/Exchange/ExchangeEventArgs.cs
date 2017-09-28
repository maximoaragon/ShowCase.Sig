using System;
using System.ComponentModel;
using System.Runtime.Serialization;

//using ClientDataModel.model.busobjs;

namespace Exchange.Contracts
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class OperationStateEventArgs : EventArgs
    {
        private ExchangeRequest m_ExchangeRequest = null;
        private AsyncOperationState m_OperationState = AsyncOperationState.Unknown;

        /// <summary>
        /// Constructor using fields
        /// </summary>
        /// <param name="exchangeRequest"></param>
        /// <param name="operationState"></param>
        public OperationStateEventArgs(
            ExchangeRequest exchangeRequest,
            AsyncOperationState operationState)
        {
            m_ExchangeRequest = exchangeRequest;
            m_OperationState = operationState;
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
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ExchangeRequestProgressChangedEventArgs : ProgressChangedEventArgs
    {
        /// <summary>
        /// Constructor using fields
        /// </summary>
        /// <param name="progressPercentage"></param>
        /// <param name="userToken"></param>
        public ExchangeRequestProgressChangedEventArgs(int progressPercentage, object userToken)
            : base(progressPercentage, userToken)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ExchangeRequestCompletedEventArgs : AsyncCompletedEventArgs
    {
        private ExchangeRequest m_ExchangeRequest = null;

        /// <summary>
        /// Constructor using fields
        /// </summary>
        /// <param name="exRequest"></param>
        /// <param name="e"></param>
        /// <param name="canceled"></param>
        /// <param name="state"></param>
        public ExchangeRequestCompletedEventArgs(ExchangeRequest exRequest, Exception e, bool canceled, object state)
            : base(e, canceled, state)
        {
            this.m_ExchangeRequest = exRequest;
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
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ExchangeRequestStartedEventArgs : EventArgs
    {
        private ExchangeRequest m_ExchangeRequest = null;
        private AsyncOperationState m_OperationState = AsyncOperationState.Unknown;

        /// <summary>
        /// Constructor using fields
        /// </summary>
        /// <param name="exchangeRequest"></param>
        /// <param name="operationState"></param>
        public ExchangeRequestStartedEventArgs(
            ExchangeRequest exchangeRequest,
            AsyncOperationState operationState)
        {
            m_ExchangeRequest = exchangeRequest;
            m_OperationState = operationState;
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
    }
}