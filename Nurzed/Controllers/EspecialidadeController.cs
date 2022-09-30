using Microsoft.AspNetCore.Mvc;
using Nurzed.Models;

namespace Nurzed.Controllers
{
    public class EspecialidadeController : Controller
    {
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(string id,string nome)
        {
            Especialidade especialidade = new Especialidade(id, nome);

            TempData["msg"] = especialidade.Cadastrar();

            return RedirectToAction("Listar");
        }



        public IActionResult Listar()
        {
            return View(Especialidade.Listar());
        }
    }
}
