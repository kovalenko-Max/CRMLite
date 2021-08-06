using CRMLite.CRMCore.Entities;
using System.Threading.Tasks;

namespace CRMLite.CRMAPI.JWT
{
    public interface ISessionService
    {
        Task<string> CreateAuthTokenAsync(Lead user);
    }
}
