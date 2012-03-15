using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

using WebManagement.Common;
using WebManagement.ViewModel;

namespace WebManagement.Client
{
    public partial class ListClassView : UserControl
    {
        private Lazy<ViewModelBase> _viewModelExport;

        public ListClassView()
        {
            InitializeComponent();

            try
            {
                if (!ViewModelBase.IsInDesignModeStatic)
                {
                    _viewModelExport = App.Container.GetExport<ViewModelBase>(
                        ViewModelTypes.ListClassViewModel);
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
                if (sender is List<WebManagement.Service.Vlu_Khoa>)
                {
                    Telerik.Windows.Controls.GridViewComboBoxColumn col = rtlData.Columns["khoa"] as Telerik.Windows.Controls.GridViewComboBoxColumn;
                    if (col != null)
                    {
                        col.ItemsSource = sender as List<WebManagement.Service.Vlu_Khoa>;
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
