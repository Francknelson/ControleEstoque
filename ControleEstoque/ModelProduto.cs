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

        internal DtoProduto GetProdutoID(int id)
        {
            Context db = new Context();
            DtoProduto produto = db.produto.FirstOrDefault(o => o.id == id);

            return produto;
        }

        internal void SetEntradaProduto(DtoEntradaProduto entrada)
        {
            Context db = new Context();
            db.entrada_produto.Add(entrada);
            db.SaveChanges();

        }

        internal void SetSaidaProduto(DtoSaidaProduto saida)
        {
            Context db = new Context();
            db.saida_produto.Add(saida);
            db.SaveChanges();

        }

        public  List<DtoSaidaProdutoLista> GetSaidas()
        {
            Context db = new Context();

            List<DtoSaidaProdutoLista> saidas = (from s in db.saida_produto
                                                     select new DtoSaidaProdutoLista
                                                     {
                                                         id = s.id,
                                                         produto_id = s.produto_id,
                                                         preco_custo = s.preco_custo,
                                                         preco_total = s.preco_total,
                                                         quantidade = s.quantidade,
                                                         data_compra = s.data_compra
                                                     }).ToList();
            return saidas;
        }

        public List<DtoEntradaProdutoLista> GetEntradas()
        {
            Context db = new Context();

            List<DtoEntradaProdutoLista> entradas = (from e in db.entrada_produto
                                              select new DtoEntradaProdutoLista
                                              {
                                                  id = e.id,
                                                  produto_id = e.produto_id,
                                                  preco_custo = e.preco_custo,
                                                  quantidade = e.quantidade,
                                                  data_compra = e.data_compra
                                              }).ToList();
            return entradas;
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
