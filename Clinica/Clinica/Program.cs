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
            Reparto Medicina = new Reparto("Medicina", 5);

            Paziente p1 = new Paziente("Federico", "Melon", "Medicina");
            Paziente p2 = new Paziente("Carmine", "Valacchio", "Medicina");
            Paziente p3 = new Paziente("Emiliano", "Spiller", "Medicina");
            Paziente p4 = new Paziente("Esposito", "Lorenzo", "Medicina");
            Medicina.AggiungiPaziente(p1);
            Medicina.AggiungiPaziente(p2);
            Medicina.AggiungiPaziente(p3);
            Medicina.AggiungiPaziente(p4);
            Console.WriteLine("==Pazienti===");
            Medicina.StampaPazienti();
            Console.WriteLine();
            Console.WriteLine();
            //temperatura modificata dei pazienti
            Medicina.ModificaTemperatura("Federico", "Melon", 2);
            Medicina.StampaPazienti();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==pazienti con febbre==");
            Medicina.PazientiFebbre();

            Console.ReadLine();
        }
    }
}