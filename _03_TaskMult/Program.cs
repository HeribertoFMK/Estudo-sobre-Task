using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace _03_TaskMult
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> lista = new List<Task>();
            lista.Add(Task.Factory.StartNew(Metodo01));
            lista.Add(Task.Factory.StartNew(Metodo01));
            lista.Add(Task.Factory.StartNew(Metodo01));
            lista.Add(Task.Factory.StartNew(Metodo01));

            Task.WaitAny(lista.ToArray());

            Console.WriteLine("Programa Finalizado");
            Console.ReadKey();

            WebClient web = new WebClient();
            string[] enderecos = new string[] {"https://www.google.com.br/","https://www.facebook.com/"};
            var listaEnd = from end in enderecos select DownloadPagina(end);
            Task.WaitAll(listaEnd.ToArray());

        }
        static void Metodo01()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Valor" + i  + " TaskId: "  + Task.CurrentId);
            }
        }
        public static async Task DownloadPagina(string end)
        {
            WebClient web = new WebClient();
            string html = await web.DownloadStringTaskAsync(end);
            Console.WriteLine("Downlaod Realizado para pagina: " + end);
        }
    }
}
