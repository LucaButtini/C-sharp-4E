using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparazione_alla.verifica
{
    internal interface IRitornaLista
    {
        List<ClasseBase> MetodoRitornaLista();
        List<Object> MetodoRitornaListaObject();
    }
}
