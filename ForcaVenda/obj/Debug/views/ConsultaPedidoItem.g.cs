﻿#pragma checksum "D:\FA7\SW-II Windows Phone\TrabalhoSW2\ForcaVenda\views\ConsultaPedidoItem.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2B3D97486121E66D935B2A20238698D7"
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
    
    
    public partial class ConsultaPedidoItem : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.TextBlock txtPedido;
        
        internal System.Windows.Controls.TextBlock txtData;
        
        internal System.Windows.Controls.TextBlock txtCliente;
        
        internal System.Windows.Controls.TextBlock txtTotal;
        
        internal System.Windows.Controls.ListBox listaPedidoItens;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/ForcaVenda;component/views/ConsultaPedidoItem.xaml", System.UriKind.Relative));
            this.txtPedido = ((System.Windows.Controls.TextBlock)(this.FindName("txtPedido")));
            this.txtData = ((System.Windows.Controls.TextBlock)(this.FindName("txtData")));
            this.txtCliente = ((System.Windows.Controls.TextBlock)(this.FindName("txtCliente")));
            this.txtTotal = ((System.Windows.Controls.TextBlock)(this.FindName("txtTotal")));
            this.listaPedidoItens = ((System.Windows.Controls.ListBox)(this.FindName("listaPedidoItens")));
        }
    }
}

