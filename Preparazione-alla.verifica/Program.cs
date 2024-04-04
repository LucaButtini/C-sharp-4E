using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparazione_alla.verifica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ClasseBase> lista = new List<ClasseBase>() 
            {
               new ClasseBase(4),
               new ClasseDerivata1(5,8),
               new ClasseDerivata2(10,12),
               new ClasseDerivata2(10,12),
               new ClasseDerivata2(10,12),
               new ClasseDerivata2(10,12),
               new ClasseDerivata2(10,12),
               new ClasseDerivata2(10,12),
               new ClasseDerivata11(120,13,69),
            };
            lista.ForEach(a => { Console.WriteLine(a.Stampa() +" * "+ a.GetType().Name); }) ;
            lista.ForEach(a => { if (a is ClasseDerivata2) { Console.WriteLine("Sono classe derivata 2"); } });
            Console.ReadLine();
        }
    }
}
