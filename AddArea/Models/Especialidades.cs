using System;
using MySql.Data.MySqlClient;



using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddArea.Models {
    public class Especialidades {

        static string conex = "Server=ESN509VMYSQL;Database=vct;User id=aluno;Password=Senai1234";

        private int nomearea;
        private string cpfgestor;

        public Especialidades(int nomearea, string cpfgestor) {
            this.nomearea = nomearea;
            this.cpfgestor = cpfgestor;
        }

        public int Nomearea { get => nomearea; set => nomearea = value; }
        public string Cpfgestor { get => cpfgestor; set => cpfgestor = value; }

        //cadastro de Produtos



        public static Especialidades Cadastrar(string nomearea, string cpfgestor) {




            MySqlConnection con = new MySqlConnection(conex);

          
                con.Open();
          
            MySqlCommand com = new MySqlCommand("INSERT INTO area (nomearea, cpfgestor)VALUES (@nomearea, @cpfgestor)", con);
            com.Parameters.AddWithValue("@nomearea", nomearea);
            com.Parameters.AddWithValue("@cpfgestor", cpfgestor);
           


                com.ExecuteNonQuery();
                con.Close();


            return null;

          
             
            
            
              




            
        }
    }
}
