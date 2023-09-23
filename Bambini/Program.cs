using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bambini
{
    class Program
    {
        static void Main(string[] args)
        {
            // aiutare la maestra a fare l'appello
            int NumeroStudenti, i;
            string[] NomeStudenti;
            
            int scelta;
            /* Prevedere quindi un menu descritto dalle righe che seguono e  implementare il punto 1 e il punto 2 
             * ( se l'utente dovesse scegliere i punti 3 o 4 scrivere a video "funzionalità non ancora implementata").
            === Registro di classe===
             [1] inserimento
             [2] presenti
             [3] ricerca
             [4] ricerca posizione alunno / registro
             [5] esci


            NOTA: se l'utente sceglie il punto 1 bisogna inserire il nome dello studente nel registro (se c'è posto...) se l'utente scegli il numero 2 stampare a video l'elenco degli studenti inseriti tramite il punto 1.Il menu deve rimanere attivo fino a quando non si preme[5] (programma finito)
            NOTA2: questo esercizio è un'evoluzione degli ultimi esercizi svolti (che possono essere presi come punto di partenza)*/
            // Inserimento bambini

            Console.WriteLine("Quanti studenti vuoi inserire?");
            NumeroStudenti = Convert.ToInt32(Console.ReadLine());
            NomeStudenti = new string[NumeroStudenti];
            int z=0;
            string nome;
            bool assente = true;
            
            Console.WriteLine("Scegli una di queste opzioni");
            Console.WriteLine("=== Registro di classe===");
            Console.WriteLine("[1] inserimento");
            Console.WriteLine("[2] presenti");
            Console.WriteLine("[3] ricerca");
            Console.WriteLine("[4] ricerca posizione alunno / registro");
            Console.WriteLine("[5] esci");
            scelta = Convert.ToInt32(Console.ReadLine());
            do
            {
                switch (scelta)
                {
                    case 1:
                        do
                        {
                            Console.WriteLine($"Inserisci nome dello studente {z + 1}");
                            NomeStudenti[z] = Console.ReadLine();
                            z++;
                        } while (NumeroStudenti != z);
                        break;
                    case 2:
                        for (i = 0; i < NumeroStudenti; i++)
                        {
                            Console.WriteLine($"Nome alunno[{i + 1}]: {NomeStudenti[i]}");
                        }
                        break;
                    case 3:
                        Console.WriteLine("FUNZIONE NON IMPLEMENTATA");
                        break;
                    case 4:
                        Console.WriteLine("Quale alunno vuoi cercare?");
                        nome = Console.ReadLine();
                        for (int t = 0; t < NumeroStudenti; t++)
                        {
                            if (nome == NomeStudenti[t])
                            {
                                Console.WriteLine($"L'alunno {nome} si trova in posizione [{t + 1}]");
                                assente = false;
                            }                            
                        }
                        if (assente)
                        {
                            Console.WriteLine("L'alunno cercato non riuslta nel registro");
                        }
                        else
                        {
                            assente = true;
                        }
                        break;
                    case 5:
                        Console.WriteLine("Programma finito");
                        break;
                    default:
                        Console.WriteLine("PULSANTE NON IMPLEMENTATO");
                        break;
                       
                }
                Console.WriteLine("Scegli una di queste opzioni");
                Console.WriteLine("=== Registro di classe===");
                Console.WriteLine("[1] inserimento");
                Console.WriteLine("[2] presenti");
                Console.WriteLine("[3] ricerca");
                Console.WriteLine("[4] ricerca posizione alunno / registro");
                Console.WriteLine("[5] esci");
                scelta = Convert.ToInt32(Console.ReadLine());
            } while (scelta != 5);
        }

    }
}
