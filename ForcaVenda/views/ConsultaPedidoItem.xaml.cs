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

namespace ForcaVenda.views
{
    public partial class ConsultaPedidoItem : PhoneApplicationPage
    {
        private int idPedido;
        public ConsultaPedidoItem()
        {
            InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            idPedido = Convert.ToInt32(NavigationContext.QueryString["pedido"]);
            txtPedido.Text = string.Format("PEDIDO Nº {0}", idPedido);

            using (var bd = new BancoDados())
            {

                var lista = (from item in bd.TbPedidoItem
                             join ped in bd.TbPedido on item.idPedido equals ped.IdPedido
                             join prod in bd.TbProduto on item.IdProduto equals prod.IdProduto
                             join cli in bd.TbCliente on ped.IdCliente equals cli.IdCliente
                             where item.idPedido == idPedido
                             orderby item.IdPedidoItem
                             select new
                             {
                                 Data = ped.DataPedido,
                                 Cliente = cli.Nome,
                                 Item = item.IdPedidoItem,
                                 Produto = prod.Descricao,
                                 Qtd = item.QtdPedido,
                                 Preco = item.PrecoUnitario
                             }).ToList();


                listaPedidoItens.ItemsSource = lista;
                var total = lista.Sum(t => t.Qtd * t.Preco);
                txtTotal.Text = string.Format("TOTAL: R${0}", total);
                txtData.Text = string.Format("Data do Pedido: {0}",  lista[0].Data.ToString());
                txtCliente.Text = string.Format("Cliente: {0}", lista[0].Cliente.ToString());

                
            }

        }

    }
}