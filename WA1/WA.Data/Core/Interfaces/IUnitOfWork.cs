using System.Threading.Tasks;

namespace WA.Data.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
