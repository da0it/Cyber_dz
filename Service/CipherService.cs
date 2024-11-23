using Cyber_dz.Cipher;
using System;

namespace Cyber_dz.Service
{
    public class CipherService
    {
        public string Encrypt(string input, int cipherType)
        {
            return cipherType switch
            {
                1 => Kuznechik.EncryptGrassHopper2(input),
                2 => GOST.EncryptStreebog2(input),
                //3 => RSA(input),
                _ => input,
            };
        }

        public string Decrypt(string input, int cipherType)
        {
            return cipherType switch
            {
                1 => Kuznechik.DecryptGrassHopper2(input),
                //2 => GOST.EncryptStreebog2(input, true),
                // 3 => RSA(input, true),
                _ => input,
            };
        }
    }
}
