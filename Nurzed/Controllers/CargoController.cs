using Microsoft.AspNetCore.Mvc;
using Nurzed.Models;

namespace Nurzed.Controllers
{
    public class CargoController : Controller
    {
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(string id, string nome)
        {
            Cargo cargo = new Cargo(id, nome);
            TempData["msg"] = cargo.Cadastrar();
            return RedirectToAction("Login");
        }
       
    }
}
