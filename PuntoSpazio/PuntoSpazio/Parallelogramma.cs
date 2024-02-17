using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoSpazio
{
    internal class Parallelogramma : Rettangolo
    {
        float _profondita, _volume;
        public Parallelogramma(float larghezza, float altezza, Punto p, float profondita) : base(larghezza, altezza, p)
        {
            Profondita = profondita;
        }

        public float Profondita { get => _profondita; private set => _profondita = value; }
        public float Volume { get => _volume; private set => _volume = value; }

        public float CalcoloVolume()
        {
            return _profondita * _altezza * _larghezza;
        }
        public override string ToString()
        {
            return string.Format("PARALLELOGRAMMA -> ALTEZZA: {0}, LARGHEZZA: {1}, PROFONDITA': {2} AREA {3}, PERIMETRO {4}, VOLUME: {5}\n", Altezza, Larghezza, Profondita, CalcoloArea(), CalcoloPerimetro(), CalcoloVolume());
        }
    }
}
