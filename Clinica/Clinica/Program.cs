using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Clinica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            string[] options = { "Inserimento", "Visualizza", "Temperature", "Esci" };
            Reparto Medicina = new Reparto("Medicina", 5);
            do
            {
                for (int i = 0; i < options.Length; i++)
                    Console.WriteLine("[{0}] {1}", i + 1, options[i]);
                Console.WriteLine("Che scelta vuoi fare?");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("===Inserimento===");
                        Paziente p1 = new Paziente("Federico", "Melon", "Medicina");
                        Paziente p2 = new Paziente("Carmine", "Valacchio", "Medicina");
                        Paziente p4 = new Paziente("Esposito", "Lorenzo", "Medicina");
                        Paziente p3 = new Paziente("Emiliano", "Spiller", "Medicina");
                        Medicina.AggiungiPaziente(p1);
                        Medicina.AggiungiPaziente(p2);
                        Medicina.AggiungiPaziente(p3);
                        Medicina.AggiungiPaziente(p4);
                        Console.WriteLine("Utenti inseriti grazie ai metodi costruttori");
                        break;
                    case 2:
                        Console.WriteLine("==Visualizza===");
                        Medicina.StampaPazienti();
                        break;
                    case 3:
                        Console.WriteLine("===Temperature===");
                        //temperatura modificata dei pazienti
                        Medicina.ModificaTemperatura("Federico", "Melon", 2);
                        Console.WriteLine("==pazienti con febbre==");
                        Medicina.PazientiFebbre();
                        break;
                    case 4:
                        Console.WriteLine("Programma finito");
                        break;
                    default:
                        Console.WriteLine("reinserire opzione");
                        break;
                }
                if (choice != 4)
                {
                    Console.WriteLine("Premi invio per uscire");
                    Console.ReadLine();
                    Console.Clear();
                }

                //Reparto Medicina = new Reparto("Medicina", 5);

                //Paziente p1 = new Paziente("Federico", "Melon", "Medicina");
                //Paziente p2 = new Paziente("Carmine", "Valacchio", "Medicina");
                //Paziente p4 = new Paziente("Esposito", "Lorenzo", "Medicina");
                //Paziente p3 = new Paziente("Emiliano", "Spiller", "Medicina");
                //Medicina.AggiungiPaziente(p1);
                //Medicina.AggiungiPaziente(p2);
                //Medicina.AggiungiPaziente(p3);
                //Medicina.AggiungiPaziente(p4);
                //Console.WriteLine("==Pazienti===");
                //Medicina.StampaPazienti();
                //Console.WriteLine();
                //Console.WriteLine();
                ////temperatura modificata dei pazienti
                //Medicina.ModificaTemperatura("Federico", "Melon", 2);
                //Medicina.StampaPazienti();
                //Console.WriteLine();
                //Console.WriteLine();
                //Console.WriteLine("==pazienti con febbre==");
                //Medicina.PazientiFebbre();
            } while (choice != 4);
        }


    }
}