using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezzoTrasportoEreditarieta
{
    internal class MezzoTrasporto
    {
        int numPosti;

        public MezzoTrasporto(int numPosti)
        {
            NumPosti = numPosti;
        }
        public int NumPosti { get => numPosti; private set => numPosti = value; }
        public void MetodoQualsiasi()
        {
            Console.WriteLine($"Sono metodo qualsiasi di mezzo di trasporto e il mio numero di posti è: {NumPosti}");
        }
    }


}
