using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            string nome = textBox1.Text;
            string cognome = textBox2.Text;
            if (!CheckInserimento(nome) && !CheckInserimento(cognome))
            {
                MessageBox.Show("Inserimento dati non valido o nullo", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Persona persona = new Persona(textBox1.Text, textBox2.Text);
            if (CheckDoppi(nome, cognome))
            {
                MessageBox.Show("Elemento già presente nella lista", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            anagrafica.Add(persona);
            lstanag.Items.Add(persona.ToString());
            Cancella();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string nome = textBox1.Text;
            string cognome = textBox2.Text;
            if (!CheckInserimento(nome) && !CheckInserimento(cognome))
            {
                MessageBox.Show("Inserimento dati non valido o nullo", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Studente studente = new Studente(nome, cognome);
            if (CheckDoppi(nome, cognome))
            {
                MessageBox.Show("Elemento già presente nella lista", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            anagrafica.Add(studente);
            lstanag.Items.Add(studente.ToString());
            Cancella();
        }
        private bool CheckDoppi(string nome, string cognome)
        {
            if (anagrafica.Any(p => p.Nome == nome && p.Cognome == cognome))
            {
                return true;
            }
            return false;
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Vuoi uscire dal form?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
