using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaClassiPrepVerifica
{
    internal class Auto : Veicolo
    {
        static double quota = 0.2;
        int _cilindrata, _volumi;
        public Auto(string marca, string modello, double km, double costoNoleggio, int cilindrata, int volumi) : base(marca, modello, km, costoNoleggio)
        {
            _cilindrata = cilindrata;
            _volumi = volumi;
        }
        public int Cilindrata { get => _cilindrata; set => _cilindrata = value; }
        public int Volumi { get => _volumi; set => _volumi = value; }
        public override double CalcoloCosto()
        {
            return quota * CostoNoleggio * Cilindrata;
        }
        public override string Stampa()
        {
            return String.Format($"VEICOLO -> {this.GetType().Name}, Marca: {Marca}, Modello: {Modello}, km: {Km}, costo: {CostoNoleggio}, cilindrata: {Cilindrata}, Volumi: {Volumi}, Costo: {CalcoloCosto()}");
        }
    }
}
