using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PerVerificaClassi
{
    internal class BellinazziCo
    {
        string nome;
        static int matricola;
        List<Lavoratore> lavoratori;
        public BellinazziCo(string nome)
        {
            lavoratori = new List<Lavoratore>();
            Nome = nome;
        }

        static public int Matricola
        {
            get { return ++matricola; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public void Aggiungi(Lavoratore lv)
        {
            lavoratori.Add(lv);
        }
        public void Stampa()
        {
            lavoratori.ForEach(lv => { Console.WriteLine(lv.ToString()); });
        }
        public Lavoratore Ricerca(string cognome, int matricola)
        {
            return lavoratori.Find(l => l.Matricola == matricola || l.Cognome == cognome);
        }
        public int Cancella(string cognome, int matricola)
        {
            return lavoratori.RemoveAll(l => l.Matricola == matricola || l.Cognome == cognome);
        }
        public List<Lavoratore> ListaAzioni(azioni azione)
        {
            return lavoratori.FindAll(l => azione == l.Azione);
        }
    }
}