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
    [Export(ViewModelTypes.EditTrainingViewModel, typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditTrainingViewModel : ViewModelBase, IViewModel
    {
        #region Private Members

        private ITrainingModel _modelTrain;
        public const string ViewKey = "WM_EDITTRAINING";

        public int EditID { get; set; }
        public Vlu_ChuongTrinhDT ItemEdit { get; set; }
        public int KhoaID { get; set; }
        public int MonHocID { get; set; }
        public Vlu_MonHoc ItemMonHoc { get; set; }
        public int LopID { get; set; }
        public Vlu_LopHoc ItemLopHoc { get; set; }

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

        private List<CustomizeYear> _listNamHoc;
        public List<CustomizeYear> ListNamHoc
        {
            get { return _listNamHoc; }
            set
            {
                if (_listNamHoc != value)
                {
                    _listNamHoc = value;
                    RaisePropertyChanged("ListNamHoc");
                }
            }
        }

        private CustomizeYear _selectedNamHoc;
        public CustomizeYear SelectedNamHoc
        {
            get { return _selectedNamHoc; }
            set
            {
                if (_selectedNamHoc != value)
                {
                    _selectedNamHoc = value;
                    RaisePropertyChanged("SelectedNamHoc");
                }
            }
        }

        private List<CustomizeSemester> _listHocKy;
        public List<CustomizeSemester> ListHocKy
        {
            get { return _listHocKy; }
            set
            {
                if (_listHocKy != value)
                {
                    _listHocKy = value;
                    RaisePropertyChanged("ListHocKy");
                }
            }
        }

        private CustomizeSemester _selectedHocKy;
        public CustomizeSemester SelectedHocKy
        {
            get { return _selectedHocKy; }
            set
            {
                if (_selectedHocKy != value)
                {
                    _selectedHocKy = value;
                    RaisePropertyChanged("SelectedHocKy");
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

        private string _lopHoc;
        public string LopHoc
        {
            get { return _lopHoc; }
            set
            {
                if (value != _lopHoc)
                {
                    _lopHoc = value;
                    RaisePropertyChanged("LopHoc");
                }
            }
        }
        private bool _visibleErrLopHoc;
        public bool VisibleErrLopHoc
        {
            get { return _visibleErrLopHoc; }
            set
            {
                if (value != _visibleErrLopHoc)
                {
                    _visibleErrLopHoc = value;
                    RaisePropertyChanged("VisibleErrLopHoc");
                }
            }
        }
        private string _stringErrLopHoc;
        public string StringErrLopHoc
        {
            get { return _stringErrLopHoc; }
            set
            {
                if (value != _stringErrLopHoc)
                {
                    _stringErrLopHoc = value;
                    RaisePropertyChanged("StringErrLopHoc");
                }
            }
        }

        private string _monHoc;
        public string MonHoc
        {
            get { return _monHoc; }
            set
            {
                if (value != _monHoc)
                {
                    _monHoc = value;
                    RaisePropertyChanged("MonHoc");
                }
            }
        }
        private bool _visibleErrMonHoc;
        public bool VisibleErrMonHoc
        {
            get { return _visibleErrMonHoc; }
            set
            {
                if (value != _visibleErrMonHoc)
                {
                    _visibleErrMonHoc = value;
                    RaisePropertyChanged("VisibleErrMonHoc");
                }
            }
        }
        private string _stringErrMonHoc;
        public string StringErrMonHoc
        {
            get { return _stringErrMonHoc; }
            set
            {
                if (value != _stringErrMonHoc)
                {
                    _stringErrMonHoc = value;
                    RaisePropertyChanged("StringErrMonHoc");
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
                if (value.Sender is ListTrainingViewModel)
                {
                    EditID = -1;
                    MonHocID = -1;
                    LopID = -1;
                    KhoaID = -1;
                    if ((value.Sender as ListTrainingViewModel).SelectedItem != null)
                    {
                        EditID = (value.Sender as ListTrainingViewModel).SelectedItem.ID;
                        MonHocID = (value.Sender as ListTrainingViewModel).SelectedItem.MonHocID;
                        LopID = (value.Sender as ListTrainingViewModel).SelectedItem.LopID;
                        KhoaID = (value.Sender as ListTrainingViewModel).SelectedItem.KhoaID;
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
        public EditTrainingViewModel(ITrainingModel modelTrain)
        {
            _modelTrain = modelTrain;
            _modelTrain.GetListAuthenticationFormComplete += new EventHandler<ComplexResultsArgs<Authentication>>(_model_GetListAuthenticationFormComplete);
            _modelTrain.GetListDepartmentComplete += new EventHandler<EntityResultsArgs<Vlu_Khoa>>(_modelTrain_GetListDepartmentComplete);
            _modelTrain.GetSubjectComplete += new EventHandler<EntityResultsArgs<Vlu_MonHoc>>(_modelTrain_GetSubjectComplete);
            _modelTrain.GetClassComplete += new EventHandler<EntityResultsArgs<Vlu_LopHoc>>(_modelTrain_GetClassComplete);
            _modelTrain.GetTrainingComplete += new EventHandler<EntityResultsArgs<Vlu_ChuongTrinhDT>>(_modelTrain_GetTrainingComplete);
            _modelTrain.SaveTrainingComplete += new EventHandler<SubmitOperationEventArgs>(_modelTrain_SaveTrainingComplete);
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
                        ItemEdit.NamHoc = SelectedNamHoc.ID;
                        ItemEdit.HocKy = SelectedHocKy.ID;
                        ItemEdit.KhoaID = SelectedKhoa.KhoaID;
                        ItemEdit.LopID = ItemLopHoc.LopID;
                        ItemEdit.MonHocID = ItemMonHoc.MonHocID;
                        _modelTrain.SaveTrainingAsync(ItemEdit);
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

        private RelayCommand _lopHocClickCommand;
        public RelayCommand LopHocClickCommand
        {
            get
            {
                if (_lopHocClickCommand == null)
                {
                    _lopHocClickCommand = new RelayCommand(OnLopHocClickCommand);
                }
                return _lopHocClickCommand;
            }
        }
        private void OnLopHocClickCommand()
        {
            try
            {
                CallDialog.Show(this, ViewTypes.EditChooseClassView, c =>
                {
                    if (c == MessageBoxResult.OK)
                    {
                        LopHoc = ItemLopHoc.TenLop;
                    }
                });
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }

        private RelayCommand _monHocClickCommand;
        public RelayCommand MonHocClickCommand
        {
            get
            {
                if (_monHocClickCommand == null)
                {
                    _monHocClickCommand = new RelayCommand(OnMonHocClickCommand);
                }
                return _monHocClickCommand;
            }
        }
        private void OnMonHocClickCommand()
        {
            try
            {
                CallDialog.Show(this, ViewTypes.EditChooseSubjectView, c =>
                {
                    if (c == MessageBoxResult.OK)
                    {
                        MonHoc = ItemMonHoc.TenMonHoc;
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
            if (ItemEdit != null && ItemLopHoc != null && ItemMonHoc != null && _listKhoa != null)
            {
                IsLoading = false;
                ListNamHoc = CommonMethods.GetListCutomizeYear();
                ListHocKy = CommonMethods.GetListCustomizeSemester();

                MonHoc = ItemMonHoc.TenMonHoc;
                LopHoc = ItemLopHoc.TenLop;

                if (KhoaID != -1)
                    SelectedKhoa = ListKhoa.FirstOrDefault(c => c.KhoaID == ItemEdit.KhoaID);
                if (SelectedKhoa == null)
                    SelectedKhoa = ListKhoa.FirstOrDefault();

                if (ItemEdit.NamHoc != -1)
                    SelectedNamHoc = ListNamHoc.FirstOrDefault(c => c.ID == ItemEdit.NamHoc);
                if (SelectedNamHoc == null)
                    SelectedNamHoc = ListNamHoc.FirstOrDefault();

                if (ItemEdit.HocKy != -1)
                    SelectedHocKy = ListHocKy.FirstOrDefault(c => c.ID == ItemEdit.HocKy);
                if (SelectedHocKy == null)
                    SelectedHocKy = ListHocKy.FirstOrDefault();
            }
        }

        public void ReloadData()
        {
            IsLoading = true;
            _listKhoa = null;
            ItemEdit = null;
            ItemLopHoc = null;
            ItemMonHoc = null;
            ClearError();

            _modelTrain.GetListDepartmentAsync();
            _modelTrain.GetSubjectAsync(MonHocID);
            _modelTrain.GetClassAsync(LopID, 0);
            _modelTrain.GetTrainingAsync(EditID);
        }

        private void ErrorProcess()
        {
            IsLoading = false;
        }

        private bool CheckInputData()
        {
            bool result = true;
            ClearError();
            if (LopID == -1)
            {
                VisibleErrLopHoc = true;
                StringErrLopHoc = "Chưa chọn lớp học";
                result = false;
            }
            if (MonHocID == -1)
            {
                VisibleErrMonHoc = true;
                StringErrMonHoc = "Chưa chọn môn học";
                result = false;
            }
            return result;
        }

        private void ClearError()
        {
            VisibleErrLopHoc = VisibleErrMonHoc = false;
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

        private void _modelTrain_GetTrainingComplete(object sender, EntityResultsArgs<Vlu_ChuongTrinhDT> e)
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
                        MessageCustomize.Show("Đối tượng này đã được xóa", "Báo lỗi", MessageImage.Alert);
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
                        ItemLopHoc = e.Results.FirstOrDefault();
                        LoadInitComplete();
                    }
                    else
                    {
                        MessageCustomize.Show("Lớp này đã được xóa", "Báo lỗi", MessageImage.Alert);
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
                        ItemMonHoc = e.Results.FirstOrDefault();
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

        private void _modelTrain_SaveTrainingComplete(object sender, SubmitOperationEventArgs e)
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
                        MessageCustomize.Show("Đã thêm mới");
                    else
                        MessageCustomize.Show("Đã cập nhật");
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
                _modelTrain.GetListDepartmentComplete -= new EventHandler<EntityResultsArgs<Vlu_Khoa>>(_modelTrain_GetListDepartmentComplete);
                _modelTrain.GetSubjectComplete -= new EventHandler<EntityResultsArgs<Vlu_MonHoc>>(_modelTrain_GetSubjectComplete);
                _modelTrain.GetClassComplete -= new EventHandler<EntityResultsArgs<Vlu_LopHoc>>(_modelTrain_GetClassComplete);
                _modelTrain.SaveTrainingComplete -= new EventHandler<SubmitOperationEventArgs>(_modelTrain_SaveTrainingComplete);
                _modelTrain = null;
            }
            _listKhoa = null;
            _listHocKy = null;
            _listNamHoc = null;
            ItemEdit = null;
            ItemLopHoc = null;
            ItemMonHoc = null;
            if (_dialogSended != null)
                _dialogSended = null;
            base.Cleanup();
        }
        #endregion
    }
}
