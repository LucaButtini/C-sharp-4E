using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace RipassoInItinere
{
    internal class Veicolo
    {
        string marca, targa, modello;
        int codiceVeicolo;
        numeroPosti posti;
        public Veicolo(string insMarca, string insModello, numeroPosti insNPosti, string insTarga)
        {
            Marca = insMarca;
            Modello = insModello;
            posti = insNPosti;
            targa = insTarga;
            codiceVeicolo = Flotte.Code;
        }
        public int Codice
        {
            get { return codiceVeicolo; }
            set
            {

                if (codiceVeicolo > 999)
                {
                    throw new Exception("Troppi veicoli");
                }
                else
                {
                    codiceVeicolo = value;
                }
            }
        }
        public numeroPosti Posti
        {
            get { return posti; }
            set { posti = value; }
        }
        public string Targa
        {
            get { return targa; }
            set { targa = value; }
        }

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        public string Modello
        {
            get { return modello; }
            set { modello = value; }
        }
        public override string ToString()
        {
            return string.Format($"CODICE: [{Codice}],  TARGA: [{Targa}],  MARCA: [{Marca}], MODELLO:[{Modello}], NUMERO POSTI: [{Posti}]");
        }
    }
}
