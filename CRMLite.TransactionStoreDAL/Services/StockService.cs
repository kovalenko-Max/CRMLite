using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreBLL.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<IEnumerable<Stock>> GetAllStocksAsync()
        {
            var response = await _stockRepository.GetAllStocksAsync();

            return response;
        }
    }
}