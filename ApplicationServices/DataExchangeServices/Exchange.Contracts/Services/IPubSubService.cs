using System.ServiceModel;
using Exchange.Contracts;

namespace Exchange.Contracts.Services
{

    [ServiceContract(Namespace = "http://schemas.Aptitude.com/PubSubService")]
    [ServiceKnownType("GetKnownPublishingTypes", typeof(ServiceHelpers))]
    public interface IPublishingService //: IEventNotification<Message>
    {
        [OperationContract(IsOneWay = true)]
        void Publish(Message message);
    }

    [ServiceContract(CallbackContract = typeof(IPublishingService), Namespace = "http://schemas.Aptitude.com/2010/09/PubSubService")]
    [ServiceKnownType("GetKnownSubscriptionTypes", typeof(ServiceHelpers))]
    public interface ISubscriptionService
    {
        [OperationContract]
        void Subscribe(Subscription subscription);

        [OperationContract]
        void UnSubscribe(Subscription subscription);
    }
}
