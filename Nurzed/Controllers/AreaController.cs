using Microsoft.AspNetCore.Mvc;
using Nurzed.Models;

namespace Nurzed.Controllers
{
    public class AreaController : Controller
    {
        public IActionResult Cadastrar()
        {
            ViewData["listaArea"] = Area.Listar();
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(string id, string nome, string status1)
        {
            Area area = new Area(id, nome, status1);
            
            TempData["msg"] = area.Cadastrar();
            if (TempData["msg"].ToString().Contains("Sucesso"))
            {
                return RedirectToAction("Cadastrar");
            }
            else
            {
                ViewData["listaArea"] = Area.Listar();
                return View();
            }
            
        }



        public IActionResult Listar()
        {
            return View(Area.Listar());
        }
    }
}
