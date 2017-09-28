using Exchange.Contracts.ShowCase;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Exchange.Contracts.Services
{
    [ServiceContractAttribute(Namespace = "http://aptitudesolutions.com/AuthenticationService/", ConfigurationName = "AuthenticationService.IAuthenticationService")]
    public interface IAuthenticationService
    {
        [OperationContractAttribute(Action = "http://aptitudesolutions.com/AuthenticationService/IAuthenticationService/AuthenticateUser", 
            ReplyAction = "http://aptitudesolutions.com/AuthenticationService/IAuthenticationService/AuthenticateUserResponse")]
        AuthenticationResponse AuthenticateUser(string userName, string password, Dictionary<string, string> additionalCredentials);

        [OperationContractAttribute(Action = "http://aptitudesolutions.com/AuthenticationService/IAuthenticationService/AuthenticateUser", 
            ReplyAction = "http://aptitudesolutions.com/AuthenticationService/IAuthenticationService/AuthenticateUserResponse")]
        Task<AuthenticationResponse> AuthenticateUserAsync(string userName, string password, System.Collections.Generic.Dictionary<string, string> additionalCredentials);

        [OperationContractAttribute(Action = "http://aptitudesolutions.com/AuthenticationService/IAuthenticationService/AuthenticateSupervisor",
            ReplyAction = "http://aptitudesolutions.com/AuthenticationService/IAuthenticationService/AuthenticateSupervisorResponse")]
        AuthenticationResponse AuthenticateSupervisor(string userName, string password, Dictionary<string, string> additionalCredentials, Dictionary<string, Claim[]> supervisorClaims);

        [System.ServiceModel.OperationContractAttribute(Action = "http://aptitudesolutions.com/AuthenticationService/IAuthenticationService/AuthenticateSupervisor"
            , ReplyAction = "http://aptitudesolutions.com/AuthenticationService/IAuthenticationService/AuthenticateSupervisorResponse")]
        Task<AuthenticationResponse> AuthenticateSupervisorAsync(string userName, string password, System.Collections.Generic.Dictionary<string, string> additionalCredentials, System.Collections.Generic.Dictionary<string, Claim[]> supervisorClaims);

        [OperationContractAttribute(Action = "http://aptitudesolutions.com/AuthenticationService/IAuthenticationService/ChangePassword", 
            ReplyAction = "http://aptitudesolutions.com/AuthenticationService/IAuthenticationService/ChangePasswordResponse")]
        AuthenticationResponse ChangePassword(string userName, string oldPassword, string newPassword, System.Collections.Generic.Dictionary<string, string> additionalCredentials);

        [OperationContractAttribute(Action = "http://aptitudesolutions.com/AuthenticationService/IAuthenticationService/ChangePassword"
            , ReplyAction = "http://aptitudesolutions.com/AuthenticationService/IAuthenticationService/ChangePasswordResponse")]
        Task<AuthenticationResponse> ChangePasswordAsync(string userName, string oldPassword, string newPassword, System.Collections.Generic.Dictionary<string, string> additionalCredentials);
    }
}
