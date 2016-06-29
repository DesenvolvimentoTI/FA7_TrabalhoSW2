using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForcaVenda.models
{
    [Table]
    public class Produto
    {
        [Column(IsPrimaryKey =true, IsDbGenerated =true)]
        int IdProduto;
        string Descricao;
        int QtdEstoque;
    }
}
