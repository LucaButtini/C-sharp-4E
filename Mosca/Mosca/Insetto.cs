using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mosca
{
    public class Insetto
    {
        private RadioButton Mosca;
        private RadioButton Farfalla;
        private RadioButton Ragno;
        private RadioButton Ape;
        private PictureBox Bug;

        private string path;

        public Insetto(RadioButton mosca, RadioButton farfalla, RadioButton ragno, RadioButton ape, PictureBox bug, string path)
        {
            Mosca = mosca;
            Farfalla = farfalla;
            Ragno = ragno;
            Ape = ape;
            Bug = bug;
            this.path = path;
        }

        public void Mosca_CheckedChanged(object sender, EventArgs e)
        {
            if (Mosca.Checked)
            {
                Bug.Image = Image.FromFile(path + "\\mosca.gif");
            }
            else if (Farfalla.Checked)
            {
                Bug.Image = Image.FromFile(path + "\\farfalla.gif");
            }
            else if (Ragno.Checked)
            {
                Bug.Image = Image.FromFile(path + "\\ragno.gif");
            }
            else if (Ape.Checked)
            {
                Bug.Image = Image.FromFile(path + "\\ape.gif");
            }
        }

        public string NomeImmagine()
        {
            if (Mosca.Checked)
            {
                return "mosca";
            }
            else if (Farfalla.Checked)
            {
                return "farfalla";
            }
            else if (Ragno.Checked)
            {
                return "ragno";
            }
            else if (Ape.Checked)
            {
                return "ape";
            }

            return ""; // Ritorno vuoto nel caso in cui nessun RadioButton sia selezionato
        }
    }
}
