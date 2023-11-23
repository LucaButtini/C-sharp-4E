using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooDiCasaMia
{
    internal class AnimaleDomestico
    {
        string specie;
        string razza;
        string cibo;
        int quantita;
        string verso;
        Mangiato mangiato;
        public void SetSpecie(string specie)
        {
            this.specie = specie;
        }
        public void SetRazza(string razza)
        {
            this.razza = razza;
        }
        public void SetCibo(string cibo)
        {
            this.cibo = cibo;
        }
        public void SetQuantita(int quantita)
        {
            this.quantita = quantita;
        }
        public void SetVerso(string verso)
        {
            this.verso = verso;
        }
        public void SetMangiato(Mangiato mangiato)
        {
            this.mangiato = mangiato;
        }
        public string GetSpecie()
        {
            return this.specie;
        }

        public string GetRazza()
        {
            return this.razza;
        }

        public string GetCibo()
        {
            return this.cibo;
        }

        public int GetQuantita()
        {
            return this.quantita;
        }

        public string GetVerso()
        {
            return this.verso;
        }

        public Mangiato GetMangiato()
        {
            return this.mangiato;
        }
        public bool DeveMangiare()
        {
            return GetMangiato() == Mangiato.deve_mangiare && GetQuantita() >= 0; //controllo che la quantità di cibo sia superiore a zero
                                                                                  //e che l'animale e che l'oggetto abbia deve mangiare come stato
        }
    }
}
