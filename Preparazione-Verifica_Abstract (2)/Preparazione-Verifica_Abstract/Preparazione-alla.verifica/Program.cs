using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparazione_alla.verifica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<ClasseBase> lista = new List<ClasseBase>() 
            //{

            //   new ClasseDerivata1(5,8),
            //   new ClasseDerivata2(10,12),
            //   new ClasseDerivata2(10,12),
            //   new ClasseDerivata2(10,12),
            //   new ClasseDerivata2(10,12),
            //   new ClasseDerivata2(10,12),
            //   new ClasseDerivata2(10,12),
            //   new ClasseDerivata11(120,13,69),
            //};
            //lista.ForEach(a => { Console.WriteLine(a.Stampa() +" * "+ a.GetType().Name); }) ;
            //lista.ForEach(a => { if (a is ClasseDerivata2) { Console.WriteLine("Sono classe derivata 2"); } });
            //lista.ForEach(a => { if (a is ClasseDerivata1) { Console.WriteLine(((ClasseDerivata1)a).Saluti("Ciao")); } });


            /*ritorna ClasseBase*/
            List<ClasseBase> classeBase = new List<ClasseBase>();
            Contenitore contenitore = new Contenitore();
            classeBase = contenitore.MetodoRitornaLista();
            classeBase.ForEach(x => Console.WriteLine(x.Stampa()));

            /*ritorna Object*/
            //List<ClasseBase> classeBase = new List<ClasseBase>();
            //Contenitore contenitore = new Contenitore();
            //List<Object> listObject = new List<Object>();
            //listObject = contenitore.MetodoRitornaListaObject();
            //listObject.ForEach(x=>classeBase.Add((ClasseBase)x));
            //classeBase.ForEach(x => Console.WriteLine(x.Stampa()));
            Console.ReadLine();
        }
    }
}
