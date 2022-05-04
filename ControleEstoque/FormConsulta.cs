using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleEstoque
{
    public partial class FormConsulta : Form
    {   
        public int idProduto = 0;
        public FormConsulta()
        {
            InitializeComponent();
        }

        private void textPesquisa_TextChanged(object sender, EventArgs e)
        {
            ModelProduto m = new ModelProduto();
            List<DtoProdutoLista> list = m.GetProdutos();
            dataProdutos.DataSource = list;
        }

        private void dataProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                idProduto = (Int32)dataProdutos.CurrentRow.Cells[0].Value;
                Close();
            }
        }
    }
}
