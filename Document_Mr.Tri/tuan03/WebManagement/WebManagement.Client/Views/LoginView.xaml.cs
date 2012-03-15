using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

using WebManagement.Common;
using WebManagement.ViewModel;
using System.Windows.Input;

namespace WebManagement.Client
{
    public partial class LoginView : Telerik.Windows.Controls.RadWindow
    {
        private Lazy<ViewModelBase> _viewModelExport;

        public LoginView(DialogMessage dialog)
        {
            InitializeComponent();

            try
            {
                if (!ViewModelBase.IsInDesignModeStatic)
                {
                    _viewModelExport = App.Container.GetExport<ViewModelBase>(
                        ViewModelTypes.LoginViewModel);
                    if (_viewModelExport != null)
                    {
                        DataContext = _viewModelExport.Value;
                        if (_viewModelExport.Value is IViewModel)
                        {
                            (_viewModelExport.Value as IViewModel).DialogSended = dialog;
                            (_viewModelExport.Value as IViewModel).LoadPermission();
                            (_viewModelExport.Value as IViewModel).CloseWindow += new EventHandler(View_CloseWindow);
                            (_viewModelExport.Value as IViewModel).SetFocus += new EventHandler(View_SetFocus);
                        }
                        this.KeyUp += new KeyEventHandler(View_KeyUp);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }            
        }

        private void View_SetFocus(object sender, EventArgs e)
        {
            try
            {
                txtUserName.Focus();
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }  
        }

        private void View_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter && btnLogin.IsEnabled)
                {
                    var binding = txtPassword.GetBindingExpression(PasswordBox.PasswordProperty);
                    binding.UpdateSource();
                    btnLogin.Command.Execute(btnLogin.CommandParameter);
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }

        private void View_CloseWindow(object sender, EventArgs e)
        {
            try
            {
                if (DataContext != null)
                    ((ICleanup)DataContext).Cleanup();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }
    }
}

