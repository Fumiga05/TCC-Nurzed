using Microsoft.AspNetCore.Mvc;
using Nurzed.Models;

namespace Nurzed.Controllers
{
    public class CursoController : Controller
    {
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(string id,string nome)
        {
            Curso curso = new Curso(id,nome);
            TempData["msg"] = curso.Cadastrar();
            return RedirectToAction("Login");
        }
      
    }
}
