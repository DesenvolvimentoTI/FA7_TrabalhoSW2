﻿#pragma checksum "D:\FA7\SW-II Windows Phone\TrabalhoSW2\ForcaVenda\views\CadastroCliente.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "379B36B5AA072AE0AE312D3457843118"
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
    
    
    public partial class CadastroCliente : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.TextBox txtNome;
        
        internal System.Windows.Controls.TextBox txtEndereco;
        
        internal System.Windows.Controls.TextBox txtEmail;
        
        internal System.Windows.Controls.TextBox txtFone;
        
        internal System.Windows.Controls.Image imgFoto;
        
        internal System.Windows.Controls.ListBox listaClientes;
        
        internal System.Windows.Controls.Button btFoto;
        
        internal System.Windows.Controls.Button btAdicionaCliente;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/ForcaVenda;component/views/CadastroCliente.xaml", System.UriKind.Relative));
            this.txtNome = ((System.Windows.Controls.TextBox)(this.FindName("txtNome")));
            this.txtEndereco = ((System.Windows.Controls.TextBox)(this.FindName("txtEndereco")));
            this.txtEmail = ((System.Windows.Controls.TextBox)(this.FindName("txtEmail")));
            this.txtFone = ((System.Windows.Controls.TextBox)(this.FindName("txtFone")));
            this.imgFoto = ((System.Windows.Controls.Image)(this.FindName("imgFoto")));
            this.listaClientes = ((System.Windows.Controls.ListBox)(this.FindName("listaClientes")));
            this.btFoto = ((System.Windows.Controls.Button)(this.FindName("btFoto")));
            this.btAdicionaCliente = ((System.Windows.Controls.Button)(this.FindName("btAdicionaCliente")));
        }
    }
}

