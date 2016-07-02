﻿using System;
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
using Microsoft.Phone.Maps.Controls;
using System.Windows.Media.Imaging;
using System.Device.Location;

namespace ForcaVenda.views
{
    public partial class Pedido : PhoneApplicationPage
    {

        public Pedido()
        {
            InitializeComponent();
            CarregarClientes();
            CarregaMapa();
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
            

            using (var bd = new BancoDados())
            {

                models.Pedido pedido = new models.Pedido();
                pedido.DataPedido = Convert.ToDateTime(txtData.Text);
                pedido.IdCliente = ((Cliente)listaClientes.SelectedItem).IdCliente;

               
                    pedido.Latitude = localPedido.Center.Latitude;
                    pedido.Longitude = localPedido.Center.Longitude;
                

                bd.TbPedido.InsertOnSubmit(pedido);
                bd.SubmitChanges();

                novoPedido = bd.TbPedido.Max(p => p.IdPedido);

            }

            NavigationService.Navigate(new Uri(string.Format("/views/PedidoItem.xaml?pedido={0}", novoPedido), UriKind.Relative));
        }

        public async void CarregaMapa()
        {
            Geolocator geo = new Geolocator();





            if (geo.LocationStatus != PositionStatus.Disabled)
            {
                Geoposition pos = await geo.GetGeopositionAsync();
              

                MapOverlay MyOverlay = new MapOverlay();
                Image image = new Image();
                image.Height = 100;
                image.Width = 100;
                image.Source = new BitmapImage(new Uri("/Assets/pin.png", UriKind.Relative));
                MyOverlay.Content = image;
                MyOverlay.GeoCoordinate = new GeoCoordinate(pos.Coordinate.Latitude, pos.Coordinate.Longitude);

                MapLayer MyLayer = new MapLayer();
                MyLayer.Add(MyOverlay);

                localPedido.Center = MyOverlay.GeoCoordinate;
                localPedido.ZoomLevel = 15;
                localPedido.Layers.Clear();
                localPedido.Layers.Add(MyLayer);
            }





        }

    }
}