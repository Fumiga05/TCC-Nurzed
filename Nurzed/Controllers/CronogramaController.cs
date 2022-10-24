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
        string periodo, mes, ano;
        
        

        [HttpPost]
        public Object Cadastrar([FromBody] Object cronograma)
        {
            dynamic cronogram = JsonConvert.DeserializeObject(cronograma.ToString());
              Console.WriteLine(cronogram.ToString());
            string id = cronogram.id;
            string id_Usuarios = cronogram.id_Usuarios;
            string data = cronogram.data;
            string legenda = cronogram.legenda;
            string periodo = cronogram.periodo;
            Cronograma.Cadastrar(id, id_Usuarios, data, legenda, periodo);
            

            return cronograma;
            // "{'data': 'PR/PR...'}"    -   cronograma.data
        }

       
        public IActionResult Cadastrar(string id_Cargo, string periodo, string id_Area,int ano,int mes)
        {

            
            ano = 2022;
            mes = 10;
            periodo = "manha";

            
            ViewData["listaEnfermeiros"] = Usuarios.ListarUsuarios("5", periodo, id_Area);
            ViewData["listaTecnicos"] = Usuarios.ListarUsuarios("1", periodo, id_Area);
            ViewData["listaAux"] = Usuarios.ListarUsuarios("4",periodo, id_Area);
            ViewData["listaDias"] = DiasDoMes(ano,mes);
           
           

            return View();
        }
        [HttpPost]
        public IActionResult Atualizar(string periodo,string ano,string mes)
        {
            return RedirectToAction("Cadastrar");
        }

        //[HttpPost]
        //public List<Usuarios> Avancar(string periodo,int mes,int ano)
        //{
        //    List<string> listaAvancar = new List<string>();
        //    listaAvancar.Add(periodo);
        //    listaAvancar.Add(mes);
        //    listaAvancar.Add(ano);

        //    listaAvancar = DiasDoMes(ano, mes);
        //    Cadastrar
            
        //    return Usuarios.ListarUsuarios("5",periodo,"f");
        //}
        
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
