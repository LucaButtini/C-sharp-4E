using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattelloAstratta
{
    internal class Nave : Battello
    {
        static double _costoXMiglia = 2;

        public Nave(string nome, int miglia): base(nome, miglia)
        {

        }
        public override double CostoViaggio()
        {
            return _costoXMiglia * _miglia;
        }
    }
}
