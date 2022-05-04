using System;

namespace ControleEstoque
{   
    public class DtoEntradaProdutoLista
    {   
        public int id { get; internal set; }
        public int produto_id { get; internal set; }
        public decimal preco_custo { get; internal set; }
        public int quantidade { get; internal set; }
        public DateTime data_compra { get; internal set; }
    }
}
