using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaraPiloti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Gara";
            int scelta;
            string[] opzioni = { "Inserimento", "Visualizza", "Vincitore", "Exit" };
            Gara gara = new Gara();

            do
            {
                scelta = Menu(opzioni, "GARA");
                Console.Clear();

                if (gara.NumPiloti() == 0 && scelta != 0)
                {
                    Console.WriteLine("Griglia di partenza vuota");
                }
                else
                {
                    switch (scelta)
                    {
                        case 0:
                            if (gara.NumPiloti() < 3)
                            {
                                Inserimento(gara);
                            } else
                            {
                                Console.WriteLine("Griglia di partenza al completo");
                            }
                            break;

                        case 1:
                            gara.StampaGriglia();
                            break;

                        case 2:
                            gara.VincitoreGara();
                            break;
                    }
                }

                if (scelta != opzioni.Length - 1)
                {
                    Console.WriteLine("\n\nPremi invio per tornare al menù principale");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (scelta != opzioni.Length - 1);
        }
        static int Menu(string[] opzioni, string titolo)
        {
            int scelta;

            Console.WriteLine($"======== {titolo} ========\n");

            for (int i = 0; i < opzioni.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] <<  {opzioni[i]}");
            }

            Console.WriteLine("\n======================\n");

            scelta = InserimentoInt("Inserisci la scelta: ", opzioni.Length, 1);
            return scelta - 1;
        }
        static void Inserimento(Gara gara)
        {
            string nome, cognome, scuderia;

            nome = InserimentoStringa("Inserisci il nome del pilota:");

            cognome = InserimentoStringa("\nInserisci il cognome del pilota:");

            scuderia = InserimentoStringa("\nInserisci la scuderia dell'auto:");

            gara.AddScuderia(new Auto(scuderia, new Pilota(nome, cognome)));
        }
        static string InserimentoStringa(string input)
        {
            string stringa;
            do
            {
                Console.WriteLine(input);
                stringa = Console.ReadLine();

                foreach (char c in stringa)
                {
                    if (char.IsDigit(c))
                    {
                        stringa = "";
                        break;
                    }
                }
            } while (stringa == "");

            return stringa;
        }
        static int InserimentoInt(string input, int valMax, int valMin)
        {
            int val;

            do
            {
                Console.WriteLine(input);

            } while (!int.TryParse(Console.ReadLine(), out val) || val > valMax || val < valMin);

            return val;
        }
    }
}
