using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica
{
    internal class Paziente
    {
        string _nome;
        string _cognome;
        double _temperatura;
        string _reparto;
        public Paziente(string _nome, string _cognome, string _reparto)
        {
            SetNome(_nome);
            SetCognome(_cognome);
            SetTemperatura(36);
            SetReparto(_reparto);
        }
        private void SetNome(string nome)
        {
            _nome = nome;
        }
        private void SetCognome(string cognome)
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