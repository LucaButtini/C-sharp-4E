using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaraPiloti
{
    internal class Pilota
    {
        string _nome, _cognome;

        public Pilota(string nome, string cognome)
        {
            _nome = nome;
            _cognome = cognome;
        }
        public void SetNome(string nome)
        {
            _nome = nome;
        }
        public void SetCognome(string cognome)
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

        public string StampaPilota()
        {
            return string.Format($"NOME: {GetNome()}, COGNOME: {GetCognome()}");
        }

    }
}
