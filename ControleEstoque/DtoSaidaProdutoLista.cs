using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque
{   
    public class DtoSaidaProdutoLista
    {   
        public int id { get; internal set; }
        public int produto_id { get; internal set; }
        public decimal preco_custo { get; internal set; }
        public decimal preco_total { get; internal set; }
        public int quantidade { get; internal set; }
        public DateTime data_compra { get; internal set; }
    }
}
