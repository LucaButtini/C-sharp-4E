using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificaClassiRifatta
{
    internal class Articolo
    {
        int codice;
        string descrizione;
        double prezzo, giacenza;
        public Articolo(string insDesc, double insPrezzo)
        {
            codice = Magazzino.CodiceProdotto;
            Descrizione = insDesc;
            Prezzo = insPrezzo;
            Giacenza = 10;
        }
        public int Codice { get { return codice; } }
        public string Descrizione { get { return descrizione; } set { descrizione = value; } }
        public double Prezzo
        {
            get { return prezzo; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("prezzo errato");
                }
                else
                {
                    prezzo = value;
                }
            }
        }

        public double Giacenza { get { return giacenza; } set { giacenza = value; } }


        public override string ToString()
        {
            return string.Format($"CODICE: {Codice}, DESCRIZIONE: {Descrizione}, PREZZO {Prezzo}, GIACENZA: {Giacenza}");
        }
    }
}
