using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerVerEredPol
{
    internal class EBook : RisorsaBibliotecaria
    {
        static int tassaEbook = 8;
        public EBook(string titolo, string autore, double prezzo) : base(titolo, autore, prezzo) { }
        public override double CalcolaCosto()
        {
            return prezzo + tassaEbook;
        }
    }
}
