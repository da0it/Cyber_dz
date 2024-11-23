using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Cyber_dz.Models
{
    public class EncryptionDecryptionModel
    {
        public string Input { get; set; }
        public string EncryptedString { get; set; }
        public string StringToDecrypt { get; set; }
        public string DecryptedString { get; set; }
    }
}
