using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaClass
{
    internal class Studente
    {
        string nome, cognome;
        int media;

        public void SetName(string nome)
        {
            this.nome = nome;
        }

        public void SetCognome(string cognome)
        {
            this.cognome = cognome;
        }
        public void SetMedia(int media)
        {
            this.media = media;
        }
        public string GetName()
        {
            return this.nome;
        }

        public string GetCognome()
        {
            return this.cognome;
        }

        public int GetMedia()
        {
            return this.media;
        }
    }
}
