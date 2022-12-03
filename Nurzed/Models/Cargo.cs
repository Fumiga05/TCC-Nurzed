using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Nurzed.Models
{
    public class Cargo
    {

        private string id, nome;
        static MySqlConnection con = new MySqlConnection("server=localhost;database=vct;user id=root;password=TJBghjkFGYUI842");

        public Cargo(string id, string nome)
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

                MySqlCommand qry = new MySqlCommand("INSERT INTO Cargo VALUES(@id,@nome)",con);

                qry.Parameters.AddWithValue("@id", id);
                qry.Parameters.AddWithValue("@nome", nome);
                qry.ExecuteNonQuery();

                return "Cargo cadastrado com sucesso";


            }catch(Exception e)
            {
                return "Erro: " + e;
            }
            finally
            {
                con.Close();
            }
        }
        public static List<Cargo> Listar()
        {
            List<Cargo> lista = new List<Cargo>();

            int i = 0;

            try
            {
                con.Open();

                MySqlCommand qry = new MySqlCommand("SELECT * FROM Cargo ORDER BY nome", con);

                MySqlDataReader leitor = qry.ExecuteReader();

                while (leitor.Read())
                {
                    Cargo cargo = new Cargo(leitor["id"].ToString(), leitor["nome"].ToString());
                    lista.Add(cargo);
                    i++;
                }

                leitor.Close();

                return lista;

            }
            catch(Exception e) {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
