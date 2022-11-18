using MySql.Data.MySqlClient;
using System;

namespace Nurzed.Models
{
    public class Plantao
    {
        private string nome;
        private int numeroDoMes, qtdDias;
        static MySqlConnection con = new MySqlConnection("server=localhost;database=vct;user id=teste;password=12345678");

        public Plantao(string nome, int numeroDoMes, int qtdDias)
        {
            this.nome = nome;
            this.numeroDoMes = numeroDoMes;
            this.qtdDias = qtdDias;
        }

        public string Nome { get => nome; set => nome = value; }
        public int NumeroDoMes { get => numeroDoMes; set => numeroDoMes = value; }
        public int QtdDias { get => qtdDias; set => qtdDias = value; }


       


        }
    }
