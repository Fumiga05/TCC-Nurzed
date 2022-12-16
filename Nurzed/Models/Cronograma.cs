using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace Nurzed.Models
{
    public class Cronograma
    {
        private string id, id_Usuarios, legenda, periodo, data, usuario_modificacao, data_de_criacao, data_de_modificacao;

        static MySqlConnection con = new MySqlConnection(Conexao.conexaoString());
        public Cronograma(string id, string id_Usuarios, string data, string legenda, string periodo, string usuario_modificacao, string data_de_modificacao, string data_de_criacao)
        {
            this.id = id;
            this.id_Usuarios = id_Usuarios;
            this.data = data;
            this.legenda = legenda;
            this.periodo = periodo;
            this.usuario_modificacao = usuario_modificacao;
            this.data_de_modificacao = data_de_modificacao;
            this.data_de_criacao = data_de_criacao;
        }

        public string Id { get => id; set => id = value; }
        public string Id_Usuarios { get => id_Usuarios; set => id_Usuarios = value; }
        public string Data { get => data; set => data = value; }
        public string Legenda { get => legenda; set => legenda = value; }
        public string Periodo { get => periodo; set => periodo = value; }

        public string Data_de_criacao { get => data_de_criacao; set => data_de_criacao = value; }
        public string Data_de_modificacao { get => data_de_modificacao; set => data_de_modificacao = value; }
        public string Usuario_modificacao { get => usuario_modificacao; set => usuario_modificacao = value; }

        public static string Cadastrar(string id_Usuarios, string data, string legenda, string periodo, string usuario_modificacao, string data_de_modificacao, string data_de_criacao)
        {

            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("INSERT INTO Cronograma(id_Usuarios,data1,legenda,periodo,usuario_modificacao,data_de_modificacao,data_de_criacao) VALUES(@id_Usuarios,@data,@legenda,@periodo,@usuario_modificacao,@data_de_modificacao,@data_de_criacao);", con);

                var date = DateTime.Now;

                data_de_criacao = String.Format("{0:yyyy-MM-dd HH:mm:ss}", date);
                data_de_modificacao = String.Format("{0:yyyy-MM-dd HH:mm:ss}", date);
                qry.Parameters.AddWithValue("@id_Usuarios", id_Usuarios);
                qry.Parameters.AddWithValue("@data", data);
                qry.Parameters.AddWithValue("@legenda", legenda);
                qry.Parameters.AddWithValue("@periodo", periodo);
                qry.Parameters.AddWithValue("@usuario_modificacao", usuario_modificacao);
                qry.Parameters.AddWithValue("@data_de_modificacao", data_de_modificacao);
                qry.Parameters.AddWithValue("@data_de_criacao", data_de_criacao);
                qry.ExecuteNonQuery();
                return "Cronograma cadastrado com sucesso";
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

        public static string Editar(string id,string legenda,string usuario_modificacao, string data_de_modificacao)
        {
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("UPDATE Cronograma SET legenda = @legenda,data_de_modificacao = @data_de_modificacao, usuario_modificacao = @usuario_modificacao" +
                    " WHERE id = @id", con);

                var date = DateTime.Now;
                data_de_modificacao = String.Format("{0:yyyy-MM-dd HH:mm:ss}", date);
                qry.Parameters.AddWithValue("@id", id);       
                qry.Parameters.AddWithValue("@legenda", legenda);               
                qry.Parameters.AddWithValue("usuario_modificacao", usuario_modificacao);
                qry.Parameters.AddWithValue("data_de_modificacao", data_de_modificacao);

                qry.ExecuteNonQuery();


                return "Usuário Editado com Sucesso";
            }
            catch (Exception e)
            {
                return "Erro:" + e;
            }
            finally
            {
                con.Close();
            }
        }

        public static List<Cronograma> Listar(string mes,string ano,string id_Cargo,string periodo)
        {
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("SELECT usuarios.nome,cronograma.id_Usuarios,cronograma.legenda,cronograma.id AS cronoID," +
                    "cronograma.data1,usuarios.id,cronograma.usuario_modificacao,cronograma.data_de_modificacao FROM Cronograma " +
                    "INNER JOIN Usuarios WHERE MONTH(cronograma.data1) = @mes AND YEAR(cronograma.data1) = @ano AND usuarios.id = cronograma.id_Usuarios" +
                    " AND usuarios.id_Cargo = @id_Cargo AND cronograma.periodo = @periodo ORDER BY usuarios.nome,cronograma.id;", con);
                qry.Parameters.AddWithValue("@mes", mes);
                qry.Parameters.AddWithValue("@ano", ano);
                qry.Parameters.AddWithValue("@id_Cargo", id_Cargo);
                qry.Parameters.AddWithValue("@periodo", periodo);

                MySqlDataReader leitor = qry.ExecuteReader();
                List<Cronograma> lista = new List<Cronograma>();
                while (leitor.Read())
                {
                    Cronograma cronograma = new Cronograma(leitor["cronoID"].ToString(), leitor["id_Usuarios"].ToString(),
                       leitor["data1"].ToString(), leitor["legenda"].ToString(), "", leitor["usuario_modificacao"].ToString(),
                        leitor["data_de_modificacao"].ToString(), "");
                    lista.Add(cronograma);


                }
                return lista;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

 

    }
}