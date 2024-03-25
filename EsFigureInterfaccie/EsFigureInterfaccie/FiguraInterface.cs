using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsFigureInterfaccie
{
    internal interface FiguraInterface
    {
        double Base { get; }
        double Altezza { get; }
        double CalcoloArea();
        double CalcoloPerimetro();
    }
}
