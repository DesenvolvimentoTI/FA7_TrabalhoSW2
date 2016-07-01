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
    public partial class CadastroProduto : PhoneApplicationPage
    {
        private int idProduto;

        public CadastroProduto()
        {
            InitializeComponent();
            CarregarProdutos();
        }

        void CarregarProdutos()
        {
            using (var bd = new BancoDados())
            {

                var produtos = (from produto in bd.TbProduto
                                orderby produto.Descricao
                                select produto).ToList();

                listaProdutos.ItemsSource = produtos;

                btAdicionaProduto.Content = "ADICIONAR PRODUTO";
                idProduto = 0;
                txtDescricao.Text = "";
                txtQtdEstoque.Text = "";


            }
        }

        private void btAdicionaProduto_Click(object sender, RoutedEventArgs e)
        {
            if (txtDescricao.Text.Equals("") || txtQtdEstoque.Text.Equals(""))
            {
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                using (var bd = new BancoDados())
                {
                    Produto produto = new Produto();

                    if (idProduto > 0)
                    {
                        // Alteração dos dados
                        produto = bd.TbProduto.Single(u => u.IdProduto == idProduto);
                        produto.Descricao = txtDescricao.Text;
                        produto.QtdEstoque = Convert.ToInt32(txtQtdEstoque.Text);
                        bd.SubmitChanges();
                        MessageBox.Show("Produto Alterado!");
                    }
                    else
                    {
                        // Novo produto
                        produto.Descricao = txtDescricao.Text;
                        produto.QtdEstoque = Convert.ToInt32(txtQtdEstoque.Text);
                        bd.TbProduto.InsertOnSubmit(produto);
                        bd.SubmitChanges();
                        MessageBox.Show("Produto Adicionado!");
                    }

                    CarregarProdutos();
                }
            }
        }


        private void btExcluir_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var produto = listaProdutos.SelectedItem as Produto;

            if (MessageBox.Show("Confirma exclusão do produto?", "Excluir", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                using (var bd = new BancoDados())
                {
                    bd.TbProduto.Attach(produto);
                    bd.TbProduto.DeleteOnSubmit(produto);
                    bd.SubmitChanges();

                    MessageBox.Show("Produto Excluido!");

                    CarregarProdutos();
                }
            }
        }

        private void btEdit_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            btAdicionaProduto.Content = "SALVAR PRODUTO";
            Produto produtoSelecionado = new Produto();
            produtoSelecionado = (Produto)listaProdutos.SelectedItem;
            idProduto = produtoSelecionado.IdProduto;
            txtDescricao.Text = produtoSelecionado.Descricao;
            txtQtdEstoque.Text = produtoSelecionado.QtdEstoque.ToString();
        }
    }
}