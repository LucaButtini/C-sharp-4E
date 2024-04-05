using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparazione_alla.verifica
{
    internal class ClasseDerivata1 : ClasseBase,Interface1
    {
        int numeroDerivata1;
        public ClasseDerivata1(int numeroBase, int numDer) : base (numeroBase)
        {
            numeroDerivata1 = numDer;
        }
        public override string Stampa()
        {
            return String.Format($"Numero base: {NumeroBase}, Numero derivata 1: {numeroDerivata1}");
        }
        public string Saluti(string s)
        {
            return String.Format($"Messaggio da {this.GetType().Name}: {s}");
        }
    }
}
