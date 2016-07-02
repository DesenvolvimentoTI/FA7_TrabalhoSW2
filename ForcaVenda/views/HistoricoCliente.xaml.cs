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

namespace ForcaVenda.views
{
    public partial class HistoricoCliente : PhoneApplicationPage
    {
        private int idCliente;

        public HistoricoCliente()
        {
            InitializeComponent();
            CarregarClientes();
        }

        void CarregarClientes()
        {
            using (var bd = new BancoDados())
            {
                var clientes = (from cliente in bd.TbCliente
                                orderby cliente.Nome
                                select cliente).ToList();

                List<Cliente> listaNomes = new List<Cliente>();

                foreach (var cliente in clientes)
                {
                    listaNomes.Add(cliente);
                }

                listaClientes.ItemsSource = listaNomes;
            }
        }

        private void listaClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using(var bd = new BancoDados())
            {
                int idCliente = ((Cliente)listaClientes.SelectedItem).IdCliente;

                var pedidos = (from p in bd.TbPedido
                               join i in bd.TbPedidoItem on p.IdPedido equals i.idPedido
                               where p.IdCliente == idCliente
                               orderby p.IdPedido
                               select new
                               {
                                   pPedido = i.idPedido,
                                   pTotal = i.QtdPedido * i.PrecoUnitario 
                               }) 
                               .GroupBy(g=> g.pPedido).Select(g => new { Pedido = g.Key, Total = g.Sum(a => a.pTotal) })
                               .ToList();


                listaPedidosCliente.ItemsSource = pedidos;
            }

        }
    }

}