using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Cyber_dz.Models
{
    public class EncryptionModel
    {
        public string Input { get; set; }
        public string EncryptedString { get; set; }
    }

    public class DecryptionModel
    {
        public string StringToDecrypt { get; set; }
        public string DecryptedString { get; set; }
    }
}
