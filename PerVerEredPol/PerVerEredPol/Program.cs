using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerVerEredPol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<RisorsaBibliotecaria> webLibrary = new List<RisorsaBibliotecaria>();
            Libro libro = new Libro("harry potter", "luciano", 40.2);
            EBook eBook = new EBook("harry potter ebook", "frabco", 43.2);
            Audiolibro audiolibro = new Audiolibro("harry potter audio", "jerry", 21.65);
            webLibrary.Add(libro);
            webLibrary.Add(eBook);
            webLibrary.Add(audiolibro);
            webLibrary.ForEach(l => { Console.WriteLine(l.CalcolaCosto()); });
            Console.ReadLine();
        }
    }
}
