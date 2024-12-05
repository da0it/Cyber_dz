using Cyber_dz.Cipher;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Cyber_dz.Service
{
    public class CipherService
    {
        public string Encrypt(string input, int cipherType, string public_key = null)
        {
            return cipherType switch
            {
                1 => Kuznechik.EncryptGrassHopper2(input),
                2 => GOST.EncryptStreebog2(input),
                3 => !string.IsNullOrEmpty(public_key)? RSA16384.Encrypt(input, public_key) : throw new ArgumentException("Public key is required for RSA encryption"),
                _ => input,
            };
        }

        public string Decrypt(string input, int cipherType, string private_key = null)
        {
            return cipherType switch
            {
                1 => Kuznechik.DecryptGrassHopper2(input),
                //2 => GOST.EncryptStreebog2(input, true),
                2 => !string.IsNullOrEmpty(private_key) ? RSA16384.Encrypt(input, private_key) : throw new ArgumentException("Public key is required for RSA encryption"),
                _ => input,
            };
        }
    }
}
