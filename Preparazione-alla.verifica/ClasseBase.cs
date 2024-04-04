using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparazione_alla.verifica
{
    internal class ClasseBase
    {
        int numeroBase;
        public ClasseBase(int numero) {
            numeroBase = numero;
        }
        public virtual string Stampa()
        {
            return String.Format($"numero base: {numeroBase}");
        }
    }
}
