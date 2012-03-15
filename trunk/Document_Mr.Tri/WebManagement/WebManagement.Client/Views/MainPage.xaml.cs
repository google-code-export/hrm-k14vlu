using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

using WebManagement.Common;
using WebManagement.ViewModel;

namespace WebManagement.Client
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Browser.HtmlPage.Plugin.Focus();
                if (!ViewModelBase.IsInDesignModeStatic)
                {
                    DataContext = App.Container.GetExportedValue<ViewModelBase>(
                        ViewModelTypes.MainPageViewModel);
                }

                HomeView home = new HomeView(null);
                home.NotifyChangeTheme += new EventHandler(home_NotifyChangeTheme);
                contentMain.Content = home;

                AppMessages.SendMessage.Register(this, OnSendMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void home_NotifyChangeTheme(object sender, EventArgs e)
        {
            try
            {
                List<AuthenticationLib.AuthService.Authentication> lstAuth = ((sender as HomeView).DataContext as HomeViewModel).ListAuth;
                (sender as HomeView).NotifyChangeTheme -= new EventHandler(home_NotifyChangeTheme);
                GalaSoft.MvvmLight.Messaging.Messenger.Default.Unregister(sender);
                if ((sender as HomeView).DataContext != null)
                    ((ICleanup)(sender as HomeView).DataContext).Cleanup();

                HomeView home = new HomeView(lstAuth);
                home.NotifyChangeTheme += new EventHandler(home_NotifyChangeTheme);
                contentMain.Content = home;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void OnSendMessage(DialogMessage dialogMessage)
        {
            if (dialogMessage != null)
            {
                MessageView msg = new MessageView();
                msg.Diaglog = dialogMessage;
                msg.ShowDialog();
            }
        }
    }
}
