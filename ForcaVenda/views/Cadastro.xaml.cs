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
    public partial class Cadastro : PhoneApplicationPage
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void btProdutos_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/views/CadastroProduto.xaml", UriKind.Relative));
        }

        private void btClientes_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/views/CadastroCliente.xaml", UriKind.Relative));
        }
    }
}