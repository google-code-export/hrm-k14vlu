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

namespace WebManagement.ViewModel
{
    [Export(ViewModelTypes.EditChooseDepartmentViewModel, typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditChooseDepartmentViewModel : ViewModelBase, IViewModel
    {
        #region Private Members

        private ITrainingModel _modelTrain;

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

        private List<Vlu_Khoa> _listData;
        public List<Vlu_Khoa> ListData
        {
            get { return _listData; }
            private set
            {
                if (value != _listData)
                {
                    _listData = value;
                    RaisePropertyChanged("ListData");
                }
            }
        }

        private Vlu_Khoa _selectedItem;
        public Vlu_Khoa SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value != _selectedItem)
                {
                    _selectedItem = value;
                    RaisePropertyChanged("SelectedItem");
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
        public EditChooseDepartmentViewModel(ITrainingModel modelTrain)
        {
            _modelTrain = modelTrain;
            _modelTrain.GetListDepartmentComplete += new EventHandler<EntityResultsArgs<Vlu_Khoa>>(_modelTrain_GetListDepartmentComplete);
        }
        #endregion

        #region Commands
        private RelayCommand _refreshClickCommand;
        public RelayCommand RefreshClickCommand
        {
            get
            {
                if (_refreshClickCommand == null)
                {
                    _refreshClickCommand = new RelayCommand(OnRefreshClickCommand);
                }
                return _refreshClickCommand;
            }
        }
        private void OnRefreshClickCommand()
        {
            try
            {
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }

        private RelayCommand _chooseClickCommand;
        public RelayCommand ChooseClickCommand
        {
            get
            {
                if (_chooseClickCommand == null)
                {
                    _chooseClickCommand = new RelayCommand(OnChooseClickCommand);
                }
                return _chooseClickCommand;
            }
        }
        private void OnChooseClickCommand()
        {
            try
            {
                if (SelectedItem != null)
                {
                    if (DialogSended != null)
                    {
                        if (CheckSelected())
                        {
                            if (DialogSended.Sender is EditDepartmentViewModel)
                            {
                                EditDepartmentViewModel view = DialogSended.Sender as EditDepartmentViewModel;
                                view.ParentID = SelectedItem.KhoaID;
                                view.ItemParent = SelectedItem;
                            }                            
                            DialogSended.ProcessCallback(MessageBoxResult.OK);
                        }
                    }
                    if (CloseWindow != null)
                        CloseWindow(this, null);
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }

        private bool CheckSelected()
        {
            if (DialogSended.Sender is EditDepartmentViewModel)
            {
                EditDepartmentViewModel view = DialogSended.Sender as EditDepartmentViewModel;
                if (view.ParentID > 0)
                {
                    if (view.ParentID == SelectedItem.KhoaID)
                    {
                        MessageCustomize.Show("Không được chọn chính nhóm đó", "Lỗi", MessageImage.Alert);
                        return false;
                    }
                }
            }
            return true;
        }

        private RelayCommand _cancelClickCommand;
        public RelayCommand CancelClickCommand
        {
            get
            {
                if (_cancelClickCommand == null)
                {
                    _cancelClickCommand = new RelayCommand(OnCancelClickCommand);
                }
                return _cancelClickCommand;
            }
        }
        private void OnCancelClickCommand()
        {
            try
            {
                if (DialogSended != null)
                    DialogSended.ProcessCallback(MessageBoxResult.Cancel);
                if (CloseWindow != null)
                    CloseWindow(this, null);
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
            if (_listData != null)
            {
                IsLoading = false;
            }
        }

        public void ReloadData()
        {
            IsLoading = true;
            _listData = null;

            _modelTrain.GetListDepartmentAsync();
        }

        private void ErrorProcess()
        {
            IsLoading = false;
        }

        public void LoadPermission()
        {            
            ReloadData();
        }

        #region Handlers
        private void _modelTrain_GetListDepartmentComplete(object sender, EntityResultsArgs<Vlu_Khoa> e)
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
                    List<Vlu_Khoa> lst = e.Results.Where(c => c.ParentID == null).ToList();
                    Vlu_Khoa obj = new Vlu_Khoa();                    
                    obj.KhoaID = -1;
                    obj.MaKhoa = "< Nhóm chính >";
                    obj.TenKhoa = "< Nhóm chính >";

                    lst.Insert(0, obj);
                    ListData = lst;
                    LoadInitComplete();
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
            if (_modelTrain != null)
            {
                _modelTrain.GetListDepartmentComplete -= new EventHandler<EntityResultsArgs<Vlu_Khoa>>(_modelTrain_GetListDepartmentComplete);
                _modelTrain = null;
            }
            _listData = null;
            _selectedItem = null;
            if (DialogSended != null)
                DialogSended = null;
            base.Cleanup();
        }
        #endregion
    }
}
