using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsFigureInterfaccie
{
    internal class Cerchio : FiguraInterface
    {
        protected double _raggio;
        public Cerchio(double raggio)
        {
            _raggio = raggio;
        }
        public double Base { get => _raggio; set => _raggio = value; }
        public double Altezza { get; }
        public double CalcoloPerimetro()
        {
            return (Base * 2) * 3.14;
        }
        public double CalcoloArea()
        {
            return (Base * Base) * 3.14;
        }
        public override string ToString()
        {
            return string.Format($"CERCHIO --> Raggio: {Base}, Area: {CalcoloArea()}, Perimetro: {CalcoloPerimetro()}");
        }
    }
}
