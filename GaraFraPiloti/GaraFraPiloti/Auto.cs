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
        public Auto(string scuderia, Pilota mioPilota)
        {
            _scuderia = scuderia;
            _mioPilota = mioPilota;
        }

        public void SetScuderia(string scuderia)
        {
            _scuderia = scuderia;
        }
        public string GetScuderia()
        {
            return _scuderia;
        }
        public string Stampa()
        {
            return string.Format($"SCUDERIA: {GetScuderia()}, {_mioPilota.Stampa()}");
        }
    }
}
