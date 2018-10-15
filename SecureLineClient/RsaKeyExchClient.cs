using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SecureLineClient
{
     class RsaKeyExchClient : IDisposable
    {
        private readonly RSACryptoServiceProvider _rsa;

        private readonly string _pubKey;

        public string PubKey { get => _pubKey; }
        #region ctor
        public RsaKeyExchClient()
        {
            _rsa = new RSACryptoServiceProvider();
            _pubKey = Convert.ToBase64String(_rsa.ExportCspBlob(false));
        }
        #endregion

        public AesCryptoProvider ImportPassword(string Pass)
        {
            var key = Convert.FromBase64String(Pass);
            var K = System.Text.Encoding.ASCII.GetString(_rsa.Decrypt(key, false));
            return new AesCryptoProvider(K);
        }



        public void Dispose()
        {
            _rsa.Dispose();
        }
    }
}
