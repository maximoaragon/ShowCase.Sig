using System;
using System.Data;
using System.Runtime.Serialization;

namespace Exchange.Contracts.ShowCase
{

    [DataContract]
    public class CachedDataTableRequest
    {
        #region Members

        private string m_CacheDomain;           // The name of the target database environment "Collier","Collier Test", etc
        private string m_DataTableName;         // The name of the datatable
        private DateTime m_CurrentCacheVersion;   // DateTime representing the last change to the datatable

        #endregion

        #region Properties

        /// <summary>
        /// Specifies the domain (Database name) of the cached item the caller wishes to retrieve 
        /// </summary>
        /// <value>
        /// The name of the domain instance
        /// </value>
        /// <returns></returns>
        /// <remarks>The domain could be "Collier", "Collier Dev", "Test", etc...</remarks>
        [DataMember]
        public string CacheDomain
        {
            get { return m_CacheDomain; }
            set { m_CacheDomain = value; }
        }

        /// <summary>
        /// Specifies the name of the cached datatable the caller wants returned
        /// </summary>
        /// <value>String representing the table name</value>
        /// <returns></returns>
        /// <remarks>Example: Agency</remarks>
        [DataMember]
        public string DataTableName
        {
            get { return m_DataTableName; }
            set { m_DataTableName = value; }
        }

        /// <summary>
        /// Date time representing the latest change to the DataTable in the clients cache. DateTime.MinValue if the client doesn't have
        /// an instance of this DataTable in cache.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks>If the DateTime value passed in this property matches the DateTime of the server cached instance 
        /// the cached DataTable will be returned as nothing (null) in the response</remarks>
        [DataMember]
        public DateTime CurrentCacheVersion
        {
            get { return m_CurrentCacheVersion; }
            set { m_CurrentCacheVersion = value; }
        }

        /// <summary>
        /// Optional filter used when loading the cache. This allows narrow the cached data.
        /// </summary>
        [DataMember]
        public string DataFilter { get; set; }

        #endregion
    }


    [DataContract]
    public class CachedDataTableResponse
    {
        #region Members

        private string m_CacheDomain = String.Empty;                   // The name of the target database environment "Collier","Collier Test", etc
        private string m_DataTableName = String.Empty;                 // The name of the datatable
        private DataTable m_CachedDataTable = null;                 // The DataTable returned from cache
        private DateTime m_CurrentCacheVersion = DateTime.MinValue;    // DateTime representing the last change to the datatable
        private TimeSpan m_RefreshDelay = new TimeSpan(0, 1, 0);       // Time to wait before checking cache
        private string m_SerializedDataTable = string.Empty;

        #endregion

        #region Properties

        /// <summary>
        /// Specifies the domain (Database name) of the cached item the caller wishes to retrieve 
        /// </summary>
        /// <value>
        /// The name of the domain instance
        /// </value>
        /// <returns></returns>
        /// <remarks>The domain could be "Collier", "Collier Dev", "Test", etc...</remarks>
        [DataMember]
        public string CacheDomain
        {
            get { return m_CacheDomain; }
            set { m_CacheDomain = value; }
        }

        /// <summary>
        /// Specifies the name of the cached datatable the caller wants returned
        /// </summary>
        /// <value>String representing the table name</value>
        /// <returns></returns>
        /// <remarks>Example: Agency</remarks>
        [DataMember]
        public string DataTableName
        {
            get { return m_DataTableName; }
            set { m_DataTableName = value; }
        }

        /// <summary>
        /// Specifies the minimum time the client should wait before checking the cache again
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [DataMember]
        public TimeSpan RefreshDelay
        {
            get { return m_RefreshDelay; }
            set { m_RefreshDelay = value; }
        }

        /// <summary>
        /// Date time representing the latest change to the DataTable in the clients cache. DateTime.MinValue if the client doesn't have
        /// an instance of this DataTable in cache.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks>If the DateTime value passed in this property matches the DateTime of the server cached instance 
        /// the cached DataTable will be returned as nothing (null) to the response</remarks>
        [DataMember]
        public DataTable cachedDataTable
        {
            get { return m_CachedDataTable; }
            set { m_CachedDataTable = value; }
        }

        /// <summary>
        /// Date time representing the latest change to the DataTable in the servers cache.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks>If the DateTime value passed in this property matches the DateTime of the server cached instance 
        /// the cached DataTable will be returned as nothing (null) in the response</remarks>
        [DataMember]
        public DateTime CurrentCacheVersion
        {
            get { return m_CurrentCacheVersion; }
            set { m_CurrentCacheVersion = value; }
        }

        [DataMember]
        public string SerializedDataTable
        {
            get { return m_SerializedDataTable; }
            set { m_SerializedDataTable = value; }
        }

        #endregion
    }
}
