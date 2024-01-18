using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Es_Ripasso
{
    internal class Flotta
    {
        List<Veicolo> parcoVeicoli;
        List<string> logData;
        string nome;
        string autorizzazione;
        public Flotta(string insNome, string insAutorizzazione)
        {
            parcoVeicoli = new List<Veicolo>();
            logData = new List<string>();
            nome = insNome;
            autorizzazione = insAutorizzazione;
        }
        public void InserimentoVeicoli(Veicolo V)
        {
            parcoVeicoli.Add(V);
        }
        public int LungLista()
        {
            return parcoVeicoli.Count;
        }
        public void Stampa()
        {
            parcoVeicoli.ForEach(v => Console.WriteLine(v.ToString()));
        }
        public void Elimina(string elimina)
        {
            Veicolo veicoloDaEliminare = parcoVeicoli.Find(v => v.Targa == elimina || v.Codice == Convert.ToInt32(elimina));
            if (veicoloDaEliminare != null)
            {
                parcoVeicoli.Remove(veicoloDaEliminare);
                Console.WriteLine($"Veicolo con targa/codice {elimina} eliminato dalla lista.\n");
            }
            else
            {
                Console.WriteLine("Hai inserito il codice o la targa sbagliati\n");
            }
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Autorizzazione
        {
            get { return autorizzazione; }
            set { autorizzazione = value; }
        }
        public List<Veicolo> GetLista()
        {
            List<Veicolo> copiaParcoVeicoli = new List<Veicolo>(parcoVeicoli);//incapsulamento, i dati rimangono protetti
            return copiaParcoVeicoli;
        }
        public void FileTesto()
        {
            StreamWriter sw = File.AppendText(GetFilePathWithDate());
            try
            {
                foreach (Veicolo v in parcoVeicoli)
                {
                    sw.WriteLine(v.ToString());
                }
                foreach (string logEntry in logData)
                {
                    sw.WriteLine(logEntry);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore durante il salvataggio dei dati: \n" + ex.Message);
            }
            sw.Close();
        }
        static string GetFilePathWithDate()
        {
            DateTime dataoggi = DateTime.Now;
            string formattedDate = dataoggi.ToString("dd-MM-yyyy");
            return formattedDate + ".txt";
        }
        public string GeneraCodice()
        {
            Random rand = new Random();

            char lettera = Random(rand);

            int numero1 = rand.Next(10);
            int numero2 = rand.Next(10);
            int numero3 = rand.Next(10);
            int numero4 = rand.Next(10);

            autorizzazione = $"{numero1}{numero2}{numero3}{numero4}{lettera}";

            return autorizzazione;
        }
        static char Random(Random random)
        {
            const string alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int indice = random.Next(alfabeto.Length);
            return alfabeto[indice];
        }
        public void VisualizzaInformazioni(string informazioni)
        {
            Veicolo veicolo = parcoVeicoli.Find(v => v.Targa == informazioni || v.Codice == Convert.ToInt32(informazioni));
            if (veicolo != null)
            {
                Console.WriteLine(veicolo);
            }
            else
            {
                Console.WriteLine("Hai inserito il codice o la targa sbagliati\n");
            }
        }
        //public int Ricerca(string nPosti)
        //{
        //    int count = 0;
        //    foreach (Veicolo V in parcoVeicoli)
        //    {
        //        if (V.Posti == nPosti)
        //        {
        //            count++;
        //        }
        //    }
        //    return count;
        //}
        public int Inventario(string marca)
        {
            int count = 0;

            foreach (Veicolo V in parcoVeicoli)
            {
                if (V.Marca == marca)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
