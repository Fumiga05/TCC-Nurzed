using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Nurzed.Models;

namespace Nurzed.Controllers
{
    public class UsuariosController : Controller
    {
        

        public IActionResult Cadastrar()
        {
            PadraoController padrao = new PadraoController();
            if (padrao.Logado(HttpContext) == true)
            {
                if(padrao.Privilegios(HttpContext) == "adm" || padrao.Privilegios(HttpContext) == "Gestor")
                {
                    ViewData["listaUniversidade"] = Universidade.Listar();
                    ViewData["listaCurso"] = Curso.Listar();
                    ViewData["listaEspecialidade"] = Especialidade.Listar();
                    ViewData["listaCargo"] = Cargo.Listar();
                    ViewData["listaArea"] = Area.Listar();

                    return View();
                }
                else
                {
                    TempData["msg"] = "Privilegios insuficientes";
                    return RedirectToAction("HomeEnf", "Usuarios");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
           
        }
        [HttpPost]
        public IActionResult Cadastrar(string status1, string nome, string senha, string nome_da_mae, string nome_do_pai, string data_de_nascimento, string sexo, string cpf, string rg, string data_de_inicio_Universidade, string data_de_termino_Universidade, string coren, string cep, string telefone, string matricula, string Id_Especialidade, string Id_Cargo, string tipo_de_contrato, string data_de_criacao, string data_de_modificacao, string privilegios, string id_Universidade, string id_Curso,string id_Area)
        {

            
            Usuarios usuarios = new Usuarios(status1, nome, senha, nome_da_mae, nome_do_pai, data_de_nascimento, sexo, cpf, rg, data_de_inicio_Universidade, data_de_termino_Universidade, coren, cep, telefone, matricula, Id_Especialidade, Id_Cargo, tipo_de_contrato, data_de_criacao, data_de_modificacao, privilegios, id_Universidade, id_Curso, id_Area)
            {

            };
            TempData["msg"] = usuarios.Cadastrar();

            
            
            return RedirectToAction("Login");

        }

       public IActionResult Listar()
        
        {
            return View(Usuarios.Listar());
        }
        public IActionResult Editar(string cpf)
        {
           
            TempData["cpf"] = cpf;
            ViewData["dados"] = Usuarios.ListarDados(cpf);

            return View();
        }

        public IActionResult Ativar(string cpf)
        {

            
                Usuarios usuarios = new Usuarios("","","","","","", "", cpf, "", "", "", "", "", "", "", "", "", "", "", "","","","","");

                TempData["msg"] = usuarios.AtivarInativar("ativar");
                return RedirectToAction("Listar");
           

        }
        public IActionResult Inativar(string cpf)
        {
            Usuarios usuarios = new Usuarios("", "", "", "", "", "", "",cpf, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "","");

            TempData["msg"] = usuarios.AtivarInativar("inativar");
            return RedirectToAction("Listar");
        }



        [HttpPost]
        public IActionResult Editar(string status1, string nome, string senha, string nome_da_mae, string nome_do_pai, string data_de_nascimento, string sexo, string cpf, string rg, string data_de_inicio_Universidade, string data_de_termino_Universidade, string coren, string cep, string telefone, string matricula, string Id_Especialidade, string Id_Cargo, string tipo_de_contrato, string data_de_criacao, string data_de_modificacao, string privilegios, string id_Universidade, string id_Curso)
        {
                      

           
            return View();

        }

        public IActionResult Login()
        {

            if (HttpContext.Session.GetString("usuarios") == null)
            {
                return View();
            } else
            {
                return RedirectToAction("Listar");
            }
        }

        [HttpPost]
        public IActionResult Login(string cpf,string senha)
        {

            Usuarios u = new Usuarios("", "",senha, "", "", "", "", cpf, "", "", "", "", "", "", "", "", "", "", "", "","", "", "","");
            Usuarios usuarios = u.Verificar();
           

            if (usuarios != null)
            {

                if (usuarios.Status1 == "ativado")
                {
                    if(usuarios.Privilegios == "adm")
                    {
                        HttpContext.Session.SetString("usuarios", JsonConvert.SerializeObject(usuarios));
                        return RedirectToAction("HomeAdm");
                    }
                    else if (usuarios.Privilegios == "Gestor")  
                    {
                        HttpContext.Session.SetString("usuarios", JsonConvert.SerializeObject(usuarios));
                        return RedirectToAction("HomeGestor");
                    }else if (usuarios.Privilegios == "Enfermeiro")
                    {
                        HttpContext.Session.SetString("usuarios", JsonConvert.SerializeObject(usuarios));
                        return RedirectToAction("HomeEnf");
                    }else
                    {
                        TempData["msg"] = "Privilegio incorreto";
                        return RedirectToAction("Login");
                    }
                    

                }
                else
                {
                    TempData["msg"] = "Usuário/Senha Incorreto(s)";
                    return RedirectToAction("Login");
                }
            }
            else
            {
                TempData["msg"] = "Conta não cadastrada, por favor entre em contato com o administrador";
                return RedirectToAction("Login");
            }
            
           
        }
        public IActionResult Sair()
        {
            HttpContext.Session.Remove("usuarios");
            return RedirectToAction("Login");
        }
        public IActionResult HomeAdm()
        {
            PadraoController padrao = new PadraoController();

            if (padrao.Logado(HttpContext) == true)
            {
                if (padrao.Privilegios(HttpContext) == "adm")
                {
                    return View();
                }
                else if (padrao.Privilegios(HttpContext) == "Gestor")
                {
                    return RedirectToAction("HomeGestor");
                }
                else if (padrao.Privilegios(HttpContext) == "Enfermeiro")
                {
                    return RedirectToAction("HomeEnf");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public IActionResult HomeGestor()
        {
            PadraoController padrao = new PadraoController();
            if (padrao.Logado(HttpContext) == true)
            {
                if (padrao.Privilegios(HttpContext) == "adm")
                {
                    return RedirectToAction("HomeAdm");
                }
                else if (padrao.Privilegios(HttpContext) == "Gestor")
                {
                    return View();
                }
                else if (padrao.Privilegios(HttpContext) == "Enfermeiro")
                {
                    return RedirectToAction("HomeEnf");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        public IActionResult HomeEnf()
        {
            PadraoController padrao = new PadraoController();
            if (padrao.Logado(HttpContext) == true)
            {
                if (padrao.Privilegios(HttpContext) == "adm")
                {
                    return RedirectToAction("HomeAdm");
                }
                else if (padrao.Privilegios(HttpContext) == "Gestor")
                {
                    return RedirectToAction("HomeGestor");
                }
                else if (padrao.Privilegios(HttpContext) == "Enfermeiro")
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}

