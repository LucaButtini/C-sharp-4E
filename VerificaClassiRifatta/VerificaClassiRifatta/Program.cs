using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificaClassiRifatta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Magazzino magazzino = new Magazzino("magazzino");
            Articolo a1, a2;
            int code;
            double quantita;
            try
            {
                a1 = new Articolo("desc1", 58.2);
                a2 = new Articolo("desc2", 55.9);
            }
            catch (Exception ex)
            {
                a1 = null;
                a2 = null;
                Console.WriteLine(ex.Message);
            }
            magazzino.Aggiungi(a1);
            magazzino.Aggiungi(a2);
            magazzino.Stampa();
            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("cosa vuoi fare?");
            Console.WriteLine("[1] SCARICO");
            Console.WriteLine("[2] CARICO");
            if (Scelta(2) == 1)
            {
                Console.WriteLine("scarico");
                Console.WriteLine("Inserisci codice articolo");
                int.TryParse(Console.ReadLine(), out code);
                Console.WriteLine("Inserisci la quantita da prelevare");
                double.TryParse(Console.ReadLine(), out quantita);
                magazzino.Scarico(code, quantita);
            }
            else
            {
                Console.WriteLine("carico");
                Console.WriteLine("Inserisci codice articolo");
                int.TryParse(Console.ReadLine(), out code);
                Console.WriteLine("Inserisci la quantita da aggiungere");
                double.TryParse(Console.ReadLine(), out quantita);
                magazzino.Carico(code, quantita);

            }
            Console.WriteLine("==OUTPUT==");
            magazzino.Stampa();
            double saldo = magazzino.SaldoTotale();
            Console.WriteLine("Saldo totale: {0}", saldo);
            Console.ReadLine();
        }
        static int Scelta(int supDex) //prende in input l'estremo destro per verificare che l'utente inserisca solo le opzioni disponibili
        {
            //uso il metodo per controllare che l'utente scelga solo le opzioni disponibili
            int s;
            int.TryParse(Console.ReadLine(), out s);
            while (s < 1 || s > supDex)
            {
                Console.WriteLine("Opzione non valida");
                int.TryParse(Console.ReadLine(), out s);
            }
            return s;
        }
    }
}
