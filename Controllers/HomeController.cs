using Cyber_dz.Cipher;
using Cyber_dz.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace Cyber_dz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new EncryptionModel());
        }

        [HttpPost]
        public IActionResult Index(EncryptionModel model)
        {
            if (!string.IsNullOrEmpty(model.Input))
            {
                model.EncryptedString = EncryptGrassHopper2(model.Input);
            }
            else
            {
                model.EncryptedString = "Пожалуйста, введите строку для шифрования.";
            }
            return View("Index", model);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private static string EncryptGrassHopper2(string text) 
        {
            byte[] result;
            bool test = ContainsGtoZ(text);
            if (test == true)
            {
                result = Encoding.UTF8.GetBytes(text);
            }
            else
            {
                result = System.Convert.FromHexString(text);
            }
            byte[] padded_text = PaddArray(result);
            Array.Reverse(padded_text);
            string out_data = Cipher.Kuznechik.KuznechikEncrypt(padded_text);
            return out_data;
        }

        /*private static string DecryptGrassHopper2(string text)
        {
            byte[] toDecrypt = System.Convert.FromHexString(text);
            Array.Reverse(toDecrypt);
            string decrypted_string = Kuznechik.KuznechikDecrypt(toDecrypt);
            byte[] decrypted_string_unreversed = System.Convert.FromHexString(decrypted_string);
            Array.Reverse(decrypted_string_unreversed);
            string decrypted_string_reversed = BitConverter.ToString(decrypted_string_unreversed);
            return decrypted_string_reversed;
        }*/

        static bool ContainsGtoZ(string text)
        {
            foreach (char c in text)
            {
                if (c >= 'g' && c <= 'z') return true;
            }
            return false;
        } 


        //Добавление нулей в массив байтов, если длина сообщения меньше BLOCK_SIZE
        static byte[] PaddArray(byte[] bytes)
        {
            if (bytes.Length < 16)
            {
                byte[] paddedBytes = new byte[16];
                Array.Copy(bytes, paddedBytes, bytes.Length);
                return paddedBytes;
            }
            return bytes;
        }
    }
}
