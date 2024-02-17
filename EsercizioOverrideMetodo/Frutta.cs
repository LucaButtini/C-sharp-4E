using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioOverrideMetodo
{
    internal class Frutta : Cibo
    {
        string _coloreBuccia;

        public Frutta(string coloreBuccia, DateTime scadenza, double calorie): base(scadenza, calorie)
        {
            _coloreBuccia = coloreBuccia;
        }

        new public void Stampa()
        {
            Console.WriteLine("colore buccia: {0}", _coloreBuccia);
            base.Stampa();
        }
    }
}
