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
    [Export(ViewModelTypes.MainPageViewModel, typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MainPageViewModel : ViewModelBase, IViewModel
    {
        #region Private Members
        private IAuthenticationModel _modelAuth;
        private ITrainingModel _modelTrain;
        //private IActionModel _actionModel;
        //private IGroupModel _groupModel;
        //private IObjectModel _objModel;
        //private IPrivilegeModel _privilegeModel;
        //private IUserModel _modelUser;
        //private IAuthenticationModel _modelAuthentication;
        //private SYS_User _itemUser;
        public const string ViewKey = "WM";
        private List<Authentication> _listAuth;
        private LoginUser _itemLogin;
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
        public MainPageViewModel(IAuthenticationModel modelAuth, ITrainingModel modelTrain)
        {
            _modelAuth = modelAuth;
            _modelTrain = modelTrain;
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
                        _modelAuth.LogoutAsync();
                        break;
                    case "ChangePasswordView": CallDialog.Show(this, ViewTypes.ChangePasswordView, null);
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
            if (_itemLogin != null)
            {
                IsLoading = false;

                if (SystemConfig.UserType != 1)
                {
                    List<string> lst = _listAuth.Select(c => c.Key).ToList();
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
            if (_itemLogin != null)
            {
                SystemConfig.UserID = _itemLogin.UserID;
                SystemConfig.UserName = _itemLogin.Name;
                SystemConfig.DisplayName = _itemLogin.LastName + " " + _itemLogin.FirstName;
                SystemConfig.UserType = _itemLogin.UserType;

                SystemConfig.CurrentDate = DateTime.Now;

                DisplayName = "Người dùng: " + SystemConfig.DisplayName;
                DisplayDate = "Ngày: " + DateTime.Now.ToString("dd/MM/yyyy");

                if (SystemConfig.UserType > 1)
                {
                    _listAuth = null;
                    _modelAuth.GetListAuthenticationMenuAsync();
                }
                else
                {
                    _listAuth = new List<Authentication>();
                    LoadInitComplete();
                }
            }
        }

        private void ErrorProcess()
        {
            IsLoading = false;
        }

        #region Permission

        public void LoadPermission()
        {
            IsLoading = true;
            _modelAuth.LoadUserAsync();
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
                        _itemLogin = e.LoginOp.User as LoginUser;
                        ReloadData();
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
                    _listAuth = e.Results.ToList();
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
    }
}
