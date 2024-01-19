using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Es_Ripasso
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Flotta f1 = new Flotta("flotta1", "AAA0"); 
            Veicolo v1;
            Veicolo v2;
            string t1 = GeneraTarga();
            string t2 = GeneraTarga();
            try
            {
                v1 = new Veicolo("marca1", "modello1", NumeroPosti.Quattro, t1, 2);
                v2 = new Veicolo("marca2", "modello2", NumeroPosti.Quattro, t2, 5);

            }
            catch (Exception ex)
            {
                v1 = null;
                v2 = null;
                Console.WriteLine(ex.Message);
            }
            f1.InserimentoVeicoli(v1);
            f1.InserimentoVeicoli(v2);
            Console.ReadLine();
        }
        static string GeneraTarga()
        {
            string targa;
            Random random = new Random();

            char lettera1 = Random(random);
            char lettera2 = Random(random);

            int numero1 = random.Next(10);
            int numero2 = random.Next(10);
            int numero3 = random.Next(10);

            char lettera3 = Random(random);
            char lettera4 = Random(random);

            targa = $"{lettera1}{lettera2}{numero1}{numero2}{numero3}{lettera3}{lettera4}";

            return targa;
        }
        static char Random(Random random)
        {
            const string alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int indice = random.Next(alfabeto.Length);
            return alfabeto[indice];
        }
    }
}
