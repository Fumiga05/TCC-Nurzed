
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Nurzed.Models
{
    public class Usuarios
    {
        private string id,status1, nome, senha, nome_da_mae, nome_do_pai, data_de_nascimento, sexo, cpf, rg, data_de_inicio_Universidade, data_de_termino_Universidade, coren, cep, telefone, matricula, id_Especialidade, id_Cargo, tipo_de_contrato, data_de_criacao, data_de_modificacao, privilegios,id_Universidade, id_Curso,id_Area,usuario_modificacao;
     

        static MySqlConnection con = new MySqlConnection("server=localhost;database=vct;user id=teste;password=12345678");

        public Usuarios(string id, string status1, string nome, string senha, string nome_da_mae,
            string nome_do_pai, string data_de_nascimento, string sexo, string cpf, string rg,
            string data_de_inicio_Universidade, string data_de_termino_Universidade, string coren,
            string cep, string telefone, string matricula, string id_Especialidade, string id_Cargo,
            string tipo_de_contrato, string data_de_criacao, string data_de_modificacao, string privilegios,
            string id_Universidade, string id_Curso,string id_Area,string usuario_modificacao)
        {
            this.id = id;
            this.status1 = status1;
            this.nome = nome;
            this.senha = senha;
            this.nome_da_mae = nome_da_mae;
            this.nome_do_pai = nome_do_pai;
            this.data_de_nascimento = data_de_nascimento;
            this.sexo = sexo;
            this.cpf = cpf;
            this.rg = rg;
            this.data_de_inicio_Universidade = data_de_inicio_Universidade;
            this.data_de_termino_Universidade = data_de_termino_Universidade;
            this.coren = coren;
            this.cep = cep;
            this.telefone = telefone;
            this.matricula = matricula;
            this.id_Especialidade = id_Especialidade;
            this.id_Cargo = id_Cargo;
            this.tipo_de_contrato = tipo_de_contrato;
            this.data_de_criacao = data_de_criacao;
            this.data_de_modificacao = data_de_modificacao;
            this.privilegios = privilegios;      
            this.id_Universidade = id_Universidade;
            this.id_Curso = id_Curso;
            this.id_Area = id_Area;
            this.usuario_modificacao = usuario_modificacao;
        }

        public string Id { get => id; set => id = value; }
        public string Status1 { get => status1; set => status1 = value; }
        public string Nome { get => nome; set => nome = value; }


        public string Senha { get => senha; set => senha = value; }
        public string Nome_da_mae { get => nome_da_mae; set => nome_da_mae = value; }
        public string Nome_do_pai { get => nome_do_pai; set => nome_do_pai = value; }
        public string Data_de_nascimento { get => data_de_nascimento; set => data_de_nascimento = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Rg { get => rg; set => rg = value; }
        public string Data_de_inicio_Universidade { get => data_de_inicio_Universidade; set => data_de_inicio_Universidade = value; }
        public string Data_de_termino_Universidade { get => data_de_termino_Universidade; set => data_de_termino_Universidade = value; }
        public string Coren { get => coren; set => coren = value; }
        public string Cep { get => cep; set => cep = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Matricula { get => matricula; set => matricula = value; }
        public string Id_Especialidade { get => id_Especialidade; set => id_Especialidade = value; }
        public string Id_Cargo { get => id_Cargo; set => id_Cargo = value; }
        public string Tipo_de_contrato { get => tipo_de_contrato; set => tipo_de_contrato = value; }
        public string Data_de_criacao { get => data_de_criacao; set => data_de_criacao = value; }
        public string Data_de_modificacao { get => data_de_modificacao; set => data_de_modificacao = value; }
        public string Privilegios { get => privilegios; set => privilegios = value; }
        public string Id_Universidade { get => id_Universidade; set => id_Universidade = value; }
        public string Id_Curso { get => id_Curso; set => id_Curso = value; }
        public string Id_Area { get => id_Area; set => id_Area = value; }
        public string Usuario_modificacao { get => usuario_modificacao; set => usuario_modificacao = value; }

        public static string RemoveHora(string s)
        {
            s = s.Replace("00:00:00", "");

            return s;
        }

        public static string EncontrarForeignKey(string nome, string tabela)
        {

            MySqlDataReader leitor = null;

            try
            {
                MySqlCommand qry = new MySqlCommand("SELECT id FROM " + tabela + " WHERE nome = @nome;",con);
                qry.Parameters.AddWithValue("@nome", nome);
                leitor = qry.ExecuteReader();

                if(leitor.Read())
                {
                    string id = leitor["id"].ToString();
                    return id; 
                } else
                {
                    return "Não foi possível encontrar";
                }
            }
            catch(Exception e)
            {
                return "Erro: " + e;
            } finally
            {
                leitor.Close();
            }


        }
        
        public string Cadastrar()
        {
            try
            {

                con.Open();

                MySqlCommand qry = new MySqlCommand("INSERT INTO Usuarios(status1, nome, senha, nome_da_mae, nome_do_pai, data_de_nascimento," +
                    "sexo, cpf, rg, data_de_inicio_Universidade, data_de_termino_Universidade, id_Universidade, id_Curso," +
                    "coren, cep, telefone, matricula,id_Especialidade, id_Cargo, tipo_de_contrato, data_de_criacao, data_de_modificacao," +
                    "privilegios,id_Area,usuario_modificacao) VALUES('ativado',@nome,@senha,@nome_da_mae,@nome_do_pai,@data_de_nascimento," +
                    "@sexo,@cpf,@rg,@data_de_inicio_Universidade,@data_de_termino_Universidade,@id_Universidade,@id_Curso," +
                    "@coren,@cep,@telefone,@matricula,@id_Especialidade,@id_Cargo,@tipo_de_contrato,@data_de_criacao,@data_de_modificacao," +
                    "@privilegios,@id_Area,@usuario_modificacao); ", con);
                var date = DateTime.Now;
                data_de_criacao  = String.Format("{0:yyyy-MM-dd HH:mm:ss}", date);
                data_de_modificacao = String.Format("{0:yyyy-MM-dd HH:mm:ss}", date);
                qry.Parameters.AddWithValue("@nome", nome);
                qry.Parameters.AddWithValue("@senha", senha);
                qry.Parameters.AddWithValue("@nome_da_mae", nome_da_mae);
                qry.Parameters.AddWithValue("@nome_do_pai", nome_do_pai);
                qry.Parameters.AddWithValue("@data_de_nascimento", data_de_nascimento);
                qry.Parameters.AddWithValue("@sexo", sexo);
                qry.Parameters.AddWithValue("@cpf", cpf);
                qry.Parameters.AddWithValue("@rg", rg);
                qry.Parameters.AddWithValue("@data_de_inicio_Universidade", data_de_inicio_Universidade);
                qry.Parameters.AddWithValue("@data_de_termino_Universidade", data_de_termino_Universidade);
                qry.Parameters.AddWithValue("@coren", coren);
                qry.Parameters.AddWithValue("@cep", cep);
                qry.Parameters.AddWithValue("@telefone", telefone);
                qry.Parameters.AddWithValue("@matricula", int.Parse(matricula));
                qry.Parameters.AddWithValue("@id_Especialidade", id_Especialidade);
                qry.Parameters.AddWithValue("@id_Cargo", id_Cargo);
                qry.Parameters.AddWithValue("@tipo_de_contrato", tipo_de_contrato);
                qry.Parameters.AddWithValue("@data_de_criacao", data_de_criacao);
                qry.Parameters.AddWithValue("@data_de_modificacao", data_de_modificacao);
                qry.Parameters.AddWithValue("@privilegios", privilegios);               
                qry.Parameters.AddWithValue("@id_Universidade",id_Universidade);
                qry.Parameters.AddWithValue("@id_Curso",id_Curso);
                qry.Parameters.AddWithValue("@id_Area",id_Area);
                qry.Parameters.AddWithValue("@usuario_modificacao", usuario_modificacao);

                qry.ExecuteNonQuery();
                return "Usuário cadastrado com Sucesso";
            }
            catch (Exception e)
            {
                return "Erro: " + e;
            }
            finally
            {
                con.Close();
            }

        }

        public static List <Usuarios> Listar()
        {
            List<Usuarios> lista = new List<Usuarios>();

            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("SELECT usuarios.id,usuarios.status1,usuarios.nome ,usuarios.cpf,usuarios.id_Especialidade,id_Cargo,especialidade.nome as nomeEspec,cargo.nome as nomeCargo FROM Usuarios,Especialidade,Cargo WHERE usuarios.id_Cargo = cargo.id AND usuarios.id_Especialidade = Especialidade.id", con);


                MySqlDataReader leitor = qry.ExecuteReader();

                while (leitor.Read())
                {
                    Usuarios usuarios = new Usuarios(leitor["id"].ToString(),leitor["status1"].ToString(), leitor["nome"].ToString(),"","", "", "","", leitor["cpf"].ToString(), "","", "","", "", "","", leitor["nomeEspec"].ToString(), leitor["nomeCargo"].ToString(), "", "", "", "", "", "","","");
                    lista.Add(usuarios);
                }

                leitor.Close();

                return lista;


            }
            catch(Exception e)
            {
                return null;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               

            }
            finally
            {
                con.Close();
            }
        }

        public static List<Usuarios> ListarDados(string id)
        {
            List<Usuarios> lista = new List<Usuarios>(); 

            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("SELECT u.id,u.status1,u.nome,u.nome_da_mae,u.nome_do_pai," +
                    "u.data_de_nascimento,u.sexo,u.cpf,u.rg,u.data_de_inicio_Universidade," +
                    "u.data_de_termino_Universidade,u.coren, u.cep, u.telefone, u.matricula," +
                    " u.tipo_de_contrato, u.privilegios,u.data_de_modificacao,u.usuario_modificacao,a.nome AS nomeArea, e.nome AS nomeEspec, uni.nome AS nomeUni," +
                    " cur.nome AS cursoNome, car.nome AS cargoNome FROM Usuarios AS u, Especialidade AS e," +
                    " Universidade AS uni, Curso AS cur,Area AS a, Cargo AS car WHERE u.id = @id AND u.id_Area = a.id AND u.id_Universidade = uni.id AND u.id_Curso = cur.id AND "+
                     "u.id_Especialidade = e.id AND u.id_Cargo = car.id", con);
                qry.Parameters.AddWithValue("@id", id);
              
                MySqlDataReader leitor = qry.ExecuteReader();

                string data = "2/5/2004 12:00:00 AM";
               
                while (leitor.Read())
                {
                    Usuarios usuarios = new Usuarios(leitor["id"].ToString(),leitor["status1"].ToString(),leitor["nome"].ToString(),"", leitor["nome_da_mae"].ToString(), leitor["nome_do_pai"].ToString(), RemoveHora(leitor["data_de_nascimento"].ToString()), leitor["sexo"].ToString(),leitor["cpf"].ToString(), leitor["rg"].ToString(), RemoveHora(leitor["data_de_inicio_Universidade"].ToString()), RemoveHora(leitor["data_de_termino_Universidade"].ToString()),leitor["coren"].ToString(),leitor["cep"].ToString(), leitor["telefone"].ToString(), leitor["matricula"].ToString(),leitor["nomeEspec"].ToString(), leitor["cargoNome"].ToString(), leitor["tipo_de_contrato"].ToString(), "", leitor["data_de_modificacao"].ToString(), leitor["privilegios"].ToString(), leitor["nomeUni"].ToString(), leitor["cursoNome"].ToString(),
                        leitor["nomeArea"].ToString(), leitor["usuario_modificacao"].ToString());
                    lista.Add(usuarios);
                }
                
                return lista;
            }
            catch(Exception e)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public Usuarios Verificar()
        {
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("SELECT * FROM Usuarios WHERE cpf = @cpf AND senha = @senha;", con);
                qry.Parameters.AddWithValue("@cpf", cpf);
                qry.Parameters.AddWithValue("@senha", senha);
                MySqlDataReader leitor = qry .ExecuteReader();

                if (leitor.Read())
                {
                    return  new Usuarios(leitor["id"].ToString(),leitor["status1"].ToString(), leitor["nome"].ToString(), "",
                        leitor["nome_da_mae"].ToString(), leitor["nome_do_pai"].ToString(), leitor["data_de_nascimento"].ToString(),
                        leitor["sexo"].ToString(), leitor["cpf"].ToString(), leitor["rg"].ToString(), 
                        leitor["data_de_inicio_Universidade"].ToString(), leitor["data_de_termino_Universidade"].ToString(),
                        leitor["coren"].ToString(), leitor["cep"].ToString(), leitor["telefone"].ToString(),
                        leitor["matricula"].ToString(), leitor["id_Especialidade"].ToString(),
                        leitor["id_Cargo"].ToString(), leitor["tipo_de_contrato"].ToString(),
                        "", "", leitor["privilegios"].ToString(), leitor["id_Universidade"].ToString(),
                        leitor["id_Curso"].ToString(), leitor["id_Area"].ToString(), leitor["usuario_modificacao"].ToString());
                }
                else
                {
                    return null;
                }

            }
            catch(Exception e)
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }

        public string Editar(string id)
        {
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("UPDATE Usuarios SET status1 = @status1,nome = @nome,nome_da_mae = @nome_da_mae,nome_do_pai = @nome_do_pai," +
                    "data_de_nascimento = @data_de_nascimento, sexo = @sexo, cpf = @cpf, rg = @rg, data_de_inicio_Universidade = @data_de_inicio_Universidade," +
                    "data_de_termino_Universidade = @data_de_termino_Universidade, id_Universidade = @id_Universidade, id_Curso = @id_Curso, coren = @coren," +
                    " cep = @cep, telefone = @telefone, matricula = @matricula, id_Especialidade = @id_Especialidade, id_Cargo = @id_Cargo, tipo_de_contrato = @tipo_de_contrato," +
                    " privilegios = @privilegios,data_de_modificacao = @data_de_modificacao,usuario_modificacao = @usuario_modificacao WHERE id = @id", con);
                
                var date = DateTime.Now;
                data_de_modificacao = String.Format("{0:yyyy-MM-dd HH:mm:ss}", date);

                qry.Parameters.AddWithValue("@id", id);
                qry.Parameters.AddWithValue("@status1", status1);
                qry.Parameters.AddWithValue("@nome", nome);               
                qry.Parameters.AddWithValue("@nome_da_mae", nome_da_mae);
                qry.Parameters.AddWithValue("@nome_do_pai", nome_do_pai);
                qry.Parameters.AddWithValue("@data_de_nascimento", data_de_nascimento);
                qry.Parameters.AddWithValue("@sexo", sexo);
                qry.Parameters.AddWithValue("@cpf", cpf);
                qry.Parameters.AddWithValue("@rg", rg);
                qry.Parameters.AddWithValue("@data_de_inicio_Universidade", data_de_inicio_Universidade);
                qry.Parameters.AddWithValue("@data_de_termino_Universidade", data_de_termino_Universidade);
                qry.Parameters.AddWithValue("@coren", coren);
                qry.Parameters.AddWithValue("@cep", cep);
                qry.Parameters.AddWithValue("@telefone", telefone);
                qry.Parameters.AddWithValue("@matricula", matricula);
                qry.Parameters.AddWithValue("@id_Especialidade", EncontrarForeignKey(id_Especialidade,"Especialidade"));
                qry.Parameters.AddWithValue("@id_Cargo",EncontrarForeignKey( id_Cargo,"Cargo"));
                qry.Parameters.AddWithValue("@tipo_de_contrato", tipo_de_contrato);           
                qry.Parameters.AddWithValue("@privilegios", privilegios);
                qry.Parameters.AddWithValue("@id_Universidade",EncontrarForeignKey(id_Universidade,"Universidade"));
                qry.Parameters.AddWithValue("@id_Curso",EncontrarForeignKey( id_Curso,"Curso"));
                qry.Parameters.AddWithValue("@id_Area",EncontrarForeignKey( id_Area,"Area"));
                qry.Parameters.AddWithValue("@data_de_modificacao", data_de_modificacao);
                qry.Parameters.AddWithValue("@usuario_modificacao", usuario_modificacao);
                
                
                qry.ExecuteNonQuery();
               
                return "Usuários editado com sucesso";






            }
            catch(Exception e)
            {
                return "Erro: " + e;
            }
            finally
            {
                con.Close();
            }
        }

        public string Salvar()
        {
            try
            {
                con.Open();

                

                return "Usuário salvo com sucesso";
            }
            catch(Exception e)
            {
                return "Erro:"+ e;
            }
            finally
            {
                con.Close();
            }
        }

        public string AtivarInativar(string acao)
        {

            string novoStatus, msg;
            try
            {
                con.Open();

                if (acao == "ativar")
                {
                    novoStatus = "ativado";
                    msg = "Ativado";

                }
                else
                {
                    novoStatus = "desativado";
                    msg = "Desativado";
                }

                MySqlCommand qry = new MySqlCommand("UPDATE Usuarios SET status1 = @status1 WHERE cpf = @cpf", con);
                qry.Parameters.AddWithValue("@cpf", cpf);
                qry.Parameters.AddWithValue("@status1",novoStatus);

                qry.ExecuteNonQuery();

                return "Status do usuário atualizados com sucesso";

            }
            catch(Exception e)
            {
                return "Não foi possivel atualizar os status do usuário";
            }
            finally
            {
                con.Close();
            }
        }
     

    }
}

