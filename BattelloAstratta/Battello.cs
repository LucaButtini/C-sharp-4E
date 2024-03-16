using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattelloAstratta
{
    internal abstract class Battello
    {
        protected string _nome;
        protected int _miglia;

        public Battello(string nome, int miglia)
        {
            _nome = nome;
            _miglia = miglia;
        }

        public abstract double CostoViaggio();
    }
}
