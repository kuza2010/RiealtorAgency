﻿#pragma checksum "..\..\AddedClient.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B426604353DFA84A12DA7F6EAD757FAF5DC4404E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using RealtorAgency__Course_work_;
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


namespace RealtorAgency__Course_work_ {
    
    
    /// <summary>
    /// AddedClient
    /// </summary>
    public partial class AddedClient : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 59 "..\..\AddedClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\AddedClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Name;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\AddedClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LastName;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\AddedClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Patron;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\AddedClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Phone;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\AddedClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\AddedClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Ok;
        
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
            System.Uri resourceLocater = new System.Uri("/RealtorAgency (Course work);component/addedclient.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddedClient.xaml"
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
            this.MainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.Name = ((System.Windows.Controls.TextBox)(target));
            
            #line 78 "..\..\AddedClient.xaml"
            this.Name.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.DataPreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.LastName = ((System.Windows.Controls.TextBox)(target));
            
            #line 81 "..\..\AddedClient.xaml"
            this.LastName.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.DataPreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Patron = ((System.Windows.Controls.TextBox)(target));
            
            #line 84 "..\..\AddedClient.xaml"
            this.Patron.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.DataPreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Phone = ((System.Windows.Controls.TextBox)(target));
            
            #line 87 "..\..\AddedClient.xaml"
            this.Phone.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Phone_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Back = ((System.Windows.Controls.Button)(target));
            
            #line 95 "..\..\AddedClient.xaml"
            this.Back.Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Ok = ((System.Windows.Controls.Button)(target));
            
            #line 96 "..\..\AddedClient.xaml"
            this.Ok.Click += new System.Windows.RoutedEventHandler(this.Ok_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

