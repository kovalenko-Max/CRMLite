using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRMLite.TransactionStoreDomain.Interfaces;

namespace CRMLite.TransactionStoreBLL.Services
{
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository _repository;
        private IWalletRepository _walletRepository;
        private readonly IExchangeRateService _exchangeRateService;
        private readonly Dictionary<string, Guid> _startedCheckoutsCache;

        public TransactionService(ITransactionRepository transactionRepository, IWalletRepository walletRepository,
            IExchangeRateService exchangeRateService)
        {
            _startedCheckoutsCache = new Dictionary<string, Guid>();
            _repository = transactionRepository;
            _walletRepository = walletRepository;
            _exchangeRateService = exchangeRateService;
        }

        public void СheckoutStarted(string paymentId, Guid leadID)
        {
            _startedCheckoutsCache.Add(paymentId, leadID);
        }

        public async Task CreateTransactionAsync(Transaction transaction)
        {
            if (transaction != null)
            {
                transaction.WalletFrom = await _walletRepository.GetWalletByIDAsync(transaction.WalletFrom.ID);
                transaction.WalletTo = await _walletRepository.GetWalletByIDAsync(transaction.WalletTo.ID);

                var exchangeRateFrom = await _exchangeRateService.GetExchangeRateForCurrencyAsync(
                    transaction.WalletFrom.Currency.Code);
                var exchangeRateTo = await _exchangeRateService.GetExchangeRateForCurrencyAsync(
                    transaction.WalletTo.Currency.Code);

                var ammountFrom = (transaction.Amount / exchangeRateTo.Value) * exchangeRateFrom.Value;

                transaction.WalletFrom.Amount -= ammountFrom;
                transaction.WalletTo.Amount += transaction.Amount;

                if (transaction.WalletFrom.Amount > 0)
                {
                    await _repository.CreateTransactionAsync(transaction);
                }
                else
                {
                    throw new Exception("Insufficient funds in the account");
                }
            }
            else
            {
                throw new ArgumentNullException("Transaction is null");
            }
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var response = await _repository.GetAllTransactionsByLeadIDAsync(leadID);
                var transactions = new List<Transaction>();

                foreach (var tr in response)
                {
                    transactions.Add(ConvertTransactionDTOtoTransaction(tr));
                }

                return transactions;
            }

            throw new ArgumentException("Guid  LeadID is empty");
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsByWalletIDAsync(Guid walletID)
        {
            if (walletID != Guid.Empty)
            {
                var response = await _repository.GetAllTransactionsByWalletIDAsync(walletID);
                var transactions = new List<Transaction>();

                foreach (var tr in response)
                {
                    transactions.Add(ConvertTransactionDTOtoTransaction(tr));
                }

                return transactions;
            }

            throw new ArgumentException("Guid  WalletID is empty");
        }

        public Guid GetCheckoutUserGuid(string paymentId)
        {
            Guid userGuid = Guid.Empty;
            _startedCheckoutsCache.TryGetValue(paymentId, out userGuid);

            return userGuid;
        }

        private Transaction ConvertTransactionDTOtoTransaction(TransactionDTO transactionDTO)
        {
            return new Transaction()
            {
                ID = transactionDTO.ID,
                LeadID = transactionDTO.LeadID,
                Amount = transactionDTO.Amount,
                Timestamp = transactionDTO.Timestamp,
                WalletFrom = new Wallet()
                {
                    ID = transactionDTO.WalletFromID,
                    Amount = transactionDTO.WalletFromAmount,
                    Currency = new Currency()
                    {
                        ID = transactionDTO.CurrencyFromID,
                        Code = transactionDTO.CurrencyFromCode,
                        Title = transactionDTO.CurrencyFromTitle
                    }
                },
                WalletTo = new Wallet()
                {
                    ID = transactionDTO.WalletToID,
                    Amount = transactionDTO.WalletToAmount,
                    Currency = new Currency()
                    {
                        ID = transactionDTO.CurrencyToID,
                        Code = transactionDTO.CurrencyToCode,
                        Title = transactionDTO.CurrencyToTitle
                    }
                },
                OperationType = new OperationType()
                {
                    ID = transactionDTO.OperationTypeID,
                    Type = transactionDTO.OperationTypeType
                }
            };
        }
    }
}