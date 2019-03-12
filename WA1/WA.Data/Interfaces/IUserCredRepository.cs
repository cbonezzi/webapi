using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA.Data.Core.Interfaces;

namespace WA.Data.Interfaces
{
    /// <summary>
    /// this will create signatures for crud operation inherited from baserepository for UserCredRepository
    /// </summary>
    public interface IUserCredRepository : IBaseRepository<UserCred>
    {
    }
}
