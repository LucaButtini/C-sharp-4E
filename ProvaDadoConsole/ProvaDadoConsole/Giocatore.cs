using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ProvaDadoConsole
{
    internal class Giocatore
    {
        string _nome;
        int _nVittorie;
        Dado _dado; //da vedere
        public Giocatore(string nome, Dado dado)
        {
            _nome = nome;
            _nVittorie = 0;
            _dado = dado;
        }
        public Dado DadoGiocatore { get { return _dado; } set { _dado = value; } }
        public string Nome { get => _nome; set => _nome = value; }

        public int NVittorie { get => _nVittorie; set => _nVittorie = value; }
        public string Scrivi()
        {
            return $"nome: {Nome}, vittorie: {NVittorie}";
        }
    }
}
