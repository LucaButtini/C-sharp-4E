﻿using System;
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
            Console.ReadLine();
        }

        static bool[] ConvertDpToBin(int[] dp)  //METODO 1
        {
            bool[] bn = new bool[32];
            int j = bn.Length - 1;  // Inizializza j all'ultimo indice dell'array bn

            for (int i = 0; i < dp.Length; i++)
            {
                int num = dp[i];  // Salva il numero corrente
                do
                {
                    bn[j] = num % 2 == 1;  // Inserisci il bit corretto in ordine inverso
                    num = num / 2;
                    j--;
                } while (num > 0 && j >= 0);
            }
            return bn;
        }

        static int ConvertDpToIntero(int[] dp) //METODO 2
        {
            int decimale = 0;
            int j = 3;
            for (int i = 0; i < dp.Length; i++)
            {
                decimale += dp[i] * (int)Math.Pow(256, j--);
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

    }
}

