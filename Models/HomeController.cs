namespace Cyber_dz.Models
{
    public class EncryptionModel
    {
        public string InputText { get; set; }
        public string EncryptedText { get; set; }
        public string DecryptedText { get; set; }
        public int CipherType { get; set; } // 1, 2 или 3 для выбора шифра
    }
}
