using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaraFraPiloti
{
    internal class Auto
    {
        string _scuderia;
        Pilota _mioPilota;
        double _tempoInGara;
        public Auto(string scuderia, Pilota mioPilota)
        {
            _scuderia = scuderia;
            _mioPilota = mioPilota;
        }
        public override string ToString()
        {
            return string.Format($"SCUDERIA: [{Scuderia}], {_mioPilota.Stampa()}");
        }
        public string Scuderia
        {
            get { return _scuderia; }
            set { _scuderia = value; }
        }
        public double TempoInGara
        {
            get { return _tempoInGara; }
            set { _tempoInGara = value; }
        }
        public Pilota MioPilota
        {
            get { return _mioPilota; }
            set { _mioPilota = value; }
        }
    }
}