using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoSpazio
{
    internal class Punto
    {
        int _x, _y;
        public Punto()
        {
            X = 0;
            Y = 0;
        }
        public Punto(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get => _x; private set => _x = value; }
        public int Y { get => _y; private set => _y = value; }
        public override string ToString()
        {
            return string.Format("PUNTO: X: [{0}], Y: [{1}]\n", X, Y);
        }
    }
}
