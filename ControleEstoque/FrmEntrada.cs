using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ControleEstoque
{
    public partial class FrmEntrada : ControleEstoque.FormBase
    {
        public FrmEntrada()
        {
            InitializeComponent();
            CarregarEntradas();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormConsulta f = new FormConsulta();
            f.ShowDialog();
            if (f.idProduto != 0)
            {
                textProduto.Text = f.idProduto.ToString();
                textProduto.Focus();
            }
        }

        private void textProduto_Leave(object sender, EventArgs e)
        {
            ModelProduto get = new ModelProduto();
            DtoProduto produto = get.GetProdutoID(int.Parse(textProduto.Text));
            textPesquisa.Text = produto.nome;
            textPreco.Text = produto.preco_custo.ToString();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
        }

        private void CarregarEntradas()
        {
            ModelProduto entrada = new ModelProduto();
            List<DtoEntradaProdutoLista> lista = entrada.GetEntradas();
            dataEntradas.DataSource = lista;
        }

        private void HabilitarCampos()
        {
            textProduto.Enabled = true;
            textPreco.Enabled = true;
            textQuantidade.Enabled = true;
        }

        private void DesabilitarCampos()
        {
            textProduto.Enabled = false;
            textPreco.Enabled = false;
            textQuantidade.Enabled = false;
        }

        private void LimparCampos()
        {
            textPesquisa.Text = String.Empty;
            textPreco.Text = String.Empty;
            textProduto.Text = String.Empty;
            textQuantidade.Text = String.Empty;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {   
            DtoEntradaProduto entrada = new DtoEntradaProduto();
            entrada.produto_id = int.Parse(textProduto.Text);
            entrada.preco_custo = decimal.Parse(textPreco.Text);
            entrada.quantidade = int.Parse(textQuantidade.Text);
            entrada.data_compra = DateTime.Now;

            ModelProduto model = new ModelProduto();
            DtoProduto produto = model.GetProduto(int.Parse(textProduto.Text));
            produto.quantidade += entrada.quantidade;
            produto.preco_custo = entrada.preco_custo;
            model.EditarProduto(produto);
            model.SetEntradaProduto(entrada);
            DesabilitarCampos();
            LimparCampos();
            CarregarEntradas();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DesabilitarCampos();
            LimparCampos();
        }
    }
}
