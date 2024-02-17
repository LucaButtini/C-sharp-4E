using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoSpazio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Punto p = new Punto(50, 21);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(p.ToString());
            Console.ForegroundColor = ConsoleColor.White;
            Quadrato q = new Quadrato(22, 15, p);
            Parallelogramma pa = new Parallelogramma(35, 10, p, 3);
            Rettangolo r = new Rettangolo(10, 5, p);
            Console.WriteLine(r.ToString());
            Console.WriteLine(q.ToString());
            Console.WriteLine(pa.ToString());

            Console.ReadLine();
        }

    }
}
