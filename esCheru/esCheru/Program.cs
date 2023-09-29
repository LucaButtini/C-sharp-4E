using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esCheru
{
    class Program
    {
        enum Sesso
        {
            maschio, femmina
        }
        static void Main(string[] args)
        {
            Sesso tipo;
            int scelta;
            string titolo = "=====ANAGRAFICA=====";
            string[] opzioni;
            do
            {
                opzioni = Enum.GetNames(typeof(Sesso)); // converte enumeratore in stringa
                scelta = Menu(opzioni, titolo, 10, 0, ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Magenta);
                SceltaSesso(scelta, out tipo);
                Console.WriteLine(tipo.ToString());
                Console.ReadLine();
            } while (scelta != opzioni.Length - 1);

        }
        static string GiustificaOpzione(string titolo, string opzione, int segnaposto)
        {
            int bianchi = titolo.Length - opzione.Length - segnaposto;
            for (int i = 0; i < bianchi; i++)
            {
                opzione += " ";
            }
            return opzione;
        }
        static int Menu(string[] opzioni, string titolo, int x, int y, ConsoleColor coloreTitolo, ConsoleColor coloreTesto, ConsoleColor coloreSfondo)
        {
            bool riuscito;
            int temp = y; // per salvare valore (mandatory)
            int scelta;
            y = temp;
            Console.Clear();
            Console.ForegroundColor = coloreTitolo;
            Console.BackgroundColor = coloreSfondo;
            Console.SetCursorPosition(x, y++); // cambio posizione al titolo
            Console.WriteLine(titolo);
            Console.ForegroundColor = coloreTesto;
            for (int i = 0; i < opzioni.Length; i++)
            {
                Console.SetCursorPosition(x, y++);
                Console.WriteLine($"[{i + 1}] {GiustificaOpzione(titolo, opzioni[i], 4)}");
            }
            Console.SetCursorPosition(x, y);
            Console.WriteLine(GiustificaOpzione(titolo, "Inserire Opzione", 0));
            do
            {
                riuscito = int.TryParse(Console.ReadLine(), out scelta);
            } while (!riuscito || scelta < 1 || scelta > opzioni.Length); // per non fare crashare programma


            scelta--; // perché l'utente vede le opzioni aumentate di uno
            return scelta;

        }
        static void ControlloScelta(int scelta, string[] opzioni)
        {

            // setto i colori standard della console
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            switch (scelta)
            {
                case 0:
                    Console.WriteLine(opzioni[0]);
                    break;
                case 1:
                    Console.WriteLine(opzioni[1]);
                    break;
                    //case 2:
                    //    Console.WriteLine(opzioni[2]);
                    //    break;
            }
            Console.WriteLine("Premere invio per continuare");
            Console.ReadLine();
        }
        static void SceltaSesso(int scelta, out Sesso tipo)
        {
            tipo = Sesso.maschio;
            // setto i colori standard della console
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            switch (scelta)
            {
                case 1:
                    tipo = Sesso.femmina;
                    break;

            }
            Console.WriteLine("Premere invio per continuare");
            Console.ReadLine();
        }
    }
}

