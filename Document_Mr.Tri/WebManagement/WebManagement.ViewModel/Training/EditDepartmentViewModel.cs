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
    [Export(ViewModelTypes.EditDepartmentViewModel, typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditDepartmentViewModel : ViewModelBase, IViewModel
    {
        #region Private Members

        private ITrainingModel _modelTrain;
        public const string ViewKey = "WM_EDITDEPARTMENT";

        public int EditID { get; set; }
        public Vlu_Khoa ItemEdit { get; set; }
        public int ParentID { get; set; }
        public Vlu_Khoa ItemParent { get; set; }
        private bool _checkMaKhoa = false;
        private bool _failMaKhoa = false;

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

        private string _maKhoa;
        public string MaKhoa
        {
            get { return _maKhoa; }
            set
            {
                if (value != _maKhoa)
                {
                    _maKhoa = value;
                    if (_maKhoa != null && _maKhoa != string.Empty)
                    {
                        _checkMaKhoa = true;
                        _modelTrain.GetDepartmentByKeyAsync(EditID, _maKhoa);
                    }
                    RaisePropertyChanged("MaKhoa");
                }
            }
        }
        private bool _visibleErrMaKhoa;
        public bool VisibleErrMaKhoa
        {
            get { return _visibleErrMaKhoa; }
            set
            {
                if (value != _visibleErrMaKhoa)
                {
                    _visibleErrMaKhoa = value;
                    RaisePropertyChanged("VisibleErrMaKhoa");
                }
            }
        }
        private string _stringErrMaKhoa;
        public string StringErrMaKhoa
        {
            get { return _stringErrMaKhoa; }
            set
            {
                if (value != _stringErrMaKhoa)
                {
                    _stringErrMaKhoa = value;
                    RaisePropertyChanged("StringErrMaKhoa");
                }
            }
        }

        private string _tenKhoa;
        public string TenKhoa
        {
            get { return _tenKhoa; }
            set
            {
                if (value != _tenKhoa)
                {
                    _tenKhoa = value;
                    RaisePropertyChanged("TenKhoa");
                }
            }
        }
        private bool _visibleErrTenKhoa;
        public bool VisibleErrTenKhoa
        {
            get { return _visibleErrTenKhoa; }
            set
            {
                if (value != _visibleErrTenKhoa)
                {
                    _visibleErrTenKhoa = value;
                    RaisePropertyChanged("VisibleErrTenKhoa");
                }
            }
        }
        private string _stringErrTenKhoa;
        public string StringErrTenKhoa
        {
            get { return _stringErrTenKhoa; }
            set
            {
                if (value != _stringErrTenKhoa)
                {
                    _stringErrTenKhoa = value;
                    RaisePropertyChanged("StringErrTenKhoa");
                }
            }
        }

        private List<CustomizeDepartmentType> _listType;
        public List<CustomizeDepartmentType> ListType
        {
            get { return _listType; }
            set
            {
                if (_listType != value)
                {
                    _listType = value;
                    RaisePropertyChanged("ListType");
                }
            }
        }

        private CustomizeDepartmentType _selectedType;
        public CustomizeDepartmentType SelectedType
        {
            get { return _selectedType; }
            set
            {
                if (_selectedType != value)
                {
                    _selectedType = value;
                    RaisePropertyChanged("SelectedType");
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
                if (value.Sender is ListDepartmentViewModel)
                {
                    EditID = -1;
                    ParentID = -1;
                    if ((value.Sender as ListDepartmentViewModel).SelectedItem != null)
                    {
                        EditID = (value.Sender as ListDepartmentViewModel).SelectedItem.KhoaID;
                        ParentID = ((value.Sender as ListDepartmentViewModel).SelectedItem.ParentID == null) ?
                            -1 : (value.Sender as ListDepartmentViewModel).SelectedItem.ParentID.Value;
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
        public EditDepartmentViewModel(ITrainingModel modelTrain)
        {
            _modelTrain = modelTrain;
            _modelTrain.GetListAuthenticationFormComplete += new EventHandler<ComplexResultsArgs<Authentication>>(_model_GetListAuthenticationFormComplete);
            _modelTrain.GetDepartmentComplete += new EventHandler<EntityResultsArgs<Vlu_Khoa>>(_modelTrain_GetDepartmentComplete);
            _modelTrain.GetDepartmentByKeyComplete += new EventHandler<EntityResultsArgs<Vlu_Khoa>>(_modelTrain_GetDepartmentByKeyComplete);
            _modelTrain.GetDepartmentParentComplete += new EventHandler<EntityResultsArgs<Vlu_Khoa>>(_modelTrain_GetDepartmentParentComplete);
            _modelTrain.SaveDepartmentComplete += new EventHandler<SubmitOperationEventArgs>(_modelTrain_SaveDepartmentComplete);
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
                        ItemEdit.MaKhoa = MaKhoa;
                        ItemEdit.TenKhoa = TenKhoa;
                        ItemEdit.Loai = _selectedType.TypeID;
                        if (ParentID > 0)
                            ItemEdit.ParentID = ParentID;
                        else
                            ItemEdit.ParentID = null;
                        _modelTrain.SaveDepartmentAsync(ItemEdit);
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
                CallDialog.Show(this, ViewTypes.EditChooseDepartmentView, c =>
                {
                    if (c == MessageBoxResult.OK)
                    {
                        ParentName = ItemParent.TenKhoa;
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
            if (ItemEdit != null && ItemParent != null)
            {
                IsLoading = false;
                MaKhoa = ItemEdit.MaKhoa;
                TenKhoa = ItemEdit.TenKhoa;
                ParentName = ItemParent.TenKhoa;

                List<CustomizeDepartmentType> lst = new List<CustomizeDepartmentType>();
                lst.Add(new CustomizeDepartmentType { TypeID = 1, TypeName = "Khoa" });
                lst.Add(new CustomizeDepartmentType { TypeID = 2, TypeName = "Ban" });
                lst.Add(new CustomizeDepartmentType { TypeID = 3, TypeName = "Nghành" });
                ListType = lst;
                SelectedType = ListType.FirstOrDefault(c => c.TypeID == ItemEdit.Loai);
                if (SelectedType == null) SelectedType = ListType.FirstOrDefault();
            }
        }

        public void ReloadData()
        {
            IsLoading = true;
            ItemEdit = null;
            ItemParent = null;
            ClearError();

            _modelTrain.GetDepartmentAsync(EditID, 0);
            _modelTrain.GetDepartmentAsync(ParentID, 1);
        }

        private void ErrorProcess()
        {
            IsLoading = false;
        }

        private bool CheckInputData()
        {
            bool result = true;
            ClearError();
            if (MaKhoa.Trim() == string.Empty)
            {
                VisibleErrMaKhoa = true;
                StringErrMaKhoa = "Chưa nhập mã khoa";
                result = false;
            }
            if (TenKhoa.Trim() == string.Empty)
            {
                VisibleErrTenKhoa = true;
                StringErrTenKhoa = "Chưa nhập tên khoa";
                result = false;
            }
            if (_checkMaKhoa || _failMaKhoa)
            {
                VisibleErrMaKhoa = true;
                result = false;
            }
            return result;
        }

        private void ClearError()
        {
            VisibleErrMaKhoa = VisibleErrTenKhoa = false;
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

        private void _modelTrain_GetDepartmentComplete(object sender, EntityResultsArgs<Vlu_Khoa> e)
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
                        MessageCustomize.Show("Nhóm này đã được xóa", "Báo lỗi", MessageImage.Alert);
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

        private void _modelTrain_GetDepartmentByKeyComplete(object sender, EntityResultsArgs<Vlu_Khoa> e)
        {
            try
            {
                _checkMaKhoa = false;
                if (e.HasError)
                {
                    MessageCustomize.Show(e.Error.Message);
                }
                else
                {
                    if (e.Results.Count() > 0)
                    {
                        VisibleErrMaKhoa = true;
                        StringErrMaKhoa = "Mã khoa đã sử dụng";
                        _failMaKhoa = true;
                    }
                    else
                    {
                        VisibleErrMaKhoa = false;
                        _failMaKhoa = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }

        private void _modelTrain_GetDepartmentParentComplete(object sender, EntityResultsArgs<Vlu_Khoa> e)
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

        private void _modelTrain_SaveDepartmentComplete(object sender, SubmitOperationEventArgs e)
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
                        MessageCustomize.Show("Đã thêm mới phòng học");
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
        #endregion

        #endregion

        #region ICleanup interface
        public override void Cleanup()
        {
            if (_modelTrain != null)
            {
                _modelTrain.GetListAuthenticationFormComplete -= new EventHandler<ComplexResultsArgs<Authentication>>(_model_GetListAuthenticationFormComplete);
                _modelTrain.GetDepartmentComplete -= new EventHandler<EntityResultsArgs<Vlu_Khoa>>(_modelTrain_GetDepartmentComplete);
                _modelTrain.GetDepartmentByKeyComplete -= new EventHandler<EntityResultsArgs<Vlu_Khoa>>(_modelTrain_GetDepartmentByKeyComplete);
                _modelTrain.GetDepartmentParentComplete -= new EventHandler<EntityResultsArgs<Vlu_Khoa>>(_modelTrain_GetDepartmentParentComplete);
                _modelTrain.SaveDepartmentComplete -= new EventHandler<SubmitOperationEventArgs>(_modelTrain_SaveDepartmentComplete);
                _modelTrain = null;
            }
            ItemEdit = null;
            ItemParent = null;
            if (_dialogSended != null)
                _dialogSended = null;
            base.Cleanup();
        }
        #endregion
    }
}
