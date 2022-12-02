using Microsoft.AspNetCore.Mvc;
using Nurzed.Models;

namespace Nurzed.Controllers
{
    public class PlantaoController : Controller
    {
        public IActionResult Plantao(string data1, string id_Cargo, string periodo, string id_Area)
        {                     

            ViewData["listaEnfermeiros"] = Usuarios.ListarUsuariosPlantao(data1,"5", periodo, "");
            ViewData["listaTecnicos"] = Usuarios.ListarUsuariosPlantao(data1, "1", periodo, "");
            ViewData["listaAux"] = Usuarios.ListarUsuariosPlantao(data1, "4", periodo, "");



            return View();
        }
    }
}
