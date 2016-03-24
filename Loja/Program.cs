using System;
using Loja.DAO;
using Loja.Entidades;
using Loja.Infra;
using NHibernate;

namespace Loja
{
    class Program
    {
        static void Main(string[] args)
        {
            //NHibernateHelper.GeraSchema();



            //Usuario usuario = new Usuario();
            //usuario.Nome = "TH";

            //ISession session = NHibernateHelper.AbreSession();
            //UsuarioDAO usuariosDAO = new UsuarioDAO(session);
            //usuariosDAO.Adiciona(usuario);

            //Console.Read();

            #region Alterando

            //ISession session = NHibernateHelper.AbreSession();
            //ITransaction Transacao = session.BeginTransaction();
            //// Nesse ponto o Usuario tem a propriedade nome com o valor Victor.
            //Usuario UsuarioDoBanco = session.Get<Usuario>(1);

            //UsuarioDoBanco.Nome = "Victor Harada";
            //Console.WriteLine("No commit, o NHibernate detecta que o Usuario foi modificado e " +
            //                  "executa um Update no banco de dados");
            //Transacao.Commit();
            //Console.Read();

            #endregion

            ISession session = NHibernateHelper.AbreSession();
            ITransaction transacao = session.BeginTransaction();
            Usuario usuario = session.Get<Usuario>(1);

            session.Delete(usuario);
            transacao.Commit();
        }
    }
}
