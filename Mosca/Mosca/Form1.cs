using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mosca
{
    public partial class Form1 : Form
    {
        Point xy;
        Random posizione = new Random();
        Insetto insetto;
        string path = Environment.CurrentDirectory + "\\mosca_immagini";
        public Form1()
        {
            InitializeComponent();
            insetto = new Insetto(Mosca, Farfalla, Ragno, Ape, Bug, path);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Mosca.Checked = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            xy.X = posizione.Next(0, (area.ClientSize.Width - Bug.Width) + 1);
            xy.Y = posizione.Next(0, (area.ClientSize.Height - Bug.Height) + 1);
            Bug.Location = xy;
        }

        private void Bug_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            // Aggiungi la "X" al nome del file corrente
            string imageName = Immagine();
            Bug.Image = Image.FromFile(path + "\\" + imageName + "X.gif");

            MessageBox.Show("Colpito", "MSG", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Bug.Image = Image.FromFile(path + "\\" + imageName + ".gif");
            timer1.Enabled = true;

        }
        private void area_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Insetti_Enter(object sender, EventArgs e)
        {

        }
        private void Mosca_CheckedChanged(object sender, EventArgs e)
        {
            insetto.Mosca_CheckedChanged(sender, e);
        }

        private string Immagine()
        {
            return insetto.NomeImmagine();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
