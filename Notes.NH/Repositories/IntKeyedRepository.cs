using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Notes.Domain;

namespace Notes.NH.Repositories
{
    public class IntKeyedRepository<T> : IRepository<T> where T : IntKeyedEntity
    {
        private readonly ISession _session;

        protected IntKeyedRepository()
        {
            var unitOfWork = new NHUnitOfWork();
            _session = unitOfWork.Session;
        }

        public T Get(int id)
        {
            return _session.Get<T>(id);
        }

        public IQueryable<T> GetAll()
        {
            return _session.Query<T>();
        }

        public void Add(T item)
        {
            _session.Save(item);
        }

        public void Update(T item)
        {
            _session.Update(item);
        }

        public void Remove(T item)
        {
            _session.Delete(item);
        }
    }
}