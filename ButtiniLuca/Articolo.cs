using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtiniLuca
{
    internal abstract class Articolo
    {
        string _titolo, _autore, _scaffale, _identificativo;
        double _prezzo;
        int _quantita;
        protected Articolo(string titolo, string autore, double prezzo, string scaffale, int quantita, string identificativo)
        {
            _titolo = titolo;
            _autore = autore;
            _prezzo = prezzo;
            _scaffale = scaffale;
            _quantita = quantita;
            _identificativo = identificativo;
        }
        //proprieta pubblici per i metodi vendita e trova
        public int Quantita { get => _quantita; set => _quantita = value; }
        public string Identificativo { get => _identificativo; private set => _identificativo = value; }
        protected string Titolo { get => _titolo; private set => _titolo = value; }
        protected string Autore { get => _autore; private set => _autore = value; }
        protected double Prezzo { get => _prezzo; private set => _prezzo = value; }
        protected string Scaffale { get => _scaffale; private set => _scaffale = value; }
        public abstract string Stampa(); //metodo astratto stampa
        public abstract string StampaRapporto();//stampo rapporto caratterista/costo degli articoli
    }
}
