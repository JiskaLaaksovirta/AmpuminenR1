﻿#pragma checksum "..\..\..\Ampujataulukko.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9CD8C25F2577553AF0184B16E47E0FB4570EEAE5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ampumapäiväkirjakonsoli;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Ampumapäiväkirjakonsoli {
    
    
    /// <summary>
    /// Ampujataulukko
    /// </summary>
    public partial class Ampujataulukko : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\Ampujataulukko.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Päivämäärä;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Ampujataulukko.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtOhje;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Ampujataulukko.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAmpumaradanPituus;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Ampujataulukko.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAmpujienMäärä;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Ampujataulukko.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Kuvaus;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Ampujataulukko.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtKuvaus;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Ampujataulukko.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Laskuri;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Ampujataulukko.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Ampumapäiväkirjakonsoli;component/ampujataulukko.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Ampujataulukko.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 27 "..\..\..\Ampujataulukko.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AloitaKirjaaminen_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Päivämäärä = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            
            #line 33 "..\..\..\Ampujataulukko.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PoistuPäävalikkoon_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 37 "..\..\..\Ampujataulukko.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.TallennaTiedot_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 40 "..\..\..\Ampujataulukko.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeskeytaKirjaus_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtOhje = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtAmpumaradanPituus = ((System.Windows.Controls.TextBox)(target));
            
            #line 50 "..\..\..\Ampujataulukko.xaml"
            this.txtAmpumaradanPituus.GotFocus += new System.Windows.RoutedEventHandler(this.txtAmpumaradanPituus_GotFocus);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txtAmpujienMäärä = ((System.Windows.Controls.TextBox)(target));
            
            #line 55 "..\..\..\Ampujataulukko.xaml"
            this.txtAmpujienMäärä.GotFocus += new System.Windows.RoutedEventHandler(this.txtAmpujienMäärä_GotFocus);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Kuvaus = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.txtKuvaus = ((System.Windows.Controls.TextBox)(target));
            
            #line 60 "..\..\..\Ampujataulukko.xaml"
            this.txtKuvaus.GotFocus += new System.Windows.RoutedEventHandler(this.txtKuvaus_GotFocus);
            
            #line default
            #line hidden
            
            #line 60 "..\..\..\Ampujataulukko.xaml"
            this.txtKuvaus.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtKuvaus_TextChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Laskuri = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

