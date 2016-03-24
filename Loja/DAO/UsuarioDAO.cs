using Loja.Entidades;
using Loja.Infra;
using NHibernate;

namespace Loja.DAO
{
    public class UsuarioDAO
    {
        private ISession session;
        public UsuarioDAO()
        {
            this.session = NHibernateHelper.AbreSession();
        }


        public UsuarioDAO(ISession session)
        {
            this.session = session;
        }


        public void Adiciona(Usuario usuario)
        {
           

            ITransaction transacao = session.BeginTransaction();
            session.Save(usuario);
            transacao.Commit();
        } 
    }
}