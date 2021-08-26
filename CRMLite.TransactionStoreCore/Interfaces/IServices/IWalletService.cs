﻿using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IServices
{
    public interface IWalletService
    {
        Task CreateWalletWithinLeadAsync(Guid leadID, Wallet wallet);
        Task<IEnumerable<Wallet>> GetAllWalletsByLeadIDAsync(Guid leadID);
        Task<Wallet> GetWalletByIDAsync(Guid id);
        Task<Wallet> GetUSDWalletByLeadIDAsync(Guid leadID);
        Task<Wallet> GetSystemUSDWalletAsync();
        Task<Wallet> GetPayPalWalletAsync();
        Task CreateDefaultWalletForLead(Guid leadID);
    }
}
