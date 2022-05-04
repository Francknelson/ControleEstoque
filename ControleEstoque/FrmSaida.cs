using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ControleEstoque
{
    public partial class FrmSaida : ControleEstoque.FormBase
    {
        public FrmSaida()
        {
            InitializeComponent();
            CarregarSaidas();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void FrmSaida_Load(object sender, EventArgs e)
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

        private void DesabilitarCampos()
        {
            textProduto.Enabled = false;
            textQuantidade.Enabled = false;
        }

        private void HabilitarCampos()
        {
            textProduto.Enabled = true;
            textQuantidade.Enabled = true;
        }
        private void LimparCampos()
        {
            textPesquisa.Text = String.Empty;
            textPreco.Text = String.Empty;
            textProduto.Text = String.Empty;
            textQuantidade.Text = String.Empty;
            textSaida.Text = String.Empty;
        }
        private void CarregarSaidas()
        {
            ModelProduto saidas = new ModelProduto();
            List<DtoSaidaProdutoLista> lista = saidas.GetSaidas();
            dataEntradas.DataSource = lista;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DtoSaidaProduto saida = new DtoSaidaProduto();
            saida.produto_id = int.Parse(textProduto.Text);
            saida.preco_custo = decimal.Parse(textPreco.Text);
            saida.preco_total = decimal.Parse(textSaida.Text);
            saida.quantidade = int.Parse(textQuantidade.Text);
            saida.data_compra = DateTime.Now;

            ModelProduto model = new ModelProduto();
            DtoProduto produto = model.GetProduto(int.Parse(textProduto.Text));

            if(saida.quantidade == produto.quantidade)
            {
                FormEstoqueZerado f = new FormEstoqueZerado();
                f.Show();
            }

            produto.quantidade -= saida.quantidade;
            model.EditarProduto(produto);
            model.SetSaidaProduto(saida);

            LimparCampos();
            DesabilitarCampos();
            CarregarSaidas();
        }

        private void textQuantidade_Leave(object sender, EventArgs e)
        {
            
            int quantidade = int.Parse(textQuantidade.Text);
            ModelProduto model = new ModelProduto();
            DtoProduto produto = model.GetProduto(int.Parse(textProduto.Text));


            if (quantidade > produto.quantidade)
            {
                FormQuantidadeProd f = new FormQuantidadeProd();
                f.Show();
            }
            else
            {
                decimal total = int.Parse(textQuantidade.Text) * int.Parse(textPreco.Text);
                textSaida.Text = total.ToString();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            DesabilitarCampos();
        }
    }
}
