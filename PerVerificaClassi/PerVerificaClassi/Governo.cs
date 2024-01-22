using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerVerificaClassi
{
    internal static class Governo
    {
        static public string GeneraCodice()
        {
            Random random = new Random();
            int n;
            string temp = "", codice;
            char c;
            // Genera 5 numeri casuali
            for (int i = 0; i < 5; i++)
            {
                n = random.Next(0, 10);
                temp += Convert.ToString(n);
            }
            // vocale casuale
            n = random.Next(65, 91);
            c = Convert.ToChar(n);
            temp += c;
            codice = temp;
            return codice;
        }
    }
}
