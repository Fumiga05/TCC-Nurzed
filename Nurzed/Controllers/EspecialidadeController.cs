using Microsoft.AspNetCore.Mvc;
using Nurzed.Models;

namespace Nurzed.Controllers
{
    public class EspecialidadeController : Controller
    {
        PadraoController padrao = new PadraoController();
        public IActionResult Cadastrar()
        {

            if (padrao.Logado(HttpContext) == true)
            {
                if (padrao.Privilegios(HttpContext) != "Administrador")
                {
                    return padrao.Home(HttpContext);
                }
                else
                {
                    ViewData["listaArea"] = Area.Listar();
                    ViewData["listaEspecialidade"] = Especialidade.Listar();
                    return View();
                }

            }
            else
            {
                return RedirectToAction("Login");
            }
          
        }
        [HttpPost]
        public IActionResult Cadastrar(string id,string nome,string nome_Area)
        {
            Especialidade especialidade = new Especialidade(id, nome,nome_Area);
            TempData["msg"] = especialidade.Cadastrar();
            if (especialidade.Cadastrar().Contains("Duplicate"))
            {
               

                return View();
            } else
            {
                return RedirectToAction("Cadastrar");
            }

        }



        public IActionResult Listar()
        {
            return View(Especialidade.Listar());
        }
    }
}
