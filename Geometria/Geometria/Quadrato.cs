using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    internal class Quadrato : Rettangolo
    {
        public Quadrato(Punto p, double lato) : base(p, lato, lato)
        {

        }
        new public string Scrivi()
        {
            return ($"lato: {_base}, Perimetro: {CalcoloPerimetro()}, Area: {CalcolaArea()}");
        }
    }
}
