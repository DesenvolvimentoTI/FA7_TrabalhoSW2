using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForcaVenda.models
{
    [Table]
    public class Cliente
    {
        [Column(IsPrimaryKey =true, IsDbGenerated =true)]
        public int IdCliente { get; set; }

        [Column]
        public string Nome { get; set; }

        [Column]
        public string Endereco { get; set; }

        [Column]
        public string Telefone { get; set; }

        [Column]
        public string Email { get; set; }

        [Column]
        public string Foto { get; set; } // String com a localização do arquivo da foto

        public override string ToString()
        {
            return Nome;
        }

    }
}
