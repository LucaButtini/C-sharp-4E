using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostVerificaFilaB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Magazzino magazzino = new Magazzino("Il magazzino di beppe e franco");
            String[] arr = new string[] { "Aggiungi articolo", "Visualizza", "Prezzo totale", "Carico", "Scarico", "Leggi log", "Esci" };
            bool esci = false;

            Scrivi("\n^^^^^^^^^^^^^^^^^");
            Scrivi($"{magazzino.Descrizione}");
            do
            {
                Console.WriteLine("Menù");
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine($"[{i + 1}] {arr[i]}");
                }
                Console.WriteLine("---------------------");
                Console.Write("Scelta: ");
                int scelta = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (scelta)
                {
                    case 1:
                        AggiungiArticolo(magazzino);
                        break;
                    case 2:
                        Visualizza(magazzino);
                        break;
                    case 3:
                        Console.WriteLine(magazzino.PrezzoTotale());
                        break;
                    case 4:
                        Carico(magazzino);
                        break;
                    case 5:
                        Scarico(magazzino);
                        break;
                    case 6:
                        Leggi();
                        break;
                    case 7:
                        esci = true;
                        break;
                }

                Console.ReadLine();
                Console.Clear();
            } while (!esci);
        }

        static void AggiungiArticolo(Magazzino m)
        {
            Console.Write("Inserire descrizione:");
            string descrizione = Console.ReadLine();

            Console.Write("Inserire prezzo:");
            double prezzo = Convert.ToInt32(Console.ReadLine());

            Articolo a = new Articolo(descrizione, prezzo, m.Codice());
            m.AggiungiArticolo(a);

            Scrivi($"{DateTime.Now.ToString()} - Articolo aggiunto >> {a.ToString()}");
        }

        static void Visualizza(Magazzino m)
        {
            Console.WriteLine("=====================");
            Console.WriteLine(m.Descrizione);
            Console.WriteLine("=====================");
            m.Lista().ForEach(elemento => Console.WriteLine(elemento.ToString()));
            Console.WriteLine("=====================");
        }

        static void Carico(Magazzino m)
        {
            Console.Write("Articolo: ");
            string articolo = Console.ReadLine();

            Console.Write("Quantità carico: ");
            double carico = Convert.ToInt32(Console.ReadLine());

            if (m.Carico(articolo, carico))
            {
                Console.WriteLine("Carico effettuato");
                Scrivi($"{DateTime.Now.ToString()} >> Articolo: {articolo} - Carico: {carico}");
            }
        }

        static void Scarico(Magazzino m)
        {
            Console.Write("Articolo: ");
            string articolo = Console.ReadLine();

            Console.Write("Quantità scarico: ");
            double carico = Convert.ToInt32(Console.ReadLine());

            if (m.Scarico(articolo, carico))
            {
                Console.WriteLine("Scarico effettuato");
                Scrivi($"{DateTime.Now.ToString()} >> Articolo: {articolo} - Scarico: {carico}");
            }
        }

        static void Scrivi(string stringa)
        {
            StreamWriter sw = File.AppendText(Path.Combine(Environment.CurrentDirectory + "\\log.txt"));
            sw.WriteLine(stringa);
            sw.Close();
        }

        static void Leggi()
        {
            StreamReader sr = File.OpenText(Path.Combine(Environment.CurrentDirectory + "\\log.txt"));
            string linea = sr.ReadLine();

            if (linea != null)
            {
                do
                {
                    Console.WriteLine(linea);
                    linea = sr.ReadLine();
                } while (linea != null);
            }

            sr.Close();
        }

    }
}