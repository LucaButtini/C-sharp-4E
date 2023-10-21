using System;
using System.Diagnostics.Eventing.Reader;
using System.Reflection;

namespace AnagraficaRefactored
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

    struct Persona
    {
        public string Id; // Codice fiscale
        public string Cognome;
        public string Nome;
        public string Cittadinanza;
        public DateTime Nascita;
        public StatoCivile Stato;
        public Sesso Genere;

        public override string ToString()//uso ovveride della stringa
        {
            return String.Format($"NOME: {Nome}, COGNOME: {Cognome}, CITTADINANZA: {Cittadinanza}, NASCITA: {Nascita}, ID: {Id}, GENERE: {Genere}, STATO CIVILE: {Stato} ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            string[] opzioni1 = { "Inserimento", "Visualizza", "Età", "Modifica Stato", "Cancella utente", "Esci dal Menu" };
            string[] opzioni2 = { "Persona", "Archivio" };
            int grandezza = 3, index = 0, check;
            Persona[] persone = new Persona[grandezza];
            int scelta1, scelta2;
            string cf;
            do
            {
                StampaMenu(opzioni1);
                Console.WriteLine("Che scelta vuoi fare?");
                int.TryParse(Console.ReadLine(), out scelta1);
                //switch case con le opzioni 
                switch (scelta1)
                {
                    case 1:
                        check = LeggiPersona(persone, ref index);
                        switch (check)
                        {
                            case 0:
                                Console.WriteLine("Inserimento completato");
                                break;
                            case 1:
                                Console.WriteLine("Anagrafica al completo");
                                break;
                        }
                        break;

                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("=====ANAGRAFICA=====");
                        StampaPersone(persone);
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
                                Persona(persone, cf);
                                break;
                            case 2:
                                Console.WriteLine("===ARCHIVIO===");
                                Archivio(persone);
                                break;
                        }
                        break;
                    case 4:
                        Console.WriteLine("===MODIFICA STATO CIVILE=== ");
                        Console.WriteLine("Inserisci il codice fiscale della persona la quale vuoi cambiare lo stato civile");
                        cf = Console.ReadLine();
                        ModificaStato(persone, cf);
                        break;
                    case 5:
                        Console.WriteLine("===CANCELLA UTENTE===");
                        Console.WriteLine("Inserisci il codice fiscale della persona da cancellare dall'anagrafuica");
                        cf = Console.ReadLine();
                        EliminaUtente(persone, cf, ref index);
                        break;
                    case 6:
                        Console.WriteLine("Uscita dal Menu");

                        break;

                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;
                }

                if (scelta1 != 6)
                {
                    Console.WriteLine("Premi Invio per tornare al Menu.");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (scelta1 != 6);
        }

        static int LeggiPersona(Persona[] p, ref int index)
        {
            bool checkDate = false;
            if (index < p.Length)
            {
                Console.WriteLine($"Inserimento persona {index + 1}:");

                Console.WriteLine("Inserisci nome: ");
                p[index].Nome = Console.ReadLine();

                Console.WriteLine("Inserisci cognome: ");
                p[index].Cognome = Console.ReadLine();

                Console.WriteLine("Inserisci cittadinanza: ");
                p[index].Cittadinanza = Console.ReadLine();
                checkDate = false; //metto a false la var bool ogni volta che si inserisce una persona.

                // Continua a chiedere all'utente di inserire la data fino a quando non viene inserita correttamente
                while (!checkDate)
                {
                    try
                    {
                        Console.WriteLine("Inserisci data di nascita (formato: dd/mm/yyyy): ");
                        p[index].Nascita = DateTime.Parse(Console.ReadLine());
                        checkDate = true; // La data è stata inserita correttamente, usciamo dal ciclo
                    }
                    catch (FormatException)
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
                index++;
                return 0; //inserimento andato a buon fine
            }
            else
            {
                return 1;//se anagrafica è piena
            }
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

        static bool CheckId(string s, Persona[] p)
        {
            for (int i = 0; i < p.Length; i++)
            {
                if (s == p[i].Id)
                    return true;
            }
            return false;
        }
        //---------------------------------------------------------------
        //---------------------------------------------------------------
        //CALCOLO ETA'
        static void Persona(Persona[] p, string cf)
        {
            DateTime dataCorrente = DateTime.Now;
            int eta = -1;  // Inizializza l'età a -1 come valore predefinito

            foreach (var persona in p)
            {
                if (persona.Id == cf)  // Controlla il codice fiscale per la persona corrente
                {
                    eta = CalcolaEtaSenzaDateTime(persona.Nascita.Year, persona.Nascita.Month, persona.Nascita.Day);
                    //eta = CalcolaAnni(persona.Nascita, dataCorrente);
                    Console.WriteLine($"Persona: {persona.Nome} {persona.Cognome}, Età: {eta}");
                }
            }
            if (eta == -1) // Nessuna persona trovata con il codice fiscale cercato
                Console.WriteLine("Nessuna persona trovata con il codice fiscale cercato");
        }
        static int CalcolaAnni(DateTime dataNascita, DateTime dataCorrente)
        {
            int eta = dataCorrente.Year - dataNascita.Year;//confronto gli anni 

            if (dataCorrente < dataNascita.AddYears(eta))//Verifica se la data corrente è precedente al giorno esatto di compleanno dell'anno corrente. 
                eta--;//Se la data corrente è prima del giorno esatto di compleanno, decrementa l'età calcolata di 1, in modo che rappresenti l'età precisa.

            return eta;
        }
        //---------------------------------------------------------------
        //---------------------------------------------------------------
        static int CalcolaEtaSenzaDateTime(int annoNascita, int meseNascita, int giornoNascita)
        {
            DateTime dataCorrente = DateTime.Now;
            int eta = dataCorrente.Year - annoNascita;

            // Verifica se la data di compleanno è successiva alla data corrente nell'anno corrente
            //Il primo controllo verifica se il mese di nascita è successivo al mese corrente.
            //Il secondo controllo viene eseguito se il mese di nascita è lo stesso mese corrente, ma il giorno di nascita è successivo al giorno corrente.
            if (meseNascita > dataCorrente.Month || (meseNascita == dataCorrente.Month && giornoNascita > dataCorrente.Day))
            {
                eta--;
            }
            return eta;
        }
        static void Archivio(Persona[] p)
        {
            int eta = 0;
            DateTime dataCorrente = DateTime.Now;
            foreach (var persona in p)
            {
                eta = CalcolaAnni(persona.Nascita, dataCorrente);
                Console.WriteLine($"Persona: {persona.Nome} {persona.Cognome}, Età: {eta}");
            }
        }
        static void StampaMenu(string[] menu)
        {
            for (int i = 0; i < menu.Length; i++)
                Console.WriteLine($"[{i + 1}] {menu[i]}");
        }

        static void StampaPersone(Persona[] p)
        {
            foreach (Persona persona in p)
            {
                Console.WriteLine(persona);
            }
        }

        static void ModificaStato(Persona[] p, string cf)
        {
            int index = 0;
            bool check = false;
            foreach (Persona persona in p)
            {
                if (cf == persona.Id)
                {
                    check = true;
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
                }
                else
                {
                    index++;
                }
            }
            if (!check)
                Console.WriteLine("Nessuna persona trovata con questo codice fiscale");
        }

        static void EliminaUtente(Persona[] p, string cf, ref int index)
        {
            bool check = false;
            for (int i = 0; i < index; i++) // itero fino ad index
            {
                if (cf == p[i].Id)
                {
                    check = true;
                    for (int j = i; j < index - 1; j++)// sposto tutti gli elementi successivi all'elemento da eliminare all'indietro
                    {
                        p[j] = p[j + 1];
                    }
                    p[index - 1] = new Persona(); // azzero l'ultimo elemento duplicato nell'array
                    index--;
                    Console.WriteLine("Eliminazione avvenuta con successo");
                    break; //esco dal ciclo
                }
            }
            if (!check)
            {
                Console.WriteLine("Nessuna persona trovata con questo codice fiscale");
            }
        }
    }
}
