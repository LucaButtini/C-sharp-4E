using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioOverrideMetodo
{
    internal class Cibo
    {
        DateTime _scadenza;
        double _calorie;

        public Cibo(DateTime scadenza, double calorie)
        {
            _scadenza = scadenza;
            _calorie = calorie;
        }
        public void Stampa()
        {
            Console.WriteLine("scadenza: {0}, calorie: {1}", _scadenza, _calorie);
        }
    }
}
