using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForcaVenda.models
{
    public class ConsultaItens
    {
        public int Item { get; set; }
        public string Produto { get; set; }
        public int Qtd { get; set; }
        public double Preco { get; set; }
        public double Total { get; set; }
    }

}
