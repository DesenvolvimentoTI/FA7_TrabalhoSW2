using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ForcaVenda.views
{
    public partial class ConsultaPedidoItem : PhoneApplicationPage
    {
        private int idPedido;
        public ConsultaPedidoItem()
        {
            InitializeComponent();
            CarregarPedido();
        }

        void CarregarPedido()
        {

        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            idPedido = Convert.ToInt32(NavigationContext.QueryString["pedido"]);
            txtPedido.Text = string.Format("PEDIDO Nº {0}", idPedido);

        }

    }
}