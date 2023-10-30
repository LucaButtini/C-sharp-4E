using System;
using System.Collections.Generic;
using System.IO;

namespace AnagrafeLog
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
            int grandezza = 3, index = 0;
            Persona[] persone = new Persona[grandezza];
            StatoElemento[] statoElementi = new StatoElemento[grandezza];
            int scelta1, scelta2;
            string cf;
            //List<Persona> lista;

            for (int i = 0; i < grandezza; i++)
            {
                statoElementi[i] = StatoElemento.Libero;//inizializzo a libero per indicare che ogni elemento è libero 
            }

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
                        Console.WriteLine("=====RICERCA ETA'=====");
                        StampaMenu(opzioni2);
                        Console.WriteLine("Inserisci la scelta");
                        int.TryParse(Console.ReadLine(), out scelta2);
                        while (scelta2 < 1 || scelta2 > opzioni2.Length)
                        {
                            Console.WriteLine("Inserisci un opzione valida");
                            int.TryParse(Console.ReadLine(), out scelta2);
                        }
                        switch (scelta2)
                        {
                            case 1:
                                Console.WriteLine("Inserisci il codice fiscale della persona la quale si desidera sapere l'età");
                                cf = Console.ReadLine();
                                TrovaEdElencaPersona(persone, statoElementi, cf);
                                break;
                            case 2:
                                Console.WriteLine("===ARCHIVIO===");
                                Archivio(persone, statoElementi);
                                break;
                        }
                        break;

                    case 4:
                        Console.WriteLine("===MODIFICA STATO CIVILE=== ");
                        Console.WriteLine("Inserisci il codice fiscale della persona la quale vuoi cambiare lo stato civile");
                        cf = Console.ReadLine();
                        ModificaStato(persone, statoElementi, cf);
                        break;

                    case 5:
                        Console.WriteLine("===CANCELLA UTENTE===");
                        Console.WriteLine("Inserisci il codice fiscale della persona da cancellare dall'anagrafica");
                        cf = Console.ReadLine();
                        EliminaUtente(persone, statoElementi, cf);
                        break;
                    case 6:
                        Console.WriteLine("Seleziona un file di log:");

                        string directory = Path.Combine(Environment.CurrentDirectory, "logBin");
                        if (Directory.Exists(directory))
                        {
                            string[] files = Directory.GetFiles(directory, "*.txt");

                            if (files.Length > 0)
                            {
                                for (int i = 0; i < files.Length; i++)
                                {
                                    Console.WriteLine($"{i + 1}: {Path.GetFileName(files[i])}");
                                }

                                //int fileChoice;
                                //Console.WriteLine("Seleziona un file digitando il numero corrispondente:");
                                //if (int.TryParse(Console.ReadLine(), out fileChoice) && fileChoice > 0 && fileChoice <= files.Length)
                                //{
                                //    string selectedFile = files[fileChoice - 1];
                                //    LeggiFile(selectedFile);
                                //}
                                //else
                                //{
                                //    Console.WriteLine("Selezione non valida. Riprova.");
                                //}
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

        static void LeggiPersona(Persona[] p, StatoElemento[] stato, ref int j)
        {
            if (j < p.Length)
            {
                int index = TrovaElementoLibero(stato);

                if (index != -1)
                {
                    bool checkDate = false;

                    Console.WriteLine($"Inserimento persona {index + 1}:");

                    Console.WriteLine("Inserisci nome: ");
                    p[index].Nome = Console.ReadLine();

                    Console.WriteLine("Inserisci cognome: ");
                    p[index].Cognome = Console.ReadLine();

                    Console.WriteLine("Inserisci cittadinanza: ");
                    p[index].Cittadinanza = Console.ReadLine();
                    checkDate = false;

                    while (!checkDate)
                    {
                        try
                        {
                            Console.WriteLine("Inserisci data di nascita (formato: dd/mm/yyyy): ");
                            p[index].Nascita = DateTime.Parse(Console.ReadLine());
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
                    p[index].Id = id;

                    Console.WriteLine("Inserisci genere");
                    switch (MenuGenere(p))
                    {
                        case 1:
                            p[index].Genere = Sesso.Maschio;
                            break;
                        case 2:
                            p[index].Genere = Sesso.Femmina;
                            break;
                    }

                    Console.WriteLine("Inserisci stato civile");
                    switch (MenuStatoCivile(p))
                    {
                        case 1:
                            p[index].Stato = StatoCivile.Celibe;
                            break;
                        case 2:
                            p[index].Stato = StatoCivile.Nubile;
                            break;
                        case 3:
                            p[index].Stato = StatoCivile.Coniugato;
                            break;
                        case 4:
                            p[index].Stato = StatoCivile.Vedovo;
                            break;
                        case 5:
                            p[index].Stato = StatoCivile.Separato;
                            break;
                    }

                    stato[index] = StatoElemento.Occupato;
                    ScriviFile(Path.Combine(Environment.CurrentDirectory, "logBin", "log.txt"), p[index].ToString());
                    j++;
                }
                else
                {
                    Console.WriteLine("Anagrafica al completo");
                }
            }
            else
            {
                Console.WriteLine("Anagrafica al completo");
            }
        }

        static int TrovaElementoLibero(StatoElemento[] stato)
        {
            for (int i = 0; i < stato.Length; i++)
            {
                if (stato[i] == StatoElemento.Libero)
                {
                    return i;//ritorna pos elemento libero
                }
            }
            return -1; // Nessun elemento libero trovato
        }

        static void StampaMenu(string[] menu)
        {
            for (int i = 0; i < menu.Length; i++)
                Console.WriteLine($"[{i + 1}] {menu[i]}");
        }

        static void StampaPersone(Persona[] p, StatoElemento[] stato)
        {
            for (int i = 0; i < stato.Length; i++)
            {
                if (stato[i] == StatoElemento.Occupato || stato[i] == StatoElemento.Cancellato)
                {
                    Console.WriteLine($"Persona {i + 1}: {p[i]}, Stato Elemento: {stato[i]}");
                }
            }
        }


        static void TrovaEdElencaPersona(Persona[] p, StatoElemento[] stato, string cf)
        {
            for (int i = 0; i < p.Length; i++)
            {
                if (stato[i] == StatoElemento.Occupato && p[i].Id == cf)
                {
                    DateTime dataCorrente = DateTime.Now;
                    int eta = CalcolaAnni(p[i].Nascita, dataCorrente);
                    Console.WriteLine($"Persona: {p[i].Nome} {p[i].Cognome}, Età: {eta}");
                    return;
                }
            }

            Console.WriteLine("Nessuna persona trovata con questo codice fiscale");
        }

        static void Archivio(Persona[] p, StatoElemento[] stato)
        {
            DateTime dataCorrente = DateTime.Now;
            for (int i = 0; i < p.Length; i++)
            {
                if (stato[i] == StatoElemento.Occupato)
                {
                    int eta = CalcolaAnni(p[i].Nascita, dataCorrente);
                    Console.WriteLine($"Persona: {p[i].Nome} {p[i].Cognome}, Età: {eta}");
                }
            }
        }

        static void ModificaStato(Persona[] p, StatoElemento[] stato, string cf)
        {
            for (int i = 0; i < p.Length; i++)
            {
                if (stato[i] == StatoElemento.Occupato && p[i].Id == cf)
                {
                    Console.WriteLine("Inserisci nuovo stato civile");
                    switch (MenuStatoCivile(p))
                    {
                        case 1:
                            p[i].Stato = StatoCivile.Celibe;
                            break;
                        case 2:
                            p[i].Stato = StatoCivile.Nubile;
                            break;
                        case 3:
                            p[i].Stato = StatoCivile.Coniugato;
                            break;
                        case 4:
                            p[i].Stato = StatoCivile.Vedovo;
                            break;
                        case 5:
                            p[i].Stato = StatoCivile.Separato;
                            break;
                    }
                    return;
                }
            }

            Console.WriteLine("Nessuna persona trovata con questo codice fiscale");
        }

        static void EliminaUtente(Persona[] p, StatoElemento[] stato, string cf)
        {
            for (int i = 0; i < p.Length; i++)
            {
                if (stato[i] == StatoElemento.Occupato && p[i].Id == cf)
                {
                    stato[i] = StatoElemento.Cancellato;
                    Console.WriteLine("Eliminazione avvenuta con successo");
                    return;
                }
            }

            Console.WriteLine("Nessuna persona trovata con questo codice fiscale");
        }

        static bool CheckId(string s, Persona[] p)
        {
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i].Id == s)
                    return true;
            }
            return false;
        }

        static int MenuGenere(Persona[] p)
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

        static int MenuStatoCivile(Persona[] p)
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
    }
}