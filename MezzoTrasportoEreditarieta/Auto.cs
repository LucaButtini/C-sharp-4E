using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezzoTrasportoEreditarieta
{
    internal class Auto : MezzoTrasporto
    {
        string categoriaInquinamento;
        int numPorte;

        public Auto(string categoriaInquinamento, int numPorte, int numPosti) : base(numPosti)
        {
            CategoriaInquinamento = categoriaInquinamento;
            NumPorte = numPorte;
        }

        public string CategoriaInquinamento { get => categoriaInquinamento; private set => categoriaInquinamento = value; }
        public int NumPorte { get => numPorte; private set => numPorte = value; }

        new public void MetodoQualsiasi()

        {
            base.MetodoQualsiasi();
            Console.WriteLine($"Sono metodo qualsiasi di auto e la mia categoria è: {CategoriaInquinamento}, il numero di porte è: {NumPorte}");
        }

        public static bool operator ==(Auto a, Auto b)
        {
            return (a.numPorte == b.numPorte && String.Equals(a.categoriaInquinamento, b.categoriaInquinamento));
        }

        public static bool operator !=(Auto a, Auto b)
        {
            return !(a == b);
        }

        public static bool operator >(Auto a, Auto b)
        {
            return (a.numPorte > b.numPorte);
        }

        public static bool operator <(Auto a, Auto b)
        {
            return (a.numPorte < b.numPorte);
        }
    }
}
