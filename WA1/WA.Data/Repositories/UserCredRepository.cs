using WA.Data.Core;
using WA.Data.Core.Interfaces;
using WA.Data.Interfaces;

namespace WA.Data.Repositories
{
    public class UserCredRepository : BaseRepository<UserCred>, IUserCredRepository
    {
        /// <summary>
        /// building UserCredRepository
        /// </summary>
        /// <param name="factory">passing factory context to construct UserCredRepository</param>
        public UserCredRepository(IContextFactory factory) : base(factory.GetContext())
        {

        }
    }
}
