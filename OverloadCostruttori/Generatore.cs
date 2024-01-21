using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadCostruttori
{
    static internal class Generatore
    {
        public static char GeneratoreLettere()
        {
            Random carattere = new Random();
            char car = (char)carattere.Next(65, 91);
            
            return car;
        }
        public static int GeneratoreNumeri()
        {
            Random numeri = new Random();
            int car = numeri.Next(1, 10);

            return car;
        }
    }
    
}
