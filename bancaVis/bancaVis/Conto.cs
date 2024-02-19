using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banca
{
    class Conto
    {
        string _nome;
        string _cognome;
        double saldo;
        int _id;
        public Conto(int id, string nome, string cognome)
        {
            _nome = nome;
            _cognome = cognome;
            _id = id;
            saldo = 10;
        }

        public Conto() : this(1000, "Nessuno", "Nessuno")
        {

        }

        public int Identifica
        {
            get { return _id; }
        }

        public string Nome
        {
            get { return _nome; }
        }

        public string Cognome
        {
            get { return _cognome; }
        }

        public double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

        public override string ToString()
        {
            return string.Format($"ID conto: {Identifica} | Nome: {Nome} | Cognome: {Cognome} | Saldo: {Saldo}");
        }

        public bool Movimento(double mov)
        {

            if (Saldo + mov < 0)
            {
                return false;
            }
            else
            {
                Saldo += mov;
                return true;
            }
        }

    }
}
