

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Nurzed.Models
{
    public class Curso
    {
        private string id,nome;
        static MySqlConnection con = new MySqlConnection("server=localhost;database=vct;user id=teste;password=12345678");

        public Curso(string id,string nome)
        {   
            this.id = id;
            this.nome = nome;
        }

        public string Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }

        public string Cadastrar()
        {
            try
            {
                con.Open();

                MySqlCommand qry = new MySqlCommand("INSERT INTO Curso(nome) VALUES (@nome)", con);

                qry.Parameters.AddWithValue("@nome", nome);
                qry.ExecuteNonQuery();
                return "Curso cadastrado com sucesso";

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
        public static List<Curso> Listar()
        {

            List<Curso> lista = new List<Curso>();

            int i = 0;
            try
            {
                con.Open();

                MySqlCommand qry = new MySqlCommand("SELECT * FROM Curso ORDER BY nome", con);

                MySqlDataReader leitor = qry.ExecuteReader();

                while (leitor.Read())
                {
                    Curso curso = new Curso(leitor["id"].ToString(),leitor["nome"].ToString());
                    lista.Add(curso);
                    i++;
                }

                leitor.Close();

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
