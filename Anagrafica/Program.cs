using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Anagrafica
{
    enum sesso
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

    struct persona//la struct è di tipo statico
    {
        public string id; //BTTLCU05T18B563G mio codice fiscale
        public string cognome;
        public string nome;
        public string cittadinanza;
        public DateTime nascita;//tipo di dato che gestisce le date 
        public StatoCivile stato;
        public sesso genere;
    }
    class Program
    {
        static void Main(string[] args)
        {
            int grandezza;
            Console.WriteLine("Quante persone devi inserire?");
            while (!int.TryParse(Console.ReadLine(), out grandezza) || grandezza <= 0)
            {
                Console.WriteLine("Inserisci un numero");
            }
            persona[] persone = new persona[grandezza];
            Console.WriteLine();
            Console.WriteLine("=====INSERIMENTO=====");
            Console.WriteLine();
            LeggiPersona(persone);
            Console.WriteLine();
            Console.WriteLine("=====ANAGRAFICA=====");
            Stampa(persone);
            Console.ReadLine();
        }

        static void LeggiPersona(persona[] p)
        {
            string id = "";
            int index = 0;
            for (int i = 0; i < p.Length; i++)
            {
                index = i;
                Console.WriteLine($"Inserimento persona {i + 1}:");
                Console.WriteLine("Inserisci nome: ");
                p[i].nome = Console.ReadLine();
                Console.WriteLine("Inserisci cognome: ");
                p[i].cognome = Console.ReadLine();
                Console.WriteLine("Inserisci cittadinanza: ");
                p[i].cittadinanza = Console.ReadLine();
                Console.WriteLine("Inserisci data di nascita (formato: dd/mm/yyyy): ");
                p[i].nascita = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Inserisci id: ");
                id = Console.ReadLine();
                while (CheckId(id, p))
                {
                    Console.WriteLine("Elemento già presente");
                    id = Console.ReadLine();
                }
                p[i].id = id;
                Console.WriteLine("Inserisci genere");
                switch (MenuGenere(p))
                {
                    case 1:
                        p[i].genere = sesso.Maschio;
                        break;
                    case 2:
                        p[i].genere = sesso.Femmina;
                        break;
                }
                Console.WriteLine("Inserisci stato civile");
                switch (MenuStatoCivile(p))
                {
                    case 1:
                        p[i].stato = StatoCivile.Celibe;
                        break;
                    case 2:
                        p[i].stato = StatoCivile.Nubile;
                        break;
                    case 3:
                        p[i].stato = StatoCivile.Coniugato;
                        break;
                    case 4:
                        p[i].stato = StatoCivile.Vedovo;
                        break;
                    case 5:
                        p[i].stato = StatoCivile.Separato;
                        break;
                }
                Console.WriteLine();
            }
        }
        static bool CheckId(string s, persona[] p)
        {

            for (int i = 0; i < p.Length; i++)
            {
                if (s == p[i].id)
                    return true;
            }
            return false;
        }
        static int MenuGenere(persona[] p)
        {
            int scelta = 0;
            string[] genere = Enum.GetNames(typeof(sesso));
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
        static int MenuStatoCivile(persona[] p)
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
        static void Stampa(persona[] p)
        {
            for (int i = 0; i < p.Length; i++)
            {
                Console.WriteLine($"Persona {i + 1}");
                Console.WriteLine($"Nome: {p[i].nome}");
                Console.WriteLine($"Cognome: {p[i].cognome}");
                Console.WriteLine($"Cittadinanza: {p[i].cittadinanza}");
                Console.WriteLine($"Data di nascita: {p[i].nascita}");
                Console.WriteLine($"ID: {p[i].id}");
                Console.WriteLine($"Genere: {p[i].genere}");
                Console.WriteLine($"Stato: {p[i].stato}");
                Console.WriteLine();
            }
        }
    }
}
