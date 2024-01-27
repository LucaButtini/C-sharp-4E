using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Magazzino
{
    internal class Magazzino
    {
        string descrizione;
        List<Articolo> articoli;
        static int codice;
        double saldo;
        public Magazzino(string nome)
        {
            articoli = new List<Articolo>(10);//assegno valore predefinito di 10 alla capacita della lista, nel nostro contesto la quantita di articoli
            descrizione = nome;
        }
        public double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }
        static public int Codice
        {
            //proprietà statica per aggiungere il codice in modo incrementale
            get { return ++codice; }
        }
        public string Descrizione
        {
            get { return descrizione; }
            set { descrizione = value; }
        }
        public double SaldoCalcolo()
        {
            //metodo per il calcolo del saldo del magazzino
            double calcolo = 0;
            for (int i = 0; i < articoli.Count; i++)
            {
                calcolo = articoli[i].Prezzo + articoli[i].Giacenza;
            }
            return calcolo;
        }
        public int Quantita()
        {
            //ottengo la capacita della lista 
            return articoli.Capacity;
        }
        public void Stampa()
        {
            //stampo la lista di articoli
            articoli.ForEach(articolo => { Console.WriteLine(articolo.ToString()); });
        }
        public void Aggiungi(Articolo a)
        {
            //aggiungo articolo alla lista
            articoli.Add(a);
        }
        public bool Trovato(int code)
        {
            //metodo per controllare che l'oggetto ricercato col codice esista
            Articolo a;
            a = articoli.Find(ar => ar.Codice == code);
            if (a != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}