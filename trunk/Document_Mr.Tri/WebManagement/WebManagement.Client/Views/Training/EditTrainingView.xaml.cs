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
    public partial class EditTrainingView : Telerik.Windows.Controls.RadWindow
    {
        private Lazy<ViewModelBase> _viewModelExport;

        public EditTrainingView(DialogMessage dialog)
        {
            InitializeComponent();
            try
            {
                if (!ViewModelBase.IsInDesignModeStatic)
                {
                    _viewModelExport = App.Container.GetExport<ViewModelBase>(
                        ViewModelTypes.EditTrainingViewModel);
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
                if (e.Key == Key.Enter && btnSave.IsEnabled)
                {
                    btnSave.Command.Execute(btnSave.CommandParameter);
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

