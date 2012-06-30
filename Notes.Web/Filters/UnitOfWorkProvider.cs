using System.Configuration;
using System.Web;
using NHibernate;
using Notes.NH;
using Notes.NH.Repositories;

namespace Notes.Web.Filters
{
    public static class UnitOfWorkProvider
    {
        private static readonly ISessionFactory _sessionFactory;
        
        static UnitOfWorkProvider()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["NotesDB"].ConnectionString;
            var helper = new NHibernateHelper(connectionString);
            _sessionFactory = helper.SessionFactory;
        }

        public static IUnitOfWork GetCurrent()
        {
            if (!HttpContext.Current.Items.Contains("UOW"))
            {
                HttpContext.Current.Items["UOW"] = new NHUnitOfWork(_sessionFactory);
            }
            return (IUnitOfWork) HttpContext.Current.Items["UOW"];
        }
    }
}