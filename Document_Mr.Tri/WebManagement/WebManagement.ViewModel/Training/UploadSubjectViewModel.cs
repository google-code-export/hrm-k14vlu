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
    [Export(ViewModelTypes.UploadSubjectViewModel, typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UploadSubjectViewModel : ViewModelBase, IViewModel
    {
        #region Private Members

        private ITrainingModel _modelTrain;
        public const string ViewKey = "WM_UPLOADSUBJECT";
        private List<Vlu_MonHoc> _listMonHoc;

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

        private List<Vlu_MonHoc> _listData;
        public List<Vlu_MonHoc> ListData
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

        #region IViewModel

        private DialogMessage _dialogSended;
        public DialogMessage DialogSended
        {
            get { return _dialogSended; }
            set
            {
                if (value.Sender is ListSubjectViewModel)
                {
                    _listMonHoc = (value.Sender as ListSubjectViewModel).ListData;
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
        public UploadSubjectViewModel(ITrainingModel modelTrain)
        {
            _modelTrain = modelTrain;
            _modelTrain.GetListAuthenticationFormComplete += new EventHandler<ComplexResultsArgs<Authentication>>(_model_GetListAuthenticationFormComplete);
            _modelTrain.ImportSubjectComplete += new EventHandler<SubmitOperationEventArgs>(_modelTrain_ImportSubjectComplete);
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
                List<Vlu_MonHoc> lst = new List<Vlu_MonHoc>();
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
                                bool checkDaiCuong = true;
                                if (lstData.Count > listColName.IndexOf("DaiCuong"))
                                {
                                    try
                                    {
                                        int i = Convert.ToInt32(lstData[listColName.IndexOf("DaiCuong")]);
                                    }
                                    catch
                                    {
                                        checkDaiCuong = false;
                                    }
                                }
                                else
                                    checkDaiCuong = false;
                                if (checkDaiCuong)
                                {
                                    Vlu_MonHoc obj = new Vlu_MonHoc
                                    {
                                        MaMonHoc = (lstData.Count > listColName.IndexOf("MaMH")) ? lstData[listColName.IndexOf("MaMH")].Trim() : string.Empty,
                                        TenMonHoc = (lstData.Count > listColName.IndexOf("TenMH")) ? lstData[listColName.IndexOf("TenMH")].Trim() : string.Empty,
                                        DVHT = (lstData.Count > listColName.IndexOf("DVHT")) ? lstData[listColName.IndexOf("DVHT")].Trim() : string.Empty,
                                        TS = (lstData.Count > listColName.IndexOf("TS")) ? lstData[listColName.IndexOf("TS")].Trim() : string.Empty,
                                        LT = (lstData.Count > listColName.IndexOf("LT")) ? lstData[listColName.IndexOf("LT")].Trim() : string.Empty,
                                        BT = (lstData.Count > listColName.IndexOf("BT")) ? lstData[listColName.IndexOf("BT")].Trim() : string.Empty,
                                        TH = (lstData.Count > listColName.IndexOf("TH")) ? lstData[listColName.IndexOf("TH")].Trim() : string.Empty,
                                        BTL = (lstData.Count > listColName.IndexOf("BTL")) ? lstData[listColName.IndexOf("BTL")].Trim() : string.Empty,
                                        DA = (lstData.Count > listColName.IndexOf("DA")) ? lstData[listColName.IndexOf("DA")].Trim() : string.Empty,
                                        LA = (lstData.Count > listColName.IndexOf("LA")) ? lstData[listColName.IndexOf("LA")].Trim() : string.Empty,
                                        ThuocNhom = (lstData.Count > listColName.IndexOf("DaiCuong")) ? Convert.ToInt32(lstData[listColName.IndexOf("DaiCuong")]) : 0
                                    };
                                    if (CheckInputData(obj))
                                    {
                                        lst.Add(obj);
                                    }
                                    else
                                        strError += (indexRow + 1).ToString() + ", ";
                                }
                                else
                                {
                                    strError += (indexRow + 1).ToString() + ", ";
                                }
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
                        _modelTrain.ImportSubjectAsync(_listMonHoc, _listData);
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
            ListType = CommonMethods.GetListCustomizeSubjectType();

            LoadInitComplete();
        }

        private bool CheckColumns(List<string> lst)
        {
            bool result = true;
            string strError = string.Empty;
            if (lst.Count(c => c == "MaMH") != 1)
            {
                strError += "MaMH, ";
                result = false;
            }
            if (lst.Count(c => c == "TenMH") != 1)
            {
                strError += "TenMH, ";
                result = false;
            }
            if (lst.Count(c => c == "DVHT") != 1)
            {
                strError += "DVHT, ";
                result = false;
            }
            if (lst.Count(c => c == "TS") != 1)
            {
                strError += "TS, ";
                result = false;
            }
            if (lst.Count(c => c == "LT") != 1)
            {
                strError += "LT, ";
                result = false;
            }
            if (lst.Count(c => c == "BT") != 1)
            {
                strError += "BT, ";
                result = false;
            }
            if (lst.Count(c => c == "TH") != 1)
            {
                strError += "TH, ";
                result = false;
            }
            if (lst.Count(c => c == "BTL") != 1)
            {
                strError += "BTL, ";
                result = false;
            }
            if (lst.Count(c => c == "DA") != 1)
            {
                strError += "DA, ";
                result = false;
            }
            if (lst.Count(c => c == "LA") != 1)
            {
                strError += "LA, ";
                result = false;
            }
            if (lst.Count(c => c == "DaiCuong") != 1)
            {
                strError += "DaiCuong, ";
                result = false;
            }
            if (!result)
            {
                MessageCustomize.Show("Không có hoặc nhiều hơn 1 cột: " + strError.Substring(0, strError.Length - 2));
            }
            return result;
        }

        private bool CheckInputData(Vlu_MonHoc obj)
        {
            try
            {
                if (obj.MaMonHoc.Trim() == string.Empty)
                    return false;
                if (obj.TenMonHoc.Trim() == string.Empty)
                    return false;
                int iCheck = Convert.ToInt32(obj.DVHT);
                iCheck = Convert.ToInt32(obj.TS);
                iCheck = Convert.ToInt32(obj.LT);
                iCheck = Convert.ToInt32(obj.BT);
                iCheck = Convert.ToInt32(obj.TH);
                iCheck = Convert.ToInt32(obj.BTL);
                iCheck = Convert.ToInt32(obj.DA);
                iCheck = Convert.ToInt32(obj.LA);
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

        public void _modelTrain_ImportSubjectComplete(object sender, SubmitOperationEventArgs e)
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
                _modelTrain.ImportSubjectComplete -= new EventHandler<SubmitOperationEventArgs>(_modelTrain_ImportSubjectComplete);
                _modelTrain = null;
            }
            _listData = null;
            _listMonHoc = null;
            _listType = null;
            if (_dialogSended != null)
                _dialogSended = null;
            base.Cleanup();
        }
        #endregion
    }
}
