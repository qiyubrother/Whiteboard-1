﻿#pragma checksum "..\..\..\ToolBar.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C0E2CE878848882BE00D9E20222BF0E7EC1A9FDABDB1E2B7C84B5D4539A9119E"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

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
using WhiteBoardTest;


namespace WhiteBoardTest {
    
    
    /// <summary>
    /// ToolBar
    /// </summary>
    public partial class ToolBar : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\ToolBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveDrwsing;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\ToolBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ClearOnec;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\ToolBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelOnec;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\ToolBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelImg;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\ToolBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RotateWindow;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\ToolBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CounterBtn;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\ToolBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SelectedBtn;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\ToolBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MaxWindow;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\ToolBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseButton;
        
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
            System.Uri resourceLocater = new System.Uri("/WhiteBoardTest;component/toolbar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ToolBar.xaml"
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
            
            #line 8 "..\..\..\ToolBar.xaml"
            ((WhiteBoardTest.ToolBar)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.BoardWindow_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SaveDrwsing = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\ToolBar.xaml"
            this.SaveDrwsing.Click += new System.Windows.RoutedEventHandler(this.SaveDrwsing_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ClearOnec = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.CancelOnec = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\ToolBar.xaml"
            this.CancelOnec.Click += new System.Windows.RoutedEventHandler(this.CancelOnec_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CancelImg = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.RotateWindow = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.CounterBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.SelectedBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.MaxWindow = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.CloseButton = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

