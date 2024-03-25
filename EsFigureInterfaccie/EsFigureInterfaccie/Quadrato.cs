using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsFigureInterfaccie
{
    internal class Quadrato : FiguraInterface
    {
        protected double @base;
        public Quadrato(double _base)
        {
            @base = _base;
        }
        public double Base { get => @base; set => @base = value; }
        public double Altezza { get; }
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
            return string.Format($"QUADRATO --> Lato: {Base}, Area: {CalcoloArea()}, Perimetro: {CalcoloPerimetro()}");
        }

    }
}
