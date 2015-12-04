using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilizandoYield
{
    class Program
    {
        static void Main(string[] args)
        {
            var pessoa = new Pessoa();

            var cronometro = new Stopwatch();
            cronometro.Start();
            IEnumerable<string> colecao = PopulaColecaoNormal(pessoa);
            cronometro.Stop();

            var tempoColecaoNormal = cronometro.Elapsed;
            cronometro.Reset();

            cronometro.Start();
            IEnumerable<string> colecaoYield = PopulaColecaoYield(pessoa);
            cronometro.Stop();

            var tempoColecaoYield = cronometro.Elapsed;

            Console.WriteLine("Tempo de execução para coleção: " + tempoColecaoNormal);
            Console.Write(Environment.NewLine);
            Console.WriteLine("Tempo de execução para coleção yield: " + tempoColecaoYield);
            Console.ReadKey();
        }

        public struct Pessoa
        {
            public string Nome { get; set; }
            public string Email { get; set; }
        }

        public static IEnumerable<string> RetornaEmails(IEnumerable<Pessoa> pessoas)
        {
            List<string> lista = new List<string>();
            foreach (Pessoa pessoa in pessoas)
            {
                if (!string.IsNullOrEmpty(pessoa.Email))
                    lista.Add(pessoa.Email);
            }
            return lista;
        }

        public static IEnumerable<string> RetornaEmailsUsandoYield(IEnumerable<Pessoa> pessoas)
        {
            foreach (Pessoa pessoa in pessoas)
            {
                if (!string.IsNullOrEmpty(pessoa.Email))
                    yield return pessoa.Email;
            }
            yield break;
        }

        private static IEnumerable<string> PopulaColecaoNormal(Pessoa pessoa)
        {
            var lista = new List<string>();

            if (string.IsNullOrEmpty(pessoa.Nome))
                lista.Add("Nome é obrigatório");

            if (string.IsNullOrEmpty(pessoa.Email))
                lista.Add("Email é obrigatório");

            return lista;
        }
        private static IEnumerable<string> PopulaColecaoYield(Pessoa pessoa)
        {
            if (string.IsNullOrEmpty(pessoa.Nome))
                yield return "Nome é obrigatório";

            if (string.IsNullOrEmpty(pessoa.Email))
                yield return "Email é obrigatório";

            yield break;
        }
    }
}
