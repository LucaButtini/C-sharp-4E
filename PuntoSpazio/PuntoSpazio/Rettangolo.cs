using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoSpazio
{
    internal class Rettangolo
    {
        protected float _larghezza, _altezza, _area, _perimetro;


        public Rettangolo(float larghezza, float altezza, Punto punto)
        {
            Altezza = altezza;
            Larghezza = larghezza;
        }

        public float Altezza { get => _altezza; private set => _altezza = value; }
        public float Larghezza { get => _larghezza; private set => _larghezza = value; }
        public float Perimetro { get => _perimetro; private set => _perimetro = value; }
        public float Area { get => _area; private set => _area = value; }
        public float CalcoloPerimetro()
        {
            return (Larghezza + Altezza) * 2;
        }
        public float CalcoloArea()
        {
            return Larghezza * Altezza;
        }
        public override string ToString()
        {
            return string.Format("RETTANGOLO -> ALTEZZA: {0}, LARGHEZZA: {1}, AREA {2}, Perimetro {3}\n", Altezza, Larghezza, CalcoloArea(), CalcoloPerimetro());
        }
    }
}
