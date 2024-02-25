
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bancaVis
{
    public partial class Form1 : Form
    {
        Banca banca;
        Conto conto;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            banca = new Banca("Intesa San Paolo");
        }

        private void creaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conto = new Conto(Convert.ToInt32(textBox4.Text), textBox1.Text, textBox2.Text);
            conto.Saldo = Convert.ToInt32(textBox3.Text);
            LBX_Conti.Items.Add(conto.ToString());
        }

        private void movimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void visualizzaContiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            banca.AggiungiConti(new Conto(Banca.Id, "Mario", "Rossi"));
            banca.AggiungiConti(new Conto(Banca.Id, "Giuseppe", "Verdi"));
            banca.AggiungiConti(new Conto(Banca.Id, "Gigi", "Piastrella"));
            foreach (Conto c in banca.CopyCorrentisti())
            {
                LBX_Conti.Items.Add(c);
            }
            Conto newConto = banca.CopyCorrentisti()[1];
            newConto.Saldo = 50;
            foreach (Conto c in banca.CopyCorrentisti())
            {
                LBX_Conti.Items.Add(c);
            }
        }
        //FATTI CON VALORI DI DEFAULT PER SEMPLICITA'
        private void prelievaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double quantita = 3; 

            bool successo = conto.Movimento(-quantita);

            if (!successo)
            {
                MessageBox.Show("Il saldo non può essere zero o negativo.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                LBX_Conti.Items.Add(conto.ToString());
            }
        }
        private void depositaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conto.Movimento(3);
            LBX_Conti.Items.Add(conto.ToString());
        }
    }
}
