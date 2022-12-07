using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nurzed.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nurzed.Controllers
{
    public class CronogramaController : Controller
    {
        PadraoController padrao = new PadraoController();

        public IActionResult Cadastrar(string id_Cargo, string periodo, string id_Area, int ano, int mes)
        {
            ano = 2022;
            mes = 10;
            periodo = "tarde";


            ViewData["listaEnfermeiros"] = Usuarios.ListarUsuarios("5", periodo, "");
            ViewData["listaTecnicos"] = Usuarios.ListarUsuarios("1", periodo, "");
            ViewData["listaAux"] = Usuarios.ListarUsuarios("4", periodo, "");
            ViewData["listaDias"] = DiasDoMes(ano, mes);



            return View();
        }

    


        [HttpPost]
        public IActionResult Cadastrar([FromBody] Object cronograma)
        {
            dynamic cronogram = JsonConvert.DeserializeObject(cronograma.ToString());
           
            string id = cronogram.id;
            string id_Usuarios = cronogram.id_Usuarios;
            string data = cronogram.data;
            string legenda = cronogram.legenda;
            string periodo = cronogram.periodo;
            Usuarios usuario = padrao.RetornarObjeto(HttpContext);            
            TempData["msg"] = Cronograma.Cadastrar(id_Usuarios, data, legenda, periodo,usuario.Nome,"","");
            

            return RedirectToAction("Cadastrar","Cronograma");
          
        }


        public List<Usuarios> Atualizar(string periodo)
        {
            List<Usuarios> u = Usuarios.ListarUsuarios("5", periodo, "");

            return u;
        }

        public IActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        public Object Editar([FromBody] Object cronograma)
        {
            dynamic cronogram = JsonConvert.DeserializeObject(cronograma.ToString());

            string id = cronogram.id;
            string id_Usuarios = cronogram.id_Usuarios;
            string data = cronogram.data;
            string legenda = cronogram.legenda;
            string periodo = cronogram.periodo;
            Usuarios usuario = padrao.RetornarObjeto(HttpContext);
            Cronograma.Editar(id,id_Usuarios, data, legenda, periodo, usuario.Nome, "");


            return cronograma;

        }



        //Método para enviar quantidade dias para o Front-End
        public  List<string> DiasDoMes(int ano,int mes)
        {
            List<string> listaDias = new List<string>();
            ano = 2022;
            mes = 10;
            int dias = DateTime.DaysInMonth(ano, mes);
            for(int i = 1;i <= dias; i++)
            {
                if(i < 10)
                {
                    listaDias.Add("0"+i);
                }
                else
                {
                    listaDias.Add(i.ToString());
                }
                
            }
            return listaDias;
        }
        
    }
}
