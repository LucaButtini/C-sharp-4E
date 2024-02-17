using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioOverrideMetodo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Frutta f1 = new Frutta("Rosso",new DateTime(2024, 2, 16), 50);
            f1.Stampa();

            Console.ReadLine();
        }
    }
}
