using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversioneIpInClasse
{
    class Program
    {
        struct Ip
        {
            public string ipDec;
            public string ipBin;
            public string ipHex;
        }
        static void Main(string[] args)
        {
            Ip indirizzo = new Ip();
            indirizzo.ipDec = Lettura();
            Console.WriteLine(indirizzo.ipDec);
            Console.ReadLine();
        }
        static string Lettura()
        {
            string ipFinal = "";
            int otteto;
            //numero ip: 10.100.100.255

            for (int i = 0; i < 4; i++)
            {
                do
                {
                    Console.WriteLine($"Inserisci otteto {i + 1}");
                    otteto = Convert.ToInt32(Console.ReadLine());
                    if (otteto < 0 && otteto > 255)
                    {
                        Console.WriteLine("non valido");
                    }

                } while (otteto < 0 && otteto > 255);
                if (i < 3)
                {
                    ipFinal = ipFinal + otteto + '.';
                }
                else
                    ipFinal = ipFinal + otteto;
            }
            return ipFinal;
        }
        static string IpBinario(string ipDecimale)
        {
            string binario = "";
            int resto;
            string[] array = ipDecimale.Split('.');
            int num;
            for (int i = 0; i < 4; i++)
            {
                num = Convert.ToInt32(array[i]);

                for (int j = 0; j < 8; j++)
                {
                    resto = num % 2;
                    num = num / 2;
                }
                return ipDecimale;
            }
        }
    }
}
