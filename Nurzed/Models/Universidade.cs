using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Nurzed.Models
{
    public class Universidade
    {

        private string id,nome,sigla;
        static MySqlConnection con = new MySqlConnection("server=localhost;database=vct;user id=teste;password=12345678");

        public Universidade(string id,string nome,string sigla)
        {
            this.id = id;
            this.nome = nome;
            this.sigla = sigla;
        }

       
        public string Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Sigla { get => sigla; set => sigla = value; }

        public string Cadastrar()
        {
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("INSERT INTO Universidade VALUES(@id,@nome,@sigla);",con);
                qry.Parameters.AddWithValue("@id", id);
                qry.Parameters.AddWithValue("@nome", nome);
                qry.Parameters.AddWithValue("@sigla", sigla);
                qry.ExecuteNonQuery();
                return "Usuário cadastrado com sucesso";
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

        public static List<Universidade> Listar()
        {

            List<Universidade> lista = new List<Universidade>();
            
            int i = 0;
            try
            {
                con.Open();

                MySqlCommand qry = new MySqlCommand("SELECT * FROM Universidade ORDER BY nome", con);

                MySqlDataReader leitor = qry.ExecuteReader();

                while (leitor.Read())
                {
                    Universidade universidade = new Universidade(leitor["id"].ToString(), leitor["nome"].ToString(), leitor["sigla"].ToString());
                    lista.Add(universidade);                   
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
