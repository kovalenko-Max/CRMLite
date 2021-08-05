using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using Insight.Database;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreInsightDatabase.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly IStockRepository _stockRepository;
        public IDbConnection DBConnection { get; }

        public StockRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _stockRepository = DBConnection.As<IStockRepository>();
        }

        public async Task<IEnumerable<Stock>> GetAllStocksAsync()
        {
            var response = await _stockRepository.GetAllStocksAsync();

            return response;
        }
    }
}