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
    public partial class Consulta : PhoneApplicationPage
    {
        public Consulta()
        {
            InitializeComponent();
        }

        private void btEstoque_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/views/EstoqueEmBaixa.xaml", UriKind.Relative));
        }
    }
}