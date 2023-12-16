using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GaraFraPiloti
{

    internal class Gara
    {
        string _nomeGara;
        int _numScuderia, _risultato;
        List<Auto> partecipanti;
        public Gara(int n, string nome) //istanzio nuova gara
        {
            partecipanti = new List<Auto>();
            _numScuderia = n;
            Circuito = nome;
        }
        public string Circuito
        {
            get { return _nomeGara; }
            set { _nomeGara = value; }
        }
        public void Aggiungi(Auto a)
        {
            partecipanti.Add(a);
        }
        public void Griglia()
        {
            partecipanti.ForEach(a => Console.WriteLine(a));
        }
        public int Vincitore()
        {
            Random random = new Random();
            _risultato = random.Next(0, partecipanti.Count);
            return _risultato;
        }
        public void GetVincitore()
        {
            int v = Vincitore();
            Console.WriteLine("Vincitore: [{0}], {1}", v + 1, partecipanti[v]);
        }
        public int NumPiloti()
        {
            return partecipanti.Count;

        }
        public void SimulaGara()
        {
            // Creazione di un oggetto Random per generare tempi casuali
            Random random = new Random();
            Pilota p; // Dichiarazione di una variabile Pilota per memorizzare il pilota associato all'auto

            // Iterazione su ogni auto partecipante per simulare la gara
            foreach (Auto auto in partecipanti)
            {
                // Generazione di un tempo casuale compreso tra 0 e 100
                double tempo = random.Next(0, 100);
                auto.TempoInGara = tempo; // Assegnazione del tempo generato all'auto
                p = auto.MioPilota; // Ottenimento del pilota associato all'auto

                // Stampa delle informazioni sulla simulazione
                int numeroGara = partecipanti.IndexOf(auto) + 1;
                Console.WriteLine($"Pilota [{numeroGara}]: {p.Stampa()}, Tempo: {tempo} secondi");
            }
        }

        public void Classifica()
        {
            // Creazione di una copia della lista partecipanti per evitare modifiche dirette all'originale
            List<Auto> classifica = new List<Auto>(partecipanti);

            // Ordinamento della classifica in base ai tempi di gara
            /* auto1.TempoInGara.CompareTo(auto2.TempoInGara) è il criterio di confronto. 
            Il metodo CompareTo è un metodo della classe double. 
            Restituisce un intero che indica se il valore di auto1.TempoInGara è inferiore, uguale o superiore a auto2.TempoInGara.
            Se il risultato è negativo, auto1.TempoInGara è minore di auto2.TempoInGara.
            Se il risultato è zero, i tempi sono uguali.
            Se il risultato è positivo, auto1.TempoInGara è maggiore di auto2.TempoInGara.*/
            classifica.Sort((auto1, auto2) => auto1.TempoInGara.CompareTo(auto2.TempoInGara));

            int pos = 1;

            // Iterazione sulla classifica ordinata per stampare i risultati
            foreach (Auto auto in classifica)
            {
                // Stampa delle informazioni sulla classifica
                Console.WriteLine("{0}. {1} {2} - Tempo: {3} secondi", pos, auto.MioPilota.Cognome, auto.MioPilota.Nome, auto.TempoInGara);
                pos++;
            }
        }

    }
}
