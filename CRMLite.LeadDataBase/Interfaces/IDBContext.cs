using System.Data;

namespace CRMLite.CRMDatabase.Interfaces
{
    public interface IDBContext
    {
        IDbConnection DBConnection { get; }
        ILeadRepository LeadRepository { get; }
    }
}
