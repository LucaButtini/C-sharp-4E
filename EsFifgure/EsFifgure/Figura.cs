using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsFifgure
{
    internal class Figura
    {
        private double _altezza;
        private double _area;
        private double _perimetro;
        private double _base;

        public Figura(double baseFigura, double altezza)
        {
            _base = baseFigura;
            _altezza = altezza;
        }
        public Figura(double baseFigura)
        {
            _base = baseFigura;
        }

        public double Altezza { get => _altezza; set => _altezza = value; }
        protected double Area { get => _area; set => _area = value; }
        protected double Perimetro { get => _perimetro; set => _perimetro = value; }
        protected double Base { get => _base; set => _base = value; }
    }
}
