﻿#pragma checksum "D:\FA7\SW-II Windows Phone\TrabalhoSW2\ForcaVenda\views\PedidoItem.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0FD3F921C7203C21B52DA2524745CEA1"
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
    
    
    public partial class PedidoItem : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.TextBlock txtPedido;
        
        internal System.Windows.Controls.TextBlock txtTotal;
        
        internal Microsoft.Phone.Controls.ListPicker listaProdutos;
        
        internal System.Windows.Controls.TextBox txtQtdEstoque;
        
        internal System.Windows.Controls.TextBox txtPreco;
        
        internal System.Windows.Controls.ListBox listaItens;
        
        internal System.Windows.Controls.Button btAdicionaItem;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/ForcaVenda;component/views/PedidoItem.xaml", System.UriKind.Relative));
            this.txtPedido = ((System.Windows.Controls.TextBlock)(this.FindName("txtPedido")));
            this.txtTotal = ((System.Windows.Controls.TextBlock)(this.FindName("txtTotal")));
            this.listaProdutos = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("listaProdutos")));
            this.txtQtdEstoque = ((System.Windows.Controls.TextBox)(this.FindName("txtQtdEstoque")));
            this.txtPreco = ((System.Windows.Controls.TextBox)(this.FindName("txtPreco")));
            this.listaItens = ((System.Windows.Controls.ListBox)(this.FindName("listaItens")));
            this.btAdicionaItem = ((System.Windows.Controls.Button)(this.FindName("btAdicionaItem")));
        }
    }
}

