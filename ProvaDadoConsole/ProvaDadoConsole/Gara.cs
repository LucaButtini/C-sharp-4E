using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaDadoConsole
{
    internal class Gara
    {
        Giocatore _g1, _g2;
        int numeroG1, numeroG2, numeroRound, _roundMax;
        bool _fineGara, _pari;
        string _winner;
        public Gara(Giocatore g1, Giocatore g2, int roundMax)
        {
            _g1 = g1;
            _g2 = g2;
            NumeroG1 = 0;
            NumeroG2 = 0;
            numeroRound = 0;
            RoundMax = roundMax;
            FineGara = false;
            Pari = false;
        }

        //--------------------------------------------------------
        public bool FineGara { get => _fineGara; set => _fineGara = value; }
        //-------------------------------------------------------

        public int NumeroG1 { get => numeroG1; private set => numeroG1 = value; }
        public int NumeroG2 { get => numeroG2; private set => numeroG2 = value; }
        public int NumeroRound { get => numeroRound; private set => numeroRound = value; }
        public int RoundMax { get => _roundMax; private set => _roundMax = value; }
        public bool Pari { get => _pari; private set => _pari = value; }
        public string Winner { get => _winner; private set => _winner = value; }

        public void Round()//esegue un round della partita
        {

            if (_g1.DadoGiocatore > _g2.DadoGiocatore)
            {
                _g1.NVittorie++;
            }
            else if (_g1.DadoGiocatore < _g2.DadoGiocatore)
            {
                _g2.NVittorie++;
            }
            else if (_g1.DadoGiocatore == _g2.DadoGiocatore)
            {
                _g1.NVittorie++;
                _g2.NVittorie++;
            }
            numeroRound++;
            if (NumeroRound == RoundMax)
            {
                FineGara = true;
            }
            Console.WriteLine(_g1.DadoGiocatore.FacciaDado);
            Console.WriteLine(_g2.DadoGiocatore.FacciaDado);
            Console.WriteLine();
            Console.WriteLine(_g1.NVittorie);
            Console.WriteLine(_g2.NVittorie);
            Console.WriteLine();
            GameWin();
            Console.WriteLine(Winner);
        }
        private void GameWin()// se la partita è finita determina il vincitore o la condizione di parità
        {
            //cambiamo i controlli
            if (FineGara)
            {
                if (_g1.NVittorie > _g2.NVittorie)
                {
                    Winner = $"Vincitore: {_g1.Nome}, Stato Partita: Terminata";
                }
                else if (_g1.NVittorie < _g2.NVittorie)
                {
                    Winner = $"Vincitore: {_g2.Nome}, Stato Partita: Terminata";
                }
                else if (_g1.NVittorie == _g2.NVittorie)
                {
                    Winner = "Non ci sono vincitori";
                }
            }
            else
            {
                Winner = "Partita ancora in corso";
            }


        }
        public void ResetGame()// resetta la partita
        {//da vedere in visuale 
            _g1.NVittorie = 0;
            _g2.NVittorie = 0;
            numeroRound = 0;
        }
    }
}
