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
    public partial class EstoqueEmBaixa : PhoneApplicationPage
    {
        public EstoqueEmBaixa()
        {
            InitializeComponent();
            CarregarProdutos();
        }

        void CarregarProdutos()
        {
            using (var bd = new BancoDados())
            {

                var produtos = (from produto in bd.TbProduto
                                where produto.QtdEstoque<10
                                orderby produto.Descricao
                                select produto).ToList();

                listaProdutos.ItemsSource = produtos;

            }
        }
    }
}