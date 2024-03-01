using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsStudentiPersone
{
    public partial class Form1 : Form
    {
        List<Persona> anagrafica;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            anagrafica = new List<Persona>();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!CheckInserimento(textBox1.Text) && !CheckInserimento(textBox2.Text))
            {
                MessageBox.Show("Inserimento dati non valido o nullo", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Persona persona = new Persona(textBox1.Text, textBox2.Text);
            if (anagrafica.Exists(p => p == persona))
            {
                MessageBox.Show("Elemento già presente nella lista", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            lstanag.Items.Add(persona.ToString());
            Cancella();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!CheckInserimento(textBox1.Text) && !CheckInserimento(textBox2.Text))
            {
                MessageBox.Show("Inserimento dati non valido o nullo", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Studente studente = new Studente(textBox1.Text, textBox2.Text);
            if (anagrafica.Exists(p => p == studente))
            {
                MessageBox.Show("Elemento già presente nella lista", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            lstanag.Items.Add(studente.ToString());
            Cancella();
        }
        private void Cancella()
        {
            textBox1.Clear();
            textBox2.Clear();
        }
        private bool CheckInserimento(string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return false;
            }
            return true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
