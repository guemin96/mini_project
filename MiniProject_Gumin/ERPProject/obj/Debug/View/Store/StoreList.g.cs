﻿#pragma checksum "..\..\..\..\View\Store\StoreList.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "42C983CCA06886713DB2F08EA27F45BFF799BA4C6205C9A1A1EB032E4A2F6D09"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using ERPProject.View.Store;
using MahApps.Metro.IconPacks;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ERPProject.View.Store {
    
    
    /// <summary>
    /// StoreList
    /// </summary>
    public partial class StoreList : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 47 "..\..\..\..\View\Store\StoreList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAddStore;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\View\Store\StoreList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnEditStore;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\View\Store\StoreList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnExportExcel;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\View\Store\StoreList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid GrdData;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ERPProject;component/view/store/storelist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Store\StoreList.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\..\View\Store\StoreList.xaml"
            ((ERPProject.View.Store.StoreList)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BtnAddStore = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\..\View\Store\StoreList.xaml"
            this.BtnAddStore.Click += new System.Windows.RoutedEventHandler(this.BtnAddStore_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnEditStore = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\..\View\Store\StoreList.xaml"
            this.BtnEditStore.Click += new System.Windows.RoutedEventHandler(this.BtnEditStore_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnExportExcel = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\..\View\Store\StoreList.xaml"
            this.BtnExportExcel.Click += new System.Windows.RoutedEventHandler(this.BtnExportExcel_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.GrdData = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

