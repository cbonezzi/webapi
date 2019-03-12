using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WA.Data.Core.Interfaces;

namespace WA.Data.Core
{
    // crud operations definitions
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DbContext Context;

        protected BaseRepository(DbContext context)
        {
            Context = context;
        }

        #region Get

        public virtual async Task<T> GetById(Guid id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public virtual IQueryable<T> GetAllQueryable()
        {
            return Context.Set<T>();
        }

        #endregion

        #region Add/Update

        public virtual async Task Add(T entity, bool autoCommit = true)
        {
            Context.Set<T>().Add(entity);

            if (autoCommit)
            {
                await SaveChanges();
            }
        }

        public virtual async Task Update(T entity, bool autoCommit = true)
        {
            Context.Entry(entity).State = EntityState.Modified;

            if (autoCommit)
            {
                await SaveChanges();
            }
        }

        public virtual async Task AddOrUpdate(T entity, bool autoCommit = true)
        {
            Context.Set<T>().AddOrUpdate(entity);

            if (autoCommit)
            {
                await SaveChanges();
            }
        }


        #endregion

        #region Delete

        public virtual async Task Delete(T entity, bool autoCommit = true)
        {
            Context.Set<T>().Remove(entity);

            if (autoCommit)
            {
                await SaveChanges();
            }
        }

        public virtual async Task Delete(Expression<Func<T, bool>> filterExpression, bool autoCommit = true)
        {
            await Delete(Filter(filterExpression), autoCommit);
        }

        public virtual async Task Delete(IEnumerable<T> entities, bool autoCommit = true)
        {
            Context.Set<T>().RemoveRange(entities);

            if(autoCommit)
            {
                await SaveChanges();
            }
        }

        #endregion

        public virtual IList<T> Filter(Expression<Func<T, bool>> filterExpression)
        {
            return Context.Set<T>().Where(filterExpression).ToList();
        }


        public async Task SaveChanges()
        {
            await Context.SaveChangesAsync();
        }

    }
}
