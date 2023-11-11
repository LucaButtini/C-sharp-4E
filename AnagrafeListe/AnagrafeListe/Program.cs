using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AnagrafeListe
{

    enum Sesso
    {
        Maschio,
        Femmina
    }

    enum StatoCivile
    {
        Celibe,
        Nubile,
        Coniugato,
        Vedovo,
        Separato
    }
    enum StatoElemento //stato anagrafica
    {
        Libero,
        Occupato,
        Cancellato
    }
    struct Persona
    {
        public string Id; // Codice fiscale
        public string Cognome;
        public string Nome;
        public string Cittadinanza;
        public DateTime Nascita;
        public StatoCivile Stato;
        public Sesso Genere;

        public override string ToString()
        {
            return $"NOME: {Nome}, COGNOME: {Cognome}, CITTADINANZA: {Cittadinanza}, NASCITA: {Nascita}, ID: {Id}, GENERE: {Genere}, STATO CIVILE: {Stato}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] opzioni1 = { "Inserimento", "Visualizza", "Età", "Modifica Stato", "Cancella utente", "Leggi Log", "CSV", "Importa CSV", "Esci dal Menu" };
            string[] opzioni2 = { "Persona", "Archivio" };
            List<Persona> persone = new List<Persona>();
            List<StatoElemento> statoElementi = new List<StatoElemento>();
            int index = 0;
            int scelta1;
            string cf;

            do
            {
                StampaMenu(opzioni1);
                Console.WriteLine("Che scelta vuoi fare?");
                int.TryParse(Console.ReadLine(), out scelta1);

                switch (scelta1)
                {
                    case 1:
                        LeggiPersona(persone, statoElementi, ref index);
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("=====ANAGRAFICA=====");
                        StampaPersone(persone, statoElementi);
                        break;
                    case 3:
                        Console.WriteLine("=== CALCOLO DELL'ETÀ ===");
                        Console.WriteLine("Inserisci il codice fiscale della persona:");
                        cf = Console.ReadLine();
                        TrovaEdElencaPersona(persone, statoElementi, cf);
                        break;

                    case 4:
                        Console.WriteLine("===MODIFICA STATO CIVILE=== ");
                        Console.WriteLine("Inserisci il codice fiscale della persona:");
                        cf = Console.ReadLine();
                        ModificaStato(persone, statoElementi, cf);
                        break;
                    case 5:
                        Console.WriteLine("===CANCELLA UTENTE===");
                        Console.WriteLine("Inserisci il codice fiscale della persona da cancellare:");
                        cf = Console.ReadLine();
                        EliminaUtente(persone, statoElementi, cf);
                        break;
                    case 6:
                        Console.WriteLine("=== LEGGI LOG ===");

                        //  estensioni desiderate
                        string[] ext = { ".txt", ".csv" };

                        // ottengo e visualizzare i file con le estensioni specificate
                        GetFiles(Path.Combine(Environment.CurrentDirectory, "logbin"), ext);
                        break;
                    case 7:
                        StreamWriter csv = new StreamWriter(Environment.CurrentDirectory + @"\logbin\logfile.csv", true);//Se true o false sovracrive o crea il file
                        string strCsv;
                        foreach (Persona p1 in persone)//Metto la struttura dati
                        {
                            //strCsv = string.Format($"Codice fiscale:{p1.cf}, Cognome: {p1.cognome}, Nome: {p1.nome}, Data di nascita: {p1.nascita.ToShortDateString()}, " +
                            //$"Stato civile: {p1.stato}, Cittadinanza: {p1.cittadinanza}, Genere: {p1.genere}");
                            strCsv = string.Format($"{p1.Id},{p1.Cognome},{p1.Nome},{p1.Nascita.ToShortDateString()}," +
                            $"{p1.Stato},{p1.Cittadinanza},{p1.Genere}");
                            csv.WriteLine(strCsv);
                        }
                        csv.Close();
                        Console.WriteLine("File csv");
                        break;
                    case 8:
                        StreamReader csvRV = new StreamReader(Environment.CurrentDirectory + @"\logbin\logfile.csv");
                        string strCsvRV;

                        while ((strCsvRV = csvRV.ReadLine()) != null)
                        {
                            Persona person = new Persona(); // Crea una nuova istanza di Persona per ogni riga del CSV

                            string[] splitted = strCsvRV.Split(',');

                            person.Id = splitted[0];
                            person.Cognome = splitted[1];
                            person.Nome = splitted[2];
                            person.Nascita = DateTime.Parse(splitted[3]);

                            if (Enum.TryParse(splitted[4].Trim(), true, out StatoCivile statoCivile)) // Il parametro true indica di ignorare la distinzione tra maiuscole e minuscole durante la conversione.
                            {
                                person.Stato = statoCivile;
                            }
                            else
                            {
                                // se stato civile non riconosciuto
                                Console.WriteLine($"Stato civile non riconosciuto: {splitted[4]}");
                            }

                            person.Cittadinanza = splitted[5];


                            if (Enum.TryParse(splitted[6].Trim(), true, out Sesso genere))
                            {
                                person.Genere = genere;
                            }
                            else
                            {
                                // se genere non riconosciuto
                                Console.WriteLine($"Genere non riconosciuto: {splitted[6]}");
                            }

                            persone.Add(person); // aggiungo persona alla lista
                        }
                        Console.WriteLine("Importazione avvenuta con successo");
                        csvRV.Close();
                        break;

                    case 9:
                        Console.WriteLine("Uscita dal Menu");
                        break;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;
                }

                if (scelta1 != 9)
                {
                    Console.WriteLine("Premi Invio per tornare al Menu.");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (scelta1 != 9);
        }

        static void LeggiPersona(List<Persona> p, List<StatoElemento> stato, ref int j)
        {
            Persona nuovaPersona = new Persona(); // Crea una nuova istanza di Persona

            bool checkDate = false;

            Console.WriteLine($"Inserimento persona {j + 1}:");

            Console.WriteLine("Inserisci nome: ");
            nuovaPersona.Nome = Console.ReadLine();

            Console.WriteLine("Inserisci cognome: ");
            nuovaPersona.Cognome = Console.ReadLine();

            Console.WriteLine("Inserisci cittadinanza: ");
            nuovaPersona.Cittadinanza = Console.ReadLine();

            checkDate = false;
            while (!checkDate)
            {
                nuovaPersona.Nascita = CheckData();
                checkDate = true;
            }

            Console.WriteLine("Inserisci id: ");
            string id = Console.ReadLine();
            while (CheckId(id, p))
            {
                Console.WriteLine("Codice fiscale già presente. Reinserisci.");
                id = Console.ReadLine();
            }
            nuovaPersona.Id = id;

            Console.WriteLine("Inserisci genere");
            switch (MenuGenere())
            {
                case 1:
                    nuovaPersona.Genere = Sesso.Maschio;
                    break;
                case 2:
                    nuovaPersona.Genere = Sesso.Femmina;
                    break;
            }

            Console.WriteLine("Inserisci stato civile");
            switch (MenuStatoCivile())
            {
                case 1:
                    nuovaPersona.Stato = StatoCivile.Celibe;
                    break;
                case 2:
                    nuovaPersona.Stato = StatoCivile.Nubile;
                    break;
                case 3:
                    nuovaPersona.Stato = StatoCivile.Coniugato;
                    break;
                case 4:
                    nuovaPersona.Stato = StatoCivile.Vedovo;
                    break;
                case 5:
                    nuovaPersona.Stato = StatoCivile.Separato;
                    break;
            }

            // Aggiungo la nuova persona alla lista e imposta lo stato come Occupato
            p.Add(nuovaPersona);
            stato.Add(StatoElemento.Occupato);

            // scrittura del file di log
            ScriviFile(Path.Combine(Environment.CurrentDirectory, "logbin", "log.txt"), nuovaPersona.ToString());
            j++;
        }

        static DateTime CheckData()
        {
            bool checkDate = false;
            DateTime dataNascita = DateTime.MinValue; //MinValue val più piccolo

            while (!checkDate)
            {
                try
                {
                    Console.WriteLine("Inserisci data di nascita (formato: dd/mm/yyyy): ");
                    dataNascita = DateTime.Parse(Console.ReadLine());
                    checkDate = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato data non valido. Inserisci nel formato corretto (dd/mm/yyyy).");
                }
            }

            return dataNascita;
        }


        //static int TrovaElementoLibero(List<StatoElemento> stato)
        //{
        //    for (int i = 0; i < stato.Count; i++)
        //    {
        //        if (stato[i] == StatoElemento.Libero)
        //        {
        //            return i; // Ritorna l'indice dell'elemento libero
        //        }
        //    }
        //    return -1; // Nessun elemento libero trovato
        //}


        static void StampaMenu(string[] menu)
        {
            for (int i = 0; i < menu.Length; i++)
                Console.WriteLine($"[{i + 1}] {menu[i]}");
        }

        static void StampaPersone(List<Persona> persone, List<StatoElemento> stato)
        {
            for (int i = 0; i < stato.Count; i++)
            {
                if (stato[i] == StatoElemento.Occupato || stato[i] == StatoElemento.Cancellato)
                {
                    Console.WriteLine($"Persona {i + 1}: {persone[i]}, Stato Elemento: {stato[i]}");
                }
            }
        }



        static void TrovaEdElencaPersona(List<Persona> persone, List<StatoElemento> stato, string cf)
        {
            foreach (var persona in persone)
            {
                int index = persone.IndexOf(persona);
                if (index != -1 && stato[index] == StatoElemento.Occupato && persona.Id == cf)
                {
                    DateTime dataCorrente = DateTime.Now;
                    int eta = CalcolaAnni(persona.Nascita, dataCorrente);
                    Console.WriteLine($"Persona: {persona.Nome} {persona.Cognome}, Età: {eta}");
                    return;
                }
            }

            Console.WriteLine("Nessuna persona trovata con questo codice fiscale");
        }



        static void Archivio(List<Persona> persone, List<StatoElemento> stato)
        {
            DateTime dataCorrente = DateTime.Now;
            foreach (var persona in persone)
            {
                int index = persone.IndexOf(persona);
                if (index != -1 && stato[index] == StatoElemento.Occupato)
                {
                    int eta = CalcolaAnni(persona.Nascita, dataCorrente);
                    Console.WriteLine($"Persona: {persona.Nome} {persona.Cognome}, Età: {eta}");
                }
            }
        }

        static void ModificaStato(List<Persona> persone, List<StatoElemento> stato, string cf)
        {
            // Verifica se l'ID è valido
            bool id = CheckId(cf, persone);

            if (id)
            {
                int index = -1;

                for (int i = 0; i < persone.Count; i++)
                {
                    if (persone[i].Id == cf && stato[i] == StatoElemento.Occupato)
                    {
                        index = i;
                        //break;
                    }
                }

                if (index != -1)
                {
                    int scelta = MenuStatoCivile();
                    StatoCivile nuovoStato;

                    switch (scelta)
                    {
                        case 1:
                            nuovoStato = StatoCivile.Celibe;
                            break;
                        case 2:
                            nuovoStato = StatoCivile.Nubile;
                            break;
                        case 3:
                            nuovoStato = StatoCivile.Coniugato;
                            break;
                        case 4:
                            nuovoStato = StatoCivile.Vedovo;
                            break;
                        case 5:
                            nuovoStato = StatoCivile.Separato;
                            break;
                        default:
                            Console.WriteLine("Scelta non valida. Nessuna modifica apportata.");
                            return;
                    }

                    Persona personaModificata = persone[index];
                    personaModificata.Stato = nuovoStato;
                    persone[index] = personaModificata;

                    Console.WriteLine("Stato civile modificato con successo.");
                    ScriviFile(Path.Combine(Environment.CurrentDirectory, "logbin", "log.txt"), $"Stato modificato: {personaModificata.ToString()}");
                }
                else
                {
                    Console.WriteLine("Nessuna persona trovata con questo codice fiscale o lo stato non è 'Occupato'.");
                }
            }
            else
            {
                Console.WriteLine("ID non valido.");
            }
        }


        static void EliminaUtente(List<Persona> persone, List<StatoElemento> stato, string cf)
        {
            for (int i = 0; i < persone.Count; i++)
            {
                if (stato[i] == StatoElemento.Occupato && persone[i].Id == cf)
                {
                    stato[i] = StatoElemento.Cancellato;
                    Console.WriteLine("Utente eliminato con successo.");

                    // Scrivi la cancellazione nel file di log
                    ScriviFile(Path.Combine(Environment.CurrentDirectory, "logbin", "log.txt"), $"Utente eliminato: {persone[i].ToString()}");
                    return;
                }
            }
            Console.WriteLine("Nessuna persona trovata con questo codice fiscale o lo stato non è 'Occupato'.");
        }


        static bool CheckId(string id, List<Persona> persone)
        {
            foreach (var persona in persone)
            {
                if (persona.Id == id)
                {
                    return true; // Restituisce true se il codice fiscale è già presente nella lista
                }
            }
            return false; // Restituisce false se il codice fiscale non è presente nella lista
        }


        static int MenuGenere()
        {
            int scelta = 0;
            string[] genere = Enum.GetNames(typeof(Sesso));
            for (int i = 0; i < genere.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {genere[i]}");
            }
            Console.WriteLine("Che scelta vuoi fare");
            int.TryParse(Console.ReadLine(), out scelta);
            while (scelta < 1 || scelta > genere.Length)
            {
                Console.WriteLine("Inserisci un opzione valida");
                int.TryParse(Console.ReadLine(), out scelta);
            }
            return scelta;
        }

        static int MenuStatoCivile()
        {
            int scelta = 0;
            string[] stato = Enum.GetNames(typeof(StatoCivile));
            for (int i = 0; i < stato.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {stato[i]}");
            }
            Console.WriteLine("Che scelta vuoi fare");
            int.TryParse(Console.ReadLine(), out scelta);
            while (scelta < 1 || scelta > stato.Length)
            {
                Console.WriteLine("Inserisci un opzione valida");
                int.TryParse(Console.ReadLine(), out scelta);
            }
            return scelta;
        }

        static int CalcolaAnni(DateTime dataNascita, DateTime dataCorrente)
        {
            int eta = dataCorrente.Year - dataNascita.Year;

            if (dataCorrente < dataNascita.AddYears(eta))
                eta--;

            return eta;
        }


        //implementazione col file di log

        static void ScriviFile(string path, string stringa)
        {
            StreamWriter sw = File.AppendText(path);
            sw.WriteLine(DateTime.Now.ToString() + " " + stringa);

            sw.Close();
        }



        static void LeggiFile(string path)
        {
            StreamReader sr = File.OpenText(path);
            string linea;
            linea = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                Console.WriteLine(linea);
                linea = sr.ReadLine();
            }
        }
        static void GetFiles(string directory, string[] estensioni)
        {
            // Verifica se la directory esiste
            if (Directory.Exists(directory))
            {
                // Ottiene tutti i file presenti nella directory
                string[] files = Directory.GetFiles(directory);

                // Lista per memorizzare i file con estensioni desiderate
                List<string> listaFile = new List<string>();

                // Filtra i file con estensioni specificate
                foreach (string file in files)
                {
                    bool ext = false;

                    foreach (string e in estensioni)
                    {
                        // Verifica se il nome del file termina con l'estensione corrente, ignorando maiuscole/minuscole
                        if (file.EndsWith(e, true, null))
                        {
                            ext = true;
                        }
                    }

                    if (ext)
                    {
                        listaFile.Add(file);
                    }
                }

                // Se ci sono file presenti nella directory
                if (listaFile.Count > 0)
                {
                    // Ciclo for per ogni file trovato
                    for (int i = 0; i < listaFile.Count; i++)
                    {
                        // Ottiene la data di creazione del file
                        DateTime dataCreazione = File.GetCreationTime(listaFile[i]);

                        // Stampa l'indice (partendo da 1), la data di creazione e il nome del file
                        Console.WriteLine($"{i + 1}: {dataCreazione} - {Path.GetFileName(listaFile[i])}");
                    }

                    int sceltaFile;
                    Console.WriteLine("Seleziona il numero del file desiderato:");

                    string inputUtente = Console.ReadLine();

                    // Verifica se l'input è un numero valido
                    if (int.TryParse(inputUtente, out sceltaFile) && sceltaFile > 0 && sceltaFile <= listaFile.Count) //Se il TryParse ha successo e il numero è maggiore di zero e minore o
                                                                                                                      //uguale al numero di file nella lista, allora la selezione dell'utente è considerata valida.
                    {
                        string fileSelezionato = listaFile[sceltaFile - 1];

                        // Legge il contenuto del file selezionato
                        LeggiFile(fileSelezionato);
                    }
                    else
                    {
                        Console.WriteLine("Selezione non valida. Riprova.");
                    }
                }
                else
                {
                    // Messaggio se la directory non esiste o non è accessibile
                    Console.WriteLine("La directory non esiste o non è accessibile.");
                }
            }
        }

    }
}