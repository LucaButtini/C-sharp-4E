using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversioneIp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string indirizzo, indirizzoBinario, pt1Bin, pt2Bin, pt3Bin, pt4Bin;
            int p1, p2, p3, p4;

            Console.WriteLine("Inserisci indirizzo IP (es: 192.168.56.1)");//metterlo simile a quello dell'esempio
            indirizzo = Console.ReadLine();

            //estraggo le parti dell'ip
            p1 = Convert.ToInt32(indirizzo.Substring(0, 3));
            p2 = Convert.ToInt32(indirizzo.Substring(3, 3));
            p3 = Convert.ToInt32(indirizzo.Substring(6, 2));
            p4 = Convert.ToInt32(indirizzo.Substring(8));

            // Converto le parti in binario
            pt1Bin = ConvertiInBinario(p1);
            pt2Bin = ConvertiInBinario(p2);
            pt3Bin = ConvertiInBinario(p3);
            pt4Bin = ConvertiInBinario(p4);

            //indirizzo IP in formato binario
            indirizzoBinario = $"{pt1Bin}.{pt2Bin}.{pt3Bin}.{pt4Bin}";
            Console.WriteLine($"Indirizzo IP in binario: {indirizzoBinario}");
            Console.ReadLine();
        }
        static string ConvertiInBinario(int num)
        {
            int resto;
            string binario = "";
            if (num == 0)
                return "0";// se è zero restituisco direttamente zero
            do
            {//converto in binario
                resto = num % 2;
                binario = resto + binario;
                num = num / 2;
            } while (num > 0);

            return binario;
        }
    }
}

