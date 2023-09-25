using System;

namespace RipassoVettori
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensione = 10;
            int estremo = 100, aumenta = 10, n = 0, posizione = -1, ultimoElemento = -1, index;
            int[] vettoreMain;
            bool booleana = false;
            CreaVettore(out vettoreMain, dimensione, estremo, ref ultimoElemento);

            Visualizza(vettoreMain);

            Console.WriteLine("-------------------");

            CambiaValore(vettoreMain, 4, 200);

            Console.WriteLine("-------------------");

            VisualizzaValori(vettoreMain, dimensione);
            

            EspandiVettore(ref vettoreMain, aumenta, estremo);
            Visualizza(vettoreMain);

            Console.WriteLine("Inserisci l'elemento da cercare");
            n = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            TrovaElemento(vettoreMain, n, ref booleana);//primo metodo trova
            Console.WriteLine("=============================");
            TrovaElemento2(vettoreMain, n, ref posizione); //secondo metodo trova
            Console.WriteLine("=============================");
            Console.WriteLine(TrovaElemento3(vettoreMain, n, posizione));
            Console.WriteLine("=============================");
            Console.WriteLine(TrovaElemento4(vettoreMain, n));
            Console.WriteLine();
            Console.WriteLine();
            //Console.WriteLine("Inserisci indice posizione");
            //index = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(Eliminazione(vettoreMain, index, ultimoElemento)); 
            Eliminazione(ref vettoreMain, n);
            Console.WriteLine("Il vettore con elemento cancellato");
            VisualizzaValori(vettoreMain, vettoreMain.Length);
            Console.ReadLine();
        }
        static void CreaVettore(out int[] vettore, int dimensione, int estremo, ref int ultimoElemento)
        {
            vettore = new int[dimensione];
            Random valori = new Random();

            for (int i = 0; i < dimensione; i++)
            {
                ultimoElemento++;
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


        static void TrovaElemento2(int[] vettoreDati, int elemento, ref int pos)
        {

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



        static bool TrovaElemento3(int[] vettoreDati, int elemento, int posizione)
        {
            bool trovato = false;

            for (int i = 0; i < vettoreDati.Length; i++)
            {
                if (vettoreDati[i] == elemento)
                {
                    trovato = true;
                }

            }
            return trovato;
        }//trovato ritornato come bool
        static int TrovaElemento4(int[] vettoreDati, int elemento)
        {

            for (int i = 0; i < vettoreDati.Length; i++)
            {
                if (vettoreDati[i] == elemento)
                {
                    return i;
                }
            }
            return -1;
        }//valore ritornato indica se l'elemento è presente o no (assieme alla posizione)


        //static void Eliminazione(int[] vettoreDati, int index, ref int ultimoElemento)//da sistemare
        //{
        //    if (index == vettoreDati.Length - 1 || index == ultimoElemento)
        //    {
        //        ultimoElemento--;
        //        return;
        //    }
        //    else
        //    {
        //        for (int i = index; i < ultimoElemento; i++)
        //        {
        //            vettoreDati[i] = vettoreDati[i + 1];
        //        }
        //        ultimoElemento--;
        //    }
        //}
        static void Eliminazione(ref int[] array, int elemento)
        {

            int j, presente = 0, k=0;
            j = TrovaElemento4(array, elemento);//invoco per trovare la posizione
            if (j != -1)
            {
                for (int i = j; i < array.Length; i++)
                {
                    if (array[i] == elemento)//mi conto gli elementi dell'array per creare quello nuovo 
                    {
                        presente++; 
                    }
                }
                int[] newArray = new int[array.Length - presente];//creo il nuovo array togliendo presente dalla Length
                foreach(int numero in array)
                {
                    if(numero!=elemento)
                    {
                        newArray[k++] = numero; //ricopio tutti quelli non uguali all'elemento. Incremento k.
                    }
                }
                array= newArray;//assegno indirizzo memoria di newArray ad array
            }
        }
    }
}
