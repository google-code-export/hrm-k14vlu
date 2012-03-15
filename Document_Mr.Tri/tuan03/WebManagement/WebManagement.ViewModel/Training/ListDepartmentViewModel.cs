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
    [Export(ViewModelTypes.ListDepartmentViewModel, typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ListDepartmentViewModel : ViewModelBase, IViewModel
    {
        #region Private Members

        private ITrainingModel _modelTrain;
        public const string ViewKey = "WM_LISTDEPARTMENT";

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

        private bool _visibleAdd;
        public bool VisibleAdd
        {
            get { return _visibleAdd; }
            set
            {
                if (value != _visibleAdd)
                {
                    _visibleAdd = value;
                    RaisePropertyChanged("VisibleAdd");
                }
            }
        }

        private bool _visibleEdit;
        public bool VisibleEdit
        {
            get { return _visibleEdit; }
            set
            {
                if (value != _visibleEdit)
                {
                    _visibleEdit = value;
                    RaisePropertyChanged("VisibleEdit");
                }
            }
        }

        private bool _visibleDelete;
        public bool VisibleDelete
        {
            get { return _visibleDelete; }
            set
            {
                if (value != _visibleDelete)
                {
                    _visibleDelete = value;
                    RaisePropertyChanged("VisibleDelete");
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
        public ListDepartmentViewModel(ITrainingModel modelTrain)
        {
            _modelTrain = modelTrain;
            _modelTrain.GetListAuthenticationFormComplete += new EventHandler<ComplexResultsArgs<Authentication>>(_model_GetListAuthenticationFormComplete);
            _modelTrain.GetListDepartmentComplete += new EventHandler<EntityResultsArgs<Vlu_Khoa>>(_modelTrain_GetListDepartmentComplete);
            _modelTrain.DeleteDepartmentComplete += new EventHandler<SubmitOperationEventArgs>(_modelTrain_DeleteDepartmentComplete);
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

        private RelayCommand _addClickCommand;
        public RelayCommand AddClickCommand
        {
            get
            {
                if (_addClickCommand == null)
                {
                    _addClickCommand = new RelayCommand(OnAddClickCommand);
                }
                return _addClickCommand;
            }
        }
        private void OnAddClickCommand()
        {
            try
            {
                SelectedItem = null;
                CallDialog.Show(this, ViewTypes.EditDepartmentView, c =>
                {
                    if (c == MessageBoxResult.OK)
                    {
                        ReloadData();
                    }
                });
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }

        private RelayCommand _editClickCommand;
        public RelayCommand EditClickCommand
        {
            get
            {
                if (_editClickCommand == null)
                {
                    _editClickCommand = new RelayCommand(OnEditClickCommand);
                }
                return _editClickCommand;
            }
        }
        private void OnEditClickCommand()
        {
            try
            {
                if (SelectedItem != null)
                {
                    CallDialog.Show(this, ViewTypes.EditDepartmentView, c =>
                    {
                        if (c == MessageBoxResult.OK)
                        {
                            ReloadData();
                        }
                    });
                }
                else
                    MessageCustomize.Show("Bạn chưa chọn khoa");
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }

        private RelayCommand _deleteClickCommand;
        public RelayCommand DeleteClickCommand
        {
            get
            {
                if (_deleteClickCommand == null)
                {
                    _deleteClickCommand = new RelayCommand(OnDeleteClickCommand);
                }
                return _deleteClickCommand;
            }
        }
        private void OnDeleteClickCommand()
        {
            try
            {
                if (SelectedItem != null)
                {
                    if (SelectedItem.Vlu_KhoaChilds.Count > 0)
                        MessageCustomize.Show("Nhóm có con không được xóa");
                    else
                        if (!_modelTrain.IsBusy)
                        {
                            MessageCustomize.Show("Bạn muốn xóa khoa này?", "Xóa", MessageBoxButton.OKCancel, MessageImage.Question, c =>
                            {
                                if (c == MessageBoxResult.OK)
                                {
                                    IsLoading = true;
                                    _modelTrain.DeleteDepartmentAsync(SelectedItem);
                                }
                            });
                        }
                }
                else
                    MessageCustomize.Show("Bạn chưa chọn khoa");
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

                if (SetFocus != null)
                    SetFocus(SystemConfig.UserType, null);
            }
        }

        public void ReloadData()
        {
            IsLoading = true;
            _listData = null;

            _modelTrain.GetListDepartmentAsync();
        }

        public void ErrorProcess()
        {
            IsLoading = false;
        }

        #region Permission

        public void LoadPermission()
        {
            if (SystemConfig.UserType != 1)
            {
                IsLoading = true;
                _modelTrain.GetListAuthenticationFormAsync(ViewKey);
            }
            else
            {
                VisibleAdd = VisibleEdit = VisibleDelete = true;
                ReloadData();
            }
        }

        private void CheckPermission(List<Authentication> lst)
        {
            Authentication obj = lst.FirstOrDefault(c => c.Key == ViewKey);
            if (obj != null)
            {
                if (!obj.IsShow)
                    NotAllow();
                else
                {
                    if (!obj.IsFull)
                    {
                        CheckItemPermission(ViewKey + ActionKey.Add, lst, c =>
                        {
                            if (c)
                                VisibleAdd = true;
                            else
                                VisibleAdd = false;
                        });

                        CheckItemPermission(ViewKey + ActionKey.Edit, lst, c =>
                        {
                            if (c)
                                VisibleEdit = true;
                            else
                                VisibleEdit = false;
                        });

                        CheckItemPermission(ViewKey + ActionKey.Del, lst, c =>
                        {
                            if (c)
                                VisibleDelete = true;
                            else
                                VisibleDelete = false;
                        });
                    }
                    else
                        VisibleAdd = VisibleDelete = VisibleEdit = true;

                    ReloadData();
                }
            }
        }

        private void CheckItemPermission(string key, List<Authentication> lst, Action<bool> callback)
        {
            Authentication obj = lst.FirstOrDefault(c => c.Key == key);
            bool flag = false;
            if (obj != null)
                flag = obj.IsShow;
            if (callback != null)
                callback.Invoke(flag);
        }

        private void NotAllow()
        {
            MessageCustomize.Show("Bạn không có quyền trên chức năng này", "Phân quyền", MessageImage.Alert);
            if (DialogSended != null)
                DialogSended.ProcessCallback(MessageBoxResult.Cancel);
            if (CloseWindow != null)
                CloseWindow(this, null);
        }

        #endregion

        #region Handlers
        private void _model_GetListAuthenticationFormComplete(object sender, ComplexResultsArgs<Authentication> e)
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
                    List<Authentication> lst = e.Results.ToList();
                    CheckPermission(lst);
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
                ErrorProcess();
            }
        }

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
                    ListData = e.Results.Where(c => c.ParentID == null).ToList();
                    LoadInitComplete();
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
                ErrorProcess();
            }
        }

        private void _modelTrain_DeleteDepartmentComplete(object sender, SubmitOperationEventArgs e)
        {
            try
            {
                IsLoading = false;
                if (e.HasError)
                {
                    MessageCustomize.Show("Không xóa được khoa này");
                    ErrorProcess();
                }
                else
                {
                    MessageCustomize.Show("Bạn đã xóa thành công", "Xóa", MessageImage.Information);
                    ReloadData();
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
                _modelTrain.GetListAuthenticationFormComplete -= new EventHandler<ComplexResultsArgs<Authentication>>(_model_GetListAuthenticationFormComplete);
                _modelTrain.GetListDepartmentComplete -= new EventHandler<EntityResultsArgs<Vlu_Khoa>>(_modelTrain_GetListDepartmentComplete);
                _modelTrain.DeleteDepartmentComplete -= new EventHandler<SubmitOperationEventArgs>(_modelTrain_DeleteDepartmentComplete);
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
