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

namespace WebManagement.ViewModel
{
    [Export(ViewModelTypes.UserSettingViewModel, typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UserSettingViewModel : ViewModelBase, IViewModel
    {
        #region Private Members

        private ISettingModel _modelSetting;
        private List<Vlu_UserSettings> _listSetting;

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

        private Dictionary<string, string> _listThemes;
        public Dictionary<string, string> ListThemes
        {
            get { return _listThemes; }
            set
            {
                if (value != _listThemes)
                {
                    _listThemes = value;
                    RaisePropertyChanged("ListThemes");
                }
            }
        }

        private string _selectedTheme;
        public string SelectedTheme
        {
            get { return _selectedTheme; }
            set
            {
                if (value != _selectedTheme)
                {
                    _selectedTheme = value;
                    RaisePropertyChanged("SelectedTheme");
                }
            }
        }

        private List<int> _listPaging;
        public List<int> ListPaging
        {
            get { return _listPaging; }
            set
            {
                if (value != _listPaging)
                {
                    _listPaging = value;
                    RaisePropertyChanged("ListPaging");
                }
            }
        }

        private int _selectedPaging;
        public int SelectedPaging
        {
            get { return _selectedPaging; }
            set
            {
                if (value != _selectedPaging)
                {
                    _selectedPaging = value;
                    RaisePropertyChanged("SelectedPaging");
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
        public UserSettingViewModel(ISettingModel modelSetting)
        {
            _modelSetting = modelSetting;
            _modelSetting.GetListSettingComplete += new EventHandler<EntityResultsArgs<Vlu_UserSettings>>(_modelSetting_GetListSettingComplete);
            _modelSetting.SaveListSettingComplete += new EventHandler<SubmitOperationEventArgs>(_modelSetting_SaveListSettingComplete);
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
                if (!_modelSetting.IsBusy)
                {
                    IsLoading = true;

                    Vlu_UserSettings obj = _listSetting.FirstOrDefault(c => c.KeySetting == KeySetting.Theme);
                    obj.ValueSetting = SelectedTheme;
                    obj = _listSetting.FirstOrDefault(c => c.KeySetting == KeySetting.PagingSize);
                    obj.ValueSetting = SelectedPaging.ToString();
                    _modelSetting.SaveListSettingAsync(_listSetting);
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
            if (_listSetting != null)
            {
                IsLoading = false;

                ListThemes = CommonMethods.GetListThemes();
                List<int> lstPage = new List<int>();
                for (int i = 2; i < 11; i++)
                    lstPage.Add(i * 5);
                ListPaging = lstPage;

                Vlu_UserSettings obj = _listSetting.FirstOrDefault(c => c.KeySetting == KeySetting.Theme);
                if (obj == null)
                {
                    obj = new Vlu_UserSettings();
                    obj.ID = -1;
                    obj.KeySetting = KeySetting.Theme;
                    obj.ValueSetting = string.Empty;
                    obj.ModifiedDate = DateTime.Now;
                    SelectedTheme = ListThemes.FirstOrDefault().Key;
                    _listSetting.Add(obj);
                }
                else
                {
                    SelectedTheme = obj.ValueSetting;
                }

                obj = _listSetting.FirstOrDefault(c => c.KeySetting == KeySetting.PagingSize);
                if (obj == null)
                {
                    obj = new Vlu_UserSettings();
                    obj.ID = -1;
                    obj.KeySetting = KeySetting.PagingSize;
                    obj.ValueSetting = string.Empty;
                    obj.ModifiedDate = DateTime.Now;
                    SelectedPaging = ListPaging.FirstOrDefault();
                    _listSetting.Add(obj);
                }
                else
                {
                    SelectedPaging = Convert.ToInt32(obj.ValueSetting);
                }
            }
        }

        public void ReloadData()
        {
            IsLoading = true;
            _listSetting = null;

            _modelSetting.GetListSettingAsync();
        }

        private void ErrorProcess()
        {
            IsLoading = false;
        }

        #region Permission

        public void LoadPermission()
        {
            ReloadData();
        }

        #endregion

        #region Handlers
        private void _modelSetting_SaveListSettingComplete(object sender, SubmitOperationEventArgs e)
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
                    SystemConfig.Theme = SelectedTheme;
                    SystemConfig.PagingSize = SelectedPaging;
                    MessageCustomize.Show("Cập nhật thành công", "Cập nhật thiết lập", MessageImage.Information);
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

        private void _modelSetting_GetListSettingComplete(object sender, EntityResultsArgs<Vlu_UserSettings> e)
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
                    _listSetting = e.Results.ToList();
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
            if (_modelSetting != null)
            {
                _modelSetting.GetListSettingComplete -= new EventHandler<EntityResultsArgs<Vlu_UserSettings>>(_modelSetting_GetListSettingComplete);
                _modelSetting.SaveListSettingComplete -= new EventHandler<SubmitOperationEventArgs>(_modelSetting_SaveListSettingComplete);
                _modelSetting = null;
            }
            _listSetting = null;

            if (DialogSended != null)
                DialogSended = null;
            base.Cleanup();
        }
        #endregion
    }
}
