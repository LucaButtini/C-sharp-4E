using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTrial
{
    internal class Class1 : Interface1, Interface2 //ereditarietà multipla, solo con interfaccie
    {
        string _name;
        public Class1(string name)
        {
            _name = name;
        }
        public string Nome
        {
            get { return _name; }
        }
        public string Metodo1()
        {
            return "metodo1 in classe1";
        }
        public int Metodo2(int num)
        {
            return num + 10;
        }
        public int Metodo3(int num)
        {
            return ++num;
        }
    }
}
