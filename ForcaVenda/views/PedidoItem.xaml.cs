using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ForcaVenda.models;
using ForcaVenda.Resources;

namespace ForcaVenda.views
{
    public partial class PedidoItem : PhoneApplicationPage
    {
        private int idPedido;
        private double totalPedido;
        private Produto produto;

        public PedidoItem()
        {
            InitializeComponent();
            totalPedido = 0;

            txtTotal.Text = string.Format("TOTAL: R${0}", totalPedido);
            CarregarProdutos();
        }

        void CarregarProdutos()
        {
            using (var bd = new BancoDados())
            {
                var produtos = (from prod in bd.TbProduto
                                orderby prod.Descricao
                                select prod).ToList();

                List<Produto> lista = new List<Produto>();

                foreach (var produto in produtos)
                {
                    lista.Add(produto);
                }

                listaProdutos.ItemsSource = lista;
            }
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            idPedido = Convert.ToInt32(NavigationContext.QueryString["pedido"]);
            txtPedido.Text = string.Format("PEDIDO Nº {0}", idPedido);
        }

        private void btAdicionaItem_Click(object sender, RoutedEventArgs e)
        {
            if(txtQtdEstoque.Text.Equals("") || txtPreco.Text.Equals(""))
            {
                MessageBox.Show("Informe todos os dados");
            }else
            {
                using (var bd = new BancoDados())
                {
                    models.PedidoItem novoItem = new models.PedidoItem();
                    novoItem.idPedido = idPedido;
                    novoItem.IdProduto = produto.IdProduto;
                    novoItem.QtdPedido = Convert.ToInt32(txtQtdEstoque.Text);
                    novoItem.PrecoUnitario = Convert.ToInt32(txtPreco.Text);
                    bd.TbPedidoItem.InsertOnSubmit(novoItem);
                    bd.SubmitChanges();

                    totalPedido += novoItem.QtdPedido * novoItem.PrecoUnitario;
                    txtTotal.Text = string.Format("TOTAL: R${0}", totalPedido);
                }
            }
        }

        private void listaProdutos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            produto = (Produto)listaProdutos.SelectedItem;
            txtQtdEstoque.Text = "";
            txtPreco.Text = produto.Preco.ToString();
        }
    }
}