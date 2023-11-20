using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Studente> studenti = new List<Studente>();
            int scelta, pos = 0;
            string[] options = { "Inserimento", "Visualizza", "GetCf", "Esci" };
            do
            {
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($" [{i + 1}] {options[i]}");
                }

                Console.WriteLine("Inserisci la scelta");
                int.TryParse(Console.ReadLine(), out scelta);
                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("Inserimento persona {0}", pos + 1);
                        Inserimento(studenti, ref pos);
                        break;
                    case 2:
                        Visualizza(studenti);
                        break;
                    case 3:
                        Console.WriteLine("non implementato");
                        break;
                    case 4:
                        Console.WriteLine("fine");
                        break;
                    default:
                        Console.WriteLine("esci");
                        break;
                }
                if (scelta != 4)
                {
                    Console.WriteLine("Premi invio per uscire");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (scelta != 4);
        }
        static void Inserimento(List<Studente> studenti, ref int pos)
        {
            Studente studente = new Studente();
            Console.Write("Nome: ");
            studente.SetName(Console.ReadLine());
            Console.Write("cognome: ");
            studente.SetCognome(Console.ReadLine());
            Console.Write("media: ");
            studente.SetMedia(Convert.ToInt32(Console.ReadLine()));
            studenti.Add(studente);
            pos++;
        }
        static void Visualizza(List<Studente> s)
        {
            for (int i = 0; i < s.Count; i++)
            {
                Console.WriteLine("Nome");
                Console.WriteLine(s[i].GetName());
                Console.WriteLine("cognome");
                Console.WriteLine(s[i].GetCognome());
                Console.WriteLine("Media");
                Console.WriteLine(s[i].GetMedia());
                Console.WriteLine("=======================================");
            }
        }
    }
}
