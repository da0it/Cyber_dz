using Microsoft.AspNetCore.Mvc;
using Cyber_dz.Models;
using Cyber_dz.Service;
using Cyber_dz.Models;
using Cyber_dz.Service;

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
            model.EncryptedText = _cipherService.Encrypt(model.InputText, model.CipherType);
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Decrypt(EncryptionModel model)
        {
            model.DecryptedText = _cipherService.Decrypt(model.InputText, model.CipherType);
            return View("Index", model);
        }
    }
}
