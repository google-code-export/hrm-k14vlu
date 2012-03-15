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
using System.Collections;

namespace WebManagement.ViewModel
{
    [Export(ViewModelTypes.ListClassViewModel, typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ListClassViewModel : ViewModelBase, IViewModel
    {
        #region Private Members

        private ITrainingModel _modelTrain;
        public const string ViewKey = "WM_LISTCLASS";

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

        private bool _visibleUpload;
        public bool VisibleUpload
        {
            get { return _visibleUpload; }
            set
            {
                if (value != _visibleUpload)
                {
                    _visibleUpload = value;
                    RaisePropertyChanged("VisibleUpload");
                }
            }
        }

        private string _totalRecord;
        public string TotalRecord
        {
            get { return _totalRecord; }
            set
            {
                if (value != _totalRecord)
                {
                    _totalRecord = value;
                    RaisePropertyChanged("TotalRecord");
                }
            }
        }

        private List<Vlu_LopHoc> _listData;
        public List<Vlu_LopHoc> ListData
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

        private Vlu_LopHoc _selectedItem;
        public Vlu_LopHoc SelectedItem
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

        private List<Vlu_Khoa> _listKhoa;
        public List<Vlu_Khoa> ListKhoa
        {
            get { return _listKhoa; }
            private set
            {
                if (value != _listKhoa)
                {
                    _listKhoa = value;
                    RaisePropertyChanged("ListKhoa");
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
        public ListClassViewModel(ITrainingModel modelTrain)
        {
            _modelTrain = modelTrain;
            _modelTrain.GetListAuthenticationFormComplete += new EventHandler<ComplexResultsArgs<Authentication>>(_model_GetListAuthenticationFormComplete);
            _modelTrain.GetListClassComplete += new EventHandler<EntityResultsArgs<Vlu_LopHoc>>(_modelTrain_GetListClassComplete);
            _modelTrain.DeleteClassComplete += new EventHandler<SubmitOperationEventArgs>(_modelTrain_DeleteClassComplete);
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
                CallDialog.Show(this, ViewTypes.EditClassView, c =>
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
                    CallDialog.Show(this, ViewTypes.EditClassView, c =>
                    {
                        if (c == MessageBoxResult.OK)
                        {
                            ReloadData();
                        }
                    });
                }
                else
                    MessageCustomize.Show("Bạn chưa chọn lớp học");
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
                    if (!_modelTrain.IsBusy)
                    {
                        MessageCustomize.Show("Bạn muốn xóa lớp học này?", "Xóa", MessageBoxButton.OKCancel, MessageImage.Question, c =>
                        {
                            if (c == MessageBoxResult.OK)
                            {
                                IsLoading = true;
                                _modelTrain.DeleteClassAsync(SelectedItem);
                            }
                        });
                    }
                }
                else
                    MessageCustomize.Show("Bạn chưa chọn môn học");
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }

        private RelayCommand _uploadClickCommand;
        public RelayCommand UploadClickCommand
        {
            get
            {
                if (_uploadClickCommand == null)
                {
                    _uploadClickCommand = new RelayCommand(OnUploadClickCommand);
                }
                return _uploadClickCommand;
            }
        }
        private void OnUploadClickCommand()
        {
            try
            {
                CallDialog.Show(this, ViewTypes.UploadClassView, c =>
                {
                    if (c == MessageBoxResult.OK)
                    {
                        _listData = null;
                        _modelTrain.GetListClassAsync();
                    }
                });
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }

        private RelayCommand<IList> _filteredCommand;
        public RelayCommand<IList> FilteredCommand
        {
            get
            {

                if (_filteredCommand == null)
                {
                    _filteredCommand = new RelayCommand<IList>(OnFilteredCommand);
                }
                return _filteredCommand;
            }
        }
        private void OnFilteredCommand(IList lst)
        {
            try
            {
                if (lst.Count > 0)
                {
                    TotalRecord = "Tổng: " + lst.Count.ToString();
                }
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
            if (_listData != null && _listKhoa != null)
            {
                IsLoading = false;

                TotalRecord = "Tổng: " + _listData.Count.ToString();
                if (SetFocus != null)
                    SetFocus(ListKhoa, null);
            }
        }

        public void ReloadData()
        {
            IsLoading = true;
            _listData = null;
            _listKhoa = null;

            _modelTrain.GetListClassAsync();
            _modelTrain.GetListDepartmentAsync();
        }

        private void ErrorProcess()
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
                VisibleAdd = VisibleEdit = VisibleDelete = VisibleUpload = true;
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

        private void _modelTrain_GetListClassComplete(object sender, EntityResultsArgs<Vlu_LopHoc> e)
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

        private void _modelTrain_DeleteClassComplete(object sender, SubmitOperationEventArgs e)
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
                    ListKhoa = e.Results.Where(c => c.ParentID == null).ToList();
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
                _modelTrain.GetListAuthenticationFormComplete -= new EventHandler<ComplexResultsArgs<Authentication>>(_model_GetListAuthenticationFormComplete);
                _modelTrain.GetListClassComplete -= new EventHandler<EntityResultsArgs<Vlu_LopHoc>>(_modelTrain_GetListClassComplete);
                _modelTrain.DeleteClassComplete -= new EventHandler<SubmitOperationEventArgs>(_modelTrain_DeleteClassComplete);
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
