using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public abstract class Repository<E> : IRepository<E> where E : class
    {
        protected readonly DbContext context;
        private readonly ILogger logger;

        public Repository(DbContext context, ILogger logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public bool Add(E entity)
        {
            context.Set<E>().Add(entity);
            return Commit();
        }

        public bool AddAll(IEnumerable<E> entities)
        {
            foreach (var entity in entities)
            {
                context.Set<E>().Add(entity);
            }

            return Commit();
        }

        public bool Delete(long id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Database
                        .ExecuteSqlRaw(String.Format("DELETE FROM {0} WHERE id = {1}", typeof(E).Name, id));
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                    transaction.Rollback();
                    return false;
                }
                
            }
        }

        public bool DeleteAll(IEnumerable<long> ids)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var id in ids)
                    {
                        context.Database
                            .ExecuteSqlRaw(String.Format("DELETE FROM {0} WHERE id = {1}", typeof(E).Name, id));
                    }
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                    transaction.Rollback();
                    return false;
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

        public bool Update(E entity)
        {
            context.Set<E>().Update(entity);
            return Commit();
        }

        public bool UpdateAll(IEnumerable<E> entities)
        {
            foreach (var entity in entities)
            {
                context.Set<E>().Update(entity);
            }

            return Commit();
        }

        private bool Commit()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
