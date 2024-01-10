using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RipassoInItinere
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Autonoleggio";
            Flotte flotta = new Flotte("FLOTTA");
            Governo autorizzazione = new Governo();
            flotta.Autorizzazione = autorizzazione.GeneraAutorizzazione();
            int choice = 0, code = 1, temp = 0, disp = 0;
            string t = " ";
            numeroPosti p = new numeroPosti();
            string[] opzioni = { "Inserimento", "Visualizza", "Elimina", "Ricerca", "Veicoli disponibili", "Ricerca posti", "Esci" };
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

                        Console.WriteLine("===Elimina===\n");
                        //Search(temp, choice, t);
                        Console.WriteLine("[1] Targa");
                        Console.WriteLine("[2] Codice");
                        Console.Write("Con cosa vuoi effetturare la ricerca? -> ");
                        int.TryParse(Console.ReadLine(), out choice);
                        while (choice < 1 || choice > 2)
                        {
                            Console.WriteLine("Inserisci un opzione valida");
                            int.TryParse(Console.ReadLine(), out choice);
                        }
                        if (choice == 1)
                        {
                            Console.Write("Inserisci la targa del veicolo da ricercare: ");
                            t = Console.ReadLine();
                        }
                        else
                        {
                            Console.Write("Inserisci codice del veicolo da ricercare: ");
                            int.TryParse(Console.ReadLine(), out temp);
                        }
                        if (flotta.Elimina(temp, t) == 0)
                            Console.WriteLine("Nessun elemento presente con questa targa o codice");
                        break;
                    case 4:

                        Console.WriteLine("===Ricerca===");
                        Console.WriteLine("[1] Targa");
                        Console.WriteLine("[2] Codice");
                        Console.Write("Con cosa vuoi effetturare la ricerca? -> ");
                        int.TryParse(Console.ReadLine(), out choice);
                        while (choice < 1 || choice > 2)
                        {
                            Console.WriteLine("Inserisci un opzione valida");
                            int.TryParse(Console.ReadLine(), out choice);
                        }
                        if (choice == 1)
                        {
                            Console.Write("Inserisci la targa del veicolo da ricercare: ");
                            t = Console.ReadLine();
                        }
                        else
                        {
                            Console.Write("Inserisci codice del veicolo da ricercare: ");
                            int.TryParse(Console.ReadLine(), out temp);
                        }
                        //Search(temp, choice, t);
                        Veicolo veicoloRicercato = flotta.Ricerca(temp, t);
                        if (veicoloRicercato != null)
                        {
                            Console.WriteLine("Informazioni del veicolo trovato:");
                            Console.WriteLine(veicoloRicercato);
                        }
                        else
                        {
                            Console.WriteLine("Nessun veicolo trovato con questa targa o codice.");
                        }
                        break;
                    case 5:
                        Console.WriteLine("===Veicoli disponibili===");
                        Console.Write("Inserisci marca veicoli da ricercare: ");
                        t = Console.ReadLine();
                        Console.WriteLine("MARCA: {0}, DISPONIBILITA': {1} elementi", t, flotta.Disponibili(t));
                        //for (int i = 1; i < code; i++)
                        //{
                        //    Console.WriteLine("MARCA: {0}, DISPONIBILITA': {1} elementi", t, flotta.Disponibili(t));
                        //}
                        break;
                    case 6:
                        Console.WriteLine("===Numero veicoli per posti===");
                        Console.WriteLine("Inserisci il numero di posti:");

                        switch (SceltaPosti())
                        {
                            case 1:
                                disp = flotta.RicercaPosti(numeroPosti.due_posti);
                                break;
                            case 2:
                                disp = flotta.RicercaPosti(numeroPosti.quattro_posti);
                                break;
                            case 3:
                                disp = flotta.RicercaPosti(numeroPosti.cinque_posti);
                                break;
                            case 4:
                                disp = flotta.RicercaPosti(numeroPosti.otto_posti);
                                break;
                        }
                        Console.WriteLine("Veicoli disponibili {0}", disp);
                        break;
                    case 7:
                        Console.WriteLine("Fine");
                        break;
                }
                if (choice != 7)
                {
                    Console.WriteLine("Premi invio per uscire");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (choice != 7);
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
                    v.Posti = numeroPosti.due_posti;
                    break;
                case 2:
                    v.Posti = numeroPosti.quattro_posti;
                    break;
                case 3:
                    v.Posti = numeroPosti.cinque_posti;
                    break;
                case 4:
                    v.Posti = numeroPosti.otto_posti;
                    break;
            }
            v.Codice = code++;
            f.Aggiungi(v);
            ScriviFile(Path.Combine(Environment.CurrentDirectory, "logbin", "log.txt"), v.ToString());
        }

        static void Menu(string[] opt)
        {
            for (int i = 0; i < opt.Length; i++)
            {
                Console.WriteLine("[{0}] {1}", i + 1, opt[i]);
            }
        }
        static void ScriviFile(string path, string stringa)
        {
            StreamWriter sw = File.AppendText(path);
            sw.WriteLine(DateTime.Now.ToString() + " " + stringa);
            sw.Close();
        }
        /*static void Search(int temp, int choice, string t)
        {
            Console.WriteLine("[1] Targa");
            Console.WriteLine("[2] Codice");
            Console.Write("Con cosa vuoi effetturare la ricerca? -> ");
            int.TryParse(Console.ReadLine(), out choice);
            while (choice < 1 || choice > 2)
            {
                Console.WriteLine("Inserisci un opzione valida");
                int.TryParse(Console.ReadLine(), out choice);
            }
            if (choice == 1)
            {
                Console.Write("Inserisci la targa del veicolo da ricercare: ");
                t = Console.ReadLine();
            }
            else
            {
                Console.Write("Inserisci codice del veicolo da ricercare: ");
                int.TryParse(Console.ReadLine(), out temp);
            }
        }*/

    }
}
