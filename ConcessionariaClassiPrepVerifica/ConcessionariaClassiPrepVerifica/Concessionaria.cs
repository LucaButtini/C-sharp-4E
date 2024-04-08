using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaClassiPrepVerifica
{
    internal class Concessionaria
    {
        List<Veicolo> autonoleggio;
        public Concessionaria()
        {
            autonoleggio = new List<Veicolo>();
        }
        public void Aggiungi(Veicolo v)
        {
            autonoleggio.Add(v);
        }
        public List<Veicolo> GetLista()
        {
            return autonoleggio.ToList();
        }
        //public void Cancella(int index)
        //{
        //    autonoleggio.RemoveAt(index);
        //}
        public int Cancella(string marca, string modello)
        {
            return autonoleggio.RemoveAll(v => v.Modello == modello || v.Marca == marca);
        }
    }
}
