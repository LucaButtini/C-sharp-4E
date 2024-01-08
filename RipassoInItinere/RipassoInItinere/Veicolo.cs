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
        int codice;
        //numeroPosti posti;

        public string Targa
        {
            get { return targa; }
            set { targa = value; }
        }
        public int Codice
        {
            get { return codice; }
            set { codice = value; }
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
    }
}
