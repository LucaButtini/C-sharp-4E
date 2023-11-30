using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Clinica
{
    internal class Reparto
    {
        string _nomeReparto;
        List<Paziente> pazienti;
        Termometro termometro;
        public Reparto(string nomeReparto)
        {
            string _nomeReparto;
            pazienti = new List<Paziente>();
            termometro = new Termometro();
        }
        public Reparto(string nomeReparto, int nPazienti)
        {
            _nomeReparto = nomeReparto;
            pazienti = new List<Paziente>(nPazienti);
            termometro = new Termometro();
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
            return pazienti.Find(p => p.GetNome() == nome && p.GetCognome() == cognome); //ritorna un paziente
        }

        public void ModificaTemperatura(string nome, string cognome, double temperatura)
        {
            Paziente pazienteRicercato = Ricerca(nome, cognome); //contiene l'indirizzo all'interno della lista dove è contenuta la persona

            if (pazienteRicercato != null)
            {
                termometro.CambiaTemperatura(temperatura);
                pazienteRicercato.SetTemperatura(termometro.GetTemperatura());//lo modifico proprio all'interno della lista, grazie all'indirizzo di memoria
            }
            else
            {
                //aggiungere sempre un eccezione alla classe 
                throw new Exception("Il paziente non è presente nella lista");
            }
        }
        public List<Paziente> GetLista()
        {
            List<Paziente> nuovaLista = new List<Paziente>();//nuovaLista contiene gli stessi dati dell'altra lista. Questa la porto fuori dalla classe e posso modificarla proteggendo i dati originali
            foreach (Paziente p in pazienti)
            {
                nuovaLista.Add(p);
            }
            return nuovaLista;
        }
        public void PazientiFebbre()
        {
            //visualizziamo i pazienti con la febbre
            foreach (Paziente p in pazienti)
            {
                if (p.GetTemperatura() > 36)
                    Console.WriteLine(p.Anagrafica());
            }
        }
    }
}
