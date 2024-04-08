using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaVisuale
{
    internal class Moto : Veicolo
    {
        static double componenteKm = 0.2;
        int nTempi;
        bool portaCasco;
        public Moto(string _marca, string _modello, double _km, double _kmNoleggio, int _nTempi, bool _portaCasco) : base(_marca, _modello, _km, _kmNoleggio)
        {
            nTempi = _nTempi;
            portaCasco = true;
            portaCasco = _portaCasco;

        }

        public static double ComponenteKm { get => componenteKm; }
        public static double ComponenteKm1 { get => componenteKm; set => componenteKm = value; }
        public int NTempi { get => nTempi; set => nTempi = value; }
        public bool PortaCasco { get => portaCasco; set => portaCasco = value; }
        public override double CostoComplessivo()
        {
            return ComponenteFissa * ComponenteKm;
        }
        public override string ToString()
        {
            return string.Format($"MOTO -> Modello: {Modello}, Marca: {Marca}, Km: {Km}, KmNoleggio: {KmNoleggio}, NTempi: {NTempi}, Porta Casco: {PortaCasco}");
        }
    }
}
