using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadCostruttori
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MiaClasse a1 = new MiaClasse(1);

            try
            {
               a1.MioMetodo(1);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(Generatore.GeneratoreLettere());
            Console.WriteLine(Generatore.GeneratoreNumeri());
            Console.ReadLine();
        }
    }
}
