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
    [Export(ViewModelTypes.EditSubjectViewModel, typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditSubjectViewModel : ViewModelBase, IViewModel
    {
        #region Private Members

        private ITrainingModel _modelTrain;
        public const string ViewKey = "WM_EDITSUBJECT";

        public int EditID { get; set; }
        public Vlu_MonHoc ItemEdit { get; set; }
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

        private string _maMonHoc;
        public string MaMonHoc
        {
            get { return _maMonHoc; }
            set
            {
                if (value != _maMonHoc)
                {
                    _maMonHoc = value;
                    if (_maMonHoc != null && _maMonHoc != string.Empty)
                    {
                        _checkKey = true;
                        _modelTrain.GetSubjectByKeyAsync(EditID, _maMonHoc);
                    }
                    RaisePropertyChanged("MaMonHoc");
                }
            }
        }
        private bool _visibleErrMaMonHoc;
        public bool VisibleErrMaMonHoc
        {
            get { return _visibleErrMaMonHoc; }
            set
            {
                if (value != _visibleErrMaMonHoc)
                {
                    _visibleErrMaMonHoc = value;
                    RaisePropertyChanged("VisibleErrMaMonHoc");
                }
            }
        }
        private string _stringErrMaMonHoc;
        public string StringErrMaMonHoc
        {
            get { return _stringErrMaMonHoc; }
            set
            {
                if (value != _stringErrMaMonHoc)
                {
                    _stringErrMaMonHoc = value;
                    RaisePropertyChanged("StringErrMaMonHoc");
                }
            }
        }

        private string _tenMonHoc;
        public string TenMonHoc
        {
            get { return _tenMonHoc; }
            set
            {
                if (value != _tenMonHoc)
                {
                    _tenMonHoc = value;
                    RaisePropertyChanged("TenMonHoc");
                }
            }
        }
        private bool _visibleErrTenMonHoc;
        public bool VisibleErrTenMonHoc
        {
            get { return _visibleErrTenMonHoc; }
            set
            {
                if (value != _visibleErrTenMonHoc)
                {
                    _visibleErrTenMonHoc = value;
                    RaisePropertyChanged("VisibleErrTenMonHoc");
                }
            }
        }
        private string _stringErrTenMonHoc;
        public string StringErrTenMonHoc
        {
            get { return _stringErrTenMonHoc; }
            set
            {
                if (value != _stringErrTenMonHoc)
                {
                    _stringErrTenMonHoc = value;
                    RaisePropertyChanged("StringErrTenMonHoc");
                }
            }
        }

        private List<CustomizeSubjectType> _listType;
        public List<CustomizeSubjectType> ListType
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

        private CustomizeSubjectType _selectedType;
        public CustomizeSubjectType SelectedType
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

        private string _dVHT;
        public string DVHT
        {
            get { return _dVHT; }
            set
            {
                if (value != _dVHT)
                {
                    _dVHT = value;
                    RaisePropertyChanged("DVHT");
                }
            }
        }

        private string _tS;
        public string TS
        {
            get { return _tS; }
            set
            {
                if (value != _tS)
                {
                    _tS = value;
                    RaisePropertyChanged("TS");
                }
            }
        }

        private string _lT;
        public string LT
        {
            get { return _lT; }
            set
            {
                if (value != _lT)
                {
                    _lT = value;
                    RaisePropertyChanged("LT");
                }
            }
        }

        private string _bT;
        public string BT
        {
            get { return _bT; }
            set
            {
                if (value != _bT)
                {
                    _bT = value;
                    RaisePropertyChanged("BT");
                }
            }
        }

        private string _tH;
        public string TH
        {
            get { return _tH; }
            set
            {
                if (value != _tH)
                {
                    _tH = value;
                    RaisePropertyChanged("TH");
                }
            }
        }

        private string _bTL;
        public string BTL
        {
            get { return _bTL; }
            set
            {
                if (value != _bTL)
                {
                    _bTL = value;
                    RaisePropertyChanged("BTL");
                }
            }
        }

        private string _dA;
        public string DA
        {
            get { return _dA; }
            set
            {
                if (value != _dA)
                {
                    _dA = value;
                    RaisePropertyChanged("DA");
                }
            }
        }

        private string _lA;
        public string LA
        {
            get { return _lA; }
            set
            {
                if (value != _lA)
                {
                    _lA = value;
                    RaisePropertyChanged("LA");
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
                if (value.Sender is ListSubjectViewModel)
                {
                    EditID = -1;
                    if ((value.Sender as ListSubjectViewModel).SelectedItem != null)
                    {
                        EditID = (value.Sender as ListSubjectViewModel).SelectedItem.MonHocID;
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
        public EditSubjectViewModel(ITrainingModel modelTrain)
        {
            _modelTrain = modelTrain;
            _modelTrain.GetListAuthenticationFormComplete += new EventHandler<ComplexResultsArgs<Authentication>>(_model_GetListAuthenticationFormComplete);
            _modelTrain.GetSubjectComplete += new EventHandler<EntityResultsArgs<Vlu_MonHoc>>(_modelTrain_GetSubjectComplete);
            _modelTrain.GetSubjectByKeyComplete += new EventHandler<EntityResultsArgs<Vlu_MonHoc>>(_modelTrain_GetSubjectByKeyComplete);
            _modelTrain.SaveSubjectComplete += new EventHandler<SubmitOperationEventArgs>(_modelTrain_SaveSubjectComplete);
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
                        ItemEdit.MaMonHoc = MaMonHoc;
                        ItemEdit.TenMonHoc = TenMonHoc;
                        ItemEdit.ThuocNhom = SelectedType.TypeID;
                        ItemEdit.DVHT = DVHT;
                        ItemEdit.TS = TS;
                        ItemEdit.LT = LT;
                        ItemEdit.BT = BT;
                        ItemEdit.TH = TH;
                        ItemEdit.BTL = BTL;
                        ItemEdit.DA = DA;
                        ItemEdit.LA = LA;
                        _modelTrain.SaveSubjectAsync(ItemEdit);
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

                ListType = CommonMethods.GetListCustomizeSubjectType();
                SelectedType = ListType.FirstOrDefault(c => c.TypeID == ItemEdit.ThuocNhom);
                if (SelectedType == null) SelectedType = ListType.FirstOrDefault();

                MaMonHoc = ItemEdit.MaMonHoc;
                TenMonHoc = ItemEdit.TenMonHoc;                
                DVHT = ItemEdit.DVHT;
                TS = ItemEdit.TS;
                LT = ItemEdit.LT;
                BT = ItemEdit.BT;
                TH = ItemEdit.TH;
                BTL = ItemEdit.BTL;
                DA = ItemEdit.DA;
                LA = ItemEdit.LA;
            }
        }

        public void ReloadData()
        {
            IsLoading = true;
            ItemEdit = null;
            ClearError();

            _modelTrain.GetSubjectAsync(EditID);
        }

        private void ErrorProcess()
        {
            IsLoading = false;
        }

        private bool CheckInputData()
        {
            bool result = true;
            ClearError();
            if (MaMonHoc.Trim() == string.Empty)
            {
                VisibleErrMaMonHoc = true;
                StringErrMaMonHoc = "Chưa nhập mã môn học";
                result = false;
            }
            if (TenMonHoc.Trim() == string.Empty)
            {
                VisibleErrTenMonHoc = true;
                StringErrTenMonHoc = "Chưa nhập tên môn học";
                result = false;
            }
            if (_checkKey || _failKey)
            {
                VisibleErrMaMonHoc = true;
                result = false;
            }
            return result;
        }

        private void ClearError()
        {
            VisibleErrMaMonHoc = VisibleErrTenMonHoc = false;
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

        private void _modelTrain_GetSubjectComplete(object sender, EntityResultsArgs<Vlu_MonHoc> e)
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
                        MessageCustomize.Show("Môn học này đã được xóa", "Báo lỗi", MessageImage.Alert);
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

        private void _modelTrain_GetSubjectByKeyComplete(object sender, EntityResultsArgs<Vlu_MonHoc> e)
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
                        VisibleErrMaMonHoc = true;
                        StringErrMaMonHoc = "Mã môn học đã sử dụng";
                        _failKey = true;
                    }
                    else
                    {
                        VisibleErrMaMonHoc = false;
                        _failKey = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }

        private void _modelTrain_SaveSubjectComplete(object sender, SubmitOperationEventArgs e)
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
                _modelTrain.GetSubjectComplete -= new EventHandler<EntityResultsArgs<Vlu_MonHoc>>(_modelTrain_GetSubjectComplete);
                _modelTrain.GetSubjectByKeyComplete -= new EventHandler<EntityResultsArgs<Vlu_MonHoc>>(_modelTrain_GetSubjectByKeyComplete);
                _modelTrain.SaveSubjectComplete -= new EventHandler<SubmitOperationEventArgs>(_modelTrain_SaveSubjectComplete);
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
