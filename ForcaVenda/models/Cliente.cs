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
        int IdCliente;
        string Nome;
        string Endereco;
        string Telefone;
        string Email;
        string Foto; // Localização da foto

    }
}
