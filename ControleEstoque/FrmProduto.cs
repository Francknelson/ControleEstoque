using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ControleEstoque
{
    public partial class FrmProduto : ControleEstoque.FormBase
    {
        public FrmProduto()
        {
            InitializeComponent();
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            ModelProduto model = new ModelProduto();
            List<DtoProdutoLista> list = model.GetProdutos();
            gridProdutos.DataSource = list;
        }

        public void LimparCampos()
        {
            textID.Text = String.Empty;
            textNome.Text = String.Empty;
            textUnidade.Text = String.Empty;
            textQuantidade.Text = String.Empty;
            textPreco_venda.Text = String.Empty;
            textPreco_custo.Text = String.Empty;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            
            if (ValidarCampos())
            {

                ModelProduto model = new ModelProduto();
                DtoProduto p = new DtoProduto
                {
                    nome = textNome.Text,
                    unidade = textUnidade.Text,
                    quantidade = int.Parse(textQuantidade.Text),
                    preco_venda = decimal.Parse(textPreco_venda.Text),
                    preco_custo = decimal.Parse(textPreco_custo.Text)
                };


                if (textID.Text == String.Empty)
                {
                    model.SetProduto(p);
                }
                else
                {
                    p.id = int.Parse(textID.Text);
                    model.EditarProduto(p);
                }

                LimparCampos();
                DesabilitarText();
                CarregarGrid();
            }
            else
            {
                FormAlertCampos f = new FormAlertCampos();
                f.Show();
            }
            
        }

        private bool ValidarCampos()
        {
            if (textNome.Text == String.Empty && textUnidade.Text == String.Empty && textPreco_venda.Text == String.Empty && textPreco_custo.Text == String.Empty)
                return false;
            else
                return true;
        }

        private void DesabilitarText()
        {
            textNome.Enabled = false;
            textUnidade.Enabled = false;
            textQuantidade.Enabled = false;
            textPreco_venda.Enabled = false;
            textPreco_custo.Enabled = false;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            HabilitarText();
            textNome.Focus();
        }

        private void HabilitarText()
        {
            textNome.Enabled = true;
            textUnidade.Enabled = true;
            textQuantidade.Enabled = true;
            textPreco_venda.Enabled = true;
            textPreco_custo.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (textID.Text == String.Empty)
            {
                FormAlertProd f = new FormAlertProd();
                f.Show();
            }
            else
            {
                HabilitarText();
                textNome.Focus();
            }
            
        }

        private void gridProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)gridProdutos.CurrentRow.Cells[0].Value;
            ModelProduto model = new ModelProduto();

            DtoProduto produto = model.GetProduto(id);

            textID.Text = produto.id.ToString();
            textNome.Text = produto.nome;
            textUnidade.Text = produto.unidade;
            textQuantidade.Text = produto.quantidade.ToString();
            textPreco_venda.Text = produto.preco_venda.ToString();
            textPreco_custo.Text = produto.preco_custo.ToString();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ModelProduto model = new ModelProduto();
            if(textID.Text == String.Empty)
            {
                FormAlertProd f = new FormAlertProd();
                f.Show();
            }
            else
            {
                model.DeletarProduto(int.Parse(textID.Text));
                CarregarGrid();
                LimparCampos();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            DesabilitarText();
        }
    }
}
