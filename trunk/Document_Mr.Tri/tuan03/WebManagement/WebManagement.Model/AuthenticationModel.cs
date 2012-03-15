using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel.DomainServices.Client;

using WebManagement.Common;
using WebManagement.Service;
using System.ServiceModel.DomainServices.Client.ApplicationServices;
using System.Security.Principal;

namespace WebManagement.Model
{
    [Export(typeof(IAuthenticationModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class AuthenticationModel : ModelBase, IAuthenticationModel
    {
        #region "Private Data"
        private static AuthenticationService _service;
        #endregion "Private Data"

        #region "Protected Propertes"
        protected AuthenticationService AuthService
        {
            get
            {
                if (_service == null)
                {
                    ((WebAuthenticationService)WebContext.Current.Authentication).DomainContext = new AuthenticationContext();
                    _service = WebContext.Current.Authentication;

                    ((INotifyPropertyChanged)_service).PropertyChanged += _service_PropertyChanged;
                    _service.LoggedIn += _service_LoggedIn;
                    _service.LoggedOut += _service_LoggedOut;
                }

                return _service;
            }
        }
        #endregion "Protected Propertes"

        #region Public Methods
        public void ChangePasswordAsync(int userID, string password, string newPassword)
        {
            ModelBusiness.ChangePassword(userID, password, newPassword, c =>
            {
                if (ChangePasswordComplete != null)
                    ChangePasswordComplete(this, new InvokeOperationEventArgs(c, null));
            }, null);
        }

        public void LoadUserAsync()
        {
            AuthService.LoadUser(LoadUserOperation_Completed, null);
        }

        public void LoginAsync(LoginParameters loginParameters)
        {
            AuthService.Login(loginParameters, LoginOperation_Completed, null);
        }

        public void LogoutAsync()
        {
            AuthService.Logout(LogoutOperation_Completed, null);
        }

        public IPrincipal User
        {
            get { return AuthService.User; }
        }

        public Boolean IsBusy
        {
            get { return AuthService.IsBusy; }
        }

        public bool IsLoadingUser
        {
            get { return AuthService.IsLoadingUser; }
        }

        public bool IsLoggingIn
        {
            get { return AuthService.IsLoggingIn; }
        }

        public bool IsLoggingOut
        {
            get { return AuthService.IsLoggingOut; }
        }

        public bool IsSavingUser
        {
            get { return AuthService.IsSavingUser; }
        }

        #endregion

        #region Events
        public event EventHandler<InvokeOperationEventArgs> ChangePasswordComplete;
        public event EventHandler<LoadUserOperationEventArgs> LoadUserComplete;
        public event EventHandler<LoginOperationEventArgs> LoginComplete;
        public event EventHandler<LogoutOperationEventArgs> LogoutComplete;
        public event EventHandler<AuthenticationEventArgs> AuthenticationChanged;
        public event EventHandler<InvokeOperationEventArgs> CountAdminComplete;
        public event EventHandler<InvokeOperationEventArgs> RegisterAdminComplete;
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Private Methods
        private void _service_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "IsBusy":
                    OnPropertyChanged("IsBusy");
                    break;
                case "IsLoadingUser":
                    OnPropertyChanged("IsLoadingUser");
                    break;
                case "IsLoggingIn":
                    OnPropertyChanged("IsLoggingIn");
                    break;
                case "IsLoggingOut":
                    OnPropertyChanged("IsLoggingOut");
                    break;
                case "IsSavingUser":
                    OnPropertyChanged("IsSavingUser");
                    break;
                case "User":
                    OnPropertyChanged("User");
                    break;
            }
        }

        private void _service_LoggedIn(object sender, AuthenticationEventArgs e)
        {
            if (AuthenticationChanged != null)
                AuthenticationChanged(this, e);
        }

        private void _service_LoggedOut(object sender, AuthenticationEventArgs e)
        {
            if (AuthenticationChanged != null)
                AuthenticationChanged(this, e);
        }

        private void LoadUserOperation_Completed(LoadUserOperation loadUserOperation)
        {
            if (loadUserOperation.HasError)
            {
                if (LoadUserComplete != null)
                    LoadUserComplete(this, new LoadUserOperationEventArgs(loadUserOperation, loadUserOperation.Error));
                loadUserOperation.MarkErrorAsHandled();
            }
            else
            {
                if (LoadUserComplete != null)
                    LoadUserComplete(this, new LoadUserOperationEventArgs(loadUserOperation));
            }
        }

        private void LoginOperation_Completed(LoginOperation loginOperation)
        {
            if (loginOperation.LoginSuccess)
            {
                if (LoginComplete != null)
                    LoginComplete(this, new LoginOperationEventArgs(loginOperation));
            }
            else
            {
                if (loginOperation.HasError)
                {
                    if (LoginComplete != null)
                        LoginComplete(this, new LoginOperationEventArgs(loginOperation, loginOperation.Error));
                    loginOperation.MarkErrorAsHandled();
                }
                else if (!loginOperation.IsCanceled)
                {
                    if (LoginComplete != null)
                    {
                        //var ex = new Exception(CommonResources.BadUserOrPassword);
                        var ex = new Exception("Tên đăng nhập hoặc mật khẩu hoặc sai");
                        LoginComplete(this, new LoginOperationEventArgs(ex));
                    }
                }
                else
                {
                    if (LoginComplete != null)
                        LoginComplete(this, new LoginOperationEventArgs(loginOperation));
                }
            }
        }

        private void LogoutOperation_Completed(LogoutOperation logoutOperation)
        {
            if (logoutOperation.HasError)
            {
                if (LogoutComplete != null)
                    LogoutComplete(this, new LogoutOperationEventArgs(logoutOperation, logoutOperation.Error));
                logoutOperation.MarkErrorAsHandled();
            }
            else
            {
                if (LogoutComplete != null)
                    LogoutComplete(this, new LogoutOperationEventArgs(logoutOperation));
            }
        }
        #endregion
    }
}
