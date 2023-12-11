using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaraFraPiloti
{
    internal class Pilota
    {
        string _nome, _cognome;
        public Pilota(string nome, string cognome)
        {
            SetNome(nome);
            SetCognome(cognome);
        }

        private void SetNome(string nome)
        {
            _nome = nome;
        }
        private void SetCognome(string cognome)
        {
            _cognome = cognome;
        }
        public string GetNome()
        {
            return _nome;
        }
        public string GetCognome()
        {
            return _cognome;
        }
        public string Stampa()
        {
            return string.Format($"COGNOME: {GetCognome()}, NOME: {GetNome()}");
        }
    }
}
