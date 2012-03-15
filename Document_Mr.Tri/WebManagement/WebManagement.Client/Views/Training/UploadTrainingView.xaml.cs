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
using WebManagement.Service;

namespace WebManagement.Client
{
    public partial class UploadTrainingView : Telerik.Windows.Controls.RadWindow
    {
        private Lazy<ViewModelBase> _viewModelExport;

        public UploadTrainingView(DialogMessage dialog)
        {
            InitializeComponent();
            try
            {
                if (!ViewModelBase.IsInDesignModeStatic)
                {
                    _viewModelExport = App.Container.GetExport<ViewModelBase>(
                        ViewModelTypes.UploadTrainingViewModel);
                    if (_viewModelExport != null)
                    {
                        DataContext = _viewModelExport.Value;
                        if (_viewModelExport.Value is IViewModel)
                        {
                            (_viewModelExport.Value as IViewModel).DialogSended = dialog;
                            (_viewModelExport.Value as IViewModel).SetFocus += new EventHandler(View_SetFocus);
                            (_viewModelExport.Value as IViewModel).CloseWindow += new EventHandler(View_CloseWindow);
                            (_viewModelExport.Value as IViewModel).LoadPermission();                                                        
                        }
                        this.KeyUp += new System.Windows.Input.KeyEventHandler(View_KeyUp);
                    }
                    this.Closed += new EventHandler<Telerik.Windows.Controls.WindowClosedEventArgs>(View_Closed);
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
                if (sender is int)
                {
                    switch (Convert.ToInt32(sender))
                    {
                        case 0:
                            OpenFileDialog op = new OpenFileDialog();
                            op.Filter = "Excel xml (*.xml)|*.xml";
                            if (op.ShowDialog() == true)
                            {
                                if (this.DataContext is UploadTrainingViewModel)
                                {
                                    (this.DataContext as UploadTrainingViewModel).OnGetFileClickComplete(op.File);
                                }
                            }
                            break;
                    }
                }
                if (sender is List<Vlu_Khoa>)
                {
                    Telerik.Windows.Controls.GridViewComboBoxColumn col = rgvData.Columns["khoa"] as Telerik.Windows.Controls.GridViewComboBoxColumn;
                    if (col != null)
                    {
                        col.ItemsSource = sender as List<Vlu_Khoa>;
                    }
                }
                if (sender is List<Vlu_LopHoc>)
                {
                    Telerik.Windows.Controls.GridViewComboBoxColumn col = rgvData.Columns["lop"] as Telerik.Windows.Controls.GridViewComboBoxColumn;
                    if (col != null)
                    {
                        col.ItemsSource = sender as List<Vlu_LopHoc>;
                    }
                }
                if (sender is List<Vlu_MonHoc>)
                {
                    Telerik.Windows.Controls.GridViewComboBoxColumn col = rgvData.Columns["monhoc"] as Telerik.Windows.Controls.GridViewComboBoxColumn;
                    if (col != null)
                    {
                        col.ItemsSource = sender as List<Vlu_MonHoc>;
                    }
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

        private void View_Closed(object sender, Telerik.Windows.Controls.WindowClosedEventArgs e)
        {
            try
            {
                if (DataContext != null)
                    ((ICleanup)DataContext).Cleanup();
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }

        private void View_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter && btnChoose.IsEnabled)
                {
                    btnChoose.Command.Execute(btnChoose.CommandParameter);
                }
                else if (e.Key == Key.Escape && btnCancel.IsEnabled)
                {
                    btnCancel.Command.Execute(btnCancel.CommandParameter);
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }
    }
}
