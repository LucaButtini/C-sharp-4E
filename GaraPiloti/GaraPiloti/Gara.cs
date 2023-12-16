using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaraPiloti
{
    internal class Gara
    {
        string _nomeGara;
        int _numScuderia, _vincitore, _cont = 0;
        List<Auto> _grigliaPartenza;
        Random _random;

        public Gara(string nomeGara, int numScuderia)
        {
            _nomeGara = nomeGara;
            _numScuderia = numScuderia;
            _grigliaPartenza = new List<Auto>();
        }
        public Gara() 
        {
            _grigliaPartenza = new List<Auto>();
        }

        public void SetNomeGara(string nomeGara)
        {
            _nomeGara = nomeGara;
        }
        public void SetNumScuderia(int numScuderia)
        {
            _numScuderia = numScuderia;
        }
        public string GetNomeGara()
        {
            return _nomeGara;
        }
        public int GetNumScuderia()
        {
            return _numScuderia;
        }
        public void AddScuderia(Auto a)
        {
            _grigliaPartenza.Add(a);
        }
        public int NumPiloti()
        {
            return _grigliaPartenza.Count;
        }
        public void StampaGriglia()
        {
            Console.WriteLine("{0,-20} {1,-20} {2}", "NOME", "COGNOME", "SCUDERIA\n");
            _grigliaPartenza.ForEach(a => Console.WriteLine(a.StampaAuto()));
        }
        public void VincitoreGara()
        {
            Random _random = new Random();
            _vincitore = _random.Next(0, NumPiloti());
            Console.WriteLine("Il vincitore della gara è {0}", _grigliaPartenza[_vincitore].ToString());
        }

    }
}
