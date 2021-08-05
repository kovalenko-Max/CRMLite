using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalletController : Controller
    {
        IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpGet("{leadID}")]
        public async Task<IEnumerable<Wallet>> GetAllWalletsByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var response = await _walletService.GetAllWalletsByLeadIDAsync(leadID);

                return response;
            }

            throw new ArgumentException("Guid leadID is empty");
        }

        [HttpGet("{walletID}")]
        public async Task<Wallet> GetWalletByIDAsync(Guid walletID)
        {
            if (walletID != Guid.Empty)
            {
                var response = await  _walletService.GetWalletByIDAsync(walletID);

                return response;
            }

            throw new ArgumentException("Guid walletID is empty");
        }

        [HttpPost]
        public async Task CreateWalletWithinLeadAsync(Wallet wallet)
        {
            if (wallet != null)
            {
                await _walletService.CreateWalletWithinLeadAsync(wallet);
            }
            else
            {
                throw new ArgumentNullException("Wallet is null");
            }
        }
    }
}
