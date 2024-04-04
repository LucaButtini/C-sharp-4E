using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerVerErdPol2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Veicolo> concessionaria = new List<Veicolo>();
            Auto auto = new Auto("ford", "alpha", 34.5);
            MacchinaVintage macchinaVintage = new MacchinaVintage("ford", "vintage", 34.5, "carmine valacchio king vintage benevento");
            Camion camion = new Camion("landini", "ford", 545.9, 89.104);
            Camion camion1 = new Camion("trenore", "fiat", 547.9, 89.104);
            Camion camion2 = new Camion("francone", "ford", 65.4, 54.59);
            concessionaria.Add(auto);
            concessionaria.Add(macchinaVintage);
            concessionaria.Add(camion);
            concessionaria.Add(camion1);
            concessionaria.Add(camion2);
            concessionaria.ForEach(v => { Console.WriteLine(v.Stampa()); });
            Console.WriteLine();
            Console.WriteLine();
            concessionaria.ForEach(v => { if (v is Camion) { Console.WriteLine(v.GetType().Name); }; });
            Console.ReadLine();
        }
    }
}
