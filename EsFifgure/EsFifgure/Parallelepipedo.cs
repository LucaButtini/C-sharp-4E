using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsFifgure
{
    internal class Parallelepipedo : Rettangolo
    {
        double _profondita, _volume;
        public Parallelepipedo(double profondita, double altezza, double Base) : base(altezza, Base)
        {
            _profondita = profondita;
        }
        public double Profondita { get => _profondita; set => _profondita = value; }
        public double Volume { get => _volume; set => _volume = value; }

        public double CalcolaVolume()
        {

            return Profondita * Altezza * Base;
        }
        public override string ToString()
        {
            return String.Format($"PARALLELEPIPEDO --> Volume: {CalcolaVolume()}, Base:{Base}, Altezza: {Altezza}, Prondita': {Profondita}");
        }
    }
}
