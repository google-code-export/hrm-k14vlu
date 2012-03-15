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
    [Export(ViewModelTypes.EditClassViewModel, typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditClassViewModel : ViewModelBase, IViewModel
    {
        #region Private Members

        private ITrainingModel _modelTrain;
        public const string ViewKey = "WM_EDITCLASS";

        public int EditID { get; set; }
        public Vlu_LopHoc ItemEdit { get; set; }
        public int ParentID { get; set; }
        public Vlu_LopHoc ItemParent { get; set; }
        public int KhoaID { get; set; }
        private bool _checkKey = false;
        private bool _failKey = false;

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
                    NotLoading = !value;
                    RaisePropertyChanged("IsLoading");
                }
            }
        }

        private bool _notLoading;
        public bool NotLoading
        {
            get { return _notLoading; }
            set
            {
                if (value != _notLoading)
                {
                    _notLoading = value;
                    RaisePropertyChanged("NotLoading");
                }
            }
        }

        private string _maLop;
        public string MaLop
        {
            get { return _maLop; }
            set
            {
                if (value != _maLop)
                {
                    _maLop = value;
                    if (_maLop != null && _maLop != string.Empty)
                    {
                        _checkKey = true;
                        _modelTrain.GetClassByKeyAsync(EditID, _maLop);
                    }
                    RaisePropertyChanged("MaLop");
                }
            }
        }
        private bool _visibleErrMaLop;
        public bool VisibleErrMaLop
        {
            get { return _visibleErrMaLop; }
            set
            {
                if (value != _visibleErrMaLop)
                {
                    _visibleErrMaLop = value;
                    RaisePropertyChanged("VisibleErrMaLop");
                }
            }
        }
        private string _stringErrMaLop;
        public string StringErrMaLop
        {
            get { return _stringErrMaLop; }
            set
            {
                if (value != _stringErrMaLop)
                {
                    _stringErrMaLop = value;
                    RaisePropertyChanged("StringErrMaLop");
                }
            }
        }

        private string _tenLop;
        public string TenLop
        {
            get { return _tenLop; }
            set
            {
                if (value != _tenLop)
                {
                    _tenLop = value;
                    RaisePropertyChanged("TenLop");
                }
            }
        }
        private bool _visibleErrTenLop;
        public bool VisibleErrTenLop
        {
            get { return _visibleErrTenLop; }
            set
            {
                if (value != _visibleErrTenLop)
                {
                    _visibleErrTenLop = value;
                    RaisePropertyChanged("VisibleErrTenLop");
                }
            }
        }
        private string _stringErrTenLop;
        public string StringErrTenLop
        {
            get { return _stringErrTenLop; }
            set
            {
                if (value != _stringErrTenLop)
                {
                    _stringErrTenLop = value;
                    RaisePropertyChanged("StringErrTenLop");
                }
            }
        }

        private string _parentName;
        public string ParentName
        {
            get { return _parentName; }
            set
            {
                if (value != _parentName)
                {
                    _parentName = value;
                    RaisePropertyChanged("ParentName");
                }
            }
        }

        private List<Vlu_Khoa> _listKhoa;
        public List<Vlu_Khoa> ListKhoa
        {
            get { return _listKhoa; }
            set
            {
                if (_listKhoa != value)
                {
                    _listKhoa = value;
                    RaisePropertyChanged("ListKhoa");
                }
            }
        }

        private Vlu_Khoa _selectedKhoa;
        public Vlu_Khoa SelectedKhoa
        {
            get { return _selectedKhoa; }
            set
            {
                if (_selectedKhoa != value)
                {
                    _selectedKhoa = value;
                    RaisePropertyChanged("SelectedKhoa");
                }
            }
        }

        private bool _enabledSave;
        public bool EnabledSave
        {
            get { return _enabledSave && !IsLoading; }
            set
            {
                if (value != _enabledSave)
                {
                    _enabledSave = value;
                    RaisePropertyChanged("EnabledSave");
                }
            }
        }

        #region IViewModel

        private DialogMessage _dialogSended;
        public DialogMessage DialogSended
        {
            get { return _dialogSended; }
            set
            {
                if (value.Sender is ListClassViewModel)
                {
                    EditID = -1;
                    ParentID = -1;
                    if ((value.Sender as ListClassViewModel).SelectedItem != null)
                    {
                        EditID = (value.Sender as ListClassViewModel).SelectedItem.LopID;
                        ParentID = ((value.Sender as ListClassViewModel).SelectedItem.ParentID == null) ?
                            -1 : (value.Sender as ListClassViewModel).SelectedItem.ParentID.Value;
                    }
                }
                _dialogSended = value;
            }
        }
        public event EventHandler CloseWindow;
        public event EventHandler SetFocus;

        #endregion

        #endregion

        #region Contructors
        [ImportingConstructor]
        public EditClassViewModel(ITrainingModel modelTrain)
        {
            _modelTrain = modelTrain;
            _modelTrain.GetListAuthenticationFormComplete += new EventHandler<ComplexResultsArgs<Authentication>>(_model_GetListAuthenticationFormComplete);
            _modelTrain.GetClassComplete += new EventHandler<EntityResultsArgs<Vlu_LopHoc>>(_modelTrain_GetClassComplete);
            _modelTrain.GetClassParentComplete += new EventHandler<EntityResultsArgs<Vlu_LopHoc>>(_modelTrain_GetClassParentComplete);
            _modelTrain.GetClassByKeyComplete += new EventHandler<EntityResultsArgs<Vlu_LopHoc>>(_modelTrain_GetClassByKeyComplete);
            _modelTrain.SaveClassComplete += new EventHandler<SubmitOperationEventArgs>(_modelTrain_SaveClassComplete);
            _modelTrain.GetListDepartmentComplete += new EventHandler<EntityResultsArgs<Vlu_Khoa>>(_modelTrain_GetListDepartmentComplete);
        }
        #endregion

        #region Commands
        private RelayCommand _saveClickCommand;
        public RelayCommand SaveClickCommand
        {
            get
            {
                if (_saveClickCommand == null)
                {
                    _saveClickCommand = new RelayCommand(OnSaveClickCommand);
                }
                return _saveClickCommand;
            }
        }
        private void OnSaveClickCommand()
        {
            try
            {
                if (!_modelTrain.IsBusy)
                {
                    if (CheckInputData())
                    {
                        IsLoading = true;
                        ItemEdit.MaLop = MaLop;
                        ItemEdit.TenLop = TenLop;
                        if (ParentID != -1)
                            ItemEdit.ParentID = ParentID;
                        else
                            ItemEdit.ParentID = null;
                        if (_selectedKhoa != null)
                            ItemEdit.KhoaID = _selectedKhoa.KhoaID;
                        else
                            ItemEdit.KhoaID = null;
                        _modelTrain.SaveClassAsync(ItemEdit);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
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
                if (CloseWindow != null)
                    CloseWindow(this, null);
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }

        private RelayCommand _parentClickCommand;
        public RelayCommand ParentClickCommand
        {
            get
            {
                if (_parentClickCommand == null)
                {
                    _parentClickCommand = new RelayCommand(OnParentClickCommand);
                }
                return _parentClickCommand;
            }
        }
        private void OnParentClickCommand()
        {
            try
            {
                CallDialog.Show(this, ViewTypes.EditChooseClassView, c =>
                {
                    if (c == MessageBoxResult.OK)
                    {
                        ParentName = ItemParent.TenLop;
                    }
                });
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
            if (ItemEdit != null && ItemParent != null && ListKhoa != null)
            {
                IsLoading = false;

                MaLop = ItemEdit.MaLop;
                TenLop = ItemEdit.TenLop;
                ParentName = ItemParent.TenLop;
                SelectedKhoa = ListKhoa.FirstOrDefault(c => c.KhoaID == ItemEdit.KhoaID);
            }
        }

        public void ReloadData()
        {
            IsLoading = true;
            ItemEdit = null;
            ItemParent = null;
            _listKhoa = null;
            ClearError();

            _modelTrain.GetClassAsync(EditID, 0);
            _modelTrain.GetClassAsync(ParentID, 1);
            _modelTrain.GetListDepartmentAsync();
        }

        private void ErrorProcess()
        {
            IsLoading = false;
        }

        private bool CheckInputData()
        {
            bool result = true;
            ClearError();
            if (MaLop.Trim() == string.Empty)
            {
                VisibleErrMaLop = true;
                StringErrMaLop = "Chưa nhập mã lớp";
                result = false;
            }
            if (TenLop.Trim() == string.Empty)
            {
                VisibleErrTenLop = true;
                StringErrTenLop = "Chưa nhập tên lớp";
                result = false;
            }
            if (_checkKey || _failKey)
            {
                VisibleErrMaLop = true;
                result = false;
            }
            return result;
        }

        private void ClearError()
        {
            VisibleErrMaLop = VisibleErrTenLop = false;
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
                _enabledSave = true;
                ReloadData();
            }
        }

        public void CheckPermission(List<Authentication> lst)
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
                        CheckItemPermission(ViewKey + ActionKey.Save, lst, c =>
                        {
                            if (c)
                                EnabledSave = true;
                            else
                                EnabledSave = false;
                        });
                    }

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

        private void _modelTrain_GetClassComplete(object sender, EntityResultsArgs<Vlu_LopHoc> e)
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
                    if (e.Results.Count() > 0)
                    {
                        ItemEdit = e.Results.FirstOrDefault();
                        LoadInitComplete();
                    }
                    else
                    {
                        MessageCustomize.Show("Lớp học này đã được xóa", "Báo lỗi", MessageImage.Alert);
                        if (DialogSended != null)
                            DialogSended.ProcessCallback(MessageBoxResult.Cancel);
                        if (CloseWindow != null)
                            CloseWindow(this, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
                ErrorProcess();
            }
        }

        private void _modelTrain_GetClassParentComplete(object sender, EntityResultsArgs<Vlu_LopHoc> e)
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
                    if (e.Results.Count() > 0)
                    {
                        ItemParent = e.Results.FirstOrDefault();
                        LoadInitComplete();
                    }
                    else
                    {
                        MessageCustomize.Show("Nhóm này đã được xóa", "Báo lỗi", MessageImage.Alert);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
                ErrorProcess();
            }
        }

        private void _modelTrain_GetClassByKeyComplete(object sender, EntityResultsArgs<Vlu_LopHoc> e)
        {
            try
            {
                _checkKey = false;
                if (e.HasError)
                {
                    MessageCustomize.Show(e.Error.Message);
                }
                else
                {
                    if (e.Results.Count() > 0)
                    {
                        VisibleErrMaLop = true;
                        StringErrMaLop = "Mã lớp học đã sử dụng";
                        _failKey = true;
                    }
                    else
                    {
                        VisibleErrMaLop = false;
                        _failKey = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }

        private void _modelTrain_SaveClassComplete(object sender, SubmitOperationEventArgs e)
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
                    if (EditID == -1)
                        MessageCustomize.Show("Đã thêm mới lớp học");
                    else
                        MessageCustomize.Show("Đã cập nhật thông tin");
                    if (DialogSended.Callback != null)
                        DialogSended.ProcessCallback(MessageBoxResult.OK);
                    if (CloseWindow != null)
                        CloseWindow(this, null);
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
                _modelTrain.GetClassComplete -= new EventHandler<EntityResultsArgs<Vlu_LopHoc>>(_modelTrain_GetClassComplete);
                _modelTrain.GetClassParentComplete -= new EventHandler<EntityResultsArgs<Vlu_LopHoc>>(_modelTrain_GetClassParentComplete);
                _modelTrain.GetClassByKeyComplete -= new EventHandler<EntityResultsArgs<Vlu_LopHoc>>(_modelTrain_GetClassByKeyComplete);
                _modelTrain.SaveClassComplete -= new EventHandler<SubmitOperationEventArgs>(_modelTrain_SaveClassComplete);
                _modelTrain.GetListDepartmentComplete -= new EventHandler<EntityResultsArgs<Vlu_Khoa>>(_modelTrain_GetListDepartmentComplete);
                _modelTrain = null;
            }
            ItemEdit = null;
            _listKhoa = null;
            if (_dialogSended != null)
                _dialogSended = null;
            base.Cleanup();
        }
        #endregion
    }
}
