using System;
using System.IO;
using System.Security.Cryptography;

namespace CRMLite.CRMCore.Helper
{
    public static class EncryptionHelper
    {
        private static readonly byte[] Key;
        private static readonly byte[] IV;

        static EncryptionHelper()
        {
            Key = new byte[]
            { 121, 112, 91, 42, 61, 189, 141, 28, 109, 42, 25, 187,
                155, 220, 147, 219, 230, 40, 224, 201, 247, 102,
                84, 69, 73, 1, 83, 212, 161, 175, 194, 184 };

            IV = new byte[]
            { 115, 4, 93, 240, 156, 112, 112, 79,
                16, 121, 74, 75, 221, 4, 30, 145 };
        }

        public static string Encrypt(string plainText)
        {
            if (plainText == null || plainText.Length <= 0)
            {
                throw new ArgumentNullException(nameof(plainText));
            }

            byte[] encryptedByteArray;

            using (var rijndaelManaged = new RijndaelManaged())
            {
                var encryptor = rijndaelManaged.CreateEncryptor(Key, IV);

                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        encryptedByteArray = memoryStream.ToArray();
                    }
                }
            }

            return ByteHelper.ByteArrayToString(encryptedByteArray);
        }

        public static string Decrypt(string encrypted)
        {
            var cipherText = ByteHelper.StringToByteArray(encrypted);

            if (cipherText == null || cipherText.Length <= 0)
            {
                throw new ArgumentNullException(nameof(cipherText));
            }

            string plainText;

            using (var rijndaelManaged = new RijndaelManaged())
            {
                var decryptor = rijndaelManaged.CreateDecryptor(Key, IV);

                using (var memoryStream = new MemoryStream(cipherText))
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (var streamReader = new StreamReader(cryptoStream))
                        {
                            plainText = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            return plainText;
        }
    }
}
