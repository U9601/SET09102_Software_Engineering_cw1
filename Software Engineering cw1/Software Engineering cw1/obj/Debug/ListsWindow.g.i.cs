﻿#pragma checksum "..\..\ListsWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17A1029A5FDCB953A464A7BAC4B3FAC6B474F20F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Software_Engineering_cw1;
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


namespace Software_Engineering_cw1 {
    
    
    /// <summary>
    /// ListsWindow
    /// </summary>
    public partial class ListsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\ListsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sirListbutton;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\ListsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button trendingButton;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\ListsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button mentionsListButton;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ListsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
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
            System.Uri resourceLocater = new System.Uri("/Software Engineering cw1;component/listswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ListsWindow.xaml"
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
            this.sirListbutton = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\ListsWindow.xaml"
            this.sirListbutton.Click += new System.Windows.RoutedEventHandler(this.sirListbutton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.trendingButton = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\ListsWindow.xaml"
            this.trendingButton.Click += new System.Windows.RoutedEventHandler(this.trendingButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.mentionsListButton = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\ListsWindow.xaml"
            this.mentionsListButton.Click += new System.Windows.RoutedEventHandler(this.mentionsListButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

