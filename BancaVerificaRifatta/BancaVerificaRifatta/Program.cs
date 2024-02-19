using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaVerificaRifatta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Banca banca = new Banca("banca vintage");
            ContoCorrente c1, c2;
            int code;
            double quantita;
            try
            {
                c1 = new ContoCorrente("Paolo", "Morante");
                c2 = new ContoCorrente("Carmine", "Valacchio");
            }
            catch (Exception ex)
            {
                c1 = null;
                c2 = null;
                Console.WriteLine(ex.Message);
            }
            banca.Aggiungi(c1);
            banca.Aggiungi(c2);
            Console.WriteLine("BANCA: [{0}]", banca.Nome);
            banca.Stampa();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("cosa vuoi fare?");
            Console.WriteLine("[1] PRELIEVA");
            Console.WriteLine("[2] VERSA");
            if (Scelta(2) == 1)
            {
                Console.WriteLine("PRELIEVA");
                Console.WriteLine("Inserisci codice conto");
                int.TryParse(Console.ReadLine(), out code);
                Console.WriteLine("Inserisci la quantita da prelevare");
                double.TryParse(Console.ReadLine(), out quantita);
                banca.Prelieva(code, quantita);
            }
            else
            {
                Console.WriteLine("VERSA");
                Console.WriteLine("Inserisci codice conto");
                int.TryParse(Console.ReadLine(), out code);
                Console.WriteLine("Inserisci la quantita da versare");
                double.TryParse(Console.ReadLine(), out quantita);
                banca.Versa(code, quantita);

            }
            Console.WriteLine();
            Console.WriteLine();
            double saldo = banca.SaldoTotale();
            banca.Stampa();
            Console.WriteLine("Saldo: {0}", saldo);
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
