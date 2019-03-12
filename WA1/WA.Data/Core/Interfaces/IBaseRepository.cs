using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WA.Data.Core.Interfaces
{
    // base repository interface for crud operations signatures.
    public interface IBaseRepository<T> where T : class
    {
        //CRUD operations
        Task<T> GetById(Guid id);        
        IQueryable<T> GetAllQueryable();


        Task Add(T entity, bool autoCommit = true);
        Task Update(T entity, bool autoCommit = true);
        Task AddOrUpdate(T entity, bool autoCommit = true);

        Task Delete(T entity, bool autoCommit = true);
        Task Delete(Expression<Func<T, bool>> filterExpression, bool autoCommit = true);
        Task Delete(IEnumerable<T> entities, bool autoCommit = true);

        IList<T> Filter(Expression<Func<T, bool>> filterExpression);

        Task SaveChanges();
    }
}
