using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ip
{
    struct ip
    {
        public string decimale;
        public string binario;
        public string hex;
        public override string ToString()
        {
            return string.Format($"ip: {decimale}, b: {binario}, hex: {hex}");
        }
    }

    internal class Program
    {
        //INIZIO
        static void Main(string[] args)
        {
            //DICHIARAZIONE DELLE VARIABILI
            string ip;
            string[] ottetti;
            ip indirizzo;
            int Base;
            bool nValido;
            Console.WriteLine("Inserire l'ip in formato decimale:");
            //indirizzo.decimale = "192.168.56.1";
            //indirizzo = new ip() { decimale = "255.255.255.255", binario = "11111111.11111111.11111111.11111111", hex = "FF.FF.FF.FF" };
            indirizzo = new ip() { decimale = "192.168.56.1", binario = "11111111.11111111.11111111.11111111", hex = "FF.FF.FF.FF" };

            Console.WriteLine("===PRIMO METODO===");
            Console.WriteLine(ConvertiBase(127, 2));
            Console.WriteLine();
            Console.WriteLine("In che base vuoi convertire?");
            Base = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("===SECONDO METODO===");
            Console.WriteLine(ConvertiIp(indirizzo, Base));
            Console.ReadLine();

        }

        //METODO CHE EFFETTUA LA CONVERSIONE IN BINARIO
        static string ConvertiBase(int valore, int Base)
        {
            int resto, pesoCifra = 0, lunghBin = 8, aggiungiZeri = 0;

            string valoreConvertito = "";
            do
            {
                resto = valore % Base;
                valore = valore / Base;

                if (resto >= 10)
                {
                    switch (resto)
                    {
                        case 10:
                            valoreConvertito += 'A';
                            break;

                        case 11:
                            valoreConvertito += 'B';
                            break;

                        case 12:
                            valoreConvertito += 'C';
                            break;

                        case 13:
                            valoreConvertito += 'D';
                            break;

                        case 14:
                            valoreConvertito += 'E';
                            break;

                        case 15:
                            valoreConvertito += 'F';
                            break;
                    }
                }

                else
                {
                    valoreConvertito = resto + valoreConvertito;
                }



            } while (valore != 0);

            if (Base != 16)
            {

                if (valoreConvertito.Length < lunghBin)
                {
                    aggiungiZeri = lunghBin - valoreConvertito.Length;
                    for (int i = 0; i < aggiungiZeri; i++)
                    {
                        valoreConvertito = '0' + valoreConvertito;
                    }
                }
            }
            else if (valoreConvertito.Length < 2)
            {
                valoreConvertito = '0' + valoreConvertito;
            }

            return valoreConvertito;
        }
        static string ConvertiIp(ip indirizzo, int Base)
        {
            string[] ottetiDec = indirizzo.decimale.Split('.'); // divido negli otteti
            string[] ottetiBin = new string[4];
            string ipBin;
            int octect;
            for (int i = 0; i < 4; i++)
            {
                octect = int.Parse(ottetiDec[i]);
                ottetiBin[i] = ConvertiBase(octect, Base); // Converte in binario
            }
            ipBin = string.Join(".", ottetiBin); //unisco gli ottetti convertiti
            return ipBin;
        }
    }
}