using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Windows;
using System.Windows.Markup;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WebManagement.Common;
using System.Collections.Generic;

using System.Linq;
using WebManagement.Service;

namespace WebManagement.ViewModel
{
    [Export(ViewModelTypes.ChangePasswordViewModel, typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ChangePasswordViewModel : ViewModelBase, IViewModel
    {
        #region Private Members

        private IAuthenticationModel _modelAuth;

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

        private string _newPassword;
        public string NewPassword
        {
            get { return _newPassword; }
            set
            {
                if (value != _newPassword)
                {
                    _newPassword = value;
                    RaisePropertyChanged("NewPassword");
                }
            }
        }
        private bool _visibleErrNewPassword;
        public bool VisibleErrNewPassword
        {
            get { return _visibleErrNewPassword; }
            set
            {
                if (value != _visibleErrNewPassword)
                {
                    _visibleErrNewPassword = value;
                    RaisePropertyChanged("VisibleErrNewPassword");
                }
            }
        }
        private string _stringErrNewPassword;
        public string StringErrNewPassword
        {
            get { return _stringErrNewPassword; }
            set
            {
                if (value != _stringErrNewPassword)
                {
                    _stringErrNewPassword = value;
                    RaisePropertyChanged("StringErrNewPassword");
                }
            }
        }

        private string _reNewPassword;
        public string ReNewPassword
        {
            get { return _reNewPassword; }
            set
            {
                if (value != _reNewPassword)
                {
                    _reNewPassword = value;
                    RaisePropertyChanged("ReNewPassword");
                }
            }
        }
        private bool _visibleErrReNewPassword;
        public bool VisibleErrReNewPassword
        {
            get { return _visibleErrReNewPassword; }
            set
            {
                if (value != _visibleErrReNewPassword)
                {
                    _visibleErrReNewPassword = value;
                    RaisePropertyChanged("VisibleErrReNewPassword");
                }
            }
        }
        private string _stringErrReNewPassword;
        public string StringErrReNewPassword
        {
            get { return _stringErrReNewPassword; }
            set
            {
                if (value != _stringErrReNewPassword)
                {
                    _stringErrReNewPassword = value;
                    RaisePropertyChanged("StringErrReNewPassword");
                }
            }
        }

        #region IViewModel
        public DialogMessage DialogSended { get; set; }
        public event EventHandler CloseWindow;
        public event EventHandler SetFocus;
        #endregion

        #endregion

        #region Contructors
        [ImportingConstructor]
        public ChangePasswordViewModel(IAuthenticationModel modelAuth)
        {
            _modelAuth = modelAuth;
            _modelAuth.ChangePasswordComplete += new EventHandler<InvokeOperationEventArgs>(_modelAuth_ChangePasswordComplete);
        }

        #endregion

        #region Commands
        private RelayCommand _saveClickCommand;
        public RelayCommand SaveClickCommand
        {
            get
            {
                if (_saveClickCommand == null)
                {
                    _saveClickCommand = new RelayCommand(OnSaveClickCommand);
                }
                return _saveClickCommand;
            }
        }
        private void OnSaveClickCommand()
        {
            try
            {
                if (CheckInputData())
                {
                    IsLoading = true;
                    _modelAuth.ChangePasswordAsync(SystemConfig.UserID, Password, NewPassword);
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }

        private RelayCommand _cancelClickCommand;
        public RelayCommand CancelClickCommand
        {
            get
            {
                if (_cancelClickCommand == null)
                {
                    _cancelClickCommand = new RelayCommand(OnCancelClickCommand);
                }
                return _cancelClickCommand;
            }
        }
        private void OnCancelClickCommand()
        {
            try
            {
                if (CloseWindow != null)
                    CloseWindow(this, null);
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

        private void ErrorProcess()
        {
            IsLoading = false;
        }

        private bool CheckInputData()
        {
            bool result = true;
            ClearError();
            if (Password.Trim() == string.Empty)
            {
                VisibleErrPassword = true;
                StringErrPassword = "Chưa nhập mật khẩu";
                result = false;
            }
            if (NewPassword.Trim() == string.Empty)
            {
                VisibleErrNewPassword = true;
                StringErrNewPassword = "Chưa nhập mật khẩu mới";
                result = false;
            }
            if (ReNewPassword.Trim() == string.Empty)
            {
                VisibleErrReNewPassword = true;
                StringErrReNewPassword = "Chưa nhập lại mật khẩu mới";
                result = false;
            }
            if (NewPassword.Trim() != string.Empty && ReNewPassword.Trim() != string.Empty && NewPassword != ReNewPassword)
            {
                VisibleErrReNewPassword = true;
                StringErrReNewPassword = "Mật khẩu nhập lại không giống mật khẩu mới";
                result = false;
            }
            return result;
        }

        private void ClearError()
        {
            VisibleErrPassword = VisibleErrNewPassword = VisibleErrReNewPassword = false;
        }

        #region Permission

        public void LoadPermission()
        {
            NotLoading = true;
            Password = string.Empty;
            NewPassword = string.Empty;
            ReNewPassword = string.Empty;
        }

        #endregion

        #region Handlers
        private void _modelAuth_ChangePasswordComplete(object sender, InvokeOperationEventArgs e)
        {
            try
            {
                IsLoading = false;
                if (e.HasError)
                {
                    MessageCustomize.Show(e.Error.Message);
                    ErrorProcess();
                }
                else
                {
                    int i = Convert.ToInt32(e.InvokeOp.Value);
                    switch (i)
                    {
                        case 0:
                            MessageCustomize.Show("Cập nhật mật khẩu thành công", "Thay đổi mật khẩu", MessageImage.Information);
                            if (CloseWindow != null)
                                CloseWindow(this, null);
                            break;
                        case 1:
                            MessageCustomize.Show("Tài khoản đã bị xóa", "Báo lỗi", MessageImage.Alert);
                            break;
                        case 2:
                            VisibleErrPassword = true;
                            StringErrPassword = "Nhập sai mật khẩu";
                            break;
                    }
                    IsLoading = false;
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
                ErrorProcess();
            }
        }
        #endregion

        #endregion

        #region ICleanup interface
        public override void Cleanup()
        {
            if (_modelAuth != null)
            {
                _modelAuth.ChangePasswordComplete -= new EventHandler<InvokeOperationEventArgs>(_modelAuth_ChangePasswordComplete);
                _modelAuth = null;
            }
            if (DialogSended != null)
                DialogSended = null;
            base.Cleanup();
        }
        #endregion
    }
}
