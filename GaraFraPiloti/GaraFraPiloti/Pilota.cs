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
        int _numeroGara; // numero di gara
        
        public Pilota(int numeroGara, string nome, string cognome)
        {
            _numeroGara = numeroGara;
            Nome = nome;
            Cognome = cognome;
        }
        public int NumeroGara
        {
            get { return _numeroGara; }
            set { _numeroGara = value; }
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
