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
    [Export(ViewModelTypes.EditRoomViewModel, typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditRoomViewModel : ViewModelBase, IViewModel
    {
        #region Private Members

        private ITrainingModel _modelTrain;
        public const string ViewKey = "WM_EDITROOM";

        public int EditID { get; set; }
        public Vlu_PhongHoc ItemEdit { get; set; }
        private bool _checkMaPhong = false;
        private bool _failMaPhong = false;

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

        private string _maPhong;
        public string MaPhong
        {
            get { return _maPhong; }
            set
            {
                if (value != _maPhong)
                {
                    _maPhong = value;
                    if (_maPhong != null && _maPhong != string.Empty)
                    {
                        _checkMaPhong = true;
                        _modelTrain.GetRoomByKeyAsync(EditID, _maPhong);
                    }
                    RaisePropertyChanged("MaPhong");
                }
            }
        }
        private bool _visibleErrMaPhong;
        public bool VisibleErrMaPhong
        {
            get { return _visibleErrMaPhong; }
            set
            {
                if (value != _visibleErrMaPhong)
                {
                    _visibleErrMaPhong = value;
                    RaisePropertyChanged("VisibleErrMaPhong");
                }
            }
        }
        private string _stringErrMaPhong;
        public string StringErrMaPhong
        {
            get { return _stringErrMaPhong; }
            set
            {
                if (value != _stringErrMaPhong)
                {
                    _stringErrMaPhong = value;
                    RaisePropertyChanged("StringErrMaPhong");
                }
            }
        }

        private string _tenPhong;
        public string TenPhong
        {
            get { return _tenPhong; }
            set
            {
                if (value != _tenPhong)
                {
                    _tenPhong = value;
                    RaisePropertyChanged("TenPhong");
                }
            }
        }
        private bool _visibleErrTenPhong;
        public bool VisibleErrTenPhong
        {
            get { return _visibleErrTenPhong; }
            set
            {
                if (value != _visibleErrTenPhong)
                {
                    _visibleErrTenPhong = value;
                    RaisePropertyChanged("VisibleErrTenPhong");
                }
            }
        }
        private string _stringErrTenPhong;
        public string StringErrTenPhong
        {
            get { return _stringErrTenPhong; }
            set
            {
                if (value != _stringErrTenPhong)
                {
                    _stringErrTenPhong = value;
                    RaisePropertyChanged("StringErrTenPhong");
                }
            }
        }

        private List<CustomizeBranch> _listType;
        public List<CustomizeBranch> ListType
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

        private CustomizeBranch _selectedType;
        public CustomizeBranch SelectedType
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
                if (value.Sender is ListRoomViewModel)
                {
                    EditID = -1;
                    if ((value.Sender as ListRoomViewModel).SelectedItem != null)
                    {
                        EditID = (value.Sender as ListRoomViewModel).SelectedItem.PhongID;
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
        public EditRoomViewModel(ITrainingModel modelTrain)
        {
            _modelTrain = modelTrain;
            _modelTrain.GetListAuthenticationFormComplete += new EventHandler<ComplexResultsArgs<Authentication>>(_model_GetListAuthenticationFormComplete);
            _modelTrain.GetRoomComplete += new EventHandler<EntityResultsArgs<Vlu_PhongHoc>>(_modelTrain_GetRoomComplete);
            _modelTrain.GetRoomByKeyComplete += new EventHandler<EntityResultsArgs<Vlu_PhongHoc>>(_modelTrain_GetRoomByKeyComplete);
            _modelTrain.SaveRoomComplete += new EventHandler<SubmitOperationEventArgs>(_modelTrain_SaveRoomComplete);
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
                        ItemEdit.MaPhong = MaPhong;
                        ItemEdit.TenPhong = TenPhong;
                        ItemEdit.CoSo = SelectedType.ID;
                        _modelTrain.SaveRoomAsync(ItemEdit);
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
        #endregion

        #region Private Methods
        public void LoadInitComplete()
        {
            if (ItemEdit != null)
            {
                IsLoading = false;
                ListType = CommonMethods.GetListCustomizeBrach();

                MaPhong = ItemEdit.MaPhong;
                TenPhong = ItemEdit.TenPhong;
                if (ItemEdit.CoSo != -1)
                    SelectedType = ListType.FirstOrDefault(c => c.ID == ItemEdit.CoSo);
                if (SelectedType == null)
                    SelectedType = ListType.FirstOrDefault();
            }
        }

        public void ReloadData()
        {
            IsLoading = true;
            ItemEdit = null;
            ClearError();

            _modelTrain.GetRoomAsync(EditID);
        }

        private void ErrorProcess()
        {
            IsLoading = false;
        }

        private bool CheckInputData()
        {
            bool result = true;
            ClearError();
            if (MaPhong.Trim() == string.Empty)
            {
                VisibleErrMaPhong = true;
                StringErrMaPhong = "Chưa nhập mã phòng";
                result = false;
            }
            if (TenPhong.Trim() == string.Empty)
            {
                VisibleErrTenPhong = true;
                StringErrTenPhong = "Chưa nhập tên phòng";
                result = false;
            }
            if (_checkMaPhong || _failMaPhong)
            {
                VisibleErrMaPhong = true;
                result = false;
            }
            return result;
        }

        private void ClearError()
        {
            VisibleErrMaPhong = VisibleErrTenPhong = false;
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

        private void _modelTrain_GetRoomComplete(object sender, EntityResultsArgs<Vlu_PhongHoc> e)
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

        private void _modelTrain_GetRoomByKeyComplete(object sender, EntityResultsArgs<Vlu_PhongHoc> e)
        {
            try
            {
                _checkMaPhong = false;
                if (e.HasError)
                {
                    MessageCustomize.Show(e.Error.Message);
                }
                else
                {
                    if (e.Results.Count() > 0)
                    {
                        VisibleErrMaPhong = true;
                        StringErrMaPhong = "Mã phòng đã sử dụng";
                        _failMaPhong = true;
                    }
                    else
                    {
                        VisibleErrMaPhong = false;
                        _failMaPhong = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }

        private void _modelTrain_SaveRoomComplete(object sender, SubmitOperationEventArgs e)
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
                _modelTrain.GetRoomComplete -= new EventHandler<EntityResultsArgs<Vlu_PhongHoc>>(_modelTrain_GetRoomComplete);
                _modelTrain.GetRoomByKeyComplete -= new EventHandler<EntityResultsArgs<Vlu_PhongHoc>>(_modelTrain_GetRoomByKeyComplete);
                _modelTrain.SaveRoomComplete -= new EventHandler<SubmitOperationEventArgs>(_modelTrain_SaveRoomComplete);
                _modelTrain = null;
            }
            ItemEdit = null;
            if (_dialogSended != null)
                _dialogSended = null;
            base.Cleanup();
        }
        #endregion
    }
}
