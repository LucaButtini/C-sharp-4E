using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bancaVis
{
    class Conto
    {
        string _nome;
        string _cognome;
        double saldo;
        int _id;
        public Conto(int id, string nome, string cognome)
        {
            _id = id;
            _nome = nome;
            _cognome = cognome;
            saldo = 10;
        }

        //public Conto() : this(1000, "Nessuno", "Nessuno")
        //{

        //}

        public int ID
        {
            get { return Id; }
            set { Id = value; }
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

        public int Id { get => _id; set => _id = value; }

        public override string ToString()
        {
            return string.Format($"ID conto: {_id} | Nome: {Nome} | Cognome: {Cognome} | Saldo: {Saldo}");
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
