using System;

namespace Nurzed.Models
{
    public class Plantao
    {
        private string nome;
        private int numeroDoMes, qtdDias;

        public Plantao(string nome, int numeroDoMes, int qtdDias)
        {
            this.nome = nome;
            this.numeroDoMes = numeroDoMes;
            this.qtdDias = qtdDias;
        }

        public string Nome { get => nome; set => nome = value; }
        public int NumeroDoMes { get => numeroDoMes; set => numeroDoMes = value; }
        public int QtdDias { get => qtdDias; set => qtdDias = value; }


        public string NomeMes()
        {

            //pega a data atual
            //DateTime dateAndTime = new DateTime(2003, 5, 1);
            var dateAndTime = DateTime.Now;
            var Date = dateAndTime.ToShortDateString();

            //data em lista
            string s = Date;
            string[] subs = s.Split('/');


            //total de dias de um mes
            int dias = DateTime.DaysInMonth(2020, 2);

            //dia da semana , DayOfweek presisa de uma data com horario 
            var diaSemana = dateAndTime.DayOfWeek;



            String[] meses = { "JANEIRO", "FEVEREIRO", "MARÇO", "ABRIL", "MAIO", "JUNHO", "JULHO", "AGOSTO", "SETEMBRO", "OUTUBRO", "NOVEMBRO", "DEZEMBRO" };


            //variavel mes
            int Numeromes = int.Parse(subs[1]) - 1;
            String mes = meses[Numeromes];
            return mes;
        }


        }
    }
