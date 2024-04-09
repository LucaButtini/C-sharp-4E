using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtiniLuca
{
    internal class Azienda
    {
        //attributi azienda
        string _nome, _citta, _indirizzo;
        List<Articolo> articoli;
        public Azienda(string nome, string citta, string indirizzo)
        {
            _nome = nome;
            _citta = citta;
            _indirizzo = indirizzo;
            articoli = new List<Articolo>(); //istanzio lista articoli
        }
        //proprietà azienda
        public string Nome { get => _nome; private set => _nome = value; }
        public string Citta { get => _citta; private set => _citta = value; }
        public string Indirizzo { get => _indirizzo; private set => _indirizzo = value; }
        public void Aggiungi(Articolo a) //metodo aggiunta articolo alla lista
        {
            articoli.Add(a);
        }
        public List<Articolo> GetLista() //metodo per incapsulamento lista
        {
            return articoli.ToList();
        }
        public Articolo Trova(string code) //metodo per trovare articolo, server per la vendita
        {
            return articoli.Find(a => a.Identificativo == code);
        }
        public bool Vendita(Articolo a, int quantita) //metodo vendita articolo
        {
            if (a.Quantita > quantita)
            {
                a.Quantita -= quantita;
                return true;
            }
            return false;
        }
    }
}
