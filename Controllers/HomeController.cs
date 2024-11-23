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
            var model = new EncryptionDecryptionModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(EncryptionDecryptionModel model)
        {
            // Обработка шифрования
            if (!string.IsNullOrEmpty(model.Input))
            {
                model.EncryptedString = EncryptGrassHopper2(model.Input);
            }
            else
            {
                model.EncryptedString = "Пожалуйста, введите строку для шифрования.";
            }
            return View(model);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      
        [HttpPost]
        public IActionResult Decrypt(EncryptionDecryptionModel model)
        {
            // Обработка дешифрования
            if (!string.IsNullOrEmpty(model.StringToDecrypt))
            {
                model.DecryptedString = DecryptGrassHopper2(model.StringToDecrypt);
            }
            else
            {
                model.DecryptedString = "Пожалуйста, введите строку для дешифрования.";
            }
            return View("Index", model); // Возвращаем на ту же страницу с обновленной моделью
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private static string EncryptGrassHopper2(string text) 
        {
            byte[] result;
            result = System.Convert.FromHexString(text);
            byte[] padded_text = PaddArray(result);
            Array.Reverse(padded_text);
            string out_data = Cipher.Kuznechik.KuznechikEncrypt(padded_text);
            return out_data;
        }

        private static string DecryptGrassHopper2(string text)
        {
            byte[] toDecrypt = System.Convert.FromHexString(text);
            Array.Reverse(toDecrypt);
            string decrypted_string = Kuznechik.KuznechikDecrypt(toDecrypt);
            byte[] decrypted_string_unreversed = System.Convert.FromHexString(decrypted_string);
            Array.Reverse(decrypted_string_unreversed);
            string decrypted_string_reversed = BitConverter.ToString(decrypted_string_unreversed);
            return decrypted_string_reversed.Replace("-", "");
        }

        static public int zeros = 0;
        //Добавление нулей в массив байтов, если длина сообщения меньше BLOCK_SIZE
        static byte[] PaddArray(byte[] bytes)
        {
            if (bytes.Length < 16)
            {
                zeros += 1;
                byte[] paddedBytes = new byte[16];
                Array.Copy(bytes, paddedBytes, bytes.Length);
                return paddedBytes;
            }
            return bytes;
        }
    }
}
