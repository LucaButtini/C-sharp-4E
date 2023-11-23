using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ZooDiCasaMia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AnimaleDomestico a = new AnimaleDomestico();
            int choice;
            List<AnimaleDomestico> animali = new List<AnimaleDomestico>();

            do
            {
                Console.WriteLine("[1] Inserimento");
                Console.WriteLine("[2] Visualizza");
                Console.WriteLine("[3] Esci\n");
                Console.WriteLine("Scegli un'opzione");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("==Inserimento==");
                        Inserimento(animali, a);
                        break;
                    case 2:
                        Console.WriteLine("==Visualizza==");
                        Visualizza(animali);
                        break;
                    case 3:
                        Console.WriteLine("Fine programma");
                        break;
                    default:
                        Console.WriteLine("Scelta errata reinserire");
                        break;
                }
                if (choice != 3)
                {
                    Console.WriteLine("Premi invio per uscire");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (choice != 3);
        }
        static void Inserimento(List<AnimaleDomestico> animali, AnimaleDomestico a)
        {
            Console.WriteLine("Inserisci specie");
            a.SetSpecie(Console.ReadLine());
            Console.WriteLine("Inserisci razza");
            a.SetRazza(Console.ReadLine());
            Console.WriteLine("Inserisci cibo");
            a.SetCibo(Console.ReadLine());
            Console.WriteLine("Inserisci quantita cibo");
            a.SetQuantita(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Inserisci verso");
            a.SetVerso(Console.ReadLine());
            mangiato statoMangiato = MenuStatoMangiato();
            a.SetMangiato(statoMangiato);

            animali.Add(a);
        }

        static void Visualizza(List<AnimaleDomestico> animali)
        {
            for (int i = 0; i < animali.Count; i++)
            {
                Console.WriteLine("Animale {0}:", i + 1);
                Console.WriteLine("Specie: {0}", animali[i].GetSpecie());
                Console.WriteLine("Razza: {0}", animali[i].GetRazza());
                Console.WriteLine("Cibo: {0}", animali[i].GetCibo());
                Console.WriteLine("Quantita Cibo: {0}", animali[i].GetQuantita());
                Console.WriteLine("Verso: {0}", animali[i].GetVerso());
                Console.WriteLine("Stato Mangiato: {0}", animali[i].GetMangiato());
                Console.WriteLine();
            }
        }
        static mangiato MenuStatoMangiato()
        {
            int scelta = 0;
            string[] statoMangiatoOpzioni = Enum.GetNames(typeof(mangiato));

            Console.WriteLine("Scegli uno stato di mangiato:");
            for (int i = 0; i < statoMangiatoOpzioni.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {statoMangiatoOpzioni[i]}");
            }

            Console.WriteLine("Che scelta vuoi fare?");
            int.TryParse(Console.ReadLine(), out scelta);

            while (scelta < 1 || scelta > statoMangiatoOpzioni.Length)
            {
                Console.WriteLine("Inserisci un'opzione valida");
                int.TryParse(Console.ReadLine(), out scelta);
            }

            return (mangiato)Enum.Parse(typeof(mangiato), statoMangiatoOpzioni[scelta - 1]);
        }
    }
}