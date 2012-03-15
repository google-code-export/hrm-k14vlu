using System;
using System.ComponentModel;
using System.ServiceModel.DomainServices.Client.ApplicationServices;
using System.Security.Principal;
using WebManagement.Service;

namespace WebManagement.Common
{
    public interface IAuthenticationModel : IModelBase
    {
        void ChangePasswordAsync(int userID, string password, string newPassword);
        event EventHandler<InvokeOperationEventArgs> ChangePasswordComplete;
        void LoadUserAsync();
        event EventHandler<LoadUserOperationEventArgs> LoadUserComplete;
        void LoginAsync(LoginParameters loginParameters);
        event EventHandler<LoginOperationEventArgs> LoginComplete;
        void LogoutAsync();
        event EventHandler<LogoutOperationEventArgs> LogoutComplete;

        IPrincipal User { get; }
        Boolean IsBusy { get; }
        Boolean IsLoadingUser { get; }
        Boolean IsLoggingIn { get; }
        Boolean IsLoggingOut { get; }
        Boolean IsSavingUser { get; }

        event EventHandler<AuthenticationEventArgs> AuthenticationChanged;
    }
}
