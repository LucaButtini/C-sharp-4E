using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RipassoInItinere
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Flotte flott = new Flotte();

            int choice;
            string[] opzioni = { "Inserimento", "Visualizza", "Ricerca", "Esci" };
            do
            {
                Menu(opzioni);
                Console.WriteLine("Che scelta vuoi fare?");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Inserimento");
                        break;
                    case 2:
                        Console.WriteLine("Visualizza");
                        //Console.WriteLine(auto.Targa);
                        break;
                    case 3:
                        Console.WriteLine("Ricerca");
                        break;
                    case 4:
                        Console.WriteLine("Fine");
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
        static void Inserimento(Flotte f)
        {
            Targa targa = new Targa();
            Veicolo v = new Veicolo();
            Console.WriteLine("Genera Targa (premi invio)");
            Console.ReadLine();
            v.Targa = targa.GeneraTarga();
            Console.WriteLine("Inserisci marca");
            v.Marca = Console.ReadLine();
            Console.WriteLine("Inserisci modello");
            v.Modello = Console.ReadLine();
            f.Aggiungi(v);
        }
        static void Menu(string[] opt)
        {
            for (int i = 0; i < opt.Length; i++)
            {
                Console.WriteLine("[{0}] {1}", i + 1, opt[i]);
            }
        }
    }
}
