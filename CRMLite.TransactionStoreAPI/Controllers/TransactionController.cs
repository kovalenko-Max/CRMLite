using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("{leadID}")]
        public async Task<IEnumerable<Transaction>> GetAllTransactionByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var response = await _transactionService.GetAllTransactionByLeadID(leadID);

                return response;
            }

            throw new ArgumentException("Guid  LeadID is empty");
        }

        [HttpGet("{walletID}")]
        public async Task<IEnumerable<Transaction>> GetAllTransactionByWalletIDAsync(Guid walletID)
        {
            if (walletID != Guid.Empty)
            {
                var response = await _transactionService.GetAllTransactionByWalletID(walletID);

                return response;
            }

            throw new ArgumentException("Guid  walletID is empty");
        }

        [HttpPost]
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