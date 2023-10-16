using System;
using System.Collections.Generic;

namespace ListAnagrafica
{
    enum Sesso
    {
        Maschio,
        Femmina
    }

    enum StatoCivile
    {
        Celibe,
        Nubile,
        Coniugato,
        Vedovo,
        Separato
    }

    struct Persona
    {
        public string Id; // Codice fiscale
        public string Cognome;
        public string Nome;
        public string Cittadinanza;
        public DateTime Nascita;
        public StatoCivile Stato;
        public Sesso Genere;

        public override string ToString()
        {
            return String.Format($"NOME: {Nome}, COGNOME: {Cognome}, CITTADINANZA: {Cittadinanza}, NASCITA: {Nascita}, ID: {Id}, GENERE: {Genere}, STATO CIVILE: {Stato}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Persona> Anagrafe = new List<Persona>
            {
                //assegno in maniera costante alla lista una persona
                new Persona { Id ="123", Cognome = "Z", Nome = "L", Cittadinanza = "ita", Nascita = DateTime.Parse("2005/12/18"), Stato = StatoCivile.Celibe, Genere = Sesso.Maschio }
            };
            Console.WriteLine(Anagrafe.Capacity);
            Console.WriteLine(Anagrafe.Count);
            Console.ReadLine();
        }
    }
}

