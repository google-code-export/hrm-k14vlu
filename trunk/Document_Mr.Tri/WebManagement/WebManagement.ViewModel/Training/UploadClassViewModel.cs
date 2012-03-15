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
using System.Xml.Linq;
using System.Collections;

namespace WebManagement.ViewModel
{
    [Export(ViewModelTypes.UploadClassViewModel, typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UploadClassViewModel : ViewModelBase, IViewModel
    {
        #region Private Members

        private ITrainingModel _modelTrain;
        public const string ViewKey = "WM_UPLOADCLASS";
        private List<Vlu_LopHoc> _listLopHoc;

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

        private bool _visibleSave;
        public bool VisibleSave
        {
            get { return _visibleSave; }
            set
            {
                if (value != _visibleSave)
                {
                    _visibleSave = value;
                    RaisePropertyChanged("VisibleSave");
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

        private List<CustomizeClass> _listData;
        public List<CustomizeClass> ListData
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

        private List<Vlu_Khoa> _listType;
        public List<Vlu_Khoa> ListType
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

        #region IViewModel

        private DialogMessage _dialogSended;
        public DialogMessage DialogSended
        {
            get { return _dialogSended; }
            set
            {
                if (value.Sender is ListClassViewModel)
                {
                    _listLopHoc = (value.Sender as ListClassViewModel).ListData;
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
        public UploadClassViewModel(ITrainingModel modelTrain)
        {
            _modelTrain = modelTrain;
            _modelTrain.GetListAuthenticationFormComplete += new EventHandler<ComplexResultsArgs<Authentication>>(_model_GetListAuthenticationFormComplete);
            //_modelTrain.ImportSubjectComplete += new EventHandler<SubmitOperationEventArgs>(_modelTrain_ImportSubjectComplete);
            _modelTrain.GetListDepartmentComplete += new EventHandler<EntityResultsArgs<Vlu_Khoa>>(_modelTrain_GetListDepartmentComplete);
            _modelTrain.ImportClassComplete += new EventHandler<SubmitOperationEventArgs>(_modelTrain_ImportClassComplete);
        }

        

        
        #endregion

        #region Commands
        private RelayCommand _getFileClickCommand;
        public RelayCommand GetFileClickCommand
        {
            get
            {
                if (_getFileClickCommand == null)
                {
                    _getFileClickCommand = new RelayCommand(OnGetFileClickCommand);
                }
                return _getFileClickCommand;
            }
        }
        private void OnGetFileClickCommand()
        {
            try
            {
                if (SetFocus != null)
                    SetFocus(0, null);
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }
        public void OnGetFileClickComplete(FileInfo fileOpen)
        {
            try
            {
                Stream s = fileOpen.OpenRead();
                StreamReader reader = new StreamReader(s);
                var xml = reader.ReadToEnd();
                s.Close();
                var doc = XDocument.Parse(xml);
                List<string> listColName = doc.Descendants().Where(c => c.Name.LocalName == "Row").First().Descendants().
                    Where(c => c.Name.LocalName == "Data").Select(c => c.Value).ToList();
                List<CustomizeClass> lst = new List<CustomizeClass>();
                if (CheckColumns(listColName))
                {
                    int indexRow = 0;
                    string strError = string.Empty;
                    foreach (var row in doc.Descendants().Where(c => c.Name.LocalName == "Row"))
                    {
                        if (indexRow > 0)
                        {
                            List<string> lstData = row.Descendants().Where(c => c.Name.LocalName == "Data").Select(c => c.Value).ToList();
                            if (lstData.Count > 0)
                            {
                                CustomizeClass obj = new CustomizeClass
                                {
                                    MaLop = (lstData.Count > listColName.IndexOf("MaLop")) ? lstData[listColName.IndexOf("MaLop")].Trim() : string.Empty,
                                    TenLop = (lstData.Count > listColName.IndexOf("TenLop")) ? lstData[listColName.IndexOf("TenLop")].Trim() : string.Empty,
                                    MaKhoa = (lstData.Count > listColName.IndexOf("MaKhoa")) ? lstData[listColName.IndexOf("MaKhoa")].Trim() : string.Empty,
                                    ParentKey = (lstData.Count > listColName.IndexOf("Parent")) ? lstData[listColName.IndexOf("Parent")].Trim() : string.Empty
                                };
                                if (CheckInputData(obj))
                                {
                                    lst.Add(obj);
                                }
                                else
                                    strError += (indexRow + 1).ToString() + ", ";
                            }
                        }
                        indexRow++;
                    }
                    if (strError == string.Empty)
                    {
                        ListData = lst;
                        TotalRecord = "Tổng: " + lst.Count.ToString();
                    }
                    else
                        MessageCustomize.Show("Kiểm tra dòng " + strError.Substring(0, strError.Length - 2));
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
            }
        }

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
                    if (_listData != null)
                    {
                        IsLoading = true;
                        _modelTrain.ImportClassAsync(_listLopHoc, _listData);
                    }
                    else
                        MessageCustomize.Show("Chọn file import");
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
            if (ListType != null)
            {
                IsLoading = false;

                if (SetFocus != null)
                    SetFocus(ListType, null);
            }
        }

        public void ReloadData()
        {
            IsLoading = true;

            _modelTrain.GetListDepartmentAsync();
        }

        private bool CheckColumns(List<string> lst)
        {
            bool result = true;
            string strError = string.Empty;
            if (lst.Count(c => c == "MaLop") != 1)
            {
                strError += "MaLop, ";
                result = false;
            }
            if (lst.Count(c => c == "TenLop") != 1)
            {
                strError += "TenLop, ";
                result = false;
            }
            if (lst.Count(c => c == "MaKhoa") != 1)
            {
                strError += "MaKhoa, ";
                result = false;
            }
            if (lst.Count(c => c == "Parent") != 1)
            {
                strError += "Parent, ";
                result = false;
            }
            if (!result)
            {
                MessageCustomize.Show("Không có hoặc nhiều hơn 1 cột: " + strError.Substring(0, strError.Length - 2));
            }
            return result;
        }

        private bool CheckInputData(CustomizeClass obj)
        {
            try
            {
                if (obj.MaLop.Trim() == string.Empty)
                    return false;
                if (obj.TenLop.Trim() == string.Empty)
                    return false;
                if (obj.MaKhoa.Trim() == string.Empty)
                    return false;
                Vlu_Khoa objKhoa = _listType.FirstOrDefault(c => c.MaKhoa == obj.MaKhoa);
                if (objKhoa != null)
                {
                    obj.KhoaID = objKhoa.KhoaID;
                    obj.TenKhoa = objKhoa.TenKhoa;
                }
                if (obj.ParentKey.Trim() != string.Empty)
                {
                    Vlu_LopHoc objLop = _listLopHoc.FirstOrDefault(c => c.MaLop == obj.ParentKey);
                    if (objLop != null)
                    {
                        obj.ParentID = objLop.LopID;
                        obj.ParentName = objLop.TenLop;
                    }
                    else
                        return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
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
                VisibleSave = true;
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
                        CheckItemPermission(ViewKey + ActionKey.Save, lst, c =>
                        {
                            if (c)
                                VisibleSave = true;
                            else
                                VisibleSave = false;
                        });
                    }
                    else
                        VisibleSave = true;

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

        void _modelTrain_GetListDepartmentComplete(object sender, EntityResultsArgs<Vlu_Khoa> e)
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
                    ListType = e.Results.Where(c => c.ParentID == null).ToList();
                    LoadInitComplete();
                }
            }
            catch (Exception ex)
            {
                MessageCustomize.Show(ex.Message);
                ErrorProcess();
            }
        }

        private void _modelTrain_ImportClassComplete(object sender, SubmitOperationEventArgs e)
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
                    MessageCustomize.Show("Chuyển dữ liệu lên server thành công");
                    if (DialogSended != null)
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
                _modelTrain.ImportClassComplete -= new EventHandler<SubmitOperationEventArgs>(_modelTrain_ImportClassComplete);
                _modelTrain = null;
            }
            _listData = null;
            _listLopHoc = null;
            _listType = null;
            if (_dialogSended != null)
                _dialogSended = null;
            base.Cleanup();
        }
        #endregion
    }
}
