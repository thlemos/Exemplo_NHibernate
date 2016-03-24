using Loja.Infra;

namespace Loja
{
    class Program
    {
        static void Main(string[] args)
        {
            NHibernateHelper.GeraSchema();
        }
    }
}
