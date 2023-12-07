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
            string np = "medicina";
            Reparto rep = new Reparto(np); // Crea un'istanza di Reparto vuota

            string[] options = { "Inserimento", "Visualizza", "Temperature", "Paziente successivo", "Paziente precedente", "Reset", "Febbre", "Esci" };
            Paziente pazienteCorrente = new Paziente(" ", " ", 36, " ");
            //successivo
            //precedente
            //reset
            do
            {

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
                        Inserimento(ref pos, rep, np);
                        break;
                    case 2:
                        Console.WriteLine("==Visualizza===");

                        Console.WriteLine("PAZIENTI REPARTO [{0}]", rep.GetNomeReparto());
                        rep.StampaPazienti(); // Stampa tutti i pazienti
                        Console.WriteLine("\nPAZIENTI CON FEBBRE");
                        rep.PazientiFebbre(); // Stampa i pazienti con febbre
                        break;
                    case 3:
                        // Modifica temperatura del paziente scelto
                        Console.WriteLine("=== Temperature ===");
                        Temperatura(rep);
                        break;
                    case 4:
                        Console.WriteLine("=== Paziente successivo ===");
                        // Ottieni il paziente corrente dal reparto
                        pazienteCorrente = rep.PazienteCorrente();

                        // Visualizza le informazioni del paziente corrente
                        if (pazienteCorrente != null)
                        {
                            Console.WriteLine("Paziente corrente:\n{0}", pazienteCorrente.Anagrafica());
                        }

                        // Passa al paziente successivo nel reparto
                        if (rep.MoveNext())
                        {
                            Console.WriteLine("Paziente successivo");
                        }
                        else
                        {
                            Console.WriteLine("Non ci sono più pazienti.");
                        }
                        break;
                    case 5:

                        Console.WriteLine("=== Paziente Precedente ===");
                        pazienteCorrente = rep.PazienteCorrente();

                        // Visualizza le informazioni del paziente corrente
                        if (pazienteCorrente != null)
                        {
                            Console.WriteLine("Paziente corrente:\n{0}", pazienteCorrente.Anagrafica());
                        }

                        // Passa al paziente successivo nel reparto
                        if (rep.MoveBefore())
                        {
                            Console.WriteLine("Paziente precedente");
                        }
                        else
                        {
                            Console.WriteLine("Non ci sono più pazienti.");
                        }
                        break;
                    case 6:
                        rep.ResetPaziente();
                        break;
                    case 8:
                        Console.WriteLine("Programma finito");
                        break;
                    case 7:
                        Console.WriteLine("febbre");
                        rep.Febbre().ForEach(f => Console.WriteLine(f.Anagrafica()));
                        break;
                    default:
                        Console.WriteLine("Reinserire opzione");
                        break;
                }

                if (choice != 8)
                {
                    Console.WriteLine("Premi invio per uscire");
                    Console.ReadLine();
                    Console.Clear();
                }

            } while (choice != 8);
        }

        static void Inserimento(ref int pos, Reparto r, string np)
        {
            Paziente p = new Paziente(" ", " ", 36, " ");//istanza nuova per ogni paziente
            p.SetReparto(np);
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

        static void Temperatura(Reparto r)
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