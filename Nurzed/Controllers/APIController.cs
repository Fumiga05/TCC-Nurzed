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
        [Route("/api/[Controller]/periodo/{periodo}")]
        public IActionResult RetornarFuncionariosCronograma(string periodo)
        {
            List<Usuarios> listaEnf = Usuarios.ListarUsuarios("5", periodo, "");
            List<Usuarios> listaTec = Usuarios.ListarUsuarios("1", periodo, "");
            List<Usuarios> listaAux = Usuarios.ListarUsuarios("4", periodo, "");


            List<Object> lista = new List<Object>();
            lista.Add(listaEnf);
            lista.Add(listaTec);
            lista.Add(listaAux);

            return Ok(lista);
        }


        [HttpGet]
        [Route("/api/[Controller]/data/{data1}/{periodo}")]
        public IActionResult RetornarUsuariosPlantao(string data1, string periodo)
        {

            List<Usuarios> listaEnf = Usuarios.ListarUsuariosPlantao(data1, "5", periodo, "");
            List<Usuarios> listaTec = Usuarios.ListarUsuariosPlantao(data1, "1", periodo, "");
            List<Usuarios> listaAux = Usuarios.ListarUsuariosPlantao(data1, "4", periodo, "");
            List<Usuarios> listaAusentes = Usuarios.ListarUsuariosAusentesPlantao(data1, periodo, "");
            List<Object> lista = new List<Object>();
            lista.Add(listaEnf);
            lista.Add(listaTec);
            lista.Add(listaAux);
            lista.Add(listaAusentes);
            return Ok(lista);
        }


        [HttpGet]
        [Route("/api/[Controller]/cronograma_editar/{mes}/{ano}/{periodo}")]
        public IActionResult RetornarCronograma(string mes, string ano, string periodo)
        {
          

            
            List<Usuarios> listaEnf = Usuarios.selecionarUsuariosDoCronograma(mes, ano, "5", periodo);
            List<Usuarios> listaTec = Usuarios.selecionarUsuariosDoCronograma(mes, ano, "1", periodo);
            List<Usuarios> listaAux = Usuarios.selecionarUsuariosDoCronograma(mes, ano, "4", periodo);

            
            List<Cronograma> listaLegendasEnf = Cronograma.Listar(mes,ano,"5",periodo);
            List<Cronograma> listaLegendasTec = Cronograma.Listar(mes, ano, "1", periodo);
            List<Cronograma> listaLegendasAux = Cronograma.Listar(mes, ano, "4", periodo);

           
                List<Object> lista = new List<Object>();

                lista.Add(listaEnf);
                lista.Add(listaTec);
                lista.Add(listaAux);
                lista.Add(listaLegendasEnf);
                lista.Add(listaLegendasTec);
                lista.Add(listaLegendasAux);
                return Ok(lista);
            
            

        }


    }
}