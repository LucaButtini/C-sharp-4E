using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaClasseButti
{
    internal class Studente
    {
        string nome;
        string cognome;
        byte media;


        public void SetNome(string nome)
        {
            this.nome = nome;
        }
        public void SetCognome(string cognome)
        {
            this.cognome = cognome;
        }
        public void SetMedia(byte media)
        {
            this.media = media;
        }
        public string GetNome()
        {
            return nome;
        }
        public byte GetMedia()
        {
            return media;
        }
        public string GetCognome()
        {
            return cognome;
        }
    }
}
