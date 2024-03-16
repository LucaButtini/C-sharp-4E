using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattelloAstratta
{
    internal class NaveMercantile : Nave
    {
        static double _costoXTonnellata = 3;
        double _tonnellate;

        public NaveMercantile(string nome, int miglia, double tonnellate): base(nome,miglia)
        {
            _tonnellate = tonnellate;
        }
        public override double CostoViaggio()
        {
            return base.CostoViaggio()+_costoXTonnellata*_tonnellate;
        }
    }
}
