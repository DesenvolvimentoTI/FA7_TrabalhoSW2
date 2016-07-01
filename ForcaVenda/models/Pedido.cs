using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForcaVenda.models
{
    [Table]
    public class Pedido
    {
        [Column(IsPrimaryKey =true, IsDbGenerated =true)]
        public int IdPedido { get; set; }

        [Column]
        public int IdCliente { get; set; }

        [Column]
        public DateTime DataPedido { get; set; }
    }
}
