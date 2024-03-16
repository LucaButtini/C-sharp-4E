using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaDadoConsole
{
    internal class Dado
    {
        Random rnd;
        int _nFaccie, _facciaDado;

        public int FacciaDado { get => _facciaDado; set => _facciaDado = value; }

        public Dado(int nFaccie)
        {
            rnd = new Random();
            _nFaccie = nFaccie;
            FacciaDado = LancioDado();
        }
        public int LancioDado()
        {
            return rnd.Next(1, _nFaccie + 1);
        }
        static public bool operator >(Dado dado1, Dado dado2)
        {
            return (dado1.FacciaDado > dado2.FacciaDado);
        }
        static public bool operator <(Dado dado1, Dado dado2)
        {
            return (dado1.FacciaDado < dado2.FacciaDado);
        }
        static public bool operator ==(Dado dado1, Dado dado2)
        {
            return dado1.FacciaDado == dado2.FacciaDado;
        }
        static public bool operator !=(Dado dado1, Dado dado2)
        {
            return !(dado1 == dado2);
        }
    }
}
