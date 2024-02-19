using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BancaVerificaRifatta
{
    internal class ContoCorrente
    {
        int id;
        string _nome, _cognome;
        double _saldo;

        public ContoCorrente(string nome, string cognome)
        {
            id = Banca.IdConto;
            Saldo = 10;
            Nome = nome;
            Cognome = cognome;
        }
        public int Id { get { return id; } }
        public string Nome { get => _nome; private set => _nome = value; }
        public string Cognome { get => _cognome; private set => _cognome = value; }
        public double Saldo { get => _saldo;  set => _saldo = value; }

        public override string ToString()
        {
            return string.Format($"ID: {Id}, NOME: {Nome}, COGNOME: {Cognome}, SALDO: {Saldo}");
        }
    }
}
