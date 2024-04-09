using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaClassiPrepVerifica
{
    internal class Moto : Veicolo, Interface1
    {
        static double quota = 0.4;
        int _tempi;
        bool _casco;
        public Moto(string marca, string modello, double km, double costoNoleggio, int tempi, bool casco) : base(marca, modello, km, costoNoleggio)
        {
            _casco = casco;
            _tempi = tempi;
        }
        public int Tempi { get => _tempi; set => _tempi = value; }
        public bool Casco { get => _casco; set => _casco = value; }
        public override double CalcoloCosto()
        {
            return quota * CostoNoleggio;
        }
        public override string Stampa()
        {
            return String.Format($"VEICOLO -> {this.GetType().Name}, Marca: {Marca}, Modello: {Modello}, km: {Km}, costo: {CostoNoleggio}, tempi: {Tempi}, Casco: {Casco}, Costo: {CalcoloCosto()}");
        }
        public string Targa(string s)
        {
            return String.Format($"{s}, ciao bello");
        }
    }
}
