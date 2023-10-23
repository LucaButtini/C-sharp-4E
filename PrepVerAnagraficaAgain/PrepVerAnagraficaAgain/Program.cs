using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace PrepVerAnagraficaAgain
{
    enum Sesso
    {
        Maschio,
        Femmina
    }

    enum StatoCivile
    {
        Celibe,
        Nubile,
        Coniugato,
        Vedovo,
        Separato
    }

    struct Persona
    {
        public string Id; // Codice fiscale
        public string Cognome;
        public string Nome;
        public string Cittadinanza;
        public DateTime Nascita;
        public StatoCivile Stato;
        public Sesso Genere;

        public override string ToString()//uso ovveride della stringa
        {
            return String.Format($"NOME: {Nome}, COGNOME: {Cognome}, CITTADINANZA: {Cittadinanza}, NASCITA: {Nascita}, ID: {Id}, GENERE: {Genere}, STATO CIVILE: {Stato} ");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int d = 3, pos = 0, scelta;
            string[] menuAnagrafica = { "Inserimento", "Visualizza", "Esci" };
            Persona[] p = new Persona[d];
            bool b;
            do
            {
                Console.WriteLine("======================");
                Console.WriteLine();
                Menu(menuAnagrafica);
                Console.WriteLine();
                Console.WriteLine("======================");
                Console.WriteLine();
                Console.WriteLine("Quale è la tua scelta");
                int.TryParse(Console.ReadLine(), out scelta);
                switch (scelta)
                {
                    case 1:

                        Console.WriteLine("Inserimento");

                        switch (Lettura(p, ref pos))
                        {
                            case 0:
                                Console.WriteLine("fine");
                                break;
                            case 1:
                                Console.WriteLine("completa");
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Visualizza");
                        Stampa(p, ref pos);
                        break;
                    case 3:
                        Console.WriteLine("Esci dal menu");
                        break;
                    default:
                        Console.WriteLine("Hai sbagliato");
                        break;
                }
                if (scelta != 3)
                {
                    Console.ReadLine();
                    Console.Clear();
                }

            } while (scelta != 3);

        }
        static void Menu(string[] menu)
        {
            for (int i = 0; i < menu.Length; i++)
                Console.WriteLine($"{i + 1} --> {menu[i]}");
        }
        static int Lettura(Persona[] p, ref int pos)
        {
            bool checkDate;
            string cf;
            if (pos < p.Length)
            {

                Console.WriteLine($"persona {pos + 1}");
                Console.WriteLine("nome");
                p[pos].Nome = Console.ReadLine();
                Console.WriteLine("Inserisci cognome: ");
                p[pos].Cognome = Console.ReadLine();
                Console.WriteLine("Inserisci cittadinanza: ");
                p[pos].Cittadinanza = Console.ReadLine();
                checkDate = false; //metto a false la var bool ogni volta che si inserisce una persona.

                // Continua a chiedere all'utente di inserire la data fino a quando non viene inserita correttamente
                while (!checkDate)
                {
                    try
                    {
                        //solleva l'eccezione
                        Console.WriteLine("Inserisci data di nascita (formato: dd/mm/yyyy): ");
                        p[pos].Nascita = DateTime.Parse(Console.ReadLine());
                        checkDate = true; // La data è stata inserita correttamente, usciamo dal ciclo
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Formato data non valido. Inserisci nel formato corretto (dd/mm/yyyy).");
                    }
                }
                Console.WriteLine("id");
                cf = Console.ReadLine();
                while (Id(p, cf))
                {
                    Console.WriteLine("Gia inserito, rimmetilo");
                    cf = Console.ReadLine();
                }
                Console.WriteLine("Genere");
                switch (GenereMenu())
                {
                    case 1:
                        p[pos].Genere = Sesso.Maschio;
                        break;
                    case 2:
                        p[pos].Genere = Sesso.Femmina;
                        break;
                }
                Console.WriteLine("Stato");
                switch (StatoMenu())
                {
                    case 1:
                        p[pos].Stato = StatoCivile.Celibe;
                        break;
                    case 2:
                        p[pos].Stato = StatoCivile.Nubile;
                        break;
                    case 3:
                        p[pos].Stato = StatoCivile.Coniugato;
                        break;
                    case 4:
                        p[pos].Stato = StatoCivile.Vedovo;
                        break;
                    case 5:
                        p[pos].Stato = StatoCivile.Separato;
                        break;
                }
                pos++;
                return 0;
            }
            else
            {
                return 1;
            }

        }
        static int GenereMenu()
        {
            int s;
            string[] genere = Enum.GetNames(typeof(Sesso));
            for (int i = 0; i < genere.Length; i++)
            {
                Console.WriteLine($"{i + 1} {genere[i]}");
            }
            Console.WriteLine("scelta");
            int.TryParse(Console.ReadLine(), out s);
            while (s < 1 || s > genere.Length)
            {
                Console.WriteLine("sbagliato");
                int.TryParse(Console.ReadLine(), out s);
            }
            return s;
        }
        static int StatoMenu()
        {
            int s;
            string[] stato = Enum.GetNames(typeof(StatoCivile));
            for (int i = 0; i < stato.Length; i++)
            {
                Console.WriteLine($"{i + 1} {stato[i]}");
            }
            Console.WriteLine("scelta");
            int.TryParse(Console.ReadLine(), out s);
            while (s < 1 || s > stato.Length)
            {
                Console.WriteLine("sbagliato");
                int.TryParse(Console.ReadLine(), out s);
            }
            return s;
        }

        static void Stampa(Persona[] p, ref int pos)
        {
            for (int i = 0; i < pos; i++)
            {
                Console.WriteLine(p[i]);
            }
        }
        static bool Id(Persona[] p, string cf)
        {
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i].Id == cf)
                    return true;
            }
            return false;
        }
    }
}
