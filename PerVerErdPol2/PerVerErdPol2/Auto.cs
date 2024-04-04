using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PerVerErdPol2
{
    internal class Auto : Veicolo
    {
        string modello, marca;
        double cilindrata;
        public Auto(string modello, string marca, double cilindrata)
        {
            this.modello = modello;
            this.marca = marca;
            this.cilindrata = cilindrata;
        }
        public string Marca { get => marca; set => marca = value; }
        public string Modello { get => modello; set => modello = value; }
        public double Cilindrata { get => cilindrata; set => cilindrata = value; }
        public virtual string Stampa()
        {
            return String.Format($"Marca: {Marca}, Modello; {Modello}, Cilindrata: {Cilindrata}");
        }
    }
}