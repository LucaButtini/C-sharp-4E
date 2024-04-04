using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparazione_alla.verifica
{
    internal class ClasseDerivata11 : ClasseDerivata1
    {
        int numeroDerivata11;
        public ClasseDerivata11(int numeroBase, int numDer1, int numDer11 ) : base(numeroBase, numDer1)
        {
            numeroDerivata11 = numDer11;
        }
        public override string Stampa()
        {
            return String.Format($"{base.Stampa()}, Numero derivata 11: {numeroDerivata11}");
        }
    }
}
