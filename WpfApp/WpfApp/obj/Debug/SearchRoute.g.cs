﻿#pragma checksum "..\..\SearchRoute.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3CD3D431876084CD3BBA54DFBB02FE9284A04FF950EAA0723AEC8D75BFF534CE"
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


namespace WpfApp {
    
    
    /// <summary>
    /// SearchRoute
    /// </summary>
    public partial class SearchRoute : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\SearchRoute.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image MapImage;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\SearchRoute.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas PinCanvas;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\SearchRoute.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border InstructionBorder;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\SearchRoute.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock InstructionTextBlock;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\SearchRoute.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ResetButton;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\SearchRoute.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GenerateRouteButton;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\SearchRoute.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel RouteDisplayPanel;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\SearchRoute.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock CoordinatesTextBlock;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp;component/searchroute.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SearchRoute.xaml"
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
            
            #line 7 "..\..\SearchRoute.xaml"
            ((WpfApp.SearchRoute)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 8 "..\..\SearchRoute.xaml"
            ((WpfApp.SearchRoute)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.MapImage_MouseMove);
            
            #line default
            #line hidden
            
            #line 9 "..\..\SearchRoute.xaml"
            ((WpfApp.SearchRoute)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.MapImage_MouseEnter);
            
            #line default
            #line hidden
            
            #line 10 "..\..\SearchRoute.xaml"
            ((WpfApp.SearchRoute)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.MapImage_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MapImage = ((System.Windows.Controls.Image)(target));
            
            #line 22 "..\..\SearchRoute.xaml"
            this.MapImage.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MapImage_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PinCanvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 4:
            this.InstructionBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 5:
            this.InstructionTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.ResetButton = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\SearchRoute.xaml"
            this.ResetButton.Click += new System.Windows.RoutedEventHandler(this.ResetButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.GenerateRouteButton = ((System.Windows.Controls.Button)(target));
            
            #line 105 "..\..\SearchRoute.xaml"
            this.GenerateRouteButton.Click += new System.Windows.RoutedEventHandler(this.GenerateRouteButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.RouteDisplayPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 9:
            this.CoordinatesTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

