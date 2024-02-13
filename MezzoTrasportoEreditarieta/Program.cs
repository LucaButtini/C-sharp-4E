using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezzoTrasportoEreditarieta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MezzoTrasporto mezzo1 = new MezzoTrasporto(4);
            Auto auto1 = new Auto("Euro 5", 3, 5);
            Auto auto2 = new Auto("Euro 6", 3, 5);

            mezzo1.MetodoQualsiasi();
            auto1.MetodoQualsiasi();

            if (auto1 == auto2)
            {
                Console.WriteLine("sono uguali");
            }
            else
                Console.WriteLine("Sono diverse");

            Console.ReadLine();
        }
    }
}
