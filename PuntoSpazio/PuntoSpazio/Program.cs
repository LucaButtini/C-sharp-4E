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
            Punto punto = new Punto(Console.WindowWidth, Console.WindowHeight, 0, 0, '.');
            punto.SetPunto();
            Console.ReadLine();
        }

    }
}
