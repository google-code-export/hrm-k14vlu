using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

using WebManagement.Common;
using WebManagement.ViewModel;
using AuthenticationLib.AuthService;

namespace WebManagement.Client
{
    public partial class HomeView : UserControl
    {
        #region Contructors
        public HomeView(List<Authentication> lstAuth)
        {
            InitializeComponent();

            try
            {
                AppMessages.ChangeMenuItemMessage.Register(this, OnChangeMenuItemMessage);
                AppMessages.WindowMessage.Register(this, OnWindowMessage);
                AppMessages.WindowDialogMessage.Register(this, OnWindowDialogMessage);
                AppMessages.HelpWindowMessage.Register(this, OnHelpWindowMessage);

                if (!ViewModelBase.IsInDesignModeStatic)
                {
                    DataContext = App.Container.GetExportedValue<ViewModelBase>(
                        ViewModelTypes.HomeViewModel);

                    if (DataContext != null)
                    {
                        if (DataContext is IViewModel)
                        {
                            (DataContext as IViewModel).SetFocus += new EventHandler(View_SetFocus);
                            if (lstAuth == null)
                                (DataContext as IViewModel).LoadPermission();
                            else
                            {
                                (DataContext as HomeViewModel).ListAuth = lstAuth;
                                (DataContext as IViewModel).ReloadData();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }
        #endregion

        #region Private Members
        public event EventHandler NotifyChangeTheme;
        #endregion

        #region Events

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {                
                rpHelp.IsHidden = true;
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
                if (sender != null)
                {
                    if (sender is int)
                    {
                        //0 Clear tab, 1 Show all menu, 2 Change theme
                        switch (Convert.ToInt32(sender))
                        {
                            case 0:
                                foreach (var item in rpgMain.Items)
                                {
                                    if (item is Telerik.Windows.Controls.RadDocumentPane)
                                    {
                                        Telerik.Windows.Controls.RadDocumentPane tab = item as Telerik.Windows.Controls.RadDocumentPane;
                                        if (tab.Content is UserControl)
                                        {
                                            if ((tab.Content as UserControl).DataContext != null)
                                                ((ICleanup)(tab.Content as UserControl).DataContext).Cleanup();
                                        }
                                        tab.Unloaded -= new RoutedEventHandler(item_Unloaded);
                                    }
                                }
                                rpgMain.Items.Clear();
                                break;
                            case 1:
                                foreach (var item in robCategories.Items)
                                    CheckMenuItem(item, null, true);
                                break;
                            case 2: ChangeTheme();
                                break;
                            default:
                                break;
                        }
                    }
                    //Change menu when user is not admin
                    if (sender is List<string>)
                    {
                        List<string> lstMenu = sender as List<string>;
                        foreach (var item in robCategories.Items)
                            CheckMenuItem(item, lstMenu, false);
                        foreach (var item in robCategories.Items)
                            if (item is Telerik.Windows.Controls.RadOutlookBarItem)
                                if ((item as Telerik.Windows.Controls.RadOutlookBarItem).Visibility == Visibility.Visible)
                                {
                                    robCategories.SelectedItem = item;
                                    return;
                                }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }

        #endregion

        #region Private Methods

        private void ChangeTheme()
        {
            switch (SystemConfig.Theme)
            {
                case ApplicationTheme.Expression_DarkTheme:
                    Telerik.Windows.Controls.StyleManager.ApplicationTheme = new Telerik.Windows.Controls.Expression_DarkTheme();
                    break;
                case ApplicationTheme.MetroTheme:
                    Telerik.Windows.Controls.StyleManager.ApplicationTheme = new Telerik.Windows.Controls.MetroTheme();
                    break;
                case ApplicationTheme.Office_BlackTheme:
                    Telerik.Windows.Controls.StyleManager.ApplicationTheme = new Telerik.Windows.Controls.Office_BlackTheme();
                    break;
                case ApplicationTheme.Office_BlueTheme:
                    Telerik.Windows.Controls.StyleManager.ApplicationTheme = new Telerik.Windows.Controls.Office_BlueTheme();
                    break;
                case ApplicationTheme.Office_SilverTheme:
                    Telerik.Windows.Controls.StyleManager.ApplicationTheme = new Telerik.Windows.Controls.Office_SilverTheme();
                    break;
                case ApplicationTheme.SummerTheme:
                    Telerik.Windows.Controls.StyleManager.ApplicationTheme = new Telerik.Windows.Controls.SummerTheme();
                    break;
                case ApplicationTheme.TransparentTheme:
                    Telerik.Windows.Controls.StyleManager.ApplicationTheme = new Telerik.Windows.Controls.TransparentTheme();
                    break;
                case ApplicationTheme.VistaTheme:
                    Telerik.Windows.Controls.StyleManager.ApplicationTheme = new Telerik.Windows.Controls.VistaTheme();
                    break;
                case ApplicationTheme.Windows7Theme:
                    Telerik.Windows.Controls.StyleManager.ApplicationTheme = new Telerik.Windows.Controls.Windows7Theme();
                    break;
                default:
                    break;
            }
            if (NotifyChangeTheme != null)
                NotifyChangeTheme(this, null);
        }

        private void CheckMenuItem(object mnu, List<string> lst, bool isFull)
        {
            if (mnu is Telerik.Windows.Controls.RadOutlookBarItem)
            {
                Telerik.Windows.Controls.RadOutlookBarItem obj = mnu as Telerik.Windows.Controls.RadOutlookBarItem;
                if (!isFull)
                {
                    if (obj.Tag != null)
                    {
                        string nameKey = obj.Tag.ToString();
                        if (lst.Contains(nameKey))
                        {
                            obj.Visibility = Visibility.Visible;
                            if (obj.Content is Telerik.Windows.Controls.RadTreeView)
                            {
                                Telerik.Windows.Controls.RadTreeView rtv = obj.Content as Telerik.Windows.Controls.RadTreeView;
                                foreach (var child in rtv.Items)
                                    CheckMenuItem(child, lst, isFull);
                            }
                        }
                        else
                            obj.Visibility = Visibility.Collapsed;
                    }
                }
                else
                {
                    obj.Visibility = Visibility.Visible;
                    if (obj.Content is Telerik.Windows.Controls.RadTreeView)
                    {
                        Telerik.Windows.Controls.RadTreeView rtv = obj.Content as Telerik.Windows.Controls.RadTreeView;
                        foreach (var child in rtv.Items)
                            CheckMenuItem(child, lst, isFull);
                    }
                }
            }
            if (mnu is Telerik.Windows.Controls.RadTreeViewItem)
            {
                Telerik.Windows.Controls.RadTreeViewItem obj = mnu as Telerik.Windows.Controls.RadTreeViewItem;
                if (!isFull)
                {
                    if (obj.Tag != null)
                    {
                        string nameKey = obj.Tag.ToString();
                        if (lst.Contains(nameKey))
                        {
                            obj.Visibility = Visibility.Visible;
                            foreach (var child in obj.Items)
                                CheckMenuItem(child, lst, isFull);
                        }
                        else
                            obj.Visibility = Visibility.Collapsed;
                    }
                }
                else
                {
                    obj.Visibility = Visibility.Visible;
                    foreach (var child in obj.Items)
                        CheckMenuItem(child, lst, isFull);
                }
            }
        }

        private void OnHelpWindowMessage(string menuName)
        {
            rhpHelp.SourceUrl = new Uri(menuName, UriKind.RelativeOrAbsolute);
            rpHelp.IsHidden = false;
        }
        
        private void item_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is Telerik.Windows.Controls.RadDocumentPane)
                {
                    Telerik.Windows.Controls.RadDocumentPane tab = sender as Telerik.Windows.Controls.RadDocumentPane;
                    if (tab.Content is UserControl)
                    {
                        if ((tab.Content as UserControl).DataContext != null)
                            ((ICleanup)(tab.Content as UserControl).DataContext).Cleanup();
                    }
                    tab.Unloaded -= new RoutedEventHandler(item_Unloaded);
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }

        private void OnWindowMessage(DialogMessage dialogMessage)
        {
            Telerik.Windows.Controls.RadWindow win = CreateWindow(dialogMessage);
            if (win != null)
            {
                win.Show();
            }
        }

        private void OnWindowDialogMessage(DialogMessage dialogMessage)
        {
            Telerik.Windows.Controls.RadWindow win = CreateWindow(dialogMessage);
            if (win != null)
            {
                win.ShowDialog();
            }
        }

        //Load menu by name when click on left menu bar
        private void OnChangeMenuItemMessage(string menuName)
        {
            Telerik.Windows.Controls.RadDocumentPane item;
            for (int i = 0; i < rpgMain.Items.Count; i++)
            {
                if (rpgMain.Items[i] is Telerik.Windows.Controls.RadDocumentPane)
                {
                    if ((rpgMain.Items[i] as Telerik.Windows.Controls.RadDocumentPane).Tag.ToString() == menuName)
                    {
                        rpgMain.SelectedIndex = i;
                        return;
                    }
                }
            }
            switch (menuName)
            {
                //Training
                case ViewTypes.ListClassView:
                    item = new Telerik.Windows.Controls.RadDocumentPane();
                    item.Tag = ViewTypes.ListClassView;
                    item.Header = "Danh sách lớp học";
                    item.Content = new ListClassView();
                    break;
                case ViewTypes.ListDepartmentView:
                    item = new Telerik.Windows.Controls.RadDocumentPane();
                    item.Tag = ViewTypes.ListDepartmentView;
                    item.Header = "Danh sách khoa";
                    item.Content = new ListDepartmentView();
                    break;
                case ViewTypes.ListRoomView:
                    item = new Telerik.Windows.Controls.RadDocumentPane();
                    item.Tag = ViewTypes.ListRoomView;
                    item.Header = "Danh sách phòng học";
                    item.Content = new ListRoomView();
                    break;
                case ViewTypes.ListSubjectView:
                    item = new Telerik.Windows.Controls.RadDocumentPane();
                    item.Tag = ViewTypes.ListSubjectView;
                    item.Header = "Danh sách phòng học";
                    item.Content = new ListSubjectView();
                    break;
                case ViewTypes.ListTrainingView:
                    item = new Telerik.Windows.Controls.RadDocumentPane();
                    item.Tag = ViewTypes.ListTrainingView;
                    item.Header = "Danh sách phòng học";
                    item.Content = new ListTrainingView();
                    break;


                default:
                    throw new NotImplementedException();
            }
            if (item != null)
            {
                item.Unloaded += new RoutedEventHandler(item_Unloaded);
                rpgMain.Items.Add(item);
            }
        }

        //Load when call show dialog window
        private Telerik.Windows.Controls.RadWindow CreateWindow(DialogMessage dialogMessage)
        {
            Telerik.Windows.Controls.RadWindow win = null;
            switch (dialogMessage.Content)
            {
                //Training
                case ViewTypes.EditChooseClassView:
                    win = new EditChooseClassView(dialogMessage);
                    break;
                case ViewTypes.EditChooseDepartmentView:
                    win = new EditChooseDepartmentView(dialogMessage);
                    break;
                case ViewTypes.EditChooseSubjectView:
                    win = new EditChooseSubjectView(dialogMessage);
                    break;
                case ViewTypes.EditClassView:
                    win = new EditClassView(dialogMessage);
                    break;
                case ViewTypes.EditDepartmentView:
                    win = new EditDepartmentView(dialogMessage);
                    break;
                case ViewTypes.EditRoomView:
                    win = new EditRoomView(dialogMessage);
                    break;
                case ViewTypes.EditSubjectView:
                    win = new EditSubjectView(dialogMessage);
                    break;
                case ViewTypes.EditTrainingView:
                    win = new EditTrainingView(dialogMessage);
                    break;
                case ViewTypes.UploadSubjectView:
                    win = new UploadSubjectView(dialogMessage);
                    break;
                case ViewTypes.UploadClassView:
                    win = new UploadClassView(dialogMessage);
                    break;
                case ViewTypes.UploadTrainingView:
                    win = new UploadTrainingView(dialogMessage);
                    break;


                case ViewTypes.LoginView:
                    win = new LoginView(dialogMessage);
                    break;
                case ViewTypes.ChangePasswordView:
                    win = new ChangePasswordView(dialogMessage);
                    break;
                case ViewTypes.UserSettingView:
                    win = new UserSettingView(dialogMessage);
                    break;
            }
            return win;
        }
        #endregion
    }
}
