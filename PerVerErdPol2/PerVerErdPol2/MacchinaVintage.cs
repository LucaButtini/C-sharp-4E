using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerVerErdPol2
{
    internal class MacchinaVintage : Auto
    {
        string kingVintage;
        public MacchinaVintage(string modello, string marca, double cilindrata, string kingVintage) : base(modello, marca, cilindrata)
        {
            this.kingVintage = kingVintage;
        }
        public string KingVintage { get => kingVintage; set => kingVintage = value; }

        public override string Stampa()
        {
            return String.Format($"{base.Stampa()}, kingVintage: {KingVintage}");
        }
    }
}
