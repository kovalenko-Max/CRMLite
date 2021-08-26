using CRMLite.TransactionStoreAPI.Filters.Attributes;
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
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("leadID")]
        public async Task<IEnumerable<Transaction>> GetAllTransactionsByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var response = await _transactionService.GetAllTransactionsByLeadIDAsync(leadID);

                return response;
            }

            throw new ArgumentException("Guid  LeadID is empty");
        }

        [HttpGet("walletID")]
        public async Task<IEnumerable<Transaction>> GetAllTransactionsByWalletIDAsync(Guid walletID)
        {
            if (walletID != Guid.Empty)
            {
                var response = await _transactionService.GetAllTransactionsByWalletIDAsync(walletID);

                return response;
            }

            throw new ArgumentException("Guid  walletID is empty");
        }

        [HttpPost]
        //[TypeFilter(typeof(TwoFactorAuthorizeAttribute))]
        public async Task CreateTransactionAsync(Transaction transaction)
        {
            if (transaction != null)
            {
                await _transactionService.CreateTransactionAsync(transaction);
            }
            else
            {
                throw new ArgumentNullException("Transaction is null");
            }
        }
    }
}