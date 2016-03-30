using LojaWeb.Entidades;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.DAO
{
    public class ProdutosDAO
    {
        private ISession session;

        public ProdutosDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(Produto produto)
        {
            ITransaction transacao = this.session.BeginTransaction();
            this.session.Save(produto);
            transacao.Commit();
        }

        public void Remove(Produto produto)
        {

        }

        public void Atualiza(Produto produto)
        {
            ITransaction transacao = session.BeginTransaction();
            this.session.Merge(produto);
            transacao.Commit();
        }

        public Produto BuscaPorId(int id)
        {
            return this.session.Get<Produto>(id);
        }

        public IList<Produto> Lista()
        {
            return session.QueryOver<Produto>().List();
        }

        public IList<Produto> ProdutosComPrecoMaiorDoQue(double? preco)
        {
            return session.QueryOver<Produto>().Where( x=>x.Preco > preco) .List();
        }

        public IList<Produto> ProdutosDaCategoria(string nomeCategoria)
        {
            return new List<Produto>();
        }

        public IList<Produto> ProdutosDaCategoriaComPrecoMaiorDoQue(double? preco, string nomeCategoria)
        {
            return new List<Produto>();
        }

        public IList<Produto> ListaPaginada(int paginaAtual)
        {
            return new List<Produto>();
        }

        public IList<Produto> BuscaPorPrecoCategoriaENome(double? preco, string nomeCategoria, string nome)
        {
            return new List<Produto>();
        }
    }
}