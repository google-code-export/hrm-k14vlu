using System;
using GalaSoft.MvvmLight.Messaging;

namespace WebManagement.ViewModel
{
    public interface IViewModel
    {
        void LoadInitComplete();
        void ReloadData();
        void LoadPermission();
        DialogMessage DialogSended { get; set; }
        event EventHandler CloseWindow;
        event EventHandler SetFocus;
    }
}
