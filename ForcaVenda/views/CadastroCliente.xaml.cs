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
    public partial class CadastroCliente : PhoneApplicationPage
    {
        private int idCliente;
        private Cliente cliente;
        
        public CadastroCliente()
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

                listaClientes.ItemsSource = clientes;

                btAdicionaCliente.Content = "ADICIONAR CLIENTE";
                cliente = new Cliente();
                idCliente = 0;
                txtNome.Text = "";
                txtEndereco.Text = "";
                txtEmail.Text = "";
                txtFone.Text = "";
                imgFoto.Source = null;
                
            }
        }

        private void btAdicionaCliente_Click(object sender, RoutedEventArgs e)
        {
 
            using (var bd = new BancoDados())
            {
                Cliente cliente = new Cliente();

                if (idCliente > 0)
                {
                    // Alteração dos dados
                    Cliente clienteUpdate = bd.TbCliente.Single(u => u.IdCliente == idCliente);
                    clienteUpdate.Nome = txtNome.Text;
                    clienteUpdate.Endereco = txtEndereco.Text;
                    clienteUpdate.Email = txtEmail.Text;
                    clienteUpdate.Telefone = txtFone.Text;
                    //clienteUpdate.Foto = imgFoto.Source.ToString();

                    bd.SubmitChanges();
                    MessageBox.Show("Cliente Alterado!");
                }
                else
                {
                    // Novo produto
                    cliente.Nome = txtNome.Text;
                    cliente.Endereco = txtEndereco.Text;
                    cliente.Email = txtEmail.Text;
                    cliente.Telefone = txtFone.Text;
                    //cliente.Foto = imgFoto.Source.ToString();
                    bd.TbCliente.InsertOnSubmit(cliente);
                    bd.SubmitChanges();
                    MessageBox.Show("Cliente Adicionado!");
                }

                CarregarClientes();
            }
            
        }

        private void btExcluir_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var cliente = listaClientes.SelectedItem as Cliente;

            if (MessageBox.Show("Confirma exclusão do cliente?", "Excluir", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                using (var bd = new BancoDados())
                {
                    bd.TbCliente.Attach(cliente);
                    bd.TbCliente.DeleteOnSubmit(cliente);
                    bd.SubmitChanges();

                    MessageBox.Show("Cliente Excluido!");

                    CarregarClientes();
                }
            }
        }

        private void btEdit_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            btAdicionaCliente.Content = "SALVAR CLIENTE";

            var clienteSelecionado = (Cliente)listaClientes.SelectedItem;

            idCliente = clienteSelecionado.IdCliente;
            txtNome.Text = clienteSelecionado.Nome;
            txtEndereco.Text = clienteSelecionado.Endereco;
            txtEmail.Text = clienteSelecionado.Email;
            txtFone.Text = clienteSelecionado.Telefone;
            //imgFoto.Source = clienteSelecionado.Foto.ToString();
        }
    }
}