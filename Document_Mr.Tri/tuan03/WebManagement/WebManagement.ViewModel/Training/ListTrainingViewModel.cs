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
    [Export(ViewModelTypes.ListTrainingViewModel, typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ListTrainingViewModel : ViewModelBase, IViewModel
    {
        #region Private Members

        private ITrainingModel _modelTrain;
        public const string ViewKey = "WM_TRAINING";

        #endregion

        #region Contructors
        [ImportingConstructor]
        public ListTrainingViewModel(ITrainingModel modelTrain)
        {
        }
        #endregion

        public void LoadInitComplete()
        {

        }

        public void ReloadData()
        {

        }

        public void LoadPermission()
        {

        }

        public DialogMessage DialogSended
        {
            get;
            set;
        }

        public event EventHandler CloseWindow;

        public event EventHandler SetFocus;
    }
}
