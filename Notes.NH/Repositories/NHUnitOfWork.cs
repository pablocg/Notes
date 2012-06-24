using System;
using System.Configuration;
using System.Data;
using NHibernate;

namespace Notes.NH.Repositories
{
    public class NHUnitOfWork : IUnitOfWork
    {
        private readonly ISessionFactory _sessionFactory;
        private ITransaction _transaction;
        private ISession _session;

        public NHUnitOfWork()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["NotesDB"].ConnectionString;
            var helper = new NHibernateHelper(connectionString);
            _sessionFactory = helper.SessionFactory;
        }

        public ISession Session
        {
            get
            {
                if (_session == null)
                {
                    _session = _sessionFactory.OpenSession();
                    _session.FlushMode = FlushMode.Auto;

                    _transaction = _session.BeginTransaction(IsolationLevel.ReadCommitted);

                    return _session;
                }
                
                return _session;
            }
        }

        public void Commit()
        {
            if (!_transaction.IsActive)
            {
                throw new InvalidOperationException("No active transation");
            }
            _transaction.Commit();
        }

        public void Rollback()
        {
            if (_transaction.IsActive)
            {
                _transaction.Rollback();    
            }
        }

        public void Dispose()
        {
            if (_session != null && _session.IsOpen)
            {
                _session.Close();
            }
        }
    }
}