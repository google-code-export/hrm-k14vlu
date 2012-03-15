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
    [Export(ViewModelTypes.ListRoomViewModel, typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ListRoomViewModel : ViewModelBase, IViewModel
    {
        #region Private Members

        private ITrainingModel _modelTrain;
        public const string ViewKey = "WM_LISTROOM";

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

        private List<Vlu_PhongHoc> _listData;
        public List<Vlu_PhongHoc> ListData
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

        private Vlu_PhongHoc _selectedItem;
        public Vlu_PhongHoc SelectedItem
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

        #region IViewModel

        public DialogMessage DialogSended { get; set; }
        public event EventHandler CloseWindow;
        public event EventHandler SetFocus;

        #endregion

        #endregion

        #region Contructors
        [ImportingConstructor]
        public ListRoomViewModel(ITrainingModel modelTrain)
        {
            _modelTrain = modelTrain;
            _modelTrain.GetListAuthenticationFormComplete += new EventHandler<ComplexResultsArgs<Authentication>>(_model_GetListAuthenticationFormComplete);
            _modelTrain.GetListRoomComplete += new EventHandler<EntityResultsArgs<Vlu_PhongHoc>>(_modelTrain_GetListRoomComplete);
            _modelTrain.DeleteRoomComplete += new EventHandler<SubmitOperationEventArgs>(_modelTrain_DeleteRoomComplete);
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
                CallDialog.Show(this, ViewTypes.EditRoomView, c =>
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
                    CallDialog.Show(this, ViewTypes.EditRoomView, c =>
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
                    if (!_modelTrain.IsBusy)
                    {
                        MessageCustomize.Show("Bạn muốn xóa phòng này?", "Xóa", MessageBoxButton.OKCancel, MessageImage.Question, c =>
                        {
                            if (c == MessageBoxResult.OK)
                            {
                                IsLoading = true;
                                _modelTrain.DeleteRoomAsync(SelectedItem);
                            }
                        });
                    }
                }
                else
                    MessageCustomize.Show("Bạn chưa chọn phòng");
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
            if (_listData != null)
            {
                IsLoading = false;
                TotalRecord = "Tổng: " + _listData.Count.ToString();
                ListType = CommonMethods.GetListCustomizeBrach();

                if (SetFocus != null)
                    SetFocus(ListType, null);
            }
        }

        public void ReloadData()
        {
            IsLoading = true;
            _listData = null;

            _modelTrain.GetListRoomAsync();
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

        private void _modelTrain_DeleteRoomComplete(object sender, SubmitOperationEventArgs e)
        {
            try
            {
                IsLoading = false;
                if (e.HasError)
                {
                    MessageCustomize.Show("Không xóa được phòng này");
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

        private void _modelTrain_GetListRoomComplete(object sender, EntityResultsArgs<Vlu_PhongHoc> e)
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
                    ListData = e.Results.ToList();
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
                _modelTrain.GetListRoomComplete -= new EventHandler<EntityResultsArgs<Vlu_PhongHoc>>(_modelTrain_GetListRoomComplete);
                _modelTrain.DeleteRoomComplete -= new EventHandler<SubmitOperationEventArgs>(_modelTrain_DeleteRoomComplete);
                _modelTrain = null;
            }
            _listType = null;
            _listData = null;
            _selectedItem = null;
            if (DialogSended != null)
                DialogSended = null;
            base.Cleanup();
        }
        #endregion
    }
}
