using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaRefactored
{
    internal class Paziente
    {
        string _nome;
        string _cognome;
        double _temperatura;
        string _reparto;
        public Paziente()
        {
            SetTemperatura(36);
        }
        public void SetNome(string nome)
        {
            _nome = nome;
        }
        public void SetCognome(string cognome)
        {
            _cognome = cognome;
        }
        public void SetTemperatura(double temperatura)
        {
            _temperatura = temperatura;
        }
        public void SetReparto(string reparto)
        {
            _reparto = reparto;
        }
        public string GetNome()
        {
            return _nome;
        }
        public string GetCognome()
        {
            return _cognome;
        }
        public double GetTemperatura()
        {
            return _temperatura;
        }
        public string GetReparto()
        {
            return _reparto;
        }
        public string Anagrafica()
        {
            return string.Format($"nome: {GetNome()}, cognome: {GetCognome()}, temperatura: {GetTemperatura()}, reparto: {GetReparto()}");
        }
    }

}