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
            Nome = nome;
            Cognome = cognome;
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public string Cognome
        {
            get { return _cognome; }
            set { _cognome = value; }
        }
        public string Stampa()
        {
            return string.Format($"COGNOME: [{Cognome}], NOME: [{Nome}]");
        }
    }
}
