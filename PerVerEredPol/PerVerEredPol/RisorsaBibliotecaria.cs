using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerVerEredPol
{
    internal abstract class RisorsaBibliotecaria
    {
        protected string titolo, autore;
        protected double prezzo;
        public RisorsaBibliotecaria(string titolo, string autore, double prezzo)
        {
            this.titolo = titolo;
            this.autore = autore;
            this.prezzo = prezzo;
        }

        public abstract double CalcolaCosto();
    }
}
