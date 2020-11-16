using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public abstract class Repository<E> : IRepository<E> where E : Entity
    {
        protected readonly DataContext context;
        protected readonly ILogger logger;

        public Repository(DataContext context, ILogger logger)
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
            var entity = Find(id);
            entity.Status = 0;
            context.Set<E>().Update(entity);
            return Commit();
        }

        public bool DeleteAll(IEnumerable<long> ids)
        {

            foreach (var id in ids)
            {
                var entity = Find(id);
                entity.Status = 0;
                context.Set<E>().Update(entity);
            }
            return Commit();
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
