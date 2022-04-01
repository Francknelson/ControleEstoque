using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque
{
    internal class ModelProduto
    {
        internal void SetProduto(DtoProduto p)
        {
            Context db = new Context();
            db.produto.Add(p);
            db.SaveChanges();

        }

        internal DtoProduto GetProduto(int id)
        {
            Context db = new Context();
            DtoProduto produto = db.produto.FirstOrDefault(o => o.id == id);

            return produto;
        }

        public List<DtoProdutoLista> GetProdutos()
        {
            Context db = new Context();

            List<DtoProdutoLista> produtos = (from p in db.produto
                                              select new DtoProdutoLista
                                              {
                                                  id = p.id,
                                                  nome = p.nome,
                                                  unidade = p.unidade,
                                                  quantidade = p.quantidade
                                              }).ToList();
            return produtos;
        }

        internal void EditarProduto(DtoProduto p)
        {
            Context db = new Context();
            DtoProduto produto = db.produto.FirstOrDefault(o => o.id == p.id);
            produto.nome = p.nome;
            produto.unidade = p.unidade;
            produto.quantidade = p.quantidade;
            produto.preco_venda = p.preco_venda;
            produto.preco_custo = p.preco_custo;
            db.SaveChanges();
        }

        internal void DeletarProduto(int id)
        {
            Context db = new Context();
            DtoProduto produto = db.produto.FirstOrDefault(o => o.id == id);
            db.produto.Remove(produto);
            db.SaveChanges();
        }
    }
}
