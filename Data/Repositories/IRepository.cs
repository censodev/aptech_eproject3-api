using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public interface IRepository<E> where E : Entity
    {
        DataContext Context { get; set; }
        IEnumerable<E> FindAll();
        E Find(long id);
        bool Add(E entity);
        bool AddAll(IEnumerable<E> entities);
        bool Update(E entity);
        bool UpdateAll(IEnumerable<E> entities);
        bool Delete(long id);
        bool DeleteAll(IEnumerable<long> ids);
    }
}
