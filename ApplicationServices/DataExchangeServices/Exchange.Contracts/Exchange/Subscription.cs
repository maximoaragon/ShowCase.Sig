using System;
using System.Runtime.Serialization;

namespace Exchange.Contracts
{
    /// <summary>
    /// Container object for data related to a subscription.  
    /// </summary>
    [DataContract]
    public class Subscription
    {
        /// <summary>
        /// The type of message you would like to subscribe to.  If you want to subscribe to only a specific request then pass in that request id. 
        /// If you just want to subscribe to all messages of a certain type then just pass in an instance of that type of message.
        /// </summary>
        [DataMember]
        public Message Message { get; set; }

        [DataMember]
        public Guid SubscriptionID { get; set; }

        [DataMember]
        public string Address { get; set; }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            Subscription s = obj as Subscription;
            if ((System.Object)s == null)
            {
                return false;
            }

            // Return true if the fields match:
            return SubscriptionID == s.SubscriptionID;
        }

        //Max 09/05/2013 - Not sure why overriding this operator
        //public static bool operator ==(Subscription a, Subscription b)
        //{
        //    if (a == null)
        //    {
        //        return false;
        //    }

        //    return a.Equals(b);
        //}

        //public static bool operator !=(Subscription a, Subscription b)
        //{
        //    return !(a == b);
        //}

        public override int GetHashCode()
        {
            return SubscriptionID.GetHashCode();
        }

    }
}
