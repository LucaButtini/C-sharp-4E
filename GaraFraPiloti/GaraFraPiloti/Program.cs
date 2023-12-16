using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;

namespace GaraFraPiloti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "FORMULA 1";
            Console.Title = s;
            int choice;
            Gara gara = new Gara(3, " ");
            gara.Circuito = "Gran premio";
            Console.ForegroundColor = ConsoleColor.White;
            string[] opzioni = { "Inserimento", "Visualizza", "Vincitore", "Esci" };
            do
            {
                Menu(opzioni);
                Console.WriteLine("Che scelta vuoi fare?");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Inserimento");
                        if (gara.NumPiloti() < 3)
                            Inserimento(gara);
                        else
                            Console.WriteLine("Circuito al completo");
                        break;
                    case 2:
                        //Console.WriteLine("Visualizza");
                        //Console.WriteLine("==={0}===", gara.Circuito);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("========================================");
                        Console.WriteLine("GARA: [{0}], PARTECIPANTI: [{1}]", gara.Circuito, gara.NumPiloti());
                        Console.WriteLine("========================================");
                        Console.ForegroundColor = ConsoleColor.White;
                        gara.Griglia();
                        break;
                    case 3:
                        Console.WriteLine("Vincitore");
                        Console.WriteLine("Vincitore gara [{0}]", gara.Circuito);
                        gara.GetVincitore();
                        break;
                    case 4:
                        Console.WriteLine("Fine");
                        break;
                }
                if (choice != 4)
                {
                    Console.WriteLine("Premi invio per uscire");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (choice != 4);


            Console.ReadLine();
        }
        static void Inserimento(Gara g)
        {
            Pilota p = new Pilota(" ", " ");
            Auto a = new Auto(" ", p);
            Console.Write("Inserisci nome pilota: ");
            p.Nome = Console.ReadLine();
            Console.Write("Inserisci cognome pilota: ");
            p.Cognome = Console.ReadLine();
            Console.Write("Inserisci scuderia: ");
            a.Scuderia = Console.ReadLine();
            g.Aggiungi(a);
        }
        static void Menu(string[] opt)
        {
            for (int i = 0; i < opt.Length; i++)
            {
                Console.WriteLine("[{0}] {1}", i + 1, opt[i]);
            }
        }
    }
}
