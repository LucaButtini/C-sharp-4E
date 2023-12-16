using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaraPiloti
{
    internal class Auto
    {
        string _scuderia;
        Pilota _pilota;

        public Auto(string scuderia, Pilota pilota)
        { 
            _scuderia = scuderia;
            _pilota = pilota;
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", _pilota.GetNome(), _pilota.GetCognome());
        }

        public void SetScuderia(string scuderia)
        {
            _scuderia = scuderia;
        }
        public string GetScuderia()
        {
            return _scuderia;
        }
        public string StampaAuto()
        {
            return string.Format("{0,-20} {1,-20} {2}", _pilota.GetNome(), _pilota.GetCognome(), GetScuderia());
        }
    }
}
