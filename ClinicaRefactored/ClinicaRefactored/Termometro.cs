using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaRefactored
{
    internal class Termometro
    {
        double _temperatura;
        public Termometro() //default a 36
        {
            _temperatura = 36;
        }
        public void CambiaTemperatura(double nuovaTemperatura) //metodo per il cambio temp, aggiungo la nuova temperatura
        {
            _temperatura = nuovaTemperatura;
        }
        //public void CambiaTemperatura(double temperatura)
        //{
        //    _temperatura += temperatura;
        //}
        public double GetTemperatura()
        {
            return _temperatura;
        }
        public void ResetTemperatura()
        {
            _temperatura = 36;
        }

    }

}
