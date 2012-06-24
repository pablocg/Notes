using System;
using NHibernate;

namespace Notes.NH.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ISession Session { get; }

        void Commit();
        void Rollback();
    }
}