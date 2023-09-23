using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RipassoVettori
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensione = 10;
            int estremo = 100, aumenta = 10, n = 0, posizione = 0;
            int[] vettoreMain;
            bool booleana = false;
            CreaVettore(out vettoreMain, dimensione, estremo);

            Visualizza(vettoreMain);

            Console.WriteLine("-------------------");

            CambiaValore(vettoreMain, 4, 200);

            Console.WriteLine("-------------------");

            VisualizzaValori(vettoreMain, dimensione);

            EspandiVettore(ref vettoreMain, aumenta, estremo);

            Visualizza(vettoreMain);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            TrovaElemento(vettoreMain, n, ref booleana);//primo metodo trova
            Console.WriteLine("=============================");
            TrovaElemento2(vettoreMain, n, ref posizione); //secondo metodo trova
            Console.WriteLine("=============================");
            
            Console.ReadLine();
        }
        static void CreaVettore(out int[] vettore, int dimensione, int estremo)
        {
            vettore = new int[dimensione];
            Random valori = new Random();

            for (int i = 0; i < dimensione; i++)
            {
                vettore[i] = valori.Next(1, estremo + 1);
            }
        }

        static void CambiaValore(int[] vettoreMod, int posizione, int valore)
        {
            vettoreMod[posizione] = valore;
        }

        static void Visualizza(int[] vettoreVisualizza) //se il vettore è completamente pieno usiamo .Length
        {
            for (int i = 0; i < vettoreVisualizza.Length; i++)
            {
                Console.Write(vettoreVisualizza[i] + " ");
            }
            Console.WriteLine();
        }
        static void VisualizzaValori(int[] vettoreVisualizza, int dim) //altrimenti usiamo dim
        {
            for (int i = 0; i < dim; i++)
            {
                Console.Write(vettoreVisualizza[i] + " ");
            }
            Console.WriteLine();
        }

        static void EspandiVettore(ref int[] vettoreVecchio, int aumentaDim, int estremo)
        {
            int[] vettoreEsp = new int[vettoreVecchio.Length + aumentaDim];

            for (int i = 0; i < vettoreVecchio.Length; i++)
            {
                vettoreEsp[i] = vettoreVecchio[i];
            }
            Random valori = new Random();
            for (int i = vettoreVecchio.Length; i < vettoreVecchio.Length + aumentaDim; i++)
            {

                vettoreEsp[i] = valori.Next(1, estremo + 1);
            }

            vettoreVecchio = vettoreEsp;
        }


        //cercare un elemento all'interno di un vettore ritornando la posizione se presente
        //in ogni caso il metodo deve segnalare se l'elemento è presente oppure no

        static void TrovaElemento(int[] vettoreDati, int elemento, ref bool trovato)
        {
            Console.WriteLine("Inserisci l'elemento da cercare");
            elemento = Convert.ToInt32(Console.ReadLine());

            trovato = false;  // inizializzo a false

            for (int i = 0; i < vettoreDati.Length; i++)
            {
                if (elemento == vettoreDati[i])
                {
                    Console.WriteLine($"Il numero ricercato si trova in posizione {i}");
                    trovato = true;//è presente quindi true
                }
            }
            Console.WriteLine(trovato);//stampo Trovato, in base al caso True o False
        }//ritorna trovato e posizione


        static void TrovaElemento2(int[] vettoreDati, int elemento, ref int pos) //non mi funziona se è false
        {
            Console.WriteLine("Inserisci l'elemento da cercare");
            elemento = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < vettoreDati.Length; i++)
            {
                if (elemento == vettoreDati[i])
                {
                    pos = i;
                    break;
                }
            }
            if (pos != -1)
            {
                Console.WriteLine($"Il numero ricercato è presente");
            }
            else
            {
                Console.WriteLine("Non presente");
            }
            
        }//posizione valida? trovato?



        //static bool TrovaElemento3(int[] vettoreDati, int elemento, int posizione)
        //{

        //}//trovato ritornato come bool
        //static int TrovaElemento4(int[] vettoreDati, int elemento)
        //{
        //}//valore ritornato indica se l'elemento è presente o no (assieme alla posizione)
    }
}