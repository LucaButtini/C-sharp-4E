using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazzino
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BUTTINI LUCA FILA B 23/01/2024
            Magazzino magazzino = new Magazzino("casalinghi");
            Articolo a1;
            Articolo a2;
            int q = magazzino.Quantita();//assegno la capacita della lista 
            int qIns, code;

            try
            {
                //controllo eccezzione nella creazione dell'articolo 
                a1 = new Articolo("desc 1", 5.6, q);
                a2 = new Articolo("desc 2", 18.50, q);
            }
            catch (Exception ex)
            {
                a1 = null;
                a2 = null;
                Console.WriteLine(ex.Message);
            }
            //aggiungo gli articolo al magazzino
            magazzino.Aggiungi(a1);
            magazzino.Aggiungi(a2);
            //chiamata al metodo per scrivere nel file. Il file di log si trova in Buttini Luca\Magazzino\Magazzino\bin\Debug
            ScriviFile(Path.Combine(Environment.CurrentDirectory, "log.txt"), a1.ToString());
            ScriviFile(Path.Combine(Environment.CurrentDirectory, "log.txt"), a2.ToString());
            //ScriviFile(@"C:\Users\Emilio\Desktop\Itis\C#\Magazzino\Magazzino\bin\Debug\log.txt", a1.ToString());
            //ScriviFile(@"C:\Users\Emilio\Desktop\Itis\C#\Magazzino\Magazzino\bin\Debug\log.txt", a2.ToString());

            //output lista di articoli e nome magazzino
            Console.WriteLine("==ARTICOLI===");
            Console.WriteLine("NOME MAGAZZINO: {0}\n", magazzino.Descrizione);
            magazzino.Stampa();
            Console.WriteLine("Saldo del magazzino: {0}", magazzino.SaldoCalcolo());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Vuoi caricare o scaricare dal magazzino");
            Console.WriteLine("[1] scarica");
            Console.WriteLine("[2] carica");
            if (Scelta(2) == 1)
            {
                //se scelta è 1 scarico
                Console.WriteLine("SCARICO");
                Console.WriteLine("Inserisci codice");
                int.TryParse(Console.ReadLine(), out code);
                //cerco l'articolo
                if (magazzino.Trovato(code))
                {
                    //controllo se la quantita è sufficiente 
                    Console.WriteLine("Inserisci q.tà");
                    int.TryParse(Console.ReadLine(), out qIns);
                    if (qIns > q)
                    {
                        Console.WriteLine("QUANTITA' INSUFFICIENTE");
                    }
                    else
                    {
                        //output scarico
                        Console.WriteLine("prelievo effettutato: codice {0}, q.tà {1}", code, qIns);
                    }
                }
                else
                {
                    Console.WriteLine("codice non valido");
                }
            }
            else
            {
                //se scelta è 2 carico
                Console.WriteLine("CARICO");
                Console.WriteLine("Inserisci codice");
                int.TryParse(Console.ReadLine(), out code);
                if (magazzino.Trovato(code))
                {
                    //controllo se la quantita è sufficiente 
                    Console.WriteLine("Inserisci q.tà");
                    int.TryParse(Console.ReadLine(), out qIns);
                    if (qIns > q)
                    {
                        Console.WriteLine("MAGAZZINO INESISTENTE");
                    }
                    else
                    {
                        //output carico
                        Console.WriteLine("versamento effettutato: codice {0}, q.tà {1}", code, qIns);
                    }
                }
                else
                {
                    Console.WriteLine("codice non valido");
                }
            }
            Console.ReadLine();
        }
        static void ScriviFile(string path, string contenuto)
        {
            // using statement ensures that the StreamWriter is properly closed and resources are released
            using (StreamWriter sv = File.AppendText(path))
            {
                sv.WriteLine(DateTime.Now.ToString() + contenuto);
            }
        }

        //static void ScriviFile(string path, string contenuto)
        //{
        //    //metodo scrittura nel file
        //    StreamWriter sv = File.AppendText(path);
        //    sv.WriteLine(DateTime.Now.ToString() + contenuto);
        //    sv.Close();
        //}
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
