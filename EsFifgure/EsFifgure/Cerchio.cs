using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EsFifgure
{
    internal class Cerchio : Figura
    {
        public Cerchio(double raggio) : base(raggio)
        {
        }
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
            return string.Format($"Raggio: {Base}, Area: {CalcoloArea()}, Perimetro: {CalcoloPerimetro()}");
        }
    }
}
