using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerVerificaClassi
{
    internal class Lavoratore
    {
        string nome, cognome;
        int matricola;
        string codiceAziendale;
        azioni azione;
        public Lavoratore(string insNome, string insCognome, string insCodice, azioni insAzione)
        {
            Nome = insNome;
            Cognome = insCognome;
            azione = insAzione;
            matricola = BellinazziCo.Matricola;
            codiceAziendale = insCodice;
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Cognome

        {
            get { return cognome; }
            set { cognome = value; }

        }
        public azioni Azione
        {
            get { return azione; }
            set { azione = value; }
        }
        public string CodiceAziendale
        {
            get { return codiceAziendale; }
            set { codiceAziendale = value; }
        }
        public int Matricola
        {
            get { return matricola; }
            set
            {
                if (matricola > 3)
                {
                    throw new Exception("TROPPI ELEMENTI NELLA LISTA");
                }
                else
                {
                    matricola = value;

                }

            }
        }

        public override string ToString()
        {
            return string.Format($"CODICE: {CodiceAziendale}, MATRICOLA: {Matricola}, NOME: {Nome}, COGNOME: {Cognome},  AZIONE: {Azione}");
        }
    }
}