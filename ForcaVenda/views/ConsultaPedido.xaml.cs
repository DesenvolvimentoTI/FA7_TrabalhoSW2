using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ForcaVenda.Resources;
using ForcaVenda.models;

namespace ForcaVenda
{
    public partial class ConsultaPedido : PhoneApplicationPage
    {
        public ConsultaPedido()
        {
            InitializeComponent();
        }

        private void btConsulta_Click(object sender, RoutedEventArgs e)
        {
            using (var bd = new BancoDados())
            {
                if (txtPedido.Text.Equals(""))
                {
                    var dataI = DateTime.Parse(txtDataI.Text);
                    var dataF = DateTime.Parse(txtDataF.Text);

                    var pedidos = (from p in bd.TbPedido
                                   where p.DataPedido >= dataI && p.DataPedido <= dataF
                                   orderby p.IdPedido
                                   select p);
                        
/*
                    var pedidos2 = (from p in bd.TbPedido
                                   join i in bd.TbPedidoItem on p.IdPedido equals i.idPedido
                                   where p.DataPedido >= dataI && p.DataPedido <= dataF
                                   orderby p.IdPedido
                                   select new
                                   {
                                       pPedido = i.idPedido,
                                       pTotal = i.QtdPedido * i.PrecoUnitario
                                   })
                       .GroupBy(g => g.pPedido).Select(g => new { Pedido = g.Key, Total = g.Sum(a => a.pTotal) })
                       .ToList();
*/
                    listaPedidos.ItemsSource = pedidos;

                }
                else
                {
                    NavigationService.Navigate(new Uri(string.Format( "/views/ConsultaPedidoItem.xaml?pedido={0}", int.Parse(txtPedido.Text)), UriKind.Relative));
                }


            }

        }

        private void btEdit_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var pedido = (Pedido)listaPedidos.SelectedItem;
            NavigationService.Navigate(new Uri(string.Format("/views/ConsultaPedidoItem.xaml?pedido={0}", pedido.IdPedido), UriKind.Relative));

        }
    }
}