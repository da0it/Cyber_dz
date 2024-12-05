using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;

namespace Cyber_dz.Cipher
{
    public class RSA16384
    {

        //int keySize = 2048;

        /*public static string EncryptDecrypt(string input, byte[] publicKey)
        {
            //using (RSA rsa = RSA.Create(2048))
            //{
                //byte[] publicKey = rsa.ExportRSAPublicKey();
                //byte[] _privateKey = rsa.ExportRSAPrivateKey();
            string message = input;
            byte[] encryptedMessage = Encrypt(message, publicKey);
            return Convert.ToBase64String(encryptedMessage);
              
            //}
            
        }
        */

        public static string Encrypt(string message, string publicKey)
        {
            using (RSA rsa = RSA.Create(2048))
            {
                rsa.ImportRSAPublicKey(Convert.FromBase64String(publicKey), out _);
                return Convert.ToBase64String(rsa.Encrypt(Encoding.UTF8.GetBytes(message), RSAEncryptionPadding.OaepSHA256));
            }
        }

        public static string Decrypt(string encryptedMessage, string privateKey)
        {
            byte[] strEncryptedMessage = Encoding.UTF8.GetBytes(encryptedMessage);
            using (RSA rsa = RSA.Create(2048))
            {
                rsa.ImportRSAPrivateKey(Convert.FromBase64String(privateKey), out _);
                byte[] decryptedBytes = rsa.Decrypt(strEncryptedMessage, RSAEncryptionPadding.OaepSHA256);
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }
}