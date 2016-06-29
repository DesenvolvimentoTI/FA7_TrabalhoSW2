﻿using ForcaVenda.models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForcaVenda.Resources
{
    public class BancoDados : DataContext
    {
        public BancoDados(string BdConexao) : base(BdConexao) { }

        public static string BdConexao
        {
            get
            {
                return "isostore:/forcavenda.sdf";
            }
        }

        public Table<Cliente> TbCliente;
        public Table<Produto> TbProduto;
        public Table<Pedido> TbPedido;
        public Table<PedidoItem> TbPedidoItem;

        public void CriarBancoDados()
        {
       }

    }

}