using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoSpazio
{
    internal class Quadrato : Rettangolo
    {
        public Quadrato(float larghezza, float altezza, Punto p) : base(larghezza, altezza, p)
        {

        }
        public override string ToString()
        {
            return string.Format("QUADRATO -> ALTEZZA: {0}, LARGHEZZA: {1}, AREA {2}, Perimetro {3}\n", Altezza, Larghezza, CalcoloArea(), CalcoloPerimetro());
        }
    }
}
