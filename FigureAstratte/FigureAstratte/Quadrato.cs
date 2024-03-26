using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureAstratte
{
    internal class Quadrato : Figura
    {
        double _lato;
        public Quadrato(double lato)
        {
            _lato = lato;
        }

        public double Lato { get => _lato; private set => _lato = value; }
        public override double CalcoloArea()
        {
            return Lato * Lato;
        }
        public override double CalcoloPerimetro()
        {
            return (Lato + Lato) * 2;
        }
        public override string ToString()
        {
            return string.Format($"QUADRATO --> Lato: {Lato}, Area: {CalcoloArea()}, Perimetro: {CalcoloPerimetro()}");
        }
    }
}
