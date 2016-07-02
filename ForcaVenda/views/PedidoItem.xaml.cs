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
    public partial class PedidoItem : PhoneApplicationPage
    {
        private int idPedido;
        private double totalPedido;

        public PedidoItem()
        {
            InitializeComponent();
            totalPedido = 0;

            txtTotal.Text = string.Format("TOTAL: R${0}", totalPedido);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            idPedido = Convert.ToInt32(NavigationContext.QueryString["pedido"]);
            txtPedido.Text = string.Format("PEDIDO Nº {0}", idPedido);
        }

        private void btAdicionaItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}