using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica
{
    internal class Termometro
    {
        double _temperatura;
        public Termometro()
        {
            _temperatura = 36;
        }
        public void CambiaTemperatura(double temperatura)
        {
            _temperatura += temperatura;
        }
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
//creare la classe paziente che ha come attributi (nome,cognome,reparto e temperatura(Termometro)) 
//metodo che permette di cambiare la temperatura del termometro
//altra classe che chiamerò reparto con all'interno una lista di pazienti e posso
//aggiungere un paziente nel reparto e posso visualizzare
//nome e cognome del paziente con la temperatura, (temperaturepazienti > 36)
