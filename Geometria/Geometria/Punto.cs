using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    internal class Punto
    {
        int _x, _y;

        public Punto(int x, int y)
        {
            X = x;
            Y = y;
        }
        //public Punto(int x, int y):this(x,y)
        //{
        //    _y = 0;
        //    _x = 0;
        //}
        public Punto():this(0, 0)
        {

        }

        public int X 
        { 
            get => _x; 
            private set => _x = value;
        }
        public int Y 
        { 
            get => _y; private set => _y = value;
        }
        public string Scrivi()
        {
            return ($"x: {X}, y: {Y}");
        }
    }
}
