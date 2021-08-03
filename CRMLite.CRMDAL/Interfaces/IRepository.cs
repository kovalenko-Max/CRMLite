using System.Data;

namespace CRMLite.CRMDAL.Interfaces
{
    public interface IRepository
    {
        IDbConnection DBConnection { get; }
    }
}
