using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using CRMLite.TransactionStoreInsightDatabase.Extension;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreInsightDatabase.Repositories
{
    public class StockPortfolioRepository : IStockPortfolioRepository
    {
        private readonly IStockPortfolioRepository _stockPortfolioRepository;
        public IDbConnection DBConnection { get; }

        public StockPortfolioRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _stockPortfolioRepository = DBConnection.As<IStockPortfolioRepository>();
        }

        public async Task CreateStockPortfolioAsync(StockPortfolio stockPortfolio)
        {
            if(stockPortfolio != null && stockPortfolio.LeadID != Guid.Empty)
            {
                var stockID = stockPortfolio.Stock.ID;

                await DBConnection.QueryAsync(nameof(CreateStockPortfolioAsync).GetStoredProcedureName(),
                    new
                    {
                        stockPortfolio.ID,
                        stockPortfolio.LeadID,
                        stockID,
                        stockPortfolio.Quantity
                    });
            }
            else if(stockPortfolio is null)
            {
                throw new ArgumentNullException("StockPortfolio is null");
            }
            else if( stockPortfolio.LeadID == Guid.Empty)
            {
                throw new ArgumentException("Guid leadID is empty");
            }
        }

        public async Task<IEnumerable<StockPortfolio>> GetAllStockPortfoliosByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var response = await _stockPortfolioRepository.GetAllStockPortfoliosByLeadIDAsync(leadID);

                return response;
            }

            throw new ArgumentException("Guid LeadID is empty");
        }
    }
}