using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparazione_alla.verifica
{
    internal abstract class ClasseBase
    {
        int numeroBase;
        protected ClasseBase(int numero) 
        {
            numeroBase = numero;
        }

        protected int NumeroBase { get => numeroBase; set => numeroBase = value; }

        public abstract string Stampa();

       
    }
}
