using System;
using System.Collections.Generic;
using System.IO;

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
            string[] opzioni1 = { "Inserimento", "Visualizza", "Età", "Modifica Stato", "Cancella utente", "Leggi Log", "Esci dal Menu" };
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
                        string directory = Path.Combine(Environment.CurrentDirectory, "logbin");

                        // Verifica se la directory 'logbin' esiste
                        if (Directory.Exists(directory))
                        {
                            // Ottiene tutti i file con estensione '.txt' all'interno della directory
                            string[] files = Directory.GetFiles(directory, "*.txt");

                            if (files.Length > 0)
                            {
                                // Mostra i file trovati
                                foreach (var file in files)
                                {
                                    Console.WriteLine(file);
                                }

                                // Leggi un file
                                int fileChoice;
                                Console.WriteLine("Seleziona un file digitando il numero corrispondente:");
                                if (int.TryParse(Console.ReadLine(), out fileChoice) && fileChoice > 0 && fileChoice <= files.Length)
                                {
                                    string selectedFile = files[fileChoice - 1];
                                    LeggiFile(selectedFile);
                                }
                                else
                                {
                                    Console.WriteLine("Selezione non valida. Riprova.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nessun file con estensione .txt trovato nella directory specificata.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("La directory non esiste o non è accessibile.");
                        }
                        break;
                    case 7:
                        Console.WriteLine("Uscita dal Menu");
                        break;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;
                }

                if (scelta1 != 7)
                {
                    Console.WriteLine("Premi Invio per tornare al Menu.");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (scelta1 != 7);
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
                try
                {
                    Console.WriteLine("Inserisci data di nascita (formato: dd/mm/yyyy): ");
                    nuovaPersona.Nascita = DateTime.Parse(Console.ReadLine());
                    checkDate = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato data non valido. Inserisci nel formato corretto (dd/mm/yyyy).");
                }
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

            // Aggiungi la nuova persona alla lista e imposta lo stato come Occupato
            p.Add(nuovaPersona);
            stato.Add(StatoElemento.Occupato);

            // Ora, dopo aver completato il processo di inserimento, scrivi il file di log
            ScriviFile(Path.Combine(Environment.CurrentDirectory, "logbin", "log.txt"), nuovaPersona.ToString());
            j++;
        }


        static int TrovaElementoLibero(List<StatoElemento> stato)
        {
            for (int i = 0; i < stato.Count; i++)
            {
                if (stato[i] == StatoElemento.Libero)
                {
                    return i; // Ritorna l'indice dell'elemento libero
                }
            }
            return -1; // Nessun elemento libero trovato
        }


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
            for (int i = 0; i < persone.Count; i++)
            {
                if (stato[i] == StatoElemento.Occupato && persone[i].Id == cf)
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

                    // Modifica lo stato della persona e assegna l'oggetto persona modificato
                    Persona personaModificata = persone[i];
                    personaModificata.Stato = nuovoStato;

                    // Reimposta l'elemento nella lista
                    persone[i] = personaModificata;

                    Console.WriteLine("Stato civile modificato con successo.");
                    return;
                }
            }
            Console.WriteLine("Nessuna persona trovata con questo codice fiscale o lo stato non è 'Occupato'.");
        }





        static Persona ModificaStatoPersona(Persona persona, StatoCivile nuovoStato)
        {
            persona.Stato = nuovoStato;
            return persona;
        }



        static void EliminaUtente(List<Persona> persone, List<StatoElemento> stato, string cf)
        {
            for (int i = 0; i < persone.Count; i++)
            {
                if (stato[i] == StatoElemento.Occupato && persone[i].Id == cf)
                {
                    stato[i] = StatoElemento.Cancellato;
                    Console.WriteLine("Utente eliminato con successo.");
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
        //static void ScriviFile(string path, string stringa)
        //{
        //    StreamWriter sw = File.AppendText(path);
        //    sw.WriteLine(DateTime.Now.ToString() + " " + stringa);
        //    sw.Close();
        //}
        static void LeggiFile(string path)
        {
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                // Messaggio se il file specificato non esiste
                Console.WriteLine("Il file specificato non esiste.");
            }
        }
        //static void LeggiFile(string path)
        //{
        //    StreamReader sr = File.OpenText(path);
        //    string linea;
        //    linea = sr.ReadLine();
        //    while (!sr.EndOfStream)
        //    {
        //        Console.WriteLine(linea);
        //        linea = sr.ReadLine();
        //    }
        //}
        static void GetFiles(string directory)
        {
            string[] files;
            files = Directory.GetFiles(directory);
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
            Console.WriteLine(Path.GetFileName(files[0]));
        }
    }
}