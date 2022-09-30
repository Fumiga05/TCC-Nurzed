using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nurzed.Models;

namespace Nurzed.Controllers
{
    public class UniversidadeController : Controller
    {

        PadraoController padrao = new PadraoController();

        public IActionResult Cadastrar()
        {
           

            if (padrao.Logado(HttpContext) == true)
            {

                if(padrao.Privilegios(HttpContext) == "adm")
                {
                    return View();
                } else
                {
                    TempData["msg"] = "Você não tem privilegios para acessar a pagina, entre em contato com o administrador";
                    return RedirectToAction("Listar");
                }

            } else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpPost]
        public IActionResult Cadastrar(string id,string nome, string sigla)
        {
            Universidade universidade = new Universidade(id,nome,sigla);
            
            TempData["msg"] = universidade.Cadastrar();
            return RedirectToAction("Login");
        }

        
        public IActionResult Listar()
        {

            
            return View(Universidade.Listar());
        }
        public IActionResult Login()
        {
            return View();
        }
        
        public IActionResult Teste()
        {
            return View();
        }
    }
}
