﻿#pragma checksum "D:\FA7\SW-II Windows Phone\TrabalhoSW2\ForcaVenda\views\Pedido.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CFC127378F2A8221910D529473DBE092"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Controls;
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


namespace ForcaVenda.views {
    
    
    public partial class Pedido : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.TextBlock txtPedido;
        
        internal System.Windows.Controls.TextBox txtData;
        
        internal Microsoft.Phone.Controls.ListPicker listaClientes;
        
        internal Microsoft.Phone.Maps.Controls.Map localPedido;
        
        internal System.Windows.Controls.Button btFinalizaPedido;
        
        internal System.Windows.Controls.Button btPedido;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/ForcaVenda;component/views/Pedido.xaml", System.UriKind.Relative));
            this.txtPedido = ((System.Windows.Controls.TextBlock)(this.FindName("txtPedido")));
            this.txtData = ((System.Windows.Controls.TextBox)(this.FindName("txtData")));
            this.listaClientes = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("listaClientes")));
            this.localPedido = ((Microsoft.Phone.Maps.Controls.Map)(this.FindName("localPedido")));
            this.btFinalizaPedido = ((System.Windows.Controls.Button)(this.FindName("btFinalizaPedido")));
            this.btPedido = ((System.Windows.Controls.Button)(this.FindName("btPedido")));
        }
    }
}

