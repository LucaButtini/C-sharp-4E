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
            Random random = new Random();
            Pilota p;
            foreach (Auto auto in partecipanti)
            {
                double tempo = random.NextDouble() * 100; // Modifica questo valore in base alla simulazione del tempo di gara
                auto.TempoInGara = tempo;

                p = auto.MioPilota;

                int numeroGara = partecipanti.IndexOf(auto) + 1;
                Console.WriteLine($"Pilota [{numeroGara}]: {p.Stampa()}, Tempo: {tempo} secondi");
            }
        }
        public void Classifica()
        {
            List<Auto> classifica = new List<Auto>(partecipanti);
            classifica.Sort((auto1, auto2) => auto1.TempoInGara.CompareTo(auto2.TempoInGara));

            int pos = 1;

            foreach (Auto auto in classifica)
            {

                Console.WriteLine("{0}. {1} {2} - Tempo: {3} secondi", pos, auto.MioPilota.Cognome, auto.MioPilota.Nome, auto.TempoInGara);
                pos++;
            }
        }

    }
}
