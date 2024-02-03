using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostVerificaFilaB
{
    internal class Magazzino
    {
        string descrizione;
        List<Articolo> articoli = new List<Articolo>();
        static int codice = 0;

        public int Codice()
        {
            return codice++;
        }
        public string Descrizione
        {
            get { return descrizione; }
        }

        public Magazzino(string _descrizione)
        {
            descrizione = _descrizione;
        }

        public void AggiungiArticolo(Articolo a)
        {
            articoli.Add(a);
        }

        public List<Articolo> Lista()
        {
            List<Articolo> l = new List<Articolo>();
            l.AddRange(articoli);

            return l;
        }

        public double PrezzoTotale()
        {
            double p = 0;
            articoli.ForEach(elemento => p += elemento.CostoArticolo());

            return p;
        }

        public bool Carico(string articolo, double q)
        {
            int i = articoli.FindIndex(Articolo => Articolo.Descrizione == articolo);

            //if (i != -1)
            //{
            //    articoli[i].Carico(q);
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            try
            {
                return articoli[i].Carico(q);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Scarico(string articolo, double q)
        {
            int i = articoli.FindIndex(Articolo => Articolo.Descrizione == articolo);

            //if (i != -1)
            //{   
            //    return articoli[i].Scarico(q);
            //}
            //else
            //{
            //    return false;
            //}

            try
            {
                return articoli[i].Scarico(q);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
