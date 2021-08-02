using System.Data;

namespace CRMLite.CRMDatabase.Interfaces
{
    public interface IRepository
    {
        IDbConnection DBConnection { get; }
    }
}
