using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoSpazio
{
    internal class Punto
    {
        int maxWidth, maxHeight, riga, colonna;
        int posizioneX, posizioneY;
        char disegna;
        ConsoleKey tasto;
        bool premuto;
        public Punto(int maxWidth, int maxHeight, int riga, int colonna, char disegna)
        {
            MaxWidth = maxWidth;
            MaxHeight = maxHeight;
            Riga = riga;
            Colonna = colonna;
            Disegna = disegna;
            premuto = true;
        }

        public int MaxHeight { get => maxHeight; set => maxHeight = value; }
        public int MaxWidth { get => maxWidth; set => maxWidth = value; }
        public int Riga { get => riga; set => riga = value; }
        public int Colonna { get => colonna; set => colonna = value; }
        public char Disegna { get => disegna; set => disegna = value; }
        public int PosizioneX { get => posizioneX; set => posizioneX = value; }
        public int PosizioneY { get => posizioneY; set => posizioneY = value; }

        public void SetPunto()
        {
            Console.SetCursorPosition(Riga, Colonna);
            Console.Write(Disegna);

            Console.SetCursorPosition(Colonna, Riga);
            if (premuto)
                Console.Write(Disegna);
            PosizioneX = Console.CursorLeft;
            posizioneY = Console.CursorTop;
        }
    }
}
