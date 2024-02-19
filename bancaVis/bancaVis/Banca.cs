using Banca;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace bancaVis
{
    class Banca
    {
        static int id;
        string name;
        List<Conto> conti;
        public Banca(string _name)
        {
            Name = _name;
            conti = new List<Conto>();
        }

        static public int IdConto
        {
            get { return ++id; }
        }

        public string Name
        {
            get => name;
            set => name = value;
        }
        public Conto Ricerca(int id)
        {
            return conti.Find(c => c.Identifica == id);
        }
        public void Prelieva(int codice, double quantita)
        {
            Conto c = Ricerca(codice);
            if (c != null)
            {
                if (c.Saldo >= quantita)
                {
                    c.Saldo -= quantita;
                }
                else
                {
                    Console.WriteLine("non disponibile la quantita");
                }
            }
        }
        public double SaldoTotale()
        {
            double saldoTot = 0;
            for (int i = 0; i < conti.Count; i++)
            {
                saldoTot += conti[i].Saldo * conti.Count;
            }
            return saldoTot;
        }
        public void Versa(int codice, double quantita)
        {
            Conto c = Ricerca(codice);
            if (c != null)
            {
                c.Saldo += quantita;
            }
        }
        public void Aggiungi(Conto c)
        {
            conti.Add(c);
        }
    }
}
