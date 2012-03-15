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
    public partial class ListCategoryView : UserControl
    {
        private Lazy<ViewModelBase> _viewModelExport;

        public ListCategoryView()
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
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }
    }
}
