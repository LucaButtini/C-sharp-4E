using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConcessionariaVisuale
{
    internal abstract class Veicolo
    {
        static int componenteFissa = 25;
        string marca, modello;
        double km, kmNoleggio;

        protected Veicolo(string _marca, string _modello, double _km, double _kmNoleggio)
        {
            marca = _marca;
            modello = _modello;
            km = _km;
            kmNoleggio = _kmNoleggio;
        }

        protected static int ComponenteFissa { get => componenteFissa; }
        public string Marca { get => marca; set => marca = value; }
        public string Modello { get => modello; set => modello = value; }
        protected double Km { get => km; set => km = value; }
        protected double KmNoleggio { get => kmNoleggio; set => kmNoleggio = value; }
        public abstract double CostoComplessivo();
    }
}
