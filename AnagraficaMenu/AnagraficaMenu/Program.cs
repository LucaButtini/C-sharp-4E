using System;
namespace AnagraficaMenu
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
            string[] opzioni1 = { "Inserimento", "Visualizza", "Età", "Esci dal Menu" };
            string[] opzioni2 = { "Persona", "Archivio" };
            int grandezza = 3;
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
                        Console.WriteLine();
                        Console.WriteLine("=====INSERIMENTO=====");
                        LeggiPersona(persone);
                        Console.WriteLine("Inserimento completato.");
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
                        Console.WriteLine("Uscita dal Menu");
                        break;

                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;
                }

                if (scelta1 != 4)
                {
                    Console.WriteLine("Premi Invio per tornare al Menu.");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (scelta1 != 4);
        }

        static void LeggiPersona(Persona[] p)
        {
            for (int i = 0; i < p.Length; i++)
            {
                Console.WriteLine($"Inserimento persona {i + 1}:");
                Console.WriteLine("Inserisci nome: ");
                p[i].Nome = Console.ReadLine();
                Console.WriteLine("Inserisci cognome: ");
                p[i].Cognome = Console.ReadLine();
                Console.WriteLine("Inserisci cittadinanza: ");
                p[i].Cittadinanza = Console.ReadLine();
                Console.WriteLine("Inserisci data di nascita (formato: dd/mm/yyyy): ");
                p[i].Nascita = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Inserisci id: ");
                string id = Console.ReadLine();
                while (CheckId(id, p))//invoco il metodo checkid per controllare che non ci siano duplicati
                {
                    Console.WriteLine("Codice fiscale già presente. Reinserisci.");
                    id = Console.ReadLine();
                }
                p[i].Id = id;
                Console.WriteLine("Inserisci genere");
                switch (MenuGenere(p))
                {
                    case 1:
                        p[i].Genere = Sesso.Maschio;
                        break;
                    case 2:
                        p[i].Genere = Sesso.Femmina;
                        break;
                }
                Console.WriteLine("Inserisci stato civile");
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
                    eta = CalcolaAnni(persona.Nascita, dataCorrente);
                    Console.WriteLine($"Persona: {persona.Nome} {persona.Cognome}, Età: {eta}");
                    //return;
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

        static void Archivio(Persona[] p)
        {
            int eta = 0;
            DateTime dataCorrente = DateTime.Now;
            foreach (var persona in p)
            {
                eta = CalcolaAnni(persona.Nascita, dataCorrente); // Correzione qui
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
    }
}
