using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaClasseButti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Studente studente = new Studente();
            studente.SetNome(Console.ReadLine());
            studente.SetCognome(Console.ReadLine());
            studente.SetMedia(Convert.ToByte(Console.ReadLine()));
            Console.WriteLine($"Studente ha nome {studente.GetNome()} e cognome {studente.GetCognome()}, media {studente.GetMedia()}");
            Console.ReadLine();
        }
    }
}
