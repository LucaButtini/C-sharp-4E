using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsFifgure
{
    internal class Quadrato : Figura
    {
        public Quadrato(double baseFig) : base(baseFig)
        {

        }
        public double CalcoloArea()
        {
            return Base * Base;
        }
        public double CalcoloPerimetro()
        {
            return (Base + Base) * 2;
        }
        public override string ToString()
        {
            return string.Format($"Lato: {Base}, Area: {CalcoloArea()}, Perimetro: {CalcoloPerimetro()}");
        }
    }
}
