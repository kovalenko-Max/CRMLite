﻿using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreInsightDatabase.Repositories
{
    class StockPortfolioRepository : IStockPortfolioRepository
    {
        private readonly IStockPortfolioRepository _stockPortfolioRepository;
        public IDbConnection DBConnection { get; }

        public StockPortfolioRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _stockPortfolioRepository = DBConnection.As<IStockPortfolioRepository>();
        }

        public async Task<IEnumerable<StockPortfolio>> GetAllStocksByLeadIDAsync(Guid leadID)
        {
            var response = await _stockPortfolioRepository.GetAllStocksByLeadIDAsync(leadID);
            
            return response;
        }
    }
}