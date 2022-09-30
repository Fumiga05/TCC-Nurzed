using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Nurzed.Models
{
    public class Area
    {
        private string id, nome, status1;
        static MySqlConnection con = new MySqlConnection("server=localhost;database=vct;user id=teste;password=12345678");

        public Area(string id, string nome, string status1)
        {
            this.id = id;
            this.nome = nome;
            this.status1 = status1;
        }

        public string Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Status1 { get => status1; set => status1 = value; }

        public string Cadastrar()
        {
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("INSERT INTO Area VALUES(@id,@nome,'ativado')", con);

                qry.Parameters.AddWithValue("@id", id);
                qry.Parameters.AddWithValue("@nome", nome);
                qry.Parameters.AddWithValue("@status1", status1);

                qry.ExecuteNonQuery();

                return "Area cadastrada com sucesso";

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
        public static List<Area> Listar()
        {
            List<Area> lista = new List<Area>();
            int i = 0;
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("SELECT * FROM Area ORDER BY nome", con);

                MySqlDataReader leitor = qry.ExecuteReader();

                while (leitor.Read())
                {
                    Area area = new Area(leitor["id"].ToString(), leitor["nome"].ToString(), leitor["status1"].ToString());
                    lista.Add(area);
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


