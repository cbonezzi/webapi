using System.Threading.Tasks;
using WA.Service.Models;
using WA.Service.Results;

namespace WA.Service.Interfaces
{
    public interface IUserCredService
    {
        Task<GuidResult> CreateGuid(CredentialModel model);
        Task<GuidResult> ReadGuid(string guid);
        Task<GuidResult> DeleteGuid(string guid);
        Task<GuidResult> Update(CredentialModel model);

    }
}
