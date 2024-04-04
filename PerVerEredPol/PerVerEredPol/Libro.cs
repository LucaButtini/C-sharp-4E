using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PerVerEredPol
{
    internal class Libro : RisorsaBibliotecaria
    {
        static int tassaLibro = 6;
        public Libro(string titolo, string autore, double prezzo) : base(titolo, autore, prezzo) { }
        public override double CalcolaCosto()
        {
            return prezzo * tassaLibro;
        }
    }
}
