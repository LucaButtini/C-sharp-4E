using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattelloAstratta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Battello b1 = new Battello(); NON SI PUO FARE!!!
            List<Battello> battellos = new List<Battello>();

            battellos.Add(new Nave("TITANIC",5));
            battellos.Add(new NaveMercantile("MSC", 5, 100));
            battellos.Add(new Gommone("costa crociera", 6));

            battellos.ForEach(i => Console.WriteLine(i.CostoViaggio()));
            Console.ReadLine();
        }
    }
}
