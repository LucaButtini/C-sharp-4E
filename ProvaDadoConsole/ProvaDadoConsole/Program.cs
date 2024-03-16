using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaDadoConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gara gara = new Gara(new Giocatore("g1", new Dado(6)), new Giocatore("g2", new Dado(6)), 3);
            gara.Round();
            Console.ReadLine();
            gara.Round();
            Console.ReadLine();
            gara.Round();
            Console.ReadLine();
        }
    }
}
