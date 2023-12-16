using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GaraFraPiloti
{
    //la gara è fatta da un nome, da un risultato, griglia di auto, numero di scuderie
    //fai la classe gara che la griglia di auto ed è definita da scuderie 
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
        //public void SetGara(string circuito)
        //{
        //    _nomeGara = circuito;
        //}
        //public string GetGara()
        //{
        //    return _nomeGara;
        //}
        //public void SetNumScuderia(int numScuderia)
        //{
        //    _numScuderia = numScuderia;
        //}
        //public int GetNumScuderia()
        //{
        //    return _numScuderia;
        //}
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
    }
}
