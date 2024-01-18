using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_Ripasso
{
    enum NumeroPosti
    {
        Due, Quattro, Cinque, Otto
    }
    internal class Veicolo
    {
        string targa;
        //string marca;             //tolta perchè si usa prioprietà 
        string modello;
        NumeroPosti nPosti;
        int codice;
        //string[] possibiliPosti = Enum.GetNames(typeof(NumeroPosti));
        public Veicolo(string insMarca, string insModello, NumeroPosti insNPosti, string insTarga, int insCodice)
        {
            Marca = insMarca;
            Modello = insModello;
            nPosti = insNPosti;
            targa = insTarga;
            Codice = insCodice;
        }

        //proprietà automatica si usa quando non si devono fare controlli
        //presuppone il fatto che non posso cambiare la marca
        //*********************
        //decidiamo che il codice non può superare le 3 cifre.
        //Generiamo eccezione a livello costruttore. Devo dire che se il codice non è valido e non devo istanziare l'oggetto
        public string Marca
        {
            get; private set;
        }
        public string Modello
        {
            get { return modello; }
            set { modello = value; }
        }
        public NumeroPosti Posti
        {
            get { return nPosti; }
            set { nPosti = value; }
        }
        public string Targa
        {
            get { return targa; }
            set { targa = value; }
        }
        public int Codice
        {
            get { return codice; }
            set
            {

                if (codice > 999)
                {
                    throw new Exception("Troppi veicoli");
                }
                else
                {
                    codice = value;
                }
            }
        }
        public string GeneraTarga()
        {
            Random random = new Random();

            char lettera1 = Random(random);
            char lettera2 = Random(random);

            int numero1 = random.Next(10);
            int numero2 = random.Next(10);
            int numero3 = random.Next(10);

            char lettera3 = Random(random);
            char lettera4 = Random(random);

            targa = $"{lettera1}{lettera2}{numero1}{numero2}{numero3}{lettera3}{lettera4}";

            return targa;
        }
        static char Random(Random random)
        {
            const string alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int indice = random.Next(alfabeto.Length);
            return alfabeto[indice];
        }
        //public void MenuPosti()
        //{
        //    foreach (NumeroPosti s in possibiliPosti)
        //    {
        //        Console.WriteLine(s);
        //    }
        //}
        public override string ToString()
        {
            //supponiamo di non cambiare la marca e nella proprietò c'è solo il get
            return $"Marca: {Marca}, Modello: {Modello}, Posti: {nPosti}, Targa: {targa}, Codice: {Codice}\n";
        }
    }
}
