using Microsoft.AspNetCore.Mvc;
using Nurzed.Models;

namespace Nurzed.Controllers
{
    public class EspecialidadeController : Controller
    {
        public IActionResult Cadastrar()
        {
            ViewData["listaArea"] = Area.Listar();
            ViewData["listaEspecialidade"] = Especialidade.Listar();
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(string id,string nome,string nome_Area)
        {
            Especialidade especialidade = new Especialidade(id, nome,nome_Area);

            TempData["msg"] = especialidade.Cadastrar();
            
            return RedirectToAction("Cadastrar");
        }



        public IActionResult Listar()
        {
            return View(Especialidade.Listar());
        }
    }
}
