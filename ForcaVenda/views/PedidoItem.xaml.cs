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
            CarregarItens();
        }

        void CarregarItens()
        {
            using (var bd = new BancoDados())
            {
                var lista = (from item in bd.TbPedidoItem
                             join ped in bd.TbPedido on item.idPedido equals ped.IdPedido
                             join prod in bd.TbProduto on item.IdProduto equals prod.IdProduto
                             where item.idPedido == idPedido
                             orderby item.IdPedidoItem
                             select new ConsultaItens
                             {
                                 Item = item.IdPedidoItem,
                                 Produto = prod.Descricao,
                                 Qtd = item.QtdPedido,
                                 Preco = item.PrecoUnitario,
                                 Total = item.QtdPedido * item.PrecoUnitario
                             }).ToList();

                listaItens.ItemsSource = lista;

            }

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
                    var qtdVenda = int.Parse(txtQtdEstoque.Text);
                    if (produto.QtdEstoque < qtdVenda)
                    {
                        MessageBox.Show("Estoque insuficiente!");
                        return;
                    }
                    
                    models.PedidoItem novoItem = new models.PedidoItem();
                    novoItem.idPedido = idPedido;
                    novoItem.IdProduto = produto.IdProduto;
                    novoItem.QtdPedido = qtdVenda;
                    novoItem.PrecoUnitario = Convert.ToInt32(txtPreco.Text);
                    bd.TbPedidoItem.InsertOnSubmit(novoItem);

                    bd.TbProduto.Attach(produto);
                    produto.QtdEstoque = produto.QtdEstoque - qtdVenda;

                    bd.SubmitChanges();

                    totalPedido += novoItem.QtdPedido * novoItem.PrecoUnitario;
                    txtTotal.Text = string.Format("TOTAL: R${0}", totalPedido);
                }

                CarregarItens();
            }
        }

        private void listaProdutos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            produto = (Produto)listaProdutos.SelectedItem;
            txtQtdEstoque.Text = "";
            txtPreco.Text = produto.Preco.ToString();
        }

        private void btExcluir_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var pedidoItem = (ConsultaItens)listaItens.SelectedItem;

            if (MessageBox.Show("Confirma exclusão do Item?", "Excluir", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                using (var bd = new BancoDados())
                {
                    var ped = bd.TbPedidoItem.Single(p => p.IdPedidoItem == pedidoItem.Item);
                    var produto = bd.TbProduto.Single(p => p.IdProduto == ped.IdProduto);

                    produto.QtdEstoque = produto.QtdEstoque + ped.QtdPedido;

                    bd.TbPedidoItem.DeleteOnSubmit(ped);
                    bd.SubmitChanges();

                    MessageBox.Show("Item Excluido!");

                    CarregarItens();
                }
            }

        }
    }
}