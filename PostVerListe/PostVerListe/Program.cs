using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PostVerListe
{
    internal class Program
    {
        struct Auto //definizione struttura Auto
        {
            //definizione campi della struct
            public string targa;
            public string modello;
            public int cilindrata;
            public DateTime immatricolazione; //var di tipo DateTime per la data 
            public override string ToString() //ovveride per stampa in formato tabellare 
            {
                return string.Format($"TARGA: {targa}, MODELLO: {modello}, CILINDRATA {cilindrata}, DATA IMMATRICOLAZIONE {immatricolazione}");
            }
        }
        static void Main(string[] args)
        {
            int dim = 3, pos = 0, scelta; //dimensione array, posizione per tenere conto dell'indice della conc, scelta utente
            string[] opzioni = { "Inserimento", "Visualizza", "Verifica km 0", "Esci" }; //array contenente le opzioni
            //dimensione array concessionaria
            //Auto[] concessionaria = new Auto[dim];//definizione concessionaria
            List<Auto> concessionaria = new List<Auto>(dim);
            do
            {
                Options(opzioni);
                Console.WriteLine("Che scelta vuoi effetturare");
                int.TryParse(Console.ReadLine(), out scelta); //inserimento scelta
                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("===Inserimento===");
                        Inserimento(concessionaria, ref pos);
                        break;
                    case 2:
                        Console.WriteLine("===Visualizzazione==="); //opzione di visualizzazione
                        //ulteriore controllo che permette la stampa solo se sono presenti elementi nella conc
                        if (pos != 0)
                            Visualizza(concessionaria, ref pos);//stampa conc
                        else
                            Console.WriteLine("Nessun elemento presente nella concessionaria");
                        break;
                    case 3:
                        Console.WriteLine("===verifica km 0==="); //opzione verifica km 0
                        KmZero(concessionaria);
                        break;
                }

            } while (scelta != 4);

        }
        static int GetCilindrata()
        {
            bool checkCilind = false;
            int cilindrata = 0;

            while (!checkCilind)
            {
                Console.WriteLine("Inserisci cilindrata (deve essere compresa tra 600-3000 cc):");
                string input = Console.ReadLine();

                try
                {
                    int inputCilindrata = Convert.ToInt32(input);

                    if (inputCilindrata >= 600 && inputCilindrata <= 3000)
                    {
                        cilindrata = inputCilindrata;
                        checkCilind = true;
                    }
                    else
                    {
                        Console.WriteLine("La cilindrata deve essere compresa tra 600 e 3000 cc.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato errato o valore non valido. Reinserire (600-3000 cc) come numero intero.");
                }
            }

            return cilindrata;
        }


        static void Visualizza(List<Auto> concessionaria, ref int pos) //metodo stampa concessionaria
        {
            for (int i = 0; i < pos; i++)
            {
                Console.WriteLine();
                Console.WriteLine(concessionaria[i]);
                Console.WriteLine("=================================================================");
                Console.WriteLine();
            }
        }
        static void Options(string[] opt)//stampa opzioni menu
        {
            for (int i = 0; i < opt.Length; i++)
                Console.WriteLine($" [{i + 1}] --> {opt[i]}");
        }
        static void Inserimento(List<Auto> conc, ref int pos)
        {
            Auto newAuto = new Auto();
            bool checkData = false;
            string targa = "";
            Console.WriteLine($"INSERIMENTO AUTO {pos + 1}");
            Console.WriteLine("Inserisci Targa");
            targa = Console.ReadLine();
            while (CheckTarga(targa, conc)) //invoco metodo controllo targa, se è già presente va reinserita, se non lo è la assegno alla concessionaria.
            {
                Console.WriteLine("Targa già presente resinserisci");
                targa = Console.ReadLine();
            }
            newAuto.targa = targa;
            Console.WriteLine("Inserisci Modello");
            newAuto.modello = Console.ReadLine();
            newAuto.cilindrata = GetCilindrata();
            while (!checkData) //controllo inserimento data nel formato corretto
            {
                try
                {
                    //istruzione che può sollevare eccezione
                    Console.WriteLine("Inserisci data immatricolazione (dd/mm/yyyy)");
                    newAuto.immatricolazione = DateTime.Parse(Console.ReadLine());
                    checkData = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato data errato. La data deve essere (dd/mm/yyyy)");
                }
            }
            conc.Add(newAuto);
            pos++;
        }


        static bool CheckTarga(string targa, List<Auto> c) //metodo verifica della targa, se è presente torna true, se non lo è false
        {
            foreach (Auto a in c) //scorro array per il controllo
            {
                if (a.targa == targa)
                    return true;
            }
            return false;
        }
        static void KmZero(List<Auto> conc)
        {
            int anno;
            for (int i = 0; i < conc.Count; i++)
            {
                DateTime eta = conc[i].immatricolazione;
                anno = Eta(eta);
                if (anno != -1)
                    Console.WriteLine($"Macchina {i + 1} {conc[i]}");
            }
        }
        static int Eta(DateTime eta)
        {
            int anno = eta.Year;
            int anniOggi = DateTime.Now.Year;
            if (anniOggi - anno <= 1)
            {
                return anno;
            }

            return -1;
        }
    }
}