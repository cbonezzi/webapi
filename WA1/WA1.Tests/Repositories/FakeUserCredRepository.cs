using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WA.Data;
using WA.Data.Interfaces;

namespace WA1.Tests.Repositories
{
    //Fake repository class to test CRUD operations
    internal class FakeUserCredRepository : IUserCredRepository
    {
        public async Task Add(UserCred entity, bool autoCommit = true)
        {
            await Task.Delay(0);
        }

        public async Task AddOrUpdate(UserCred entity, bool autoCommit = true)
        {
            await Task.Delay(0);
        }

        public async Task Delete(UserCred entity, bool autoCommit = true)
        {
            await Task.Delay(0);
        }

        public async Task Delete(Expression<Func<UserCred, bool>> filterExpression, bool autoCommit = true)
        {
            await Task.Delay(0);
        }

        public async Task Delete(IEnumerable<UserCred> entities, bool autoCommit = true)
        {
            await Task.Delay(0);
        }

        public IList<UserCred> Filter(Expression<Func<UserCred, bool>> filterExpression)
        {
            return new List<UserCred>();
        }

        public IQueryable<UserCred> GetAllQueryable()
        {
            return (new List<UserCred>
            {
                new UserCred {Username = "Cesar"},
                new UserCred {Username = "Leo"},
                new UserCred {Username = "Rosa"}
            }).AsQueryable();
        }

        public async Task<UserCred> GetById(Guid id)
        {
            return await Task.FromResult(new UserCred());
        }

        public async Task SaveChanges()
        {
            await Task.Delay(0);
        }

        public async Task Update(UserCred entity, bool autoCommit = true)
        {
            await Task.Delay(0);
        }
    }
}
