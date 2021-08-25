using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreBLL.Services
{
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository _repository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _repository = transactionRepository;
        }

        public async Task CreateTransactionAsync(Transaction transaction)
        {
            if (transaction != null)
            {
                await _repository.CreateTransactionAsync(transaction);
            }
            else
            {
                throw new ArgumentNullException("Transaction is null");
            }
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsByLeadIDAsync(Guid leadID)
        {
            if(leadID != Guid.Empty)
            {
                var response = await _repository.GetAllTransactionsByLeadIDAsync(leadID);
                var transactions = new List<Transaction>();
                     
                foreach(var tr in response)
                {
                    transactions.Add(
                            new Transaction()
                            {
                                ID = tr.ID,
                                LeadID = tr.LeadID,
                                Amount = tr.Amount,
                                Timestamp = tr.Timestamp,
                                WalletFrom = new Wallet()
                                {
                                    ID = tr.WalletFromID,
                                    Amount = tr.WalletFromAmount,
                                    Currency = new Currency()
                                    {
                                        ID = tr.CurrencyFromID,
                                        Code = tr.CurrencyFromCode,
                                        Title = tr.CurrencyFromTitle
                                    }
                                },
                                WalletTo = new Wallet()
                                {
                                    ID = tr.WalletToID,
                                    Amount = tr.WalletToAmount,
                                    Currency = new Currency()
                                    {
                                        ID = tr.CurrencyToID,
                                        Code = tr.CurrencyToCode,
                                        Title = tr.CurrencyToTitle
                                    }
                                },
                                OperationType = new OperationType()
                                {
                                    ID = tr.OperationTypeID,
                                    Type = tr.OperationTypeType
                                }
                            }
                        );
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
                    transactions.Add(
                            new Transaction()
                            {
                                ID = tr.ID,
                                LeadID = tr.LeadID,
                                Amount = tr.Amount,
                                Timestamp = tr.Timestamp,
                                WalletFrom = new Wallet()
                                {
                                    ID = tr.WalletFromID,
                                    Amount = tr.WalletFromAmount,
                                    Currency = new Currency()
                                    {
                                        ID = tr.CurrencyFromID,
                                        Code = tr.CurrencyFromCode,
                                        Title = tr.CurrencyFromTitle
                                    }
                                },
                                WalletTo = new Wallet()
                                {
                                    ID = tr.WalletToID,
                                    Amount = tr.WalletToAmount,
                                    Currency = new Currency()
                                    {
                                        ID = tr.CurrencyToID,
                                        Code = tr.CurrencyToCode,
                                        Title = tr.CurrencyToTitle
                                    }
                                },
                                OperationType = new OperationType()
                                {
                                    ID = tr.OperationTypeID,
                                    Type = tr.OperationTypeType
                                }
                            }
                        );
                }

                return transactions;
            }

            throw new ArgumentException("Guid  WalletID is empty");
        }
    }
}
