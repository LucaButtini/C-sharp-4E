using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace bancaVis
{
    class Banca
    {
        // List<Conto> contiCorrenti = new List<Conto>();
        List<Conto> contiCorrenti;
        static int id;
        private string name;

        static public int Id
        {
            get { return ++id; }
        }

        public string Name
        {
            set => name = value;
        }

        public Banca(string _name)
        {
            name = _name;
            contiCorrenti = new List<Conto>();
        }

        public void AggiungiConti(Conto c)
        {
            contiCorrenti.Add(c);
        }
        public List<Conto> CopyCorrentisti()
        {

            List<Conto> newCorrentisti = new List<Conto>();
            return newCorrentisti = contiCorrenti.ToList();
        }

    }
}
