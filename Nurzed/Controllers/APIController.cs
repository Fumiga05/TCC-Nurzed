using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nurzed.Models;
using System;
using System.Collections.Generic;

namespace Nurzed
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        [HttpGet]
        [Route("/api/[Controller]/{periodo}")]
       public IActionResult Retornar(string periodo)
        {
            List<Usuarios> listaEnf = Usuarios.ListarUsuarios("5", periodo, "");
            List<Usuarios> listaTec = Usuarios.ListarUsuarios("1", periodo, "");
            List<Usuarios> listaAux = Usuarios.ListarUsuarios("4",periodo,"");

            List<Object> lista = new List<Object>();
            lista.Add(listaEnf);
            lista.Add(listaTec);
            lista.Add(listaAux);

            return Ok(lista);
        }



    }
}
