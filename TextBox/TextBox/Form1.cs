using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextBox
{
    public partial class Form1 : Form
    {
        string passwordCorretta = "KingVintage*GianniMorante";
        bool accesso = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se il tasto premuto è "Invio" (codice tasto 13)
            if (e.KeyCode == Keys.Enter)
            {
                // Confronta la password inserita con la password corretta
                if (textBox1.Text == passwordCorretta)
                {
                    // Password corretta, mostra un MessageBox di successo
                    MessageBox.Show("Password corretta! Accesso consentito.", "Messaggio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    accesso = true;

                    // Cancella il testo dalla TextBox dopo il confronto
                    textBox1.Text = "";

                    // Mostra la seconda TextBox
                    textBox2.Visible = true;
                    textBox2.Focus(); // Opzionale: porta il focus sulla nuova TextBox
                }
                else
                {
                    // Password sbagliata, mostra un MessageBox di errore
                    MessageBox.Show("Password sbagliata! Accesso negato.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Cancella il testo dalla TextBox dopo il confronto
                    textBox1.Text = "";
                }
            }

            //private void textBox1_KeyDown(object sender, KeyEventArgs e)
            //{
            //    // Verifica se il tasto premuto è "Invio" (codice tasto 13)
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        // Confronta la password inserita con la password corretta
            //        if (textBox1.Text == passwordCorretta)
            //        {
            //            // Password corretta, mostra un MessageBox di successo
            //            MessageBox.Show("Password corretta! Accesso consentito.", "Messaggio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            accesso = true;
            //        }
            //        else
            //        {
            //            // Password sbagliata, mostra un MessageBox di errore
            //            MessageBox.Show("Password sbagliata! Accesso negato.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }

            //        // Cancella il testo dalla TextBox dopo il confronto
            //        textBox1.Text = "";
            //    }
            //}
        }
    }
}
