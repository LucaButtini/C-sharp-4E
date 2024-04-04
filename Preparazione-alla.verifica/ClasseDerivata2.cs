using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparazione_alla.verifica
{
    internal class ClasseDerivata2 : ClasseBase
    {
        int numeroDerivata2;
        public ClasseDerivata2(int numeroBase, int numDer) : base(numeroBase)
        {
            numeroDerivata2 = numDer;
        }
        public override string Stampa()
        {
            return String.Format($"{base.Stampa()}, Numero derivata 2: {numeroDerivata2}");
        }
    }
}
