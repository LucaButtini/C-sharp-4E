using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AnagrafeCvs
{
    enum sesso
    {
        maschio,
        femmina
    }

    enum statoCivile
    {
        celibe,
        nubile,
        coniugato,
        vedovo,
        separato
    }

    struct persona
    {
        public string cf;
        public string cognome;
        public string nome;
        public DateTime nascita;
        public statoCivile stato;
        public string cittadinanza;
        public sesso genere;
        public int eta;
        public override string ToString()
        {
            return string.Format($"Codice fiscale:{cf}, Cognome: {cognome}, Nome: {nome}, Data di nascita: {nascita.ToShortDateString()}, " +
                $"Stato civile: {stato}, Cittadinanza: {cittadinanza}, Genere: {genere}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int dimMax;
            Console.WriteLine("Quante persone vuoi inserire: ");
            while (RichiestaNum(out dimMax)) { Console.WriteLine("Quante persone vuoi inserire: "); }  // continua il ciclo fin quando una dimensione corretta è inserita
            persona[] persone = new persona[dimMax];
            persona dati = new persona();
            List<persona> anagrafica = new List<persona>();
            int scelta;
            int sceltaEta;
            int n = 0; //conta quante persone vengono inserite
            do
            {
                Menu(out scelta);
                switch (scelta)
                {
                    case 1: InputPersona(persone, dati, dimMax, ref n); break;
                    case 2: VisuaMenu(persone, n); break;
                    case 3:
                        if (n == 0)
                        {
                            Console.WriteLine("Non hai ancora inserito nessuno nell'anagrafe"); break;
                        }
                        else
                        {
                            EtaMenu(persone, out sceltaEta);
                            switch (sceltaEta)
                            {
                                case 1: int indice = RitornaIndice(persone, n, InputCF()); Console.WriteLine($"{persone[indice].cognome} {persone[indice].nome} ha {CalcoloEta(persone, n, indice)} anni"); ; break;
                                case 2:
                                    for (int i = 0; i < n; i++)
                                    {
                                        Console.WriteLine($"{persone[i].cognome} {persone[i].nome} ha {CalcoloEta(persone, n, i)} anni");
                                    }
                                    break;
                            }
                            break;
                        }
                    case 4:
                        if (n == 0)
                        {
                            Console.WriteLine("Non hai ancora inserito nessuno nell'anagrafe"); break;
                        }
                        else
                        {
                            int indice = RitornaIndice(persone, n, InputCF());
                            if (indice >= 0)
                            {
                                Console.WriteLine($"Lo stato civile di {persone[indice].cognome} {persone[indice].nome} è {persone[indice].stato}");
                                Modifica(ref persone[indice].stato);
                                GestioneFile($"Stato civile di {persone[indice].cognome} {persone[indice].nome} modificato a {persone[indice].stato}");
                            }
                            break;
                        } //chiama il metodo modifica che cambierà lo stato civile all'indice dato in input in base al codice fiscale
                    case 5:
                        int indi = RitornaIndice(persone, n, InputCF());
                        if (indi >= 0)
                        {
                            GestioneFile($"Cancellazione di {persone[indi]}");
                            Cancella(persone, indi, ref n);
                        }
                        break;
                    case 6:
                        GestioneFile(null);
                        break;
                    case 7:
                        StreamWriter csv = new StreamWriter(Environment.CurrentDirectory + @"\logs\logfile.csv", true);//Se true o false sovracrive o crea il file
                        string strCsv;
                        foreach (persona p1 in persone)//Metto la struttura dati
                        {
                            //strCsv = string.Format($"Codice fiscale:{p1.cf}, Cognome: {p1.cognome}, Nome: {p1.nome}, Data di nascita: {p1.nascita.ToShortDateString()}, " +
                            //$"Stato civile: {p1.stato}, Cittadinanza: {p1.cittadinanza}, Genere: {p1.genere}");
                            strCsv = string.Format($"{p1.cf},{p1.cognome},{p1.nome},{p1.nascita.ToShortDateString()}," +
                            $"{p1.stato},{p1.cittadinanza},{p1.genere}");
                            csv.WriteLine(strCsv);
                        }
                        csv.Close();
                        break;
                    case 8:
                        persona person = new persona();
                        StreamReader csvRV = new StreamReader(Environment.CurrentDirectory + @"\logs\logfile.csv");
                        string strCsvRV;
                        strCsvRV = csvRV.ReadLine();
                        do
                        {
                            strCsvRV = csvRV.ReadLine();
                            string[] splitted = strCsvRV.Split(',');
                            person.cf = splitted[0];
                            person.cognome = splitted[1];
                            person.nome = splitted[2];
                            person.nascita = DateTime.Parse(splitted[3]);
                            switch (splitted[4])
                            {
                                case "celibe":
                                    person.stato = statoCivile.celibe;
                                    break;
                                case "nubile":
                                    person.stato = statoCivile.nubile;
                                    break;
                                case "vedovo":
                                    person.stato = statoCivile.vedovo;
                                    break;
                                case "coniugato":
                                    person.stato = statoCivile.coniugato;
                                    break;
                                case "separato":
                                    person.stato = statoCivile.separato;
                                    break;
                            }
                            person.cittadinanza = splitted[5];
                            if (splitted[6] == "maschio")
                            {
                                person.genere = sesso.maschio;
                            }
                            else
                            {
                                person.genere = sesso.femmina;
                            }
                            anagrafica.Add(person);

                        } while (!csvRV.EndOfStream);
                        anagrafica.ForEach(p => Console.WriteLine(p.ToString()));

                        break;
                }

            } while (scelta != 9);
        }
        static void Cancella(persona[] persone, int indice, ref int n) //mette tutti i valori contenuti nell'array all'indice precedente, così lasciando l'ultimo indice aperto per una nuova persona
        {
            int i = indice;
            do
            {
                if (i == n - 1)
                {
                    persone[i] = new persona();
                }
                else
                {
                    persone[i] = persone[i + 1];
                    i++;
                }
            }
            while (i < n - 1);
            n--;
            Console.WriteLine("Cancellato correttamente");
        }
        static bool RichiestaNum(out int num)
        {
            if (int.TryParse(Console.ReadLine(), out num))
            {
                return false;
            }
            else return true;
        }
        static void Menu(out int scelta)
        {
            bool sceltaValida = true;
            do
            {
                Console.WriteLine("-----------------------------------------------\nSCEGLI TRA QUESTE OPZIONI \n 1-INSERIMENTO NELL'ANAGRAFE \n 2-VISUALIZZAZIONE ANAGRAFE \n 3-ETA\n 4-MODIFICA \n 5-CANCELLAZIONE  \n 6-LEGGI LOG \n 7-CSV \n 8-IMPORTA CSV \n 9-ESCI");
                RichiestaNum(out scelta);
                if (scelta > 0 && scelta < 10)
                {
                    sceltaValida = false;
                }
                else { Console.WriteLine("Hai inserito un numero non valido"); }
            } while (sceltaValida);
        }
        static statoCivile Modifica(ref statoCivile statoCivile)
        {
            Console.WriteLine("Inserisci il nuovo stato civile");
            if (Enum.TryParse(Console.ReadLine(), out statoCivile)) { }
            else { Console.WriteLine("Non hai inserito uno stato civile corretto, modifica non accettata"); }

            return statoCivile;
        }
        static int RitornaIndice(persona[] persona, int n, string cf) //ritorna l'indice di un certo codice fiscale all'interno dell'array
        {
            bool trovato = true;
            int indice = -1;
            for (int i = 0; trovato && i < n; i++)
            {
                if (persona[i].cf == cf)
                {
                    indice = i;
                    trovato = false;
                }
            }
            if (trovato) { Console.WriteLine("Questo codice fiscale non è presente all'interno dell'anagrafe"); }
            return indice;
        }
        static void EtaMenu(persona[] persone, out int scelta)
        {
            bool sceltaValida = true;
            do
            {
                Console.Clear();
                Console.WriteLine("\rSCEGLI TRA QUESTE OPZIONI\n1-VISUALIZZA PERSONA\n2-VISUALIZZA ARCHIVIO\r");
                RichiestaNum(out scelta);
                if (scelta > 0 && scelta < 3)
                {
                    sceltaValida = false;
                }
                else { Console.WriteLine("Hai inserito un numero non valido"); }
            } while (sceltaValida);
        }
        static void InputPersona(persona[] persone, persona dati, int dimMax, ref int n) //Ottiene i dati attraverso input e li mette dentro al vettore
        {
            bool controllo = true;
            if (n < dimMax)
            {
                do
                {
                    Console.WriteLine((n + 1) + " - Inserisci il tuo codice fiscale: "); //indica su quale parte  del menu scrive
                    dati.cf = Console.ReadLine();
                    Console.WriteLine((n + 1) + " - Inserisci il tuo cognome: ");
                    dati.cognome = Console.ReadLine();
                    Console.WriteLine((n + 1) + " - Inserisci il nome: ");
                    dati.nome = Console.ReadLine();
                    Console.WriteLine((n + 1) + " - Inserisci la tua data di nascita: ");
                    DateTime.TryParse(Console.ReadLine(), out dati.nascita);
                    Console.WriteLine((n + 1) + " - Inserisci il tuo stato civile(celibe/nubile/coniugato/vedovo/separato): ");
                    Enum.TryParse<statoCivile>(Console.ReadLine(), out dati.stato);
                    Console.WriteLine((n + 1) + " - Inserisci la tua cittadinanza: ");
                    dati.cittadinanza = Console.ReadLine();
                    Console.WriteLine((n + 1) + " - Inserisci il tuo sesso(maschio/femmina): ");
                    Enum.TryParse<sesso>(Console.ReadLine(), out dati.genere);
                    if (!ControlloCF(n, persone, dati)/* && VerificaCF(dati, persone, ref n)*/) //controllo se i dati inseriti sono validi e corretti
                    {
                        persone[n] = dati;
                        n++;
                        controllo = false;
                    }
                    else { Console.WriteLine("Hai già inserito questo codice fiscale"); }
                } while (controllo);
                Console.WriteLine("INSERITO CORRETTAMENTE");
                GestioneFile("Inserimento dati: " + dati.ToString());
            }
            else { Console.WriteLine("L'ANAGRAFE è PIENA"); }

        }

        static void VisuaMenu(persona[] persone, int n) //visualizza tutti i dati in memoria
        {
            if (n == 0)
            {
                Console.WriteLine("Non hai ancora inserito nessuno nell'anagrafe");
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Nell'indice numero " + (i + 1) + " ci sono questi dati: " + persone[i]);
                }
            }
        }

        static int CalcoloEta(persona[] persone, int n, int i)
        {
            if (persone[i].nascita.Month >= DateTime.Now.Month)
            {
                if (persone[i].nascita.Day >= DateTime.Now.Day)
                { persone[i].eta = DateTime.Now.Year - persone[i].nascita.Year; }
                else
                { persone[i].eta = (DateTime.Now.Year - 1) - persone[i].nascita.Year; }
            }
            else
            { persone[i].eta = (DateTime.Now.Year - 1) - persone[i].nascita.Year; };
            return persone[i].eta;
        }

        static string InputCF()
        {
            string CF;
            Console.WriteLine("Inserisci il codice fiscale della persona");
            CF = Console.ReadLine();
            return CF;
        }

        static bool ControlloCF(int n, persona[] persone, persona dati)
        {
            bool trovato = false;
            if (n != 0)
            {
                for (int i = 0; !trovato && (i < n); i++) // controlla se ci sono le stesse persone nell'anagrafe
                {
                    //string[] cf = Convert.ToString(persone[i]).Split((char)58, (char)44);
                    trovato = dati.cf == persone[i].cf;
                }
            }
            return trovato;
        }
        static void GestioneFile(string output)
        {
            string path = Environment.CurrentDirectory + @"\logs" + "\\" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "logFile.txt";
            if (!File.Exists(path))
            {
                FileStream newFile = File.Create(path);
                //newFile.Close();
            }
            if (output != null)
            {
                ScriviSuFile(path, output);
            }
            else
            {
                string[] files;
                getFiles(Environment.CurrentDirectory + @"\logs", out files);
                //files = Directory.GetFiles(path+@"");
                int scelta;
                scelta = int.Parse(Console.ReadLine());
                if (scelta < files.Length)
                    LeggiFile(files[scelta]);
                else
                    Console.WriteLine("Numero non valido");
            }
        }
        static void ScriviSuFile(string path, string output)
        {
            StreamWriter sw = File.AppendText(path);
            sw.WriteLine(DateTime.Now.ToString() + " " + output);
            sw.Close();
        }
        static void LeggiFile(string path)
        {
            StreamReader sr = File.OpenText(path);
            string linea;
            while (!sr.EndOfStream)
            {
                linea = sr.ReadLine();
                Console.WriteLine(linea);
            }
        }

        static void getFiles(string directory, out string[] files)
        {
            files = Directory.GetFiles(directory);
            int x = 0;
            /*foreach (string file in files)
            {
                Console.WriteLine(file);
            }*/
            foreach (string file in files)
            {
                Console.WriteLine($"[{x}] " + Path.GetFileName(files[x]));
                x++;
            }
        }
    }
}
