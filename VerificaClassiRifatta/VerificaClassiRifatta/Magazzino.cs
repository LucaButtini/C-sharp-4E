using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VerificaClassiRifatta
{
    internal class Magazzino
    {
        static int codiceProdotto;
        string descrizione;
        List<Articolo> articoli;
        public Magazzino(string insDescr)
        {
            articoli = new List<Articolo>();
            Descrizione = insDescr;
        }
        static public int CodiceProdotto
        {
            get { return ++codiceProdotto; }
        }
        public string Descrizione
        {
            get { return descrizione; }
            set { descrizione = value; }
        }
        static void ScriviFile(string stringa)
        {
            StreamWriter sw = File.AppendText(Path.Combine(Environment.CurrentDirectory, "log.txt"));
            sw.WriteLine(stringa);
            sw.Close();
        }
        public void Scarico(int codice, double quantita)
        {
            Articolo a = Ricerca(codice);
            if (a != null)
            {
                if (a.Giacenza >= quantita)
                {
                    a.Giacenza -= quantita;
                    string logString = $"{DateTime.Now} {a.Codice} {a.Descrizione} -{quantita}";
                    ScriviFile(logString);
                }
                else
                {
                    Console.WriteLine("non disponibile la quantita");
                }
            }
        }
        public void Carico(int codice, double quantita)
        {
            Articolo a = Ricerca(codice);
            if (a != null)
            {
                a.Giacenza += quantita;
                string logString = $"{DateTime.Now} {a.Codice} {a.Descrizione} {quantita}";
                ScriviFile(logString);
            }
        }
        public Articolo Ricerca(int codice)
        {
            return articoli.Find(a => a.Codice == codice);
        }
        public double SaldoTotale()
        {
            double saldoTot = 0;
            for (int i = 0; i < articoli.Count; i++)
            {
                saldoTot += articoli[i].Prezzo + articoli[i].Giacenza;
            }
            return saldoTot;
        }
        public void Aggiungi(Articolo a)
        {
            articoli.Add(a);
        }
        public void Stampa()
        {
            articoli.ForEach(a => { Console.WriteLine(a.ToString()); });
        }
    }
}
