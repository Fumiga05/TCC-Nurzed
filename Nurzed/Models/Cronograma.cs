using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Nurzed.Models
{
    public class Cronograma
    {
        private string id, id_Usuarios, legenda,periodo, data;
       
        public static MySqlConnection con = new MySqlConnection("server=localhost;database=vct;user id=teste;password=12345678");

        public Cronograma(string id, string id_Usuarios,string data, string legenda,string periodo)
        {
            this.id = id;
            this.id_Usuarios = id_Usuarios;
            this.data = data;
            this.legenda = legenda;
            this.periodo = periodo;
           
        }

        public string Id { get => id; set => id = value; }
        public string Id_Usuarios { get => id_Usuarios; set => id_Usuarios = value; }
        public string Data { get => data; set => data = value; }
        public string Legenda { get => legenda; set => legenda = value; }
        public string Periodo { get => periodo; set => periodo = value; }      
        
        public static string Cadastrar(string id,string id_Usuarios,string data,string legenda,string periodo)
        {
            
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("INSERT INTO Cronograma(id_Usuarios,data1,legenda,periodo) VALUES(@id_Usuarios,@data,@legenda,@periodo);", con);
                qry.Parameters.AddWithValue("@id_Usuarios", id_Usuarios);
                qry.Parameters.AddWithValue("@data",data);
                qry.Parameters.AddWithValue("@legenda", legenda);
                qry.Parameters.AddWithValue("@periodo", periodo);
                qry.ExecuteNonQuery();
                return "Cronograma Cadastrado com sucesso";
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
    }



  
}
