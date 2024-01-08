using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RipassoInItinere
{
    internal class Targa
    {
        string ta;
        public string Ta
        {
            get { return ta; }
            set { ta = value; }
        }
        //public string GeneraTarga()
        //{
        //    Random random = new Random();
        //    int r;
        //    string targa = "";

        //    for (int i = 0; i < 2; i++)
        //    {
        //        r = random.Next(65, 91);
        //        targa += Convert.ToChar(r);
        //    }

        //    r = random.Next(100, 1000);
        //    targa += Convert.ToString(r);

        //    for (int j = 0; j < 2; j++)
        //    {
        //        r = random.Next(65, 91);
        //        targa += Convert.ToChar(r);
        //    }

        //    return targa;
        //}
        public string GeneraTarga()
        {
            Random random = new Random();
            int l;
            string s1 = "", s2 = "", s3, targa;
            char z1, z2;//per formare la stringa
            for (int i = 0; i < 2; i++)//genero le prime due lettere
            {
                l = random.Next(65, 91);
                z1 = Convert.ToChar(l);//converto in ascii
                s1 += z1;
            }
            for (int i = 0; i < 2; i++)//genero le ultime due lettere
            {
                l = random.Next(65, 91);
                z2 = Convert.ToChar(l);//converto in ascii
                s2 += z2;
            }
            l = random.Next(100, 1000);//genero nume.ro in mezzo
            s3 = Convert.ToString(l);//converto il n in string
            targa = s1 + s3 + s2;//concateno per formare la targa
            return targa;
        }
    }
}