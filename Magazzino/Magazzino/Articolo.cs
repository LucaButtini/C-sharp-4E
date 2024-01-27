using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazzino
{
    internal class Articolo
    {
        int codice;
        string descrizione;
        double prezzo, giacenza;
        public Articolo(string desc, double pr, double giac)
        {
            descrizione = desc;
            prezzo = pr;
            giacenza = giac;
            codice = Magazzino.Codice; //assegno al codice dell'articolo il codice dato dal magazzino
        }

        public int Codice
        {
            get { return codice; }
            set { codice = value; }
        }
        public double Giacenza
        {
            get { return giacenza; }
            set { giacenza = value; }
        }
        public string Descrizione
        {
            get { return descrizione; }
            set { descrizione = value; }
        }
        public double Prezzo
        {
            get { return prezzo; }
            set
            {
                if (prezzo == 0)
                {
                    throw new Exception("Non può essere a zero");
                }
                else
                {
                    prezzo = value;
                }

            }
        }
        public override string ToString()
        {
            //ovveride ToString per stampa in formato tabellare 
            return string.Format($"CODICE: {Codice} DESCRIZIONE: {Descrizione} q.tà. {Giacenza}, PREZZO: {Prezzo}");
        }
    }
}
