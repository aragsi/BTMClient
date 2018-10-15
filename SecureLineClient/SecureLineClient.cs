using System;
using System.Collections.Generic;
using System.Text;

namespace SecureLineClient
{
    public class SecureLineClient
    {
        private AesCryptoProvider _aes;
        private readonly RsaKeyExchClient _rsaKeyXchC;

        public SecureLineClient()
        {
            _rsaKeyXchC = new RsaKeyExchClient();
        }

        public void InitaiteServer(Func<string, string> send)
        {
            _aes = _rsaKeyXchC.ImportPassword(send(_rsaKeyXchC.PubKey));
        }

        public string Encrypt(string message)
        {
            if (_aes is null) throw new Exception("Not initaited");
            return _aes.Encrypt(message);
        }

        public string Decrypt(string message)
        {
            if (_aes is null) throw new Exception("Not initaited");
            return _aes.Decrypt(message);
        }
    }
}
