using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaraFraPiloti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pilota p1 = new Pilota("Carmine", "Valacchio");
            Auto a1 = new Auto("Ford Vintage 1985", p1);
            Console.WriteLine(a1.Stampa());
            Console.ReadLine();
        }
    }
}
