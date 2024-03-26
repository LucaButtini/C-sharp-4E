using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureAstratte
{
    internal class Cerchio : Figura
    {
        double _raggio;
        public Cerchio(double raggio)
        {
            _raggio = raggio;
        }

        public double Raggio { get => _raggio; private set => _raggio = value; }
        public override double CalcoloPerimetro()
        {
            return (Raggio * 2) * 3.14;
        }
        public override double CalcoloArea()
        {
            return (Raggio * Raggio) * 3.14;
        }
        public override string ToString()
        {
            return string.Format($"CERCHIO --> Raggio: {Raggio}, Area: {CalcoloArea()}, Perimetro: {CalcoloPerimetro()}");
        }
    }
}
