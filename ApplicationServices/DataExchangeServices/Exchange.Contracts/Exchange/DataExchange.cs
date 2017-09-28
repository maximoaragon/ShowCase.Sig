
namespace Exchange.Contracts
{
    /// <summary>
    /// Implements DataExchange
    /// </summary>
    public class DataExchange
    {       
        public int ExchangeID { get; set; }

        public string ExchangeName { get; set; }

        public string ExchangeDescription { get; set; }

        public bool RealTime { get; set; }

        public string ExchangeUri { get; set; }

        public int WorkflowID { get; set; }

        public bool Anonymous { get; set; }
    }
}
