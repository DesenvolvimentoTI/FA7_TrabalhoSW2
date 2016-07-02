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
using Windows.Devices.Geolocation;

namespace ForcaVenda.views
{
    public partial class Pedido : PhoneApplicationPage
    {

        public Pedido()
        {
            InitializeComponent();
            CarregarClientes();
        }

        void CarregarClientes()
        {
            txtData.Text = String.Format("{0:dd/MM/yyyy}",  DateTime.Today) ;
            
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

        private async void btPedido_Click(object sender, RoutedEventArgs e)
        {

            /* Verificar situação do pedido 
             * se novo ou existente
            */

            int novoPedido;
            Geolocator geo = new Geolocator();

            using (var bd = new BancoDados())
            {

                models.Pedido pedido = new models.Pedido();
                pedido.DataPedido = Convert.ToDateTime(txtData.Text);
                pedido.IdCliente = ((Cliente)listaClientes.SelectedItem).IdCliente;

                if (geo.LocationStatus != PositionStatus.Disabled)
                {
                    Geoposition pos = await geo.GetGeopositionAsync();
                    pedido.Latitude = pos.Coordinate.Latitude;
                    pedido.Longitude = pos.Coordinate.Longitude;
                }

                bd.TbPedido.InsertOnSubmit(pedido);
                bd.SubmitChanges();

                novoPedido = bd.TbPedido.Max(p => p.IdPedido);

            }

            NavigationService.Navigate(new Uri(string.Format("/views/PedidoItem.xaml?pedido={0}", novoPedido), UriKind.Relative));
        }

    }
}