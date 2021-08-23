using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using Google.Authenticator;
using System;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreBLL.Services
{
    public class GoogleTFAService : ITFAService
    {
        private ILeadTFAKeyRepository _repository;
        private readonly TwoFactorAuthenticator _twoFactorAuthenticator;
        public string AccountTitle { get; set; }
        public string ApplicationName { get; set; }
        public bool SecretISBase32 { get; set; }
        public int SizeQRCode { get; set; }
        public TimeSpan TimeDrift { get; set; }

        public GoogleTFAService(ILeadTFAKeyRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> IsLeadTFAExistAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var key = await GetTFAKeyByLeadIDAsync(leadID);
                var result = key != null ? true : false;

                return result;
            }

            throw new ArgumentException("Guid leadID is empty");
        }

        public async Task<TFAModel> GetTFAModelAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var key = await GetTFAKeyByLeadIDAsync(leadID);

                SetupCode setupInfo = _twoFactorAuthenticator
                    .GenerateSetupCode(ApplicationName, AccountTitle, key, SecretISBase32, SizeQRCode);

                var tfaModel = new TFAModel()
                {
                    QRCodeBase64 = setupInfo.QrCodeSetupImageUrl,
                    ManualEntryKey = setupInfo.ManualEntryKey
                };

                return tfaModel;
            }

            throw new ArgumentException("Guid leadID is empty");
        }

        public async Task AddTFAKeyToLeadAsync(Guid leadID, string key)
        {
            if (leadID != Guid.Empty && key != null)
            {
                await _repository.AddTFAKeyToLeadAsync(leadID, key);
            }
            else if (leadID == Guid.Empty)
            {
                throw new ArgumentException("Guid leadID is empty");
            }

            throw new ArgumentNullException("String key is null");
        }

        public async Task<bool> ConfirmPinAsync(Guid leadID, string pin)
        {
            if (leadID != Guid.Empty && pin != null)
            {
                var key = await GetTFAKeyByLeadIDAsync(leadID);
                bool isCorrectPIN = _twoFactorAuthenticator.ValidateTwoFactorPIN(key, pin, TimeDrift);

                return isCorrectPIN;
            }
            else if (leadID == Guid.Empty)
            {
                throw new ArgumentException("Guid leadID is empty");
            }

            throw new ArgumentNullException("String pin is null");
        }

        private async Task<string> GetTFAKeyByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var key = await _repository.GetTFAKeyByLeadIDAsync(leadID);

                return key;
            }

            throw new ArgumentException("Guid leadID is empty");
        }
    }
}
