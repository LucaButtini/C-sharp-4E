using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerVerErdPol2
{
    internal class Camion : Veicolo
    {
        string modello, marca;
        double cilindrata;
        double pesoCarico;
        public Camion(string modello, string marca, double cilindrata, double pesoCarico)
        {
            this.modello = modello;
            this.marca = marca;
            this.cilindrata = cilindrata;
            this.pesoCarico = pesoCarico;
        }
        public string Marca { get => marca; set => marca = value; }
        public string Modello { get => modello; set => modello = value; }
        public double Cilindrata { get => cilindrata; set => cilindrata = value; }
        public double PesoCarico { get => pesoCarico; set => pesoCarico = value; }

        public virtual string Stampa()
        {
            return String.Format($"Marca: {Marca}, Modello; {Modello}, Cilindrata: {Cilindrata}, Peso carico: {PesoCarico}");
        }
    }
}
