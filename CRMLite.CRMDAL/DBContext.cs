using CRMLite.CRMDAL.Interfaces;
using CRMLite.CRMDAL.Repositories;
using System.Data;

namespace CRMLite.CRMDAL
{
    public class DBContext: IDBContext
    {
        public IDbConnection DBConnection { get; }

        public DBContext(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
        }

        public ILeadRepository LeadRepository => new LeadRepository(DBConnection);
        public IConfirmMessageRepository ConfirmMessageRepository => new ConfirmMessageRepository(DBConnection);
        public IRoleRepository RoleRepository => new RoleRepository(DBConnection);
    }
}
