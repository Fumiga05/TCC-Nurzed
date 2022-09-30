using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nurzed.Models;

namespace Nurzed.Controllers
{
    public class PadraoController : Controller
    {
        public bool Logado(HttpContext httpContext)
        {

            if (httpContext.Session.GetString("usuarios") != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Privilegios(HttpContext httpContext)
        {
            

            if (RetornarObjeto(httpContext).Privilegios == "adm")
            {
                return "adm";
            }
            else if (RetornarObjeto(httpContext).Privilegios == "Gestor")
            {
                return "Gestor";
            }
            else if (RetornarObjeto(httpContext).Privilegios == "Enfermeiro")
            {
                return "Enfermeiro";
            }
            else
            {
                return "Seu cargo está incorreto entre em contato com o administrador";
            }
           
        }

        public Usuarios RetornarObjeto(HttpContext httpContext)
        {

            Usuarios u = JsonConvert.DeserializeObject<Usuarios>(httpContext.Session.GetString("usuarios"));
            return u;
        }
    }
}
