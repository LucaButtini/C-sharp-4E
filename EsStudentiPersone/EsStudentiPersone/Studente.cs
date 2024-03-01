using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsStudentiPersone
{
    internal class Studente : Persona
    {
        int _matricola;
        Random random = new Random();
        public Studente(string nome, string cognome) : base(nome, cognome)
        {
            Matricola = random.Next(1, 100); //uso random per la matricola
        }
        public int Matricola { get => _matricola; private set => _matricola = value; }
        public override string ToString()
        {
            return string.Format("Matricola: {0}, Nome: {1}, Cognome: {2}", Matricola, Nome, Cognome);
        }
    }
}
