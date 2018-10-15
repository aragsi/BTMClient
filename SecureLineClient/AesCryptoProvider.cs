using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SecureLineClient
{
    class AesCryptoProvider
    {
        public string PassWord { get => _password; }

        private readonly string _password;
        public AesCryptoProvider(string password)
        {
            _password = password;
        }
        public AesCryptoProvider()
        {
            _password = Guid.NewGuid().ToString("N");
        }

        public string Encrypt(string clearText) => Convert.ToBase64String
               (AesEncryptor(System.Text.Encoding.UTF8.GetBytes(clearText)));

        public string Decrypt(string cipherText) => System.Text.Encoding
            .UTF8.GetString(AesDecrypt(Convert.FromBase64String(cipherText)));

        private byte[] AesEncryptor(byte[] clearBytes)
        {
            byte[] res;
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(_password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    res = ms.ToArray();
                }
            }
            return res;
        }

        private byte[] AesDecrypt(byte[] cipherBytes)
        {
            byte[] RetValuel;
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(_password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    RetValuel = ms.ToArray();
                }
            }
            return RetValuel;
        }
    }
}
