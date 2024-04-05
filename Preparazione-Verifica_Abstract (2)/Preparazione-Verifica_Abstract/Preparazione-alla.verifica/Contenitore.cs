using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparazione_alla.verifica
{
    internal class Contenitore:IRitornaLista
    {
        List<ClasseBase> lista = new List<ClasseBase>()
            {

               new ClasseDerivata1(5,8),
               new ClasseDerivata2(10,12),
               new ClasseDerivata2(20,13),
               new ClasseDerivata2(30,14),
               new ClasseDerivata2(40,15),
               new ClasseDerivata2(50,16),
               new ClasseDerivata2(60,18),
               new ClasseDerivata11(120,13,69),
            };
        public List<ClasseBase> MetodoRitornaLista()
            {
            return lista.ToList();
            }
        public List<Object> MetodoRitornaListaObject()
        {
            List<Object> NuovaLista = new List<Object>();
            lista.ForEach(n => NuovaLista.Add((Object)n));
            return NuovaLista;
        }
    }
}
