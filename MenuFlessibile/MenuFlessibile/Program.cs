using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFlessibile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int scelta = 0;
            string[] opzioni = { "Inserimento", "Ricerca", "Visualizza", "Modifica", "Elimina", "Exit" };
            do
            {
                Console.WriteLine("====================");
                Menu(opzioni, out scelta);
                Console.WriteLine("====================");
            } while (scelta != 6);
            switch (scelta)
            {
                case 1:
                    Console.WriteLine(opzioni[0]);
                    break;
                case 2:
                    Console.WriteLine(opzioni[1]);
                    break;
                case 3:
                    Console.WriteLine(opzioni[2]);
                    break;
                case 4:
                    Console.WriteLine(opzioni[3]);
                    break;
                case 5:
                    Console.WriteLine(opzioni[4]);
                    break;
                case 6:
                    Console.WriteLine(opzioni[5]);
                    break;
            }
            Console.ReadLine();
        }

        static void Menu(string[] opzioni, out int scelta)
        {
            for (int i = 0; i < opzioni.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {opzioni[i]}");
            }

            Console.WriteLine("Che scelta vuoi fare");
            int.TryParse(Console.ReadLine(), out scelta);
            //se è != da intero mette 0
            while (scelta < 1 || scelta > opzioni.Length)
            {
                Console.WriteLine("Inserisci un opzione valida");
                int.TryParse(Console.ReadLine(), out scelta);
            }
        }
    }
}
