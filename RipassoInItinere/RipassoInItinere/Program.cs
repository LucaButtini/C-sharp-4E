using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RipassoInItinere
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*umeroPosti numeroPosti = new numeroPosti();*/
            Flotte flotta = new Flotte("FLOTTA");
            Governo autorizzazione = new Governo();
            flotta.Autorizzazione = autorizzazione.GeneraAutorizzazione();
            int choice, code = 1;
            string[] opzioni = { "Inserimento", "Visualizza", "Ricerca", "Esci" };
            do
            {
                Menu(opzioni);
                Console.WriteLine("Che scelta vuoi fare?");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("===Inserimento===");
                        Inserimento(flotta, ref code);
                        break;
                    case 2:
                        Console.WriteLine("===Visualizza===");
                        Console.WriteLine("Autorizzazione Statale: [{0}]", flotta.Autorizzazione);
                        flotta.Stampa();
                        break;
                    case 3:
                        Console.WriteLine("===Ricerca===");
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
        }
        static int SceltaPosti()
        {
            int scelta = 0;
            string[] posti = Enum.GetNames(typeof(numeroPosti));
            for (int i = 0; i < posti.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {posti[i]}");
            }
            Console.WriteLine("Che scelta vuoi fare");
            int.TryParse(Console.ReadLine(), out scelta);
            while (scelta < 1 || scelta > posti.Length)
            {
                Console.WriteLine("Inserisci un opzione valida");
                int.TryParse(Console.ReadLine(), out scelta);
            }
            return scelta;
        }
        static void Inserimento(Flotte f, ref int code)
        {
            Governo targa = new Governo();
            Veicolo v = new Veicolo();
            v.Targa = targa.GeneraTarga();
            Console.Write("Inserisci marca: ");
            v.Marca = Console.ReadLine();
            Console.Write("Inserisci modello: ");
            v.Modello = Console.ReadLine();
            Console.WriteLine("Inserisci il numero di posti:");
            switch (SceltaPosti())
            {
                case 1:
                    v.Posti = numeroPosti.due;
                    break;
                case 2:
                    v.Posti = numeroPosti.quattro;
                    break;
                case 3:
                    v.Posti = numeroPosti.cinque;
                    break;
                case 4:
                    v.Posti = numeroPosti.otto;
                    break;
            }
            v.Codice = code++;
            f.Aggiungi(v);
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
