﻿#pragma checksum "D:\_Working\VS2010\Winform\WebManagement\WebManagement.Client\Views\Training\Copy of EditDepartmentView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A3D1288CC4F08ADA7E31EE21842403E5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace WebManagement.Client {
    
    
    public partial class EditDepartmentView : Telerik.Windows.Controls.RadWindow {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBox txtMaKhoa;
        
        internal System.Windows.Controls.TextBox txtTenKhoa;
        
        internal Telerik.Windows.Controls.RadButton btnSave;
        
        internal Telerik.Windows.Controls.RadButton btnCancel;
        
        internal Telerik.Windows.Controls.RadBusyIndicator rbiLoading;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/WebManagement.Client;component/Views/Training/Copy%20of%20EditDepartmentView.xam" +
                        "l", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.txtMaKhoa = ((System.Windows.Controls.TextBox)(this.FindName("txtMaKhoa")));
            this.txtTenKhoa = ((System.Windows.Controls.TextBox)(this.FindName("txtTenKhoa")));
            this.btnSave = ((Telerik.Windows.Controls.RadButton)(this.FindName("btnSave")));
            this.btnCancel = ((Telerik.Windows.Controls.RadButton)(this.FindName("btnCancel")));
            this.rbiLoading = ((Telerik.Windows.Controls.RadBusyIndicator)(this.FindName("rbiLoading")));
        }
    }
}

