namespace Cyber_dz.Models
{
    public class EncryptionModel
    {
        public string InputText { get; set; }
        public string EncryptedText { get; set; }
        public string DecryptedText { get; set; }
        public int CipherType { get; set; } // 1, 2 или 3 для выбора шифра
        public string PublicKey { get; set; }  // Для RSA
        public string PrivateKey { get; set; } // Для RSA

        public bool IsEncryptionOperation { get; set; }
    }
}
