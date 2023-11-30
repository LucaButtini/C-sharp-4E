using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int DIM = 5;
            string[] v = new string[DIM];
            List<string> l = new List<string>();
            for (int i = 0; i < DIM; i++)
            {
                v[i] = Console.ReadLine();
            }
            Console.WriteLine("======================");
            for (int i = 0; i < 3; i++)
            {
                l.Add(Console.ReadLine());
            }
            l.AddRange(v);
            Console.WriteLine("======================");
            l.ForEach(x => Console.WriteLine(x));
            Console.ReadLine();
        }
    }
}
