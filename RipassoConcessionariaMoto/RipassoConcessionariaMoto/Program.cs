using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RipassoConcessionariaMoto
{
    internal class Program
    {
        struct Moto
        {
            public string marca;
            public string modello;
            public double prezzo;
        }
        static void Main(string[] args)
        {
            Moto[] concessionaria = new Moto[6];
            int ultimoElemento = -1;

            Console.WriteLine("Inserisci moto:");
            Moto m1 = new Moto();
            m1.marca = "marca1";
            m1.modello = "modello1";
            m1.prezzo = 10;
            Moto m2 = new Moto();
            m2.marca = "marca2";
            m2.modello = "modello2";
            m2.prezzo = 20;
            Moto m3 = new Moto();
            m3.marca = "marca3";
            m3.modello = "modello3";
            m3.prezzo = 30;
            Moto m4 = new Moto();
            m4.marca = "marca4";
            m4.modello = "modello4";
            m4.prezzo = 40;
            Moto m5 = new Moto();
            m5.marca = "marca5";
            m5.modello = "modello5";
            m5.prezzo = 50;
            Moto m6 = new Moto();
            m6.marca = "marca6";
            m6.modello = "modello6";
            m6.prezzo = 60;
            Console.WriteLine(Inserimento(concessionaria, ref ultimoElemento, m1));
            Console.WriteLine(Inserimento(concessionaria, ref ultimoElemento, m2));
            Console.WriteLine(Inserimento(concessionaria, ref ultimoElemento, m3));
            Console.WriteLine(Inserimento(concessionaria, ref ultimoElemento, m4));
            Console.WriteLine(Inserimento(concessionaria, ref ultimoElemento, m5));
            Console.WriteLine(Inserimento(concessionaria, ref ultimoElemento, m6));
            VisualizzaTutte(concessionaria, ultimoElemento);
            Console.WriteLine("**************************");
            EliminazioneMoto(concessionaria, ref ultimoElemento, 0);
            VisualizzaTutte(concessionaria, ultimoElemento);
            Console.ReadLine();
        }
        static bool Inserimento(Moto[] conc, ref int ultimoElemento, Moto m)
        {
            if (controlloMoto(conc, m, ultimoElemento))
            {
                return false;
            }
            else
            {
                if (ultimoElemento < conc.Length)
                {
                    ultimoElemento++;
                    conc[ultimoElemento] = m;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        static bool controlloMoto(Moto[] conc, Moto m, int ultimoElemento)
        {
            for (int i = 0; i < ultimoElemento; i++)
            {
                if (conc[i].modello == m.modello && conc[i].marca == m.marca)
                {
                    return true;
                }
            }
            return false;
        }
        static void VisualizzaTutte(Moto[] conc, int ultimoElemento)
        {
            for (int i = 0; i <= ultimoElemento; i++)
            {
                Console.WriteLine(conc[i].modello);
                Console.WriteLine(conc[i].marca);
                Console.WriteLine(conc[i].prezzo);
            }
        }
        static Moto LeggiMoto(Moto[] conc, int index)
        {
            return conc[index];
        }
        static int TrovaMoto(Moto[] conc, Moto moto, int ultimoElemento)
        {
            for (int i = 0; i <= ultimoElemento; i++)
            {
                if (conc[i].modello == moto.modello && conc[i].marca == moto.marca)
                {
                    return i;
                }
            }
            return -1;
        }
        static void EliminazioneMoto(Moto[] conc, ref int ultimoElemento, int index)
        {
            if (index == conc.Length - 1 || index == ultimoElemento)
            {
                ultimoElemento--;
                return;
            }
            else
            {
                for (int j = index; j < ultimoElemento; j++)
                {
                    conc[j] = conc[j + 1];
                }
                ultimoElemento--;
            }
        }
    }
}