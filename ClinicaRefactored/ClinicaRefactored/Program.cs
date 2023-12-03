using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaRefactored
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice, pos = 0;
            bool repartoCreato = false;
            Reparto rep = new Reparto(" "); // Crea un'istanza di Reparto vuota
            string[] options = { "Inserimento", "Visualizza", "Temperature", "Esci" };

            do
            {
                Paziente paziente = new Paziente();//istanza nuova per ogni paziente
                //stampa menu
                for (int i = 0; i < options.Length; i++)
                    Console.WriteLine("[{0}] {1}", i + 1, options[i]);

                Console.WriteLine("Che scelta vuoi fare?");
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("===Inserimento===");
                        //inserimento nome reparto
                        if (!repartoCreato)
                        {
                            Console.Write("Inserisci il nome del reparto: ");
                            string nomeReparto = Console.ReadLine();
                            rep = new Reparto(nomeReparto);
                            paziente.SetReparto(nomeReparto);//aggiungo il nome del reparto al paziente per il suo attributo
                            repartoCreato = true;
                        }
                        Inserimento(paziente, ref pos, rep);
                        break;
                    case 2:
                        Console.WriteLine("==Visualizza===");
                        if (repartoCreato)
                        {
                            Console.WriteLine("PAZIENTI REPARTO [{0}]", rep.GetNomeReparto());
                            rep.StampaPazienti(); // Stampa tutti i pazienti
                            Console.WriteLine("\nPAZIENTI CON FEBBRE");
                            rep.PazientiFebbre(); // Stampa i pazienti con febbre
                        }
                        else
                        {
                            Console.WriteLine("Nessun reparto disponibile.");
                        }
                        break;

                    case 3:
                        //modifica temperatura del paziente scelto
                        Console.WriteLine("===Temperature===");
                        Temperatura(paziente, rep);
                        break;
                    case 4:
                        Console.WriteLine("Programma finito");
                        break;
                    default:
                        Console.WriteLine("Reinserire opzione");
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

        static void Inserimento(Paziente p, ref int pos, Reparto r)
        {
            Console.WriteLine("Inserimento persona {0}\n", pos + 1);
            Console.Write("Inserisci Nome: ");
            p.SetNome(Console.ReadLine());
            Console.Write("Inserisci Cognome: ");
            p.SetCognome(Console.ReadLine());
            // Assegna il reparto al paziente
            p.SetReparto(r.GetNomeReparto());
            r.AggiungiPaziente(p);
            pos++;
        }

        static void Temperatura(Paziente p, Reparto r)
        {
            //nome e cog del paz da ricercare ed inserisco la temperatura
            string nome, cognome;
            int temp;
            Console.WriteLine("Inserisci nome della persona la quale si desidera cambiare la temperatura");
            nome = Console.ReadLine();
            Console.WriteLine("Inserisci cognome della persona la quale si desidera cambiare la temperatura");
            cognome = Console.ReadLine();
            temp = CheckTemp();//controllo con le eccezioni l'inserimento del valore della temperatura
            r.ModificaTemperatura(nome, cognome, temp); //assegno al rep la temp del paziente modificata
        }
        static int CheckTemp() //metodo eccezioni temperatura
        {
            int temp = 0;
            bool check = false;
            while (!check)
            {
                try
                {
                    Console.Write("Inserisci Temperatura: ");
                    temp = Convert.ToInt32(Console.ReadLine());
                    check = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato errato, reinserire");
                }
            }
            return temp;
        }
    }
}