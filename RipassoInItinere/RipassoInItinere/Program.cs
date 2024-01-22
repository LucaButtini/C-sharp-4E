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
            Flotte flotta = new Flotte("FLOTTA 1");
            flotta.Autorizzazione = Governo.GeneraAutorizzazione();
            int choice = 0, temp = 0, disponibili = 0;
            string t = " ";
            string[] opzioni = { "Inserimento", "Visualizza", "Elimina", "Ricerca", "Veicoli disponibili", "Ricerca posti", "Esci" };
            string[] posti = Enum.GetNames(typeof(numeroPosti));
            do
            {
                StampaMenu(opzioni);
                Console.WriteLine("Che scelta vuoi fare?");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("===Inserimento===");
                        Console.Write("Inserisci marca: ");
                        string marca = Console.ReadLine();
                        Console.Write("Inserisci modello: ");
                        string modello = Console.ReadLine();
                        string targa = Governo.GeneraTarga();
                        Console.WriteLine("Inserisci il numero di posti:");
                        StampaMenu(posti);
                        int sceltaPosti = Search(posti.Length);
                        Inserimento(flotta, marca, modello, (numeroPosti)sceltaPosti, targa);
                        break;
                    case 2:
                        Console.WriteLine("===Visualizza===");
                        Console.WriteLine("[{0}]", flotta.Nome);
                        Console.WriteLine("Autorizzazione Statale: [{0}]", flotta.Autorizzazione);
                        flotta.Stampa();
                        break;
                    case 3:
                        Console.WriteLine("===Elimina===");
                        Console.WriteLine("[1] Targa");
                        Console.WriteLine("[2] Codice");
                        Console.Write("Con cosa vuoi effetturare la ricerca? -> ");
                        if (Search(2) == 1)
                        {
                            Console.Write("Inserisci la targa del veicolo da eliminare: ");
                            t = Console.ReadLine();
                        }
                        else
                        {
                            Console.Write("Inserisci codice del veicolo da eliminare: ");
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
                        if (Search(2) == 1)
                        {
                            Console.Write("Inserisci la targa del veicolo da ricercare: ");
                            t = Console.ReadLine();
                        }
                        else
                        {
                            Console.Write("Inserisci codice del veicolo da ricercare: ");
                            int.TryParse(Console.ReadLine(), out temp);
                        }
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
                        break;
                    case 6:
                        Console.WriteLine("===Numero veicoli per posti===");
                        Console.WriteLine("Inserisci il numero di posti:");
                        StampaMenu(posti);
                        switch (Search(posti.Length))
                        {
                            case 1:
                                disponibili = flotta.RicercaPosti(numeroPosti.due_posti);
                                break;
                            case 2:
                                disponibili = flotta.RicercaPosti(numeroPosti.quattro_posti);
                                break;
                            case 3:
                                disponibili = flotta.RicercaPosti(numeroPosti.cinque_posti);
                                break;
                            case 4:
                                disponibili = flotta.RicercaPosti(numeroPosti.otto_posti);
                                break;
                        }
                        Console.WriteLine("Veicoli disponibili {0}", disponibili);
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

        static void Inserimento(Flotte f, string marca, string modello, numeroPosti nPosti, string targa)
        {
            Veicolo v;
            try
            {
                v = new Veicolo(marca, modello, nPosti, targa);
            }
            catch (Exception ex)
            {
                v = null;
                Console.WriteLine(ex.Message);
            }

            f.Aggiungi(v);
            ScriviFile(Path.Combine(Environment.CurrentDirectory, "logbin", "log.txt"), v.ToString());
        }

        static void StampaMenu(string[] opt)
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

        static int Search(int max)
        {
            int choice;

            int.TryParse(Console.ReadLine(), out choice);
            while (choice < 1 || choice > max)
            {
                Console.WriteLine("Inserisci un opzione valida");
                int.TryParse(Console.ReadLine(), out choice);
            }
            return choice;
        }
    }
}
