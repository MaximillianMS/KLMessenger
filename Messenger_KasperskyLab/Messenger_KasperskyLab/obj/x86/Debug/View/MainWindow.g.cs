﻿#pragma checksum "..\..\..\..\View\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FE4CE2AB6799C99DF72C5AEEF269FCBB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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


namespace Messenger_KasperskyLab {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxInput;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonSend;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxOutput;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonClose;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxUsers;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxInfo;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonRefresh;
        
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
            System.Uri resourceLocater = new System.Uri("/Messenger_KasperskyLab;component/view/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\MainWindow.xaml"
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
            
            #line 8 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_Drag);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textBoxInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.buttonSend = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\View\MainWindow.xaml"
            this.buttonSend.Click += new System.Windows.RoutedEventHandler(this.buttonSend_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.textBoxOutput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.buttonClose = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\..\View\MainWindow.xaml"
            this.buttonClose.Click += new System.Windows.RoutedEventHandler(this.CloseButton);
            
            #line default
            #line hidden
            return;
            case 6:
            this.comboBoxUsers = ((System.Windows.Controls.ComboBox)(target));
            
            #line 24 "..\..\..\..\View\MainWindow.xaml"
            this.comboBoxUsers.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboBoxUsers_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.textBoxInfo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.buttonRefresh = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\View\MainWindow.xaml"
            this.buttonRefresh.Click += new System.Windows.RoutedEventHandler(this.buttonRefresh_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

