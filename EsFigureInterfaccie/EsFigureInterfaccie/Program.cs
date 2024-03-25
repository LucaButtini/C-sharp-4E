using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsFigureInterfaccie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<FiguraInterface> figure = new List<FiguraInterface>();
            Rettangolo r = new Rettangolo(2, 4);
            Quadrato q = new Quadrato(3);
            Parallelepipedo p = new Parallelepipedo(5, 4, 2);
            Cerchio c = new Cerchio(5);
            figure.Add(r);
            figure.Add(q);
            figure.Add(p);
            figure.Add(c);
            figure.ForEach(f => { Console.WriteLine(f.ToString()); });
            Console.ReadLine();
        }
    }
}
