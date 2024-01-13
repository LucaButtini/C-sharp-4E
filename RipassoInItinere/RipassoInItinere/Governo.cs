using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RipassoInItinere
{
    internal static class Governo
    {
        
       static public string GeneraAutorizzazione()
        {
            Random random = new Random();
            int n;
            string temp = "", autorizzazione;
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
            autorizzazione = temp;
            return autorizzazione;
        }
        static public string GeneraTarga()
        {
            Random random = new Random();
            int l;
            string s1 = "", s2 = "", s3, targa;
            char z1, z2;//per formare la stringa
            for (int i = 0; i < 2; i++)//genero le prime due lettere
            {
                l = random.Next(65, 91);
                z1 = Convert.ToChar(l);//converto in ascii
                s1 += z1;
            }
            for (int i = 0; i < 2; i++)//genero le ultime due lettere
            {
                l = random.Next(65, 91);
                z2 = Convert.ToChar(l);//converto in ascii
                s2 += z2;
            }
            l = random.Next(100, 1000);//genero numero in mezzo
            s3 = Convert.ToString(l);//converto il n in string
            targa = s1 + s3 + s2;//concateno per formare la targa
            return targa;
        }
    }
}