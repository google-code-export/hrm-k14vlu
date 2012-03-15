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
    [Export(ViewModelTypes.MainPageViewModel, typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MainPageViewModel : ViewModelBase, IViewModel
    {
        #region Private Members
        private IAuthenticationModel _modelAuth;
        private ITrainingModel _modelTrain;
        private ISettingModel _modelSetting;
        #endregion

        #region Properties

        #region IViewModel
        public DialogMessage DialogSended { get; set; }
        public event EventHandler CloseWindow;
        public event EventHandler SetFocus;
        #endregion

        #endregion

        #region Contructors
        [ImportingConstructor]
        public MainPageViewModel(IAuthenticationModel modelAuth, ITrainingModel modelTrain, ISettingModel modelSetting)
        {
            _modelAuth = modelAuth;
            _modelTrain = modelTrain;
            _modelSetting = modelSetting;
        }
        #endregion

        #region Private Methods
        public void LoadInitComplete()
        {

        }

        public void ReloadData()
        {

        }

        public void LoadPermission()
        {

        }
        #endregion
    }
}
