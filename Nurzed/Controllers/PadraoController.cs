using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nurzed.Models;
using System.Security.Cryptography;
using System.Text;

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
        public string Criptografar(string senha)
        {
            
            SHA256 sha256 = SHA256.Create();

            
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));

            
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

           
            return builder.ToString();
        }
        public Usuarios RetornarObjeto(HttpContext httpContext)
        {

            Usuarios u = JsonConvert.DeserializeObject<Usuarios>(httpContext.Session.GetString("usuarios"));
            return u;
        }

        public IActionResult Home(HttpContext httpContext)
        {
            if (Privilegios(httpContext) == "adm")
            {
                return RedirectToAction("HomeAdm");
            }else if(Privilegios(httpContext) == "Gestor")
            {
                return RedirectToAction("HomeGestor");
            }
            else
            {
                return RedirectToAction("HomeEnf");
            }
        }
    }
}
