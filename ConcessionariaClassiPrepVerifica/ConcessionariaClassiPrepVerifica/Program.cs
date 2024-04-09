using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaClassiPrepVerifica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Concessionaria c = new Concessionaria();
            Moto m1 = new Moto("a", "a", 4, 54.3, 4, true);
            Moto m2 = new Moto("b", "b", 2, 51, 2, false);
            Auto a1 = new Auto("c", "c", 6, 25, 8, 5);
            Auto a2 = new Auto("d", "d", 43, 24, 18, 15);
            Auto a3 = new Auto("d", "d", 43, 24, 18, 15);
            Auto a4 = new Auto("d", "d", 43, 24, 18, 15);
            Auto a5 = new Auto("d", "d", 43, 24, 18, 15);
            Auto a6 = new Auto("d", "d", 43, 24, 18, 15);
            m1.Targa("dsadasd");
            m2.Targa("dsadasd");
            c.Aggiungi(m1);
            c.Aggiungi(m2);
            c.Aggiungi(a1);
            c.Aggiungi(a2);
            c.Aggiungi(a3);
            c.Aggiungi(a4);
            c.Aggiungi(a5);
            c.Aggiungi(a6);
            List<Veicolo> list = c.GetLista(); //rispetto incapsulamento
            list.ForEach(v => { Console.WriteLine(v.Stampa()); });
            Console.WriteLine("================================");
            list.ForEach(v => { if (v is Moto) { Console.WriteLine(((Moto)v).Targa("vise")); } });
            Console.WriteLine("================================");
            Console.WriteLine("Inserisci marca");
            string ma = Console.ReadLine();
            Console.WriteLine("Inserisci modello");
            string mo = Console.ReadLine();
            if (c.Cancella(ma, mo) == 0)
            {
                Console.WriteLine("ELEMENTO NON PRESENTE");
            }
            else
            {
                Console.WriteLine("ELIMINAZIONE AVVENUTA");
            }
            list = c.GetLista();
            list.ForEach(v => { Console.WriteLine(v.Stampa()); });
            Console.ReadLine();
        }
    }
}
