using System.Threading.Tasks;
using WA.Data.Core.Interfaces;

namespace WA.Data.Core
{
    // unit of work class to help with transactional functions
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IContextFactory _contextFactory;

        public UnitOfWork(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // helps commit context changes to database
        public async Task Commit()
        {
            await _contextFactory.GetContext().SaveChangesAsync();
        }
    }
}
