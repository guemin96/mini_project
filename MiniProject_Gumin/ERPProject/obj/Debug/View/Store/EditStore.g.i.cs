﻿#pragma checksum "..\..\..\..\View\Store\EditStore.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "ACCBE8455BE257A0A9C79A3547940A684C848353BB8747EC4A3D7C37DAF02A35"
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
    /// EditStore
    /// </summary>
    public partial class EditStore : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 65 "..\..\..\..\View\Store\EditStore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TxtStoreID;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\View\Store\EditStore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtStoreName;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\View\Store\EditStore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock LblStoreName;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\View\Store\EditStore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtStoreLocation;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\View\Store\EditStore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock LblStoreLocation;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\View\Store\EditStore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAdd;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\..\View\Store\EditStore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBack;
        
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
            System.Uri resourceLocater = new System.Uri("/ERPProject;component/view/store/editstore.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Store\EditStore.xaml"
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
            
            #line 11 "..\..\..\..\View\Store\EditStore.xaml"
            ((ERPProject.View.Store.EditStore)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TxtStoreID = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.TxtStoreName = ((System.Windows.Controls.TextBox)(target));
            
            #line 68 "..\..\..\..\View\Store\EditStore.xaml"
            this.TxtStoreName.LostFocus += new System.Windows.RoutedEventHandler(this.TxtStoreName_LostFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LblStoreName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.TxtStoreLocation = ((System.Windows.Controls.TextBox)(target));
            
            #line 73 "..\..\..\..\View\Store\EditStore.xaml"
            this.TxtStoreLocation.LostFocus += new System.Windows.RoutedEventHandler(this.TxtStoreLocation_LostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.LblStoreLocation = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.BtnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\..\..\View\Store\EditStore.xaml"
            this.BtnAdd.Click += new System.Windows.RoutedEventHandler(this.BtnAdd_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BtnBack = ((System.Windows.Controls.Button)(target));
            
            #line 98 "..\..\..\..\View\Store\EditStore.xaml"
            this.BtnBack.Click += new System.Windows.RoutedEventHandler(this.BtnBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
