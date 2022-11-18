using Microsoft.AspNetCore.Mvc;
using Nurzed.Models;

namespace Nurzed.Controllers
{
    public class PlantaoController : Controller
    {
        public IActionResult Plantao(string data1, string id_Cargo, string periodo, string id_Area)
        {
            data1 = "2022-11-10";
            periodo = "manha";           

            ViewData["listaEnfermeiros"] = Usuarios.ListarUsuariosPlantao(data1,"5", periodo, "");
            ViewData["listaTecnicos"] = Usuarios.ListarUsuariosPlantao(data1, "1", periodo, "");
            ViewData["listaAux"] = Usuarios.ListarUsuariosPlantao(data1, "4", periodo, "");



            return View();
        }
    }
}
