using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RipassoInItinere
{
    internal class Flotte
    {
        string nome, autorizzazione;
        List<Veicolo> parcoVeicoli;
        public Flotte()
        {
            parcoVeicoli = new List<Veicolo>();
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Autorizzazione
        {
            get { return autorizzazione; }
            set { autorizzazione = value; }
        }
        public void Aggiungi(Veicolo v)
        {
            parcoVeicoli.Add(v);
        }
    }
}
