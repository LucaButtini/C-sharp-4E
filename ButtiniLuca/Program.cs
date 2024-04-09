using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtiniLuca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BUTTINI LUCA FILA B 9/4/2024
            Azienda azienda = new Azienda("Az 1", "citta 1", "ind 1");//istanzio azienda
            Cd cd = new Cd("titolo 1", "autore 1", 5, "s1", 3, "0001", 8, genere.classica);//istanzio cd
            Libro libro = new Libro("titolo 2", "autore 2", 4, "s2", 50, "isbn 2", 10, settore.storia);//istanzio libro
            //aggiungo articoli alla lista
            azienda.Aggiungi(cd);
            azienda.Aggiungi(libro);
            List<Articolo> listArticoli = azienda.GetLista(); //copia della lista per l'incapsualamento
            listArticoli.ForEach(a => { Console.WriteLine(a.Stampa()); }); //stampa della copia della lista
            Console.WriteLine("==========================");
            listArticoli.ForEach(a => { Console.WriteLine(a.StampaRapporto()); }); //stampo rapporto degli articoli
            Console.WriteLine("==========================");
            Articolo art = azienda.Trova("isbn 2");//trovo articolo per la vendita
            if (art != null)//controllo che articolo sia presente nella collezione
            {
                Console.WriteLine("articolo trovato");
                if (azienda.Vendita(art, 20)) //se presente effettuo una vendita controllando che la quantita sia sufficiente
                {
                    Console.WriteLine("vendita effettuata");
                    listArticoli = azienda.GetLista(); //aggiorno la lista
                    listArticoli.ForEach(a => { Console.WriteLine(a.Stampa()); }); //stampa lista dopo la vendita
                }
                else
                {
                    Console.WriteLine("quantita insufficiente");
                }
            }
            else
            {
                Console.WriteLine("non trovato");
            }
            Console.ReadLine();

        }
    }
}
