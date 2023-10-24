using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Verifica
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
            //BUTTINI LUCA Classe 4-E
            //FILA B

            int dim, pos = 0, scelta; //dimensione array, posizione per tenere conto dell'indice della conc, scelta utente
            string[] opzioni = { "Inserimento", "Visualizza", "Verifica km 0", "Esci" }; //array contenente le opzioni
            //dimensione array concessionaria
            Console.Write("Quante auto vuoi inserire nella concessionaria? -->");
            int.TryParse(Console.ReadLine(), out dim); //inserimento dim concessionaria
            Auto[] concessionaria = new Auto[dim];//definizione concessionaria
            do
            {
                Options(opzioni);
                Console.WriteLine("Che scelta vuoi effetturare");
                int.TryParse(Console.ReadLine(), out scelta); //inserimento scelta
                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("===Inserimento===");
                        switch (Inserimento(concessionaria, ref pos))
                        {//controllo il ritorno del metodo, se la conc è piena o si possono inserire altri elementi 
                            case 0:
                                Console.WriteLine("Inserimento compleatato");
                                break;
                            case 1:
                                Console.WriteLine("Concessionaria al completo");
                                break;
                        }
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
                        break;
                }

            } while (scelta != 4);

        }
        static void Visualizza(Auto[] concessionaria, ref int pos) //metodo stampa concessionaria
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
        static int Inserimento(Auto[] conc, ref int pos)
        {
            bool checkCilind = false;
            bool checkData = false;
            string targa = "";
            if (pos < conc.Length) //inserisco se la conc è ancora libera
            {
                Console.WriteLine($"INSERIMENTO AUTO {pos + 1}");
                Console.WriteLine("Inserisci Targa");
                targa = Console.ReadLine();
                while (CheckTarga(targa, conc)) //invoco metodo controllo targa, se è già presente va reinserita, se non lo è la assegno alla concessionaria.
                {
                    Console.WriteLine("Targa già presente resinserisci");
                    targa = Console.ReadLine();
                }
                conc[pos].targa = targa;
                Console.WriteLine("Inserisci Modello");
                conc[pos].modello = Console.ReadLine();
                while (!checkCilind || conc[pos].cilindrata < 600 || conc[pos].cilindrata > 3000)
                {
                    //controllo inserimento della cilindrata. Controllo che essa rispetti il range oppure che sia stata inserita nel formato corretto
                    try
                    {
                        Console.WriteLine("Inserisci cilindrata (600-3000 cc)");
                        conc[pos].cilindrata = Convert.ToInt32(Console.ReadLine());
                        checkCilind = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Formato errato, reinserire (600-3000 cc)");
                    }
                }
                while (!checkData) //controllo inserimento data nel formato corretto
                {
                    try
                    {
                        //istruzione che può sollevare eccezione
                        Console.WriteLine("Inserisci data immatricolazione (dd/mm/yyyy)");
                        conc[pos].immatricolazione = DateTime.Parse(Console.ReadLine());
                        checkData = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Formato data errato. La data deve essere (dd/mm/yyyy)");
                    }
                }
                pos++; //incremento pos per l'inserimento successivo
                return 0; //esco tornando 0
            }
            else
            {
                return 1; //se è piena ritorno 1
            }
        }
        static bool CheckTarga(string targa, Auto[] c) //metodo verifica della targa, se è presente torna true, se non lo è false
        {
            foreach (Auto a in c) //scorro array per il controllo
            {
                if (a.targa == targa)
                    return true;
            }
            return false;
        }
    }
}