using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaClassiPrepVerifica
{
    internal abstract class Veicolo
    {
        string _marca, _modello;
        double _km, _costoNoleggio;
        protected Veicolo(string marca, string modello, double km, double costoNoleggio)
        {
            _marca = marca;
            _modello = modello;
            _km = km;
            _costoNoleggio = costoNoleggio;

        }

        public string Marca { get => _marca; set => _marca = value; }
        public string Modello { get => _modello; set => _modello = value; }
        protected double Km { get => _km; set => _km = value; }
        protected double CostoNoleggio { get => _costoNoleggio; set => _costoNoleggio = value; }
        public abstract string Stampa();
        public abstract double CalcoloCosto();
    }
}
