using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Nurzed.Models
{
    public class Especialidade
    {
        private string id, nome,nome_Area;
        static MySqlConnection con = new MySqlConnection("server=localhost;database=vct;user id=teste;password=12345678");

        public Especialidade(string id, string nome,string nome_Area)
        {
            this.id = id;
            this.nome = nome;
            this.nome_Area = nome_Area;
        }

        public string Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Nome_Area { get => nome_Area; set => nome_Area = value; }

        public string Cadastrar()
        {
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("INSERT INTO Especialidade VALUES(@id,@nome,'ativado',@nome_Area)", con);

                qry.Parameters.AddWithValue("@id",id);
                qry.Parameters.AddWithValue("@nome",nome);
                qry.Parameters.AddWithValue("@nome_Area",nome_Area);
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
            
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("SELECT * FROM Especialidade ORDER BY nome_Area, nome;", con);

                MySqlDataReader leitor = qry.ExecuteReader();

                while (leitor.Read())
                {
                    Especialidade especialidade = new Especialidade(leitor["id"].ToString(), leitor["nome"].ToString(), leitor["nome_Area"].ToString());
                    lista.Add(especialidade);
                    
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

