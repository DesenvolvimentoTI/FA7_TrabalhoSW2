﻿#pragma checksum "D:\FA7\SW-II Windows Phone\TrabalhoSW2\ForcaVenda\views\CadastroProduto.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "54CA82D07D9104624A7552E5BC2DA50A"
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
    
    
    public partial class CadastroProduto : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.TextBox txtDescricao;
        
        internal System.Windows.Controls.TextBox txtQtdEstoque;
        
        internal System.Windows.Controls.TextBox txtPreco;
        
        internal System.Windows.Controls.ListBox listaProdutos;
        
        internal System.Windows.Controls.Button btAdicionaProduto;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/ForcaVenda;component/views/CadastroProduto.xaml", System.UriKind.Relative));
            this.txtDescricao = ((System.Windows.Controls.TextBox)(this.FindName("txtDescricao")));
            this.txtQtdEstoque = ((System.Windows.Controls.TextBox)(this.FindName("txtQtdEstoque")));
            this.txtPreco = ((System.Windows.Controls.TextBox)(this.FindName("txtPreco")));
            this.listaProdutos = ((System.Windows.Controls.ListBox)(this.FindName("listaProdutos")));
            this.btAdicionaProduto = ((System.Windows.Controls.Button)(this.FindName("btAdicionaProduto")));
        }
    }
}

