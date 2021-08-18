using System.Data;

namespace CRMLite.CRMDAL.Interfaces
{
    public interface IDBContext
    {
        IDbConnection DBConnection { get; }
        ILeadRepository LeadRepository { get; }
        IConfirmMessageRepository ConfirmMessageRepository { get; }
        IRoleRepository RoleRepository { get; }
    }
}
