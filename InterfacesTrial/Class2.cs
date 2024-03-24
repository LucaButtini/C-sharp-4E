using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTrial
{
    internal class Class2 : Interface1, Interface2
    {
        string _name;
        public Class2(string name)
        {
            _name = name;
        }
        public string Nome
        {
            get { return _name; }
        }
        public string Metodo1()
        {
            return "metodo1 in classe2";
        }
        public int Metodo2(int num)
        {
            return num + 100;
        }
        public int Metodo3(int num)
        {
            return num + 2;
        }
    }
}
