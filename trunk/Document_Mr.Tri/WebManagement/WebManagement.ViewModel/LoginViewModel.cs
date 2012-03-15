using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;
using System.IO;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using WebManagement.Common;
using WebManagement.Service;


namespace WebManagement.ViewModel
{
    [Export(ViewModelTypes.LoginViewModel, typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LoginViewModel : ViewModelBase, IViewModel
    {
        #region Private Members

        private IAuthenticationModel _modelAuth;
        private LoginUser _itemEdit;
        private int _editID = -1;
        private string _viewKey = string.Empty;

        #endregion

        #region Properties

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                if (value != _isLoading)
                {
                    _isLoading = value;
                    NotLoading = !value;
                    RaisePropertyChanged("IsLoading");
                }
            }
        }

        private bool _notLoading;
        public bool NotLoading
        {
            get { return _notLoading; }
            set
            {
                if (value != _notLoading)
                {
                    _notLoading = value;
                    RaisePropertyChanged("NotLoading");
                }
            }
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (value != _userName)
                {
                    _userName = value;
                    RaisePropertyChanged("UserName");
                }
            }
        }
        private bool _visibleErrUserName;
        public bool VisibleErrUserName
        {
            get { return _visibleErrUserName; }
            set
            {
                if (value != _visibleErrUserName)
                {
                    _visibleErrUserName = value;
                    RaisePropertyChanged("VisibleErrUserName");
                }
            }
        }

        private string _stringErrUserName;
        public string StringErrUserName
        {
            get { return _stringErrUserName; }
            set
            {
                if (value != _stringErrUserName)
                {
                    _stringErrUserName = value;
                    RaisePropertyChanged("StringErrUserName");
                }
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    RaisePropertyChanged("Password");
                }
            }
        }
        private bool _visibleErrPassword;
        public bool VisibleErrPassword
        {
            get { return _visibleErrPassword; }
            set
            {
                if (value != _visibleErrPassword)
                {
                    _visibleErrPassword = value;
                    RaisePropertyChanged("VisibleErrPassword");
                }
            }
        }
        private string _stringErrPassword;
        public string StringErrPassword
        {
            get { return _stringErrPassword; }
            set
            {
                if (value != _stringErrPassword)
                {
                    _stringErrPassword = value;
                    RaisePropertyChanged("StringErrPassword");
                }
            }
        }

        private bool _rememberPassword;
        public bool RememberPassword
        {
            get { return _rememberPassword; }
            set
            {
                if (value != _rememberPassword)
                {
                    _rememberPassword = value;
                    RaisePropertyChanged("RememberPassword");
                }
            }
        }
        #region IViewModel
        private DialogMessage _dialogSended;
        public DialogMessage DialogSended
        {
            get { return _dialogSended; }
            set
            {
                if (value.Sender is HomeViewModel)
                {
                    _viewKey = HomeViewModel.ViewKey;
                }
                _dialogSended = value;
            }
        }
        public event EventHandler CloseWindow;
        public event EventHandler SetFocus;
        #endregion

        #endregion

        #region Contructors
        [ImportingConstructor]
        public LoginViewModel(IAuthenticationModel modelAuth)
        {
            _modelAuth = modelAuth;
            _modelAuth.LoginComplete += new EventHandler<LoginOperationEventArgs>(_modelAuth_LoginComplete);
        }
        #endregion

        #region Commands
        private RelayCommand _loginClickCommand;
        public RelayCommand LoginClickCommand
        {
            get
            {
                if (_loginClickCommand == null)
                {
                    _loginClickCommand = new RelayCommand(OnLoginClickCommand);
                }
                return _loginClickCommand;
            }
        }
        private void OnLoginClickCommand()
        {
            try
            {
                if (CheckInputData())
                {
                    IsLoading = true;
                    _modelAuth.LoginAsync(new System.ServiceModel.DomainServices.Client.ApplicationServices.LoginParameters(
                        UserName, Password, RememberPassword, string.Empty));
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }
        #endregion

        #region Private Methods
        public void LoadInitComplete()
        {
        }

        public void ReloadData()
        {
        }

        private bool CheckInputData()
        {
            bool result = true;
            ClearError();
            if (UserName.Trim() == string.Empty)
            {
                VisibleErrUserName = true;
                StringErrUserName = "Chưa nhập tên đăng nhập";
                result = false;
            }
            if (Password.Trim() == string.Empty)
            {
                VisibleErrPassword = true;
                StringErrPassword = "Chưa nhập mật khẩu";
                result = false;
            }
            return result;
        }

        private void ClearError()
        {
            VisibleErrUserName = VisibleErrPassword = false;
        }

        #region Permission

        public void LoadPermission()
        {
            IsLoading = false;
            NotLoading = true;
            RememberPassword = false;
            UserName = string.Empty;
            Password = string.Empty;
            ClearError();
        }

        #endregion

        #region Handlers
        private void _modelAuth_LoginComplete(object sender, LoginOperationEventArgs e)
        {
            try
            {
                IsLoading = false;
                if (e.HasError)
                    MessageCustomize.Show(e.Error.Message);
                else
                {
                    if (e.LoginOp.IsComplete)
                    {
                        LoginUser obj = e.LoginOp.User as LoginUser;
                        if (obj.Roles.Contains(_viewKey))
                        {                            
                            if (DialogSended.Callback != null)
                                DialogSended.ProcessCallback(MessageBoxResult.OK);
                            if (CloseWindow != null)
                                CloseWindow(this, null);
                        }
                        else
                            MessageCustomize.Show("Bạn không có quyền trên hệ thống này ?");
                    }
                    else
                        MessageCustomize.Show("Đăng nhập thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }
        #endregion

        #endregion

        #region ICleanup interface
        public override void Cleanup()
        {
            if (_modelAuth != null)
            {
                _modelAuth.LoginComplete -= new EventHandler<LoginOperationEventArgs>(_modelAuth_LoginComplete);
                _modelAuth = null;
            }
            _itemEdit = null;
            if (_dialogSended != null)
                _dialogSended = null;
            base.Cleanup();
        }
        #endregion
    }
}
