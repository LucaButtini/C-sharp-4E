
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostVerificaFilaB
{
    internal class Articolo
    {
        string descrizione;
        double quantità;
        double prezzo;
        int codiceProgressivo;

        public override string ToString()
        {
            return String.Format($"Articolo: {descrizione} - Quantità: {quantità} - Prezzo: {prezzo} - Codice: {codiceProgressivo}");
        }

        public string Descrizione
        {
            get { return descrizione; }
        }
        public Articolo(string _descrizione, double _prezzo, int _codiceProgressivo)
        {
            descrizione = _descrizione;
            quantità = 10;
            prezzo = _prezzo;
            codiceProgressivo = _codiceProgressivo;
        }

        public double CostoArticolo()
        {
            return prezzo * quantità;
        }

        public bool Carico(double quantitaCarico)
        {
            quantità += quantitaCarico;
            return true;
        }

        public bool Scarico(double quantitaScarico)
        {
            if ((quantità - quantitaScarico) < 0)
            {
                return false;
            }
            else
            {
                quantità -= quantitaScarico;
                return true;
            }
        }
    }
}
