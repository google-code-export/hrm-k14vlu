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
using AuthenticationLib.AuthService;

namespace WebManagement.ViewModel
{
    [Export(ViewModelTypes.HomeViewModel, typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeViewModel : ViewModelBase, IViewModel
    {
        #region Private Members
        private IAuthenticationModel _modelAuth;
        public const string ViewKey = "WM";
        public List<Authentication> ListAuth { get; set; }
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
                    RaisePropertyChanged("IsLoading");
                }
            }
        }

        private string _displayName;
        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                if (value != _displayName)
                {
                    _displayName = value;
                    RaisePropertyChanged("DisplayName");
                }
            }
        }

        private string _displayDate;
        public string DisplayDate
        {
            get { return _displayDate; }
            set
            {
                if (value != _displayDate)
                {
                    _displayDate = value;
                    RaisePropertyChanged("DisplayDate");
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
        public HomeViewModel(IAuthenticationModel modelAuth)
        {
            _modelAuth = modelAuth;
            _modelAuth.LoadUserComplete += new EventHandler<LoadUserOperationEventArgs>(_modelAuth_LoadUserComplete);
            _modelAuth.GetListAuthenticationMenuComplete += new EventHandler<ComplexResultsArgs<Authentication>>(_modelAuth_GetListAuthenticationMenuComplete);
            _modelAuth.LogoutComplete += new EventHandler<LogoutOperationEventArgs>(_modelAuth_LogoutComplete);
        }
        #endregion

        #region Commands
        private RelayCommand<string> _MenuItemCommand;
        public RelayCommand<string> MenuItemCommand
        {
            get
            {
                if (_MenuItemCommand == null)
                {
                    _MenuItemCommand = new RelayCommand<string>(OnMenuItemCommand);
                }
                return _MenuItemCommand;
            }
        }
        private void OnMenuItemCommand(string menuName)
        {
            try
            {
                switch (menuName)
                {
                    case "Exit":
                        MessageCustomize.Show("Bạn muốn thoát ra ?", "THOÁT", MessageBoxButton.OKCancel, MessageImage.Question, c =>
                            {
                                if (c == MessageBoxResult.OK)
                                {
                                    if (SetFocus != null)
                                        SetFocus(0, null);
                                    _modelAuth.LogoutAsync();
                                }
                            });

                        break;
                    case ViewTypes.ChangePasswordView: CallDialog.Show(this, ViewTypes.ChangePasswordView, null);
                        break;
                    case ViewTypes.UserSettingView: CallDialog.Show(this, ViewTypes.UserSettingView, c =>
                            {
                                if (c == MessageBoxResult.OK)
                                {
                                    MessageCustomize.Show("Bạn muốn thay đổi giao diện ?", "THIẾT LẬP", MessageBoxButton.OKCancel, MessageImage.Question, d =>
                                        {
                                            if (d == MessageBoxResult.OK)
                                                if (SetFocus != null)
                                                {
                                                    SetFocus(0, null);
                                                    SetFocus(2, null);
                                                }
                                        });
                                }
                            });
                        break;
                    default: AppMessages.ChangeMenuItemMessage.Send(menuName);
                        break;
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
            if (ListAuth != null)
            {
                IsLoading = false;

                if (SystemConfig.UserType != 1)
                {
                    List<string> lst = ListAuth.Select(c => c.Key).ToList();
                    if (SetFocus != null)
                        SetFocus(lst, null);
                }
                else
                {
                    if (SetFocus != null)
                        SetFocus(1, null);
                }
            }
        }

        public void ReloadData()
        {
            if (SystemConfig.UserID != -1)
            {
                DisplayName = "Người dùng: " + SystemConfig.DisplayName;
                DisplayDate = "Ngày: " + DateTime.Now.ToString("dd/MM/yyyy");

                if (ListAuth == null)
                {
                    if (SystemConfig.UserType > 1)
                    {
                        _modelAuth.GetListAuthenticationMenuAsync();
                    }
                    else
                    {
                        ListAuth = new List<Authentication>();
                        LoadInitComplete();
                    }
                }
                else
                    LoadInitComplete();
            }
        }

        private void ErrorProcess()
        {
            IsLoading = false;
        }


        #region Permission

        public void LoadPermission()
        {
            if (SystemConfig.UserID == -1)
            {
                IsLoading = true;
                _modelAuth.LoadUserAsync();
            }
            else
            {
                ReloadData();
            }
        }

        #endregion

        #region Handlers
        private void _modelAuth_LoadUserComplete(object sender, LoadUserOperationEventArgs e)
        {
            try
            {
                if (e.HasError)
                {
                    MessageCustomize.Show("Main: " + e.Error.Message + "-" + e.Error.StackTrace);
                    ErrorProcess();
                }
                else
                {
                    if (e.LoginOp.User.Identity.Name == string.Empty)
                    {
                        CallDialog.Show(this, ViewTypes.LoginView, c =>
                            {
                                if (c == MessageBoxResult.OK)
                                    _modelAuth.LoadUserAsync();
                            });
                    }
                    else
                    {
                        LoginUser ItemLogin = e.LoginOp.User as LoginUser;

                        SystemConfig.UserID = ItemLogin.UserID;
                        SystemConfig.UserName = ItemLogin.Name;
                        SystemConfig.DisplayName = ItemLogin.LastName + " " + ItemLogin.FirstName;
                        SystemConfig.UserType = ItemLogin.UserType;
                        SystemConfig.CurrentDate = DateTime.Now;
                        if (ItemLogin.Settings.ContainsKey(KeySetting.Theme))
                            SystemConfig.Theme = ItemLogin.Settings[KeySetting.Theme];
                        if (ItemLogin.Settings.ContainsKey(KeySetting.PagingSize))
                            SystemConfig.PagingSize = Convert.ToInt32(ItemLogin.Settings[KeySetting.PagingSize]);
                        ListAuth = null;

                        if (SetFocus != null)
                            SetFocus(2, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
                ErrorProcess();
            }
        }

        private void _modelAuth_GetListAuthenticationMenuComplete(object sender, ComplexResultsArgs<Authentication> e)
        {
            try
            {
                if (e.HasError)
                {
                    MessageCustomize.Show(e.Error.Message);
                    ErrorProcess();
                }
                else
                {
                    ListAuth = e.Results.ToList();
                    LoadInitComplete();
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
                ErrorProcess();
            }
        }

        private void _modelAuth_LogoutComplete(object sender, LogoutOperationEventArgs e)
        {
            try
            {
                if (e.HasError)
                {
                    MessageCustomize.Show(e.Error.Message);
                    ErrorProcess();
                }
                else
                {
                    SystemConfig.UserID = -1;
                    SystemConfig.UserName = string.Empty;
                    SystemConfig.UserGroupID = -1;
                    if (SetFocus != null)
                        SetFocus(0, null);
                    CallDialog.Show(this, ViewTypes.LoginView, c =>
                    {
                        if (c == MessageBoxResult.OK)
                            _modelAuth.LoadUserAsync();
                    });
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
                _modelAuth.LoadUserComplete -= new EventHandler<LoadUserOperationEventArgs>(_modelAuth_LoadUserComplete);
                _modelAuth.GetListAuthenticationMenuComplete -= new EventHandler<ComplexResultsArgs<Authentication>>(_modelAuth_GetListAuthenticationMenuComplete);
                _modelAuth.LogoutComplete -= new EventHandler<LogoutOperationEventArgs>(_modelAuth_LogoutComplete);
                _modelAuth = null;
            }
            ListAuth = null;
            if (DialogSended != null)
                DialogSended = null;
            base.Cleanup();
        }
        #endregion
    }
}
