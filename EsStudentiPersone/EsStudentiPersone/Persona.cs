using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsStudentiPersone
{
    internal class Persona
    {
        string _nome, _cognome;
        public Persona(string nome, string cognome)
        {
            Nome = nome;
            Cognome = cognome;
        }
        public string Nome { get => _nome; private set => _nome = value; }
        public string Cognome { get => _cognome; private set => _cognome = value; }
        public override string ToString()
        {
            return string.Format("Nome: {0}, Cognome: {1}", Nome, Cognome);
        }
        public static bool operator ==(Persona a, Persona b)
        {
            return a._nome == b._nome && a._cognome == b._cognome;
        }
        static public bool operator !=(Persona a, Persona b)
        {
            return !(a == b);
        }
    }
}
