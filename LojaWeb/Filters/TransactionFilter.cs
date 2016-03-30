using System.Web.Mvc;
using NHibernate;

namespace LojaWeb.Filters
{
    public class TransactionFilter : ActionFilterAttribute
    {
        private ISession session;
        public TransactionFilter(ISession session)
        {
            this.session = session;
        }
        public override void OnActionExecuting(ActionExecutingContext contexto)
        {
            session.BeginTransaction();
        }
        public override void OnActionExecuted(ActionExecutedContext contexto)
        {
            session.Transaction.Commit();
            session.Close();
        }
    }
}