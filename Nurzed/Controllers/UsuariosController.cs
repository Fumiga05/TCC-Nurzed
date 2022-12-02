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
        PadraoController padrao = new PadraoController();



        public IActionResult Login()
        {
            
            if (HttpContext.Session.GetString("usuarios") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("HomeAdm");
            }
          
        }

        [HttpPost]
        public IActionResult Login(string cpf, string senha)
        {
            if (cpf != null && senha != null)
            {


                Usuarios u = new Usuarios("", "", "", padrao.Criptografar(senha), "", "", "", "", cpf, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "","");
                Usuarios usuarios = u.Verificar();


                if (usuarios != null)
                {

                    if (usuarios.Status1 == "ativado")
                    {
                        if (usuarios.Id_Cargo == "SUPORTE TI")
                        {
                            HttpContext.Session.SetString("usuarios", JsonConvert.SerializeObject(usuarios));
                            TempData["value"] = true;
                            return RedirectToAction("HomeAdm");
                        }
                        else if (usuarios.Id_Cargo == "Gestor de Enfermagem")
                        {
                            HttpContext.Session.SetString("usuarios", JsonConvert.SerializeObject(usuarios));
                            TempData["value"] = true;
                            return RedirectToAction("HomeGestor");
                        }
                        else if (usuarios.Id_Cargo == "Enfermeiro" || usuarios.Id_Cargo == "Auxiliar de Enfermagem")
                        {
                            HttpContext.Session.SetString("usuarios", JsonConvert.SerializeObject(usuarios));
                            TempData["value"] = true;
                            return RedirectToAction("HomeEnf");
                        }
                        else
                        {
                            TempData["msg"] = "Privilegio incorreto";
                            TempData["value"] = false;
                            return RedirectToAction("Login");
                        }


                    }
                    else
                    {
                        TempData["msg"] = "Usuário/Senha Incorreto(s)";
                        TempData["value"] = false;
                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    TempData["msg"] = "Usuário/Senha Incorreto(s)";
                    TempData["value"] = false;
                    return RedirectToAction("Login");
                }
            }
            else
            {

                TempData["msg"] = "Por favor, preencha os campos em branco";
                TempData["value"] = false;
                return RedirectToAction("Login");
            }

        }

       


        public IActionResult Cadastrar()
        {
            
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
                    TempData["msgPrivilegios"] = "Privilegios insuficientes";
                    return RedirectToAction("HomeEnf", "Usuarios");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
           
        }
        [HttpPost]
        public IActionResult Cadastrar(string id,string status1, string nome, string senha, string nome_da_mae, string nome_do_pai, string data_de_nascimento,
            string sexo, string cpf, string rg, string data_de_inicio_Universidade, string data_de_termino_Universidade, string coren, string cep, string telefone,
            string matricula, string Id_Especialidade, string Id_Cargo, string tipo_de_contrato, string data_de_criacao, string data_de_modificacao, string privilegios,
            string id_Universidade, string id_Curso,string id_Area, string periodo)
        {
           Usuarios u = padrao.RetornarObjeto(HttpContext) ;

            if (privilegios == "adm")
            {
                Usuarios usuarios = new Usuarios(id, status1, nome, padrao.Criptografar(senha), nome_da_mae, nome_do_pai, data_de_nascimento, sexo, cpf,
               rg, data_de_inicio_Universidade, data_de_termino_Universidade, coren, cep, telefone, matricula, Id_Especialidade, Id_Cargo, tipo_de_contrato,
               data_de_criacao, data_de_modificacao, privilegios, id_Universidade, id_Curso, id_Area, u.Nome, periodo);
                TempData["msg"] = usuarios.Cadastrar();
            }
            else
            {
                Usuarios usuarios = new Usuarios(id, status1, nome, padrao.Criptografar(senha), nome_da_mae, nome_do_pai, data_de_nascimento, sexo, cpf,
               rg, "", "", "", "", telefone, matricula, "", "", "",
               data_de_criacao, data_de_modificacao, privilegios, "", "", "", u.Nome, "");
                TempData["msg"] = usuarios.Cadastrar();
            }

            return RedirectToAction("Cadastrar");

        }



       public IActionResult Listar()        
        {
            ViewData["listaUsuarios"] = Usuarios.Listar();
            return View(Usuarios.Listar());
        }
        

        public IActionResult Ativar(string cpf)
        {

            
                Usuarios usuarios = new Usuarios("","","","","","","", "", cpf, "", "", "", "", "", "", "", "", "", "", "", "","","","","","","");

                TempData["msgAtivar"] = usuarios.AtivarInativar("ativar");
                return RedirectToAction("Listar");
           

        }
        public IActionResult Inativar(string cpf)
        {
            Usuarios usuarios = new Usuarios("","", "", "", "", "", "", "",cpf, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "","","","");

            TempData["msgInativar"] = usuarios.AtivarInativar("inativar");
            return RedirectToAction("Listar");
        }

        public IActionResult Editar(string id,string cpf, string especialidade, string cargo)
        {
            TempData["id"] = id;
            TempData["cpf"] = cpf;
            ViewData["listaUniversidade"] = Universidade.Listar();
            ViewData["listaCurso"] = Curso.Listar();
            ViewData["listaEspecialidade"] = Especialidade.Listar();
            ViewData["listaCargo"] = Cargo.Listar();
            ViewData["listaArea"] = Area.Listar();
            ViewData["dados"] = Usuarios.ListarDados(id);

            return View();
        }

        [HttpPost]
        public IActionResult Editar(string id,string status1, string nome, string senha, string nome_da_mae, string nome_do_pai,
            string data_de_nascimento, string sexo, string cpf, string rg, string data_de_inicio_Universidade, string data_de_termino_Universidade,
            string coren, string cep, string telefone, string matricula, string Id_Especialidade, string Id_Cargo, string tipo_de_contrato,
            string data_de_criacao, string data_de_modificacao, string privilegios, string id_Universidade, string id_Curso,string id_Area,string periodo)
        {
            Usuarios u = padrao.RetornarObjeto(HttpContext);
            Usuarios usuarios = new Usuarios(id, status1, nome, senha, nome_da_mae, nome_do_pai, data_de_nascimento, sexo, cpf, rg, data_de_inicio_Universidade,
                data_de_termino_Universidade, coren, cep, telefone, matricula, Id_Especialidade, Id_Cargo, tipo_de_contrato, data_de_criacao, data_de_modificacao,
                privilegios, id_Universidade, id_Curso, id_Area, u.Nome,periodo);

            TempData["id"] = id;
            TempData["msgEditar"] = usuarios.Editar(id);

            return RedirectToAction("Listar");
            
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
            return View();

        }

        public IActionResult HomeEnf()
        {
            return View();
        }

        public IActionResult Voltar()
        {
            return padrao.Home(HttpContext);
        }

        public IActionResult Plantao(string id_Cargo, string periodo, string id_Area)
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Plantao()
        {
            

            return View();
        }


    }
}

