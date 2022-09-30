using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Nurzed.Models
{
    public class Especialidade
    {
        private string id, nome;
        static MySqlConnection con = new MySqlConnection("server=localhost;database=vct;user id=teste;password=12345678");

        public Especialidade(string id, string nome)
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
                MySqlCommand qry = new MySqlCommand("INSERT INTO Especialidade VALUES(@id,@nome,'ativado')", con);

                qry.Parameters.AddWithValue("@id",id);
                qry.Parameters.AddWithValue("@nome",nome);

                qry.ExecuteNonQuery();

                return "Especialidade cadastrada com sucesso";

            }catch(Exception e)
            {
                return "Erro: " + e;
            }
            finally
            {
                con.Close();
            }
        }
        public static List<Especialidade> Listar()
        {
            List<Especialidade> lista = new List<Especialidade>();
            int i =  0;
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("SELECT * FROM Especialidade ORDER BY nome",con);

                MySqlDataReader leitor = qry.ExecuteReader();

                while (leitor.Read())
                {
                    Especialidade especialidade = new Especialidade(leitor["id"].ToString(), leitor["nome"].ToString());
                    lista.Add(especialidade);
                    i++;
                }
                    leitor.Close();
                    return lista;

            }catch(Exception e)
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
