using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RipassoInItinere
{
    internal class Flotte
    {
        string nome, autorizzazione;
        List<Veicolo> parcoVeicoli;
        public Flotte(string nome)
        {
            parcoVeicoli = new List<Veicolo>();
            nome = Nome;
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
        public void Stampa()
        {
            parcoVeicoli.ForEach(v => Console.WriteLine(v));
        }
    }
}
