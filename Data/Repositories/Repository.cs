using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public abstract class Repository<E> : IRepository<E> where E : Entity
    {
        protected readonly DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public void Add(E entity)
        {
            context.Set<E>().Add(entity);
            context.SaveChanges();
        }

        public void AddAll(IEnumerable<E> entities)
        {
            foreach (var entity in entities)
            {
                context.Set<E>().Add(entity);
            }
            context.SaveChanges();
        }

        public void Delete(long id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Database
                        .ExecuteSqlRaw(String.Format("delete from {0} where id = {1}", typeof(E).Name, id));
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                
            }
        }

        public void DeleteAll(IEnumerable<long> ids)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var id in ids)
                    {
                        context.Database
                            .ExecuteSqlRaw(String.Format("delete from {0} where id = {1}", typeof(E).Name, id));
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                
            }
        }

        public E Find(long id)
        {
            return context.Set<E>().Find(id);
        }

        public IEnumerable<E> FindAll()
        {
            return context.Set<E>().ToList();
        }

        public void Update(E entity)
        {
            context.Set<E>().Update(entity);
            context.SaveChanges();
        }

        public void UpdateAll(IEnumerable<E> entities)
        {
            foreach (var entity in entities)
            {
                context.Set<E>().Update(entity);
            }
            context.SaveChanges();
        }
    }
}
