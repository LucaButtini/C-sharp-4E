using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica
{
    internal class Reparto
    {
        string _nomeReparto;
        List<Paziente> Pazienti;
        Termometro termometro;
        public Reparto(string nomeReparto)
        {
            string _nomeReparto;
            Pazienti = new List<Paziente>();
            termometro = new Termometro();
        }
        public Reparto(string nomeReparto, int nPazienti)
        {
            _nomeReparto = nomeReparto;
            Pazienti = new List<Paziente>(nPazienti);
            termometro = new Termometro();
        }
        public void AggiungiPaziente(Paziente p)
        {
            Pazienti.Add(p);
        }
        public void StampaPazienti()
        {
            foreach (Paziente p in Pazienti)
            {
                Console.WriteLine(p.Anagrafica());
            }
        }
        public void CambiaTempRep(Paziente p)
        {
            // Reimposta la temperatura del termometro prima di misurare quella del paziente
            termometro.ResetTemperatura();

            // Cambia la temperatura del termometro di +2 gradi
            termometro.CambiaTemperatura(+2);

            // Assegna la temperatura misurata al paziente
            p.SetTemperatura(termometro.GetTemperatura());
        }
    }
}