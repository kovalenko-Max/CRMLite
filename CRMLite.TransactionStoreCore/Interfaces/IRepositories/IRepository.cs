using System.Data;

namespace CRMLite.TransactionStoreDomain.Interfaces.IRepositories
{
    public interface IRepository
    {
        IDbConnection DBConnection { get; }
    }
}
