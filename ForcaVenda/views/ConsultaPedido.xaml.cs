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
                    if (!txtDataI.Text.Equals("") && !txtDataF.Text.Equals(""))
                    {
                        var dataI = DateTime.ParseExact(txtDataI.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        var dataF = DateTime.ParseExact(txtDataF.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

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
                        MessageBox.Show("Informe algum campo para pesquisa!");
                    }
                }
                else
                {
                    var existePedido = bd.TbPedido.SingleOrDefault(p => p.IdPedido == int.Parse(txtPedido.Text));
                    if (existePedido != null)
                    {
                        NavigationService.Navigate(new Uri(string.Format("/views/ConsultaPedidoItem.xaml?pedido={0}", txtPedido.Text), UriKind.Relative));
                    }
                    else
                    {
                        MessageBox.Show("Pedido não encontrado!");
                    }


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