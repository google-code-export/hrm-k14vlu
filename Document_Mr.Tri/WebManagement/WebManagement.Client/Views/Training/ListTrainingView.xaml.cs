using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

using WebManagement.Common;
using WebManagement.ViewModel;
using Telerik.Windows;
using Telerik.Windows.Controls.GridView;

namespace WebManagement.Client
{
    public partial class ListTrainingView : UserControl
    {
        private Lazy<ViewModelBase> _viewModelExport;

        public ListTrainingView()
        {
            InitializeComponent();
            
            try
            {
                if (!ViewModelBase.IsInDesignModeStatic)
                {
                    _viewModelExport = App.Container.GetExport<ViewModelBase>(
                        ViewModelTypes.ListTrainingViewModel);
                    if (_viewModelExport != null)
                    {
                        DataContext = _viewModelExport.Value;
                        if (_viewModelExport.Value is IViewModel)
                        {
                            (_viewModelExport.Value as IViewModel).LoadPermission();
                            (_viewModelExport.Value as IViewModel).SetFocus += new EventHandler(View_SetFocus);
                        }
                    }
                }
                this.rgvData.AddHandler(Telerik.Windows.Controls.GridView.GridViewCellBase.CellDoubleClickEvent,
                    new EventHandler<Telerik.Windows.RadRoutedEventArgs>(OnCellDoubleClick), true);
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }  
        }

        private void OnCellDoubleClick(object sender, Telerik.Windows.RadRoutedEventArgs args)
        {
            Telerik.Windows.Controls.GridView.GridViewCellBase cell = args.OriginalSource as Telerik.Windows.Controls.GridView.GridViewCellBase;
            if (cell != null)
            {
                if (cell.ParentRow is Telerik.Windows.Controls.GridView.GridViewRow)
                {
                    if (btnEdit.Visibility == Visibility.Visible && btnEdit.Command != null)
                        btnEdit.Command.Execute(btnEdit.CommandParameter);
                }
            }
        }

        private void View_SetFocus(object sender, EventArgs e)
        {
            try
            {
                if (sender is List<CustomizeSubjectType>)
                {
                    Telerik.Windows.Controls.GridViewComboBoxColumn col = rgvData.Columns["type"] as Telerik.Windows.Controls.GridViewComboBoxColumn;
                    if (col != null)
                    {
                        col.ItemsSource = sender as List<CustomizeSubjectType>;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }
    }
}
