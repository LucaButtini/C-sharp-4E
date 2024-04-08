using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaVisuale
{
    internal class Auto : Veicolo
    {
        static double componenteKm = 0.4;
        int cilindrata, nVolumi;
        public Auto(string _marca, string _modello, double _km, double _kmNoleggio, int _cilindrata, int _nVolumi) : base(_marca, _modello, _km, _kmNoleggio)
        {
            cilindrata = _cilindrata;
            nVolumi = _nVolumi;
        }
        public static double ComponenteKm { get => componenteKm; }
        public int Cilindrata { get => cilindrata; set => cilindrata = value; }
        public int NVolumi { get => nVolumi; set => nVolumi = value; }
        public override double CostoComplessivo()
        {
            return ComponenteFissa * ComponenteKm;
        }
        public override string ToString()
        {
            return string.Format($"AUTO -> Modello: {Modello}, Marca: {Marca}, Km: {Km}, KmNoleggio: {KmNoleggio}, Cilindrata: {Cilindrata}, NVolumi: {NVolumi}");
        }
    }
}
