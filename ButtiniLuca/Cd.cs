using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtiniLuca
{
    internal class Cd : Articolo, ICosto
    {
        //attributi cd
        int _durata;
        genere _genere;
        public Cd(string titolo, string autore, double prezzo, string scaffale, int quantita, string identificativo, int durata, genere genere) : base(titolo, autore, prezzo, scaffale, quantita, identificativo)
        {

            _durata = durata;
            _genere = genere;
        }
        //proprieta cd
        public int Durata { get => _durata; private set => _durata = value; }
        internal genere Genere { get => _genere; private set => _genere = value; }
        public double RapportoCosto()//rapporto costo ereditato dall'interfaccia
        {
            return Durata / Prezzo;
        }
        public override string StampaRapporto()
        {
            return String.Format($"Titolo: {Titolo}, Rapporto min/costo: {RapportoCosto()}");
        }
        public override string Stampa() //metodo stampa con override per il cd
        {
            return String.Format($"Codice: {Identificativo} - Titolo: {Titolo}, - Autore: {Autore} - Prezzo: {Prezzo} - Q.ta: {Quantita} - Scaffale: {Scaffale} - Durata: {Durata} - genere: {Genere}");
        }
    }
}
