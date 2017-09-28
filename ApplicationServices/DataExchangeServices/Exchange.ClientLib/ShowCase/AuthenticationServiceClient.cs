using Exchange.Contracts.Services;
using Exchange.Contracts.ShowCase;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Exchange.ClientLib
{
    public class AuthenticationServiceClient : ClientBase<IAuthenticationService>, IAuthenticationService 
    {
        public AuthenticationServiceClient() {
        }
        
        public AuthenticationServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthenticationServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticationServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticationServiceClient(Binding binding, EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public AuthenticationResponse AuthenticateUser(string userName, string password, Dictionary<string, string> additionalCredentials) {
            return base.Channel.AuthenticateUser(userName, password, additionalCredentials);
        }

        public System.Threading.Tasks.Task<AuthenticationResponse> AuthenticateUserAsync(string userName, string password, System.Collections.Generic.Dictionary<string, string> additionalCredentials)
        {
            return base.Channel.AuthenticateUserAsync(userName, password, additionalCredentials);
        }
        
        public AuthenticationResponse AuthenticateSupervisor(string userName, string password, Dictionary<string, string> additionalCredentials, System.Collections.Generic.Dictionary<string, Claim[]> supervisorClaims) {
            return base.Channel.AuthenticateSupervisor(userName, password, additionalCredentials, supervisorClaims);
        }

        public Task<AuthenticationResponse> AuthenticateSupervisorAsync(string userName, string password, System.Collections.Generic.Dictionary<string, string> additionalCredentials, System.Collections.Generic.Dictionary<string, Claim[]> supervisorClaims)
        {
            return base.Channel.AuthenticateSupervisorAsync(userName, password, additionalCredentials, supervisorClaims);
        }

        public AuthenticationResponse ChangePassword(string userName, string oldPassword, string newPassword, Dictionary<string, string> additionalCredentials)
        {
            return base.Channel.ChangePassword(userName, oldPassword, newPassword, additionalCredentials);
        }

        public Task<AuthenticationResponse> ChangePasswordAsync(string userName, string oldPassword, string newPassword, System.Collections.Generic.Dictionary<string, string> additionalCredentials)
        {
            return base.Channel.ChangePasswordAsync(userName, oldPassword, newPassword, additionalCredentials);
        }
    }
}
