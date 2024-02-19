using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaVerificaRifatta
{
    internal class Banca
    {
        static int idConto;
        string nome;
        List<ContoCorrente> conti;

        public Banca(string nome)
        {
            conti = new List<ContoCorrente>();
            Nome = nome;
        }
        static public int IdConto
        {
            get { return ++idConto; }
        }

        public string Nome { get => nome; private set => nome = value; }
        public void Aggiungi(ContoCorrente c)
        {
            conti.Add(c);
        }
        public void Stampa()
        {
            conti.ForEach(c => { Console.WriteLine(c.ToString()); });
        }
        public ContoCorrente Ricerca(int id)
        {
            return conti.Find(c => c.Id == id);
        }
        public void Prelieva(int codice, double quantita)
        {
            ContoCorrente c = Ricerca(codice);
            if (c != null)
            {
                if (c.Saldo >= quantita)
                {
                    c.Saldo -= quantita;
                    string logString = $"{DateTime.Now} {c.Id} {c.Nome} {c.Cognome} -{quantita}";
                    ScriviFile(logString);
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
            ContoCorrente c = Ricerca(codice);
            if (c != null)
            {
                c.Saldo += quantita;
                string logString = $"{DateTime.Now} {c.Id} {c.Nome} {c.Cognome} {quantita}";
                ScriviFile(logString);
            }
        }
        static void ScriviFile(string stringa)
        {
            StreamWriter sw = File.AppendText(Path.Combine(Environment.CurrentDirectory, "log.txt"));
            sw.WriteLine(stringa);
            sw.Close();
        }
    }
}
