using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureAstratte
{
    internal class Rettangolo : Figura
    {
        protected double _base, _altezza;
        public Rettangolo(double @base, double altezza)
        {
            _base = @base;
            _altezza = altezza;
        }

        public double Base { get => _base; private set => _base = value; }
        public double Altezza { get => _altezza; private set => _altezza = value; }
        public override double CalcoloArea()
        {
            return Base * Altezza;
        }
        public override double CalcoloPerimetro()
        {
            return (Base + Altezza) * 2;
        }
        public override string ToString()
        {
            return string.Format($"RETTANGOLO --> Base: {Base}, Altezza: {Altezza}, Area: {CalcoloArea()}, Perimetro: {CalcoloPerimetro()}");
        }
    }
}
