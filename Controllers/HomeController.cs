using Microsoft.AspNetCore.Mvc;
using Cyber_dz.Models;
using Cyber_dz.Service;
using Cyber_dz.Models;
using Cyber_dz.Service;
using Cyber_dz.Cipher;
using System.Security.Cryptography;
using System.Diagnostics.Eventing.Reader;

namespace EncryptionApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly CipherService _cipherService;

        public HomeController()
        {
            _cipherService = new CipherService();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new EncryptionModel());
        }

        [HttpPost]
        public IActionResult Encrypt(EncryptionModel model)
        {
            if (model.CipherType == 3 && string.IsNullOrEmpty(model.PublicKey))
            {
                ModelState.AddModelError("", "Публичный ключ обязателен для шифрования RSA");
                return View("index", model);
            }

            try
            {
                model.EncryptedText = _cipherService.Encrypt(model.InputText, model.CipherType, model.PublicKey);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Ошибка при шифровании: {ex.Message}");
            }

            return View("Index", model);

            model.EncryptedText = _cipherService.Encrypt(model.InputText, model.CipherType);
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Decrypt(EncryptionModel model)
        {
            model.DecryptedText = _cipherService.Decrypt(model.InputText, model.CipherType);
            return View("Index", model);
        }


        [HttpPost]
        public IActionResult GenerateKeys(EncryptionModel model)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.KeySize = 2048;

                model.PublicKey = Convert.ToBase64String(rsa.ExportSubjectPublicKeyInfo());
                model.PrivateKey = Convert.ToBase64String(rsa.ExportPkcs8PrivateKey());

                return View("Index", model);
            }
        }
      

       /* [HttpPost]
        public IActionResult GenerateKeys()
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.KeySize = 2048;
                var publicKey = Convert.ToBase64String(rsa.ExportSubjectPublicKeyInfo());
                var privateKey = Convert.ToBase64String(rsa.ExportPkcs8PrivateKey());

                var model = new EncryptionModel
                {
                    PublicKey = publicKey,
                    PrivateKey = privateKey
                };
                return View("Index", model);
            }
        }
 */


        /* [HttpPost]
         public IActionResult EncryptRSA(EncryptionModel model)
         {
             model.EncryptedText = _cipherService.Encrypt(model.InputText, model.CipherType);
             return View("Index", model);
         }

         [HttpPost]
         public IActionResult DecryptRSA(EncryptionModel model)
         {
             model.DecryptedText = RSA16384.RSADecrypt(model.InputText, model.PrivateKey, true);
             return View("Index", model);
         }
        */
    }
    }


