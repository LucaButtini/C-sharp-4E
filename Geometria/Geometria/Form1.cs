using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometria
{
    public partial class Form1 : Form
    {
        //Punto p;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void creaPuntoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Punto p1 = new Punto(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox1.Text));
            listBox1.Items.Add(p1.Scrivi());
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            creaPuntoToolStripMenuItem.Enabled = textBox2.Text != "" && textBox1.Text != "";

        }

        private void creaRettangoloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Punto p1 = new Punto(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox1.Text));
            Rettangolo r1 = new Rettangolo(p1, Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
            listBox1.Items.Add(r1.Scrivi());
        }

        private void creaQuadratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Punto p1 = new Punto(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox1.Text));
            Quadrato q1 = new Quadrato(p1, Convert.ToInt32(textBox5.Text));
            listBox1.Items.Add(q1.Scrivi());
        }
    }
}
