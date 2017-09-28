using System.ServiceModel;
using System.ServiceModel.Channels;
using Exchange.Contracts.Services;

namespace Exchange.ClientLib
{
    public class PublishingServiceClient : ClientBase<IPublishingService>, IPublishingService 
    {
        public PublishingServiceClient()
        {
        }

        public PublishingServiceClient(string endpointConfigurationName) : base(endpointConfigurationName)
        {
        }

        public PublishingServiceClient(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
        {
        }

        public PublishingServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress)
        {
        }

        public PublishingServiceClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
        {
        }

        public void Publish(Exchange.Contracts.Message message)
        {
            base.Channel.Publish(message);
        }
    }
}
