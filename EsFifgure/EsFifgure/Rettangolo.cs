using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsFifgure
{
    internal class Rettangolo : Figura
    {
        public Rettangolo(double _base, double altezza) : base(_base, altezza)
        {

        }
        public double CalcoloArea()
        {
            return Base * Altezza;
        }
        public double CalcoloPerimetro()
        {
            return (Base + Altezza) * 2;
        }
        public override string ToString()
        {
            return string.Format($"RETTANGOLO --> Base: {Base}, Altezza: {Altezza}, Area: {CalcoloArea()}, Perimetro: {CalcoloPerimetro()}");
        }

    }
}
