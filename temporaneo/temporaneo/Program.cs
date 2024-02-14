using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace temporaneo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            ConsoleKey tasto;
            ConsoleKeyInfo cambiaMatita;
            int riga = 0, colonna = 0;
            int x = 0, y = 0;
            int posizioneX, posizioneY;
            int maxWidth, maxHeight;
            maxWidth = Console.WindowWidth; //larghezza massima della finestra
            maxHeight = Console.WindowHeight; //altezza massima della finestra
            char matita = '.';
            char matita2 = ' ';
            bool fine = false;
            bool premuto = true;
            bool cancella = true;

            Console.SetCursorPosition(riga, colonna);
            Console.Write(matita);

            //xMax = 120
            //yMax = 30

            Console.SetCursorPosition(1, 29);
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < Console.WindowWidth - 2; i++)
            {
                Console.Write(" ");
            }

            Console.SetCursorPosition(10, 29);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"x: {x} y: {y}");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            do
            {
                tasto = Console.ReadKey(true).Key;
                switch (tasto)
                {
                    case ConsoleKey.Escape:
                        fine = true;

                        break;
                    case ConsoleKey.RightArrow:
                        if (colonna < maxWidth - 2)
                        {
                            colonna++;

                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (colonna < maxWidth - 2)
                        {
                            colonna--;
                        }

                        break;
                    case ConsoleKey.UpArrow:
                        if (colonna < maxWidth - 2)
                        {
                            riga--;

                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (riga < maxHeight)
                        {
                            riga++;
                        }

                        break;

                    case ConsoleKey.Insert:
                        premuto = !premuto;

                        break;
                    case ConsoleKey.Delete:
                        cancella = !cancella;
                        if (cancella)
                            matita = ' ';
                        else
                            matita = '.';

                        break;
                    case ConsoleKey.F1:
                        cambiaMatita = Console.ReadKey(true);
                        matita2 = cambiaMatita.KeyChar;
                        matita = matita2;
                        break;


                }

                Console.SetCursorPosition(colonna, riga);
                if (premuto)
                    Console.Write(matita);
                posizioneX = Console.CursorLeft;
                posizioneY = Console.CursorTop;


                Console.SetCursorPosition(10, 29);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("                              ");
                Console.SetCursorPosition(10, 29);
                Console.Write($"x: {posizioneX} y: {posizioneY}");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(posizioneX, posizioneY);
            } while (!fine);
        }
    }
}