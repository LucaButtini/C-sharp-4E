using System;
using System.Collections.Generic;

namespace ClinicaRefactored
{
    internal class Reparto
    {
        private string _nomeReparto;
        private List<Paziente> pazienti;
        private Termometro termometro;
        private int _index;

        public Reparto(string nomeReparto)
        {
            _nomeReparto = nomeReparto;
            pazienti = new List<Paziente>();
            termometro = new Termometro();
        }

        public string GetNomeReparto()
        {
            return _nomeReparto;
        }

        public void AggiungiPaziente(Paziente p)
        {
            pazienti.Add(p);
        }

        public void StampaPazienti()
        {
            foreach (Paziente p in pazienti)
            {
                Console.WriteLine(p.Anagrafica());
            }
        }

        public Paziente Ricerca(string nome, string cognome)
        {
            return pazienti.Find(p => p.GetNome() == nome && p.GetCognome() == cognome);
        }

        public void ModificaTemperatura(string nome, string cognome, double temperatura)
        {
            Paziente pazienteRicercato = Ricerca(nome, cognome);

            if (pazienteRicercato != null)
            {
                termometro.CambiaTemperatura(temperatura);
                pazienteRicercato.SetTemperatura(termometro.GetTemperatura());
            }
            else
            {
                throw new Exception("Il paziente non è presente nella lista");
            }
        }

        public List<Paziente> GetLista()
        {
            List<Paziente> nuovaLista = new List<Paziente>(pazienti);
            return nuovaLista;
        }

        public void PazientiFebbre()
        {
            foreach (Paziente p in pazienti)
            {
                if (p.GetTemperatura() > 36)
                {
                    Console.WriteLine(p.Anagrafica());
                }
            }
        }
        public List<Paziente> Febbre()
        {
            List<Paziente> pf = pazienti.FindAll(p => p.GetTemperatura() > 36);
            return pf;
        }
        // Resetta l'indice dei pazienti a -1, posizionandolo all'inizio della lista.
        public void ResetPaziente()
        {
            _index = -1;
        }

        // Sposta l'indice dei pazienti al successivo e restituisce true se esiste un paziente successivo, altrimenti restituisce false.
        public bool MoveNext()
        {
            // Incrementa l'indice e verifica se è inferiore alla lunghezza della lista dei pazienti.
            return ++_index < pazienti.Count;
        }

        public bool MoveBefore()
        {
            return --_index < pazienti.Count;
        }
        // Restituisce il paziente corrente in base all'indice attuale.
        public Paziente PazienteCorrente()
        {
            if (_index >= 0 && _index < pazienti.Count)
            {
                // Se l'indice è valido, restituisce un nuovo  paziente con le informazioni del paziente corrente.
                return new Paziente(pazienti[_index].GetNome(), pazienti[_index].GetCognome(), pazienti[_index].GetTemperatura(), pazienti[_index].GetReparto());
            }
            else
            {
                // Se l'indice non è valido, restituisco null.
                return null;
            }
        }
    }
}
