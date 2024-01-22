using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PerVerificaClassi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int m = 0, choice, sceltaRicerca;
            string c = "";
            string[] menu = { "INSERISCI", "VISUALIZZA", "ELIMINA", "RICERCA", "LISTA AZIONI", "ESCI" };
            string[] menuRicerca = { "COGNOME", "MATRICOLA" };
            string[] azioniArray = Enum.GetNames(typeof(azioni));
            BellinazziCo Belloduro = new BellinazziCo("bellinazzi");
            do
            {
                Menu(menu);
                Console.WriteLine("che scelta vuoi fare");
                choice = Scelta(menu.Length);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("inserimento");
                        Console.WriteLine("inserisci nome");
                        string nome = Console.ReadLine();
                        Console.WriteLine("inserisci cognome");
                        string cognome = Console.ReadLine();
                        Console.WriteLine("inserisci azione");
                        Menu(azioniArray);
                        int azione = Scelta(azioniArray.Length) - 1;
                        string codice = Governo.GeneraCodice();
                        Inserimento(nome, cognome, codice, (azioni)azione, Belloduro);
                        break;
                    case 2:
                        Console.WriteLine("visualizza");
                        Belloduro.Stampa();
                        break;
                    case 3:
                        Console.WriteLine("elimina");
                        Menu(menuRicerca);
                        Console.WriteLine("Con cosa vuoi effettuare la ricerca?");
                        sceltaRicerca = Scelta(menuRicerca.Length);
                        if (sceltaRicerca == 1)
                        {
                            Console.WriteLine("Inserisci cognome della persona da cercare");
                            c = Console.ReadLine();
                        }
                        else if (sceltaRicerca == 2)
                        {
                            Console.WriteLine("Inserisci matricola persona da ricercare");
                            int.TryParse(Console.ReadLine(), out m);
                        }
                        if (Belloduro.Cancella(c, m) == 0)
                        {
                            Console.WriteLine("Nessuna persona presente nella lista");
                        }
                        else
                        {
                            Console.WriteLine("Eliminazione avvenuta con successo");
                        }
                        break;
                    case 4:
                        Console.WriteLine("ricerca");
                        Menu(menuRicerca);
                        Console.WriteLine("Con cosa vuoi effettuare la ricerca?");
                        sceltaRicerca = Scelta(menuRicerca.Length);
                        if (sceltaRicerca == 1)
                        {
                            Console.WriteLine("Inserisci cognome della persona da cercare");
                            c = Console.ReadLine();
                        }
                        else if (sceltaRicerca == 2)
                        {
                            Console.WriteLine("Inserisci matricola persona da ricercare");
                            int.TryParse(Console.ReadLine(), out m);
                        }

                        Lavoratore trovato = Belloduro.Ricerca(c, m);

                        if (trovato != null)
                            Console.WriteLine(trovato.ToString());
                        else
                            Console.WriteLine("Nessuna persona trovata");
                        break;

                    case 5:
                        Console.WriteLine("lista azioni");
                        //List<Lavoratore> lavAzioni = Belloduro.ListaAzioni(azioni.assente);
                        Console.WriteLine("Inserisci azione che vuoi fare");
                        Menu(azioniArray);
                        azione = Scelta(azioniArray.Length) - 1;
                        List<Lavoratore> lavAzioni = Belloduro.ListaAzioni((azioni)azione);
                        lavAzioni.ForEach(la => { Console.WriteLine(la.ToString()); });
                        break;
                    case 6:
                        break;

                }
                if (choice != 6)
                {
                    Console.WriteLine("PREMI INVIO PER USCIRE");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (choice != 6);
        }

        static void Inserimento(string nome, string cognome, string codice, azioni azione, BellinazziCo belloduro)
        {
            Lavoratore lv;
            try
            {
                lv = new Lavoratore(nome, cognome, codice, azione);
            }
            catch (Exception ex)
            {
                lv = null;
                Console.WriteLine(ex.Message);
            }
            belloduro.Aggiungi(lv);
            ScriviFile(Path.Combine(Environment.CurrentDirectory + "\\" + "log.txt"), lv.ToString());

        }
        static void Menu(string[] menu)
        {
            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine("{0}--> {1}", i + 1, menu[i]);
            }
        }
        static int Scelta(int supDex)
        {
            int scelta;
            int.TryParse(Console.ReadLine(), out scelta);
            while (scelta < 1 || scelta > supDex)
            {
                Console.WriteLine("Opzione non valida");
                int.TryParse(Console.ReadLine(), out scelta);
            }
            return scelta;
        }
        static void ScriviFile(string path, string contenuto)
        {
            //StreamWriter sw = new StreamWriter(path);
            StreamWriter sw = File.AppendText(path);
            sw.WriteLine(DateTime.Now.ToString() + " " + contenuto);
            sw.Close();
        }
    }
}