using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PostVerListeStudenti
{
    internal class Program
    {
        struct Studente
        {
            public string nome;
            public string cognome;
            public int voto;
            public DateTime nascita;
            public override string ToString()
            {
                return String.Format($"nome: {nome}, cognome: {cognome},voto: {voto} nascita: {nascita}");
            }
        }
        static void Main(string[] args)
        {
            List<Studente> classe = new List<Studente>();
            List<Studente> StMaggiorenni = new List<Studente>();
            int opzione;
            do
            {
                string[] options = { "Inserimento", "Visualizzazione", "Visualizzazione maggiorenni", "Cancella Alunno", "Scrivi CSV", "Importa CSV", "Esci" };

                Console.WriteLine("Scegli un'opzione:");
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"[{i + 1}] {options[i]}");
                }

                int.TryParse(Console.ReadLine(), out opzione);
                if (opzione != 7)
                {
                    Menu(opzione, classe, StMaggiorenni);
                }
                else
                {
                    Console.WriteLine("Programma finito");
                }
                Console.WriteLine("Premi invio per proseguire");
                Console.ReadLine();
                Console.Clear();
            } while (opzione != 7);
        }

        static void Menu(int opzione, List<Studente> classe, List<Studente> StMaggiorenni)
        {
            switch (opzione)
            {
                case 1:
                    Inserimento(classe);
                    break;
                case 2:
                    Visualizza(classe);
                    break;
                case 3:
                    Maggiorenni(classe, StMaggiorenni);
                    break;
                case 4:
                    CancellaStudente(classe);
                    break;
                case 5:
                    ScriviCSV(classe);
                    break;
                case 6:
                    ImportaCSV(classe);
                    break;
                case 7:
                    Console.WriteLine("Programma finito");
                    break;
                default:
                    Console.WriteLine("Opzione non valida. Reinserire l'opzione.");
                    break;
            }
        }
        static int GetVoto()
        {
            bool checkVoto = false;
            int voto = 0, inputVoto;
            while (!checkVoto)
            {
                Console.WriteLine("Inserisci il voto (0-10)");
                string input = Console.ReadLine();
                try
                {
                    inputVoto = Convert.ToInt32(input);
                    if (inputVoto >= 0 && inputVoto <= 10)
                    {
                        voto = inputVoto;
                        checkVoto = true;
                    }
                    else
                    {
                        Console.WriteLine("Il voto deve essere compreso fra 0 e 10");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato errato o valore non valido. Reinserire (0-10) come numero intero.");
                }
            }
            return voto;
        }
        static void ScriviCSV(List<Studente> classe)
        {
            try
            {
                using (StreamWriter csv = new StreamWriter(Environment.CurrentDirectory + @"\logbin\logfile.csv", false))
                {
                    foreach (Studente st in classe)
                    {
                        string strCsv = string.Format($"{st.cognome},{st.nome},{st.nascita.ToString("dd/MM/yyyy")},{st.voto}");
                        csv.WriteLine(strCsv);
                    }
                }
                Console.WriteLine("Scrittura del file CSV avvenuta con successo.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Errore durante la scrittura del file CSV: {e.Message}");
            }
        }



        static void ImportaCSV(List<Studente> classe)
        {
            try
            {
                using (StreamReader csvRV = new StreamReader(Environment.CurrentDirectory + @"\logbin\logfile.csv"))
                {
                    string strCsvRV;
                    while ((strCsvRV = csvRV.ReadLine()) != null)
                    {
                        Studente stud = new Studente();
                        string[] arrCsv = strCsvRV.Split(',');
                        stud.cognome = arrCsv[0];
                        stud.nome = arrCsv[1];
                        stud.nascita = DateTime.ParseExact(arrCsv[2], "dd/MM/yyyy", null);
                        stud.voto = int.Parse(arrCsv[3]);
                        classe.Add(stud);
                    }
                }
                Console.WriteLine("Importazione da file CSV avvenuta con successo.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Errore durante l'importazione da file CSV: {e.Message}");
            }
        }

        static void CancellaStudente(List<Studente> classe)
        {
            string n, cn;
            int index = -1;
            Console.WriteLine("Inserisci il nome dello studente da cancellare:");
            n = Console.ReadLine();

            Console.WriteLine("Inserisci il cognome dello studente da cancellare:");
            cn = Console.ReadLine();

            for (int i = 0; i < classe.Count; i++)
            {
                if (classe[i].nome == n && classe[i].cognome == cn)
                {
                    index = i;
                }
            }

            if (index != -1)
            {
                classe.RemoveAt(index);
                Console.WriteLine($"Studente {n} {cn} cancellato con successo.");
            }
            else
            {
                Console.WriteLine($"Studente {n} {cn} non trovato nella lista.");
            }
        }

        static DateTime CheckData()
        {
            bool checkDate = false;
            DateTime dataNascita = DateTime.MinValue; //MinValue val più piccolo

            while (!checkDate)
            {
                try
                {
                    Console.WriteLine("Inserisci data di nascita (formato: dd/mm/yyyy): ");
                    dataNascita = DateTime.Parse(Console.ReadLine());
                    checkDate = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato data non valido. Inserisci nel formato corretto (dd/mm/yyyy).");
                }
            }

            return dataNascita;
        }
        static void Inserimento(List<Studente> classe)
        {
            bool checkDate;
            Studente studente = new Studente();
            string nome = "", cognome = "";
            Console.WriteLine("Inserisci nome");
            nome = Console.ReadLine();
            Console.WriteLine("Inserisci cognome");
            cognome = Console.ReadLine();
            while (CheckAlunno(nome, cognome, classe))
            {
                Console.WriteLine("Alunno già presente reinserire");
                Console.WriteLine("Inserisci nome");
                nome = Console.ReadLine();
                Console.WriteLine("Inserisci cognome");
                cognome = Console.ReadLine();
            }
            studente.nome = nome;
            studente.cognome = cognome;
            studente.voto = GetVoto();
            checkDate = false;
            while (!checkDate)
            {
                studente.nascita = CheckData();
                checkDate = true;
            }
            classe.Add(studente);
        }
        static void Visualizza(List<Studente> output)
        {
            for (int i = 0; i < output.Count; i++)
            {
                Console.WriteLine($"Alunno {i + 1}");
                Console.WriteLine(output[i]);
                Console.WriteLine();
            }
        }

        static bool CheckAlunno(string nome, string cognome, List<Studente> classe)
        {
            //find ritorna la prima occorrenza che soddisfa la condizione.
            //find passa il risultato a contains che controlla se è presente nella lista
            return classe.Contains(classe.Find(st => st.nome == nome && st.cognome == cognome));
        }

        static void Maggiorenni(List<Studente> classe, List<Studente> StMaggiorenni)
        {
            DateTime oggi = DateTime.Now;
            StMaggiorenni = classe.FindAll(p => (oggi - p.nascita).TotalDays >= 18 * 365.25); // 365.25 giorni all'anno per tener conto degli anni bisestili
            Console.WriteLine("Studenti maggiorenni:");
            Visualizza(StMaggiorenni);
        }
    }
}