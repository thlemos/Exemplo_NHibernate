using log4net;
using LojaWeb.Entidades;
using LojaWeb.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaWeb.DAO;
using NHibernate;

namespace LojaWeb.Controllers
{
    public class ProdutosController : Controller
    {
        //
        // GET: /Produtos/
        private ProdutosDAO dao;

        public ProdutosController(ProdutosDAO dao)
        {
            this.dao = dao;
        }

        public ActionResult Index()
        {
            //ISession session = NHibernateHelper.AbreSession();
            //ProdutosDAO dao = new ProdutosDAO(session);
            IList<Produto> produtos = dao.Lista();
            return View(produtos);
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(Produto produto)
        {
            //ISession session = NHibernateHelper.AbreSession();
            //ProdutosDAO dao = new ProdutosDAO(session);
            dao.Adiciona(produto);
            return RedirectToAction("Visualiza", new { id = produto.Id });
            //return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            //ISession session = NHibernateHelper.AbreSession();
            //ProdutosDAO dao = new ProdutosDAO(session);
            Produto produto = dao.BuscaPorId(id);
            //session.Close();
            return View(produto);

            //Produto p = new Produto();
            //return View(p);
        }

        public ActionResult Atualiza(Produto produto)
        {
            //ISession session = NHibernateHelper.AbreSession();
            //ProdutosDAO dao = new ProdutosDAO(session);
            dao.Atualiza(produto);
            //session.Close();
            return RedirectToAction("Index");
        }

        public ActionResult ProdutosComPrecoMinimo(double? preco)
        {
            ViewBag.Preco = preco;
            IList<Produto> produtos = new List<Produto>();
            return View(produtos);
        }

        public ActionResult ProdutosDaCategoria(string nomeCategoria)
        {
            ViewBag.NomeCategoria = nomeCategoria;
            IList<Produto> produtos = new List<Produto>();
            return View(produtos);
        }

        public ActionResult ProdutosDaCategoriaComPrecoMinimo(double? preco, string nomeCategoria)
        {
            ViewBag.Preco = preco;
            ViewBag.NomeCategoria = nomeCategoria;
            IList<Produto> produtos = new List<Produto>();
            return View(produtos);
        }

        public ActionResult BuscaDinamica(double? preco, string nome, string nomeCategoria)
        {
            ViewBag.Preco = preco;
            ViewBag.Nome = nome;
            ViewBag.NomeCategoria = nomeCategoria;

            IList<Produto> produtos = new List<Produto>();
            return View(produtos);
        }
        public ActionResult ListaPaginada(int? pagina)
        {
            int paginaAtual = pagina.GetValueOrDefault(1);
            ViewBag.Pagina = paginaAtual;
            IList<Produto> produtos = new List<Produto>();
            return View(produtos);
        }
    }
}
