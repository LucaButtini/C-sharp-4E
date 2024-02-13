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
        int contatore = 0, livello = 0;
        public Form1()
        {
            InitializeComponent();
            insetto = new Insetto(Mosca, Farfalla, Ragno, Ape, Bug, path);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Mosca.Checked = true;
            textBox1.Text = "Livello 1" + " Velocità Insetto: " + timer1.Interval.ToString() + " ms";
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
            string imageName = Immagine();
            Bug.Image = Image.FromFile(path + "\\" + imageName + "X.gif");
            MessageBox.Show("Colpito", "MSG", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Bug.Image = Image.FromFile(path + "\\" + imageName + ".gif");
            timer1.Enabled = true;
            timer1.Interval -= 50; //aumenta la difficoltà del gioco, diminuendo l'intervallo dei tick.
            livello++;
            //resetto la posizione dell'insetto quando l'ho colpito
            xy.X = posizione.Next(0, (area.ClientSize.Width - Bug.Width) + 1);
            xy.Y = posizione.Next(0, (area.ClientSize.Height - Bug.Height) + 1);
            Bug.Location = xy;
            //text box per i livelli
            textBox1.Text = "Livello " + livello.ToString() + " Velocità Insetto: " + timer1.Interval.ToString() + " ms";
            contatore = 0;
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

        private void area_Click(object sender, EventArgs e)
        {

            contatore++;
            FineGioco(contatore >= 5);

        }

        private void FineGioco(bool var)
        {
            if (var)
            {
                MessageBox.Show("Game Over!", "Fine del gioco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                contatore = 0;
                Close();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Vuoi uscire dal gioco?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                //e.cancel a true vuol dire che non gestico l'evento
                e.Cancel = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

