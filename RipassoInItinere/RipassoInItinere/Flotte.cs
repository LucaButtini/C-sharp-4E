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
            this.nome = nome;
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
        public List<Veicolo> GetLista()
        {
            List<Veicolo> copiaParcoVeicoli = new List<Veicolo>(parcoVeicoli);//incapsulamento, i dati rimangono protetti
            return copiaParcoVeicoli;
        }
        public void Aggiungi(Veicolo v)
        {
            parcoVeicoli.Add(v);
        }
        public void Stampa()
        {
            parcoVeicoli.ForEach(v => Console.WriteLine(v.ToString()));
        }

        public int RicercaPosti(numeroPosti posti)
        {
            return parcoVeicoli.Count(v => v.Posti == posti);
        }

        public int Disponibili(string marca)
        {
            return parcoVeicoli.Count(v => v.Marca == marca);
        }

        public Veicolo Ricerca(int code, string targa)
        {
            return parcoVeicoli.Find(v => v.Codice == code || v.Targa == targa);
        }
        public int Elimina(int code, string targa)
        {
            return parcoVeicoli.RemoveAll(v => v.Codice == code || v.Targa == targa);
        }
    }
}
