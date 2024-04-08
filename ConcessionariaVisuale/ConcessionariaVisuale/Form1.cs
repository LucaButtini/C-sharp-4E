using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConcessionariaVisuale
{
    public partial class Form1 : Form
    {
        List<Veicolo> concessionaria;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            concessionaria = new List<Veicolo>();
        }
        private bool CheckDoppi(string marca, string modello)
        {
            if (concessionaria.Any(v => v.Marca == marca && v.Modello == modello))
                return true;
            return false;
        }
        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string marca = textBox1.Text, modello = textBox2.Text, km = textBox3.Text, kmNoleggio = textBox4.Text, cilindrata = textBox5.Text, nVolumi = textBox6.Text;
            if (!CheckInserimento(marca) || !CheckInserimento(modello) || !CheckInserimentoDouble(km) || !CheckInserimentoDouble(kmNoleggio) || !CheckInserimentoInt(cilindrata) || !CheckInserimentoInt(nVolumi))
            {
                MessageBox.Show("Input non valido", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                double _km, _kmNoleggio;
                int _cilindrata, _nVolumi;
                if (!double.TryParse(km, out _km) || !double.TryParse(kmNoleggio, out _kmNoleggio) || !int.TryParse(cilindrata, out _cilindrata) || !int.TryParse(nVolumi, out _nVolumi))
                {
                    MessageBox.Show("Input non valido", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                Auto auto = new Auto(marca, modello, _km, _kmNoleggio, _cilindrata, _nVolumi);
                if (CheckDoppi(modello, marca))
                {
                    MessageBox.Show("Elemento già presente nella lista", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                concessionaria.Add(auto);
                lbxConc.Items.Add(auto.ToString());
                Cancella();
            }
        }
        private void motoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string marca = textBox12.Text, modello = textBox11.Text, km = textBox10.Text, kmNoleggio = textBox9.Text, nTempi = textBox7.Text;
            if (!CheckInserimento(marca) || !CheckInserimento(modello) || !CheckInserimentoDouble(km) || !CheckInserimentoDouble(kmNoleggio) || !CheckInserimentoInt(nTempi))
            {
                MessageBox.Show("Input non valido", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                double _km, _kmNoleggio;
                int _nTempi;
                if (!double.TryParse(km, out _km) || !double.TryParse(kmNoleggio, out _kmNoleggio) || !int.TryParse(nTempi, out _nTempi))
                {
                    MessageBox.Show("Input non valido", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Moto moto = new Moto(marca, modello, _km, _kmNoleggio, _nTempi, PortaCascoScelta());
                if (CheckDoppi(modello, marca))
                {
                    MessageBox.Show("Elemento già presente nella lista", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                concessionaria.Add(moto);
                lbxConc.Items.Add(moto.ToString());
                Cancella();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private bool CheckInserimento(string str)
        {
            return !string.IsNullOrEmpty(str); //controllo se stringa vuota o nulla
        }

        private bool CheckInserimentoInt(string input)//controllo se stringa può essere convertita in intero
        {
            if (!CheckInserimento(input))
                return false;

            return int.TryParse(input, out int result);
        }

        private bool CheckInserimentoDouble(string input) //controllo se stringa può essere convertita in double
        {
            if (!CheckInserimento(input))
                return false;

            return double.TryParse(input, out double result);
        }
        private bool PortaCascoScelta()
        {
            if (radioButton1.Checked)
                return true;
            return false;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Cancella()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Vuoi uscire dal form?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void rimuoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbxConc.SelectedIndex != -1) //se non è selezionato alcun item dalla listbox ritorna -1
            {
                concessionaria.RemoveAt(lbxConc.SelectedIndex);
                lbxConc.Items.RemoveAt(lbxConc.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Seleziona un veicolo da rimuovere.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
