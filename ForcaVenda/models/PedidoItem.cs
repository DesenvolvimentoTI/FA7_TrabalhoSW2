using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForcaVenda.models
{
    [Table]
    public class PedidoItem
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int IdPedidoItem { get; set; }
        public int IdProduto { get; set; }
        public int QtdPedido { get; set; }
        public double PrecoUnitario { get; set; }
    }
}
