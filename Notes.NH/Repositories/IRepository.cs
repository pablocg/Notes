using System.Collections.Generic;
using System.Linq;
using Notes.Domain;

namespace Notes.NH.Repositories
{
    interface IRepository<T> where T : IntKeyedEntity
    {
        T Get(int id);
        IQueryable<T> GetAll();

        void Add(T item);
        void Update(T item);
        void Remove(T item);
    }
}
