using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProvaClass
{
    internal class Studente
    {
        string nome, cognome;
        int media;
        Attivita action;

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
        public void SetAction(Attivita action)
        {
            this.action = action;
        }
        public Attivita GetAction()
        {
            return this.action;
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
