using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque
{

    public class Context:DbContext
    {
        public Context(): base("postgres")
        {

        }
        public DbSet<DtoUsuario> usuario { get; set; }

        public DbSet<DtoProduto> produto { get; set; }
        public DbSet<DtoEntradaProduto> entrada_produto { get; set; }
        public DbSet<DtoSaidaProduto> saida_produto { get; set; }
    }
}
