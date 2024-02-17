using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioOverloadCostruttore
{
    internal class Disciplina
    {
        string _nome;
        int _ore;
        double _mediaStudenti;
        bool _laboratorio;

        public Disciplina(string nome, int ore, double mediaStudenti, bool laboratorio)
        {
            _nome = nome;
            _ore = ore;
            _mediaStudenti = mediaStudenti;
            _laboratorio = laboratorio;
        }
        public Disciplina(string nome, int ore, bool laboratorio): this(nome, ore, 0, laboratorio)
        {
        }
        public Disciplina(int ore): this("", ore, 0, false)
        {
        }
    }
}
