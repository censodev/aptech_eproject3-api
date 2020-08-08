using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IRepository<E> where E : Entity
    {
        IEnumerable<E> FindAll();
        E Find(long id);
        void Add(E entity);
        void AddAll(IEnumerable<E> entities);
        void Update(E entity);
        void UpdateAll(IEnumerable<E> entities);
        void Delete(long id);
        void DeleteAll(IEnumerable<long> ids);
    }
}
