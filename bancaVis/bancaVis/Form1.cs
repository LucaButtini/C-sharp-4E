using Banca;
using System;
using System.Drawing;
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
            banca = new Banca("Intesa San Paolo"); 
            conto = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void creaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crea un nuovo conto e aggiungilo alla banca
            conto = new Conto(Banca.IdConto, "Federico", "Melon");
            banca.Aggiungi(conto);

            // Aggiorna l'interfaccia utente
            LBX_Conti.Items.Add(conto.ToString());
        }

        private void movimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double importoMovimento = 5;
            if (conto != null)
            {
                if (conto.Movimento(importoMovimento))
                {
                    // Aggiorna l'interfaccia utente
                    LBX_Conti.Items.Add(conto.ToString());
                    lblSaldoTotale.Text = $"Saldo Totale Banca: {banca.SaldoTotale()}";
                }
                else
                {
                    MessageBox.Show("Saldo insufficiente.", "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleziona un conto prima di effettuare un movimento.", "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblSaldoTotale_Click(object sender, EventArgs e)
        {

        }
    }

}