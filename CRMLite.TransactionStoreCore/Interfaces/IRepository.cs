using System.Data;

namespace CRMLite.TransactionStoreDomain.Interfaces
{
    public interface IRepository
    {
        IDbConnection DBConnection { get; }
    }
}
