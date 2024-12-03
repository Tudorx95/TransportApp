﻿#pragma checksum "..\..\Search.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B3E9D9989074692FF6E4791FC6B11F30080E0274777808F1B29346BFA17524D6"
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
using WpfApp;


namespace WpfApp {
    
    
    /// <summary>
    /// Search
    /// </summary>
    public partial class Search : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\Search.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image LeftImage;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Search.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup ImagePopup;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\Search.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock FloatingLabel;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\Search.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchTextBox;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\Search.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox SuggestionsListBox;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\Search.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel RouteDisplay;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\Search.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid StationsDataGrid;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\Search.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement Media;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp;component/search.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Search.xaml"
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
            this.LeftImage = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.ImagePopup = ((System.Windows.Controls.Primitives.Popup)(target));
            
            #line 27 "..\..\Search.xaml"
            this.ImagePopup.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.ImagePopup_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.FloatingLabel = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.SearchTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 61 "..\..\Search.xaml"
            this.SearchTextBox.GotFocus += new System.Windows.RoutedEventHandler(this.SearchTextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 61 "..\..\Search.xaml"
            this.SearchTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.SearchTextBox_LostFocus);
            
            #line default
            #line hidden
            
            #line 62 "..\..\Search.xaml"
            this.SearchTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 67 "..\..\Search.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SearchButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SuggestionsListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 74 "..\..\Search.xaml"
            this.SuggestionsListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SuggestionsListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 86 "..\..\Search.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.FindPathButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.RouteDisplay = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 9:
            this.StationsDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 10:
            this.Media = ((System.Windows.Controls.MediaElement)(target));
            
            #line 140 "..\..\Search.xaml"
            this.Media.MediaEnded += new System.Windows.RoutedEventHandler(this.Media_MediaEnded);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

