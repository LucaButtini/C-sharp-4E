using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTrial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Class1 e Class2 non hanno alcun legame
            List<Interface1> lista = new List<Interface1>();
            lista.Add(new Class1("franco"));
            lista.Add(new Class2("gaba"));
            lista.ForEach(l => { Console.WriteLine(l.Metodo1() + " --- " + l.Metodo2(5)); });
            Console.ReadLine();
        }
    }
}
