using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtiniLuca
{
    internal class Libro : Articolo, ICosto
    {
        //attributi libro
        int _pag;
        settore _sett;
        public Libro(string titolo, string autore, double prezzo, string scaffale, int quantita, string identificativo, int pag, settore sett) : base(titolo, autore, prezzo, scaffale, quantita, identificativo)
        {
            _pag = pag;
            _sett = sett;

        }
        //proprieta libro
        public int Pag { get => _pag; private set => _pag = value; }
        internal settore Sett { get => _sett; private set => _sett = value; }
        public double RapportoCosto() //rapporto costo ereditato dall'interfaccia
        {
            return Pag / Prezzo;
        }
        public override string StampaRapporto()
        {
            return String.Format($"Titolo: {Titolo}, Rapporto pag/costo: {RapportoCosto()}");
        }
        public override string Stampa()//metodo stampa con override per il libro
        {
            return String.Format($"ISBN: {Identificativo} - Titolo: {Titolo} - Autore: {Autore} - Prezzo: {Prezzo} - Q.ta: {Quantita} - Scaffale: {Scaffale} - N pagine: {Pag} - Settore: {Sett}");
        }
        //operatori per il controllo dei libri
        static public bool operator ==(Libro a, Libro b)
        {
            return a == b;
        }
        static public bool operator !=(Libro a, Libro b)
        {
            return !(a == b);
        }
    }
}
