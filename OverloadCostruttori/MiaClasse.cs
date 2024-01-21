using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadCostruttori
{
    internal class MiaClasse
    {
        int _at1;
        double _at2;
        int _at3;
        double _at4;
        int _at5;
        public MiaClasse(int at1, double at2, int at3, double at4, int at5) // costruttore master
        {
            _at1 = at1;
            _at2 = at2;
            _at3 = at3;
            _at4 = at4;
            _at5 = at5;
        }
        public MiaClasse(int at1, double at2, int at3, double at4) : this(at1, at2, at3, at4, 0)
        {

        }
        public MiaClasse(int at1, double at2, int at3) : this(at1, at2, at3, 0, 0)
        {

        }
        public MiaClasse(int at1, double at2) : this(at1, at2, 0, 0, 0)
        {

        }
        public MiaClasse(int at1) : this(at1, 0, 0, 0, 0)
        {

        }
        public void MioMetodo(int a)
        {
            if (a < 0)
            {
                throw new Exception("il numero deve essere maggiore di 0");
            }
            else
            {
                Console.WriteLine("E' corretto");
            }
        }
    }
}
