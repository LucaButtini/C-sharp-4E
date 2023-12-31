﻿using System;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters;

namespace Conversioni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dp = new int[4];
            for (int i = 0; i < dp.Length; i++)
            {
                Console.WriteLine($"Inserisci cifra {i + 1}");
                dp[i] = Convert.ToInt32(Console.ReadLine());
            }
            bool[] bn = ConvertDpToBin(dp);

            for (int i = 0; i < bn.Length; i++)
            {
                Console.Write(Convert.ToInt32(bn[i]));
            }
            Console.WriteLine();
            Console.WriteLine(ConvertDpToIntero(dp));
            Console.WriteLine();
            Console.WriteLine(ConvertBinToIntero(bn));
            Console.WriteLine(); 
            Console.WriteLine(ConvertBinToDec(bn));
            Console.ReadLine();
        }

        static bool[] ConvertDpToBin(int[] dp)  //METODO 1
        {
            bool[] bn = new bool[32];
            int j = bn.Length - 1;  // Inizializza j all'ultimo indice dell'array bn

            for (int i = 0; i < dp.Length; i++)
            {
                int num = dp[i];  // Salva il numero corrente
                for (int y = 0; y < 8; y++)
                {
                    bn[j] = num % 2 == 1;  // Inserisci il bit corretto in ordine inverso
                    num = num / 2;
                    j--;
                }
            }
            return bn;
        }
        //192168561
        static int ConvertDpToIntero(int[] dp) // METODO 2
        {
            int decimale = 0;
            int j = 3;
            for (int i = 0; i < dp.Length; i++)
            {
                decimale += dp[i] * (int)Math.Pow(256, j);
                j--;
            }
            return decimale;
        }


        static int ConvertBinToIntero(bool[] bn)  //METODO 3
        {
            int intero = 0;
            int j = bn.Length - 1;

            for (int i = 0; i < bn.Length; i++)
            {
                if (bn[i])
                {
                    intero += (int)Math.Pow(2, j);
                }
                j--;
            }
            return intero;
        }
        static int ConvertBinToDec(bool[] bn) // Metodo per convertire il binario in decimale
        {
            int d = 0;
            for (int i = bn.Length - 1; i >= 0; i--) //itero al contrario fino a zero
            {
                if (bn[i])
                {
                    //Se il bit è 1, viene aggiunto al valore decimale la potenza di 2 corrispondente a quella posizione
                    //nell'array binario l'esponente è calcolato in base all'indice dell'array binario(bn.Length -1 - i)
                    //tenendo conto dell'ordine inverso dei bit.
                    d += (int)Math.Pow(2, bn.Length - 1 - i); 
                }
            }
            return d;
        }

    }
}


