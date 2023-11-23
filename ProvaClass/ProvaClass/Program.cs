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
            string[] arr = Enum.GetNames(typeof(Attivita));
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("[{0}] {1}", i + 1, arr[i]);
            }
            Console.WriteLine("Scegli un opzione");
            int s;
            int.TryParse(Console.ReadLine(), out s);
            while (s < 1 || s > arr.Length)
            {
                {
                    Console.WriteLine("Inserisci un opzione valida");
                    int.TryParse(Console.ReadLine(), out s);
                }
            }
            switch (s)
            {
                case 1:
                    studente.SetAction(Attivita.legge);
                    break;
                case 2:
                    studente.SetAction(Attivita.scrive);
                    break;
                case 3:
                    studente.SetAction(Attivita.mangia);
                    break;
                case 4:
                    studente.SetAction(Attivita.nero);
                    break;
            }
            studenti.Add(studente);
            pos++;
        }
        static void Visualizza(List<Studente> s)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < s.Count; i++)
            {
                Console.WriteLine("Nome");
                Console.WriteLine(s[i].GetName());
                Console.WriteLine("cognome");
                Console.WriteLine(s[i].GetCognome());
                Console.WriteLine("Media");
                Console.WriteLine(s[i].GetMedia());
                Console.WriteLine("attività");
                Console.WriteLine(s[i].GetAction());
                Console.WriteLine("=======================================");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
