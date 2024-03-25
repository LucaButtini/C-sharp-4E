using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EsFifgure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Figura> figure = new List<Figura>();
            Rettangolo r = new Rettangolo(3, 5);
            Quadrato q = new Quadrato(2);
            Cerchio c = new Cerchio(4);
            Parallelepipedo p = new Parallelepipedo(3, 4, 2);
            figure.Add(q);
            figure.Add(c);
            figure.Add(r);
            figure.Add(p);
            figure.ForEach(x => { Console.WriteLine(x.ToString()); });
            Console.ReadLine();
        }
    }
}
