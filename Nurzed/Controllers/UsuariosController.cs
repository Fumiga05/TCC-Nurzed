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


                Usuarios u = new Usuarios("", "", "", padrao.Criptografar(senha), "", "", "", "", cpf, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                Usuarios usuarios = u.Verificar();


                if (usuarios != null)
                {

                    if (usuarios.Status1 == "ativado")
                    {
                        if (usuarios.Privilegios == "Administrador")
                        {
                            HttpContext.Session.SetString("usuarios", JsonConvert.SerializeObject(usuarios));
                            TempData["value"] = true;
                            return RedirectToAction("HomeAdm");
                        }
                        else if (usuarios.Privilegios == "Gestor")
                        {
                            HttpContext.Session.SetString("usuarios", JsonConvert.SerializeObject(usuarios));
                            TempData["value"] = true;
                            return RedirectToAction("HomeGestor");
                        }
                        else if (usuarios.Privilegios == "Comum")
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
                        TempData["msg"] = "Sua conta está desativada, entre em contato com o Administrador";
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
                if (padrao.Privilegios(HttpContext) == "Administrador" || padrao.Privilegios(HttpContext) == "Gestor")
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
        public IActionResult Cadastrar(string id, string status1, string nome, string senha, string nome_da_mae, string nome_do_pai, string data_de_nascimento,
            string sexo, string cpf, string rg, string data_de_inicio_Universidade, string data_de_termino_Universidade, string coren, string cep, string telefone,
            string matricula, string Id_Especialidade, string Id_Cargo, string tipo_de_contrato, string data_de_criacao, string data_de_modificacao, string privilegios,
            string id_Universidade, string id_Curso, string id_Area, string periodo)
        {
            Usuarios u = padrao.RetornarObjeto(HttpContext);


            if (privilegios == "Administrador")
            {
                Usuarios usuarios = new Usuarios(id, status1, nome, padrao.Criptografar(senha), nome_da_mae, nome_do_pai, data_de_nascimento, sexo, cpf,
              rg, "", "", "", cep, telefone, "00000000000", "13", "3", "",
              data_de_criacao, data_de_modificacao, privilegios, "10", "8", "7", u.Nome, "");
                TempData["msg"] = usuarios.Cadastrar();


            }
            else
            {
                Usuarios usuarios = new Usuarios(id, status1, nome, padrao.Criptografar(senha), nome_da_mae, nome_do_pai, data_de_nascimento, sexo, cpf,
               rg, data_de_inicio_Universidade, data_de_termino_Universidade, coren, cep, telefone, matricula, Id_Especialidade, Id_Cargo, tipo_de_contrato,
               data_de_criacao, data_de_modificacao, privilegios, id_Universidade, id_Curso, id_Area, u.Nome, periodo);
                TempData["msg"] = usuarios.Cadastrar();
            }
            if (TempData["msg"].ToString().Contains("Sucesso"))
            {
                return RedirectToAction("Cadastrar");
            }
            else
            {
                ViewData["listaUniversidade"] = Universidade.Listar();
                ViewData["listaCurso"] = Curso.Listar();
                ViewData["listaEspecialidade"] = Especialidade.Listar();
                ViewData["listaCargo"] = Cargo.Listar();
                ViewData["listaArea"] = Area.Listar();
                return View();
            }


        }



        public IActionResult Listar()
        {
            if (padrao.Logado(HttpContext) == true)
            {
                if (padrao.Privilegios(HttpContext) != "Administrador")
                {
                    return padrao.Home(HttpContext);
                }
                else
                {

                    ViewData["listaUsuarios"] = Usuarios.Listar();
                    return View(Usuarios.Listar());
                }

            }
            else
            {
                return RedirectToAction("Login");
            }

            
        }


        public IActionResult Ativar(string cpf)
        {


            Usuarios usuarios = new Usuarios("", "", "", "", "", "", "", "", cpf, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");

            TempData["msgAtivar"] = usuarios.AtivarInativar("ativar");
            return RedirectToAction("Listar");


        }
        public IActionResult Inativar(string cpf)
        {
            Usuarios usuarios = new Usuarios("", "", "", "", "", "", "", "", cpf, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");

            TempData["msgInativar"] = usuarios.AtivarInativar("inativar");
            return RedirectToAction("Listar");
        }

        public IActionResult Editar(string id, string cpf, string especialidade, string cargo)
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
        public IActionResult Editar(string id, string status1, string nome, string senha, string nome_da_mae, string nome_do_pai,
            string data_de_nascimento, string sexo, string cpf, string rg, string data_de_inicio_Universidade, string data_de_termino_Universidade,
            string coren, string cep, string telefone, string matricula, string Id_Especialidade, string Id_Cargo, string tipo_de_contrato,
            string data_de_criacao, string data_de_modificacao, string privilegios, string id_Universidade, string id_Curso, string id_Area, string periodo)
        {
            Usuarios u = padrao.RetornarObjeto(HttpContext);
            Usuarios usuarios = new Usuarios(id, status1, nome, senha, nome_da_mae, nome_do_pai, data_de_nascimento, sexo, cpf, rg, data_de_inicio_Universidade,
                data_de_termino_Universidade, coren, cep, telefone, matricula, Id_Especialidade, Id_Cargo, tipo_de_contrato, data_de_criacao, data_de_modificacao,
                privilegios, id_Universidade, id_Curso, id_Area, u.Nome, periodo);

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
           

            if (padrao.Logado(HttpContext) == true)
            {
                if(padrao.Privilegios(HttpContext) != "Administrador")
                {
                    return padrao.Home(HttpContext);
                }
                else
                {
                    return View();
                }
               
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        public IActionResult HomeGestor()
        {
            if (padrao.Logado(HttpContext) == true)
            {
                if (padrao.Privilegios(HttpContext) != "Gestor")
                {
                    return padrao.Home(HttpContext);
                }
                else
                {
                    return View();
                }

            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        public IActionResult HomeEnf()
        {
            if (padrao.Logado(HttpContext) == true)
            {
                if (padrao.Privilegios(HttpContext) != "Comum")
                {
                    return padrao.Home(HttpContext);
                }
                else
                {
                    return View();
                }

            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public IActionResult Voltar()
        {
            if (padrao.Privilegios(HttpContext) == "Administrador")
            {
                return RedirectToAction("HomeAdm");
            }else if (padrao.Privilegios(HttpContext) == "Gestor")  
            {
                return RedirectToAction("HomeGestor");
            }
            else
            {
                return RedirectToAction("HomeEnf"); 
            }
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

