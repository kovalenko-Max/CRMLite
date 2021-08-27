using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CRMLite.TransactionStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "PermissionForAdminAndUserRoles")]
    public class WalletController : Controller
    {
        private readonly IWalletService _walletService;
        private readonly ICurrencyService _currencyService;

        public WalletController(IWalletService walletService, ICurrencyService currencyService)
        {
            _walletService = walletService;
            _currencyService = currencyService;
        }

        [HttpGet("leadID")]
        public async Task<IEnumerable<Wallet>> GetAllWalletsByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var response = await _walletService.GetAllWalletsByLeadIDAsync(leadID);

                return response;
            }

            throw new ArgumentException("Guid LeadID is empty");
        }

        [HttpGet("walletID")]
        public async Task<Wallet> GetWalletByIDAsync(Guid walletID)
        {
            if (walletID != Guid.Empty)
            {
                var response = await _walletService.GetWalletByIDAsync(walletID);

                return response;
            }

            throw new ArgumentException("Guid WalletID is empty");
        }

        [HttpGet("USD/{leadID}")]
        public async Task<Wallet> GetUSDWalletByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var response = await _walletService.GetUSDWalletByLeadIDAsync(leadID);

                if (response == null)
                {
                    Wallet wallet = new Wallet();
                    wallet.Currency = await _currencyService.GetCurrencyByCodeAsync("USD");
                    wallet.Amount = 0;
                    await _walletService.CreateWalletWithinLeadAsync(leadID, wallet);
                    response = await _walletService.GetUSDWalletByLeadIDAsync(leadID);

                    return response;
                }
                else
                {
                    return response;
                }
            }

            throw new ArgumentException("Guid LeadID is empty");
        }

        [HttpGet("SystemUSDWallet")]
        public async Task<Wallet> GetSystemUSDWalletAsync()
        {
            var response = await _walletService.GetSystemUSDWalletAsync();

            return response;
        }

        [HttpPost]
        public async Task CreateWalletForLeadAsync(Guid leadID, Wallet wallet)
        {
            await _walletService.CreateWalletForLeadAsync(leadID, wallet);
        }
    }
}