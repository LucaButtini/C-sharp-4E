using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsFigureInterfaccie
{
    internal class Rettangolo : FiguraInterface
    {
        protected double @base, _altezza;
        public Rettangolo(double _base, double altezza)
        {
            @base = _base;
            _altezza = altezza;
        }

        public double Base { get => @base; set => @base = value; }
        public double Altezza { get => _altezza; set => _altezza = value; }
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
