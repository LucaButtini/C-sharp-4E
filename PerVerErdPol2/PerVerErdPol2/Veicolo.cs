using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerVerErdPol2
{
    internal interface Veicolo
    {
        string Modello { get; }
        string Marca { get; }
        double Cilindrata { get; }
        string Stampa();

    }
}
