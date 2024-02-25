namespace bancaVis
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.MS_Menu = new System.Windows.Forms.MenuStrip();
            this.creaContoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prelievaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.depositaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizzaContiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LBX_Conti = new System.Windows.Forms.ListBox();
            this.Tb_Nome = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.Tb_Cognome = new System.Windows.Forms.Label();
            this.Lb_Saldo = new System.Windows.Forms.Label();
            this.Tb_ID = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.MS_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MS_Menu
            // 
            this.MS_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creaContoToolStripMenuItem});
            this.MS_Menu.Location = new System.Drawing.Point(0, 0);
            this.MS_Menu.Name = "MS_Menu";
            this.MS_Menu.Size = new System.Drawing.Size(800, 24);
            this.MS_Menu.TabIndex = 0;
            this.MS_Menu.Text = "menuStrip1";
            // 
            // creaContoToolStripMenuItem
            // 
            this.creaContoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creaToolStripMenuItem,
            this.movimentoToolStripMenuItem,
            this.visualizzaContiToolStripMenuItem});
            this.creaContoToolStripMenuItem.Name = "creaContoToolStripMenuItem";
            this.creaContoToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.creaContoToolStripMenuItem.Text = "Conto";
            // 
            // creaToolStripMenuItem
            // 
            this.creaToolStripMenuItem.Name = "creaToolStripMenuItem";
            this.creaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.creaToolStripMenuItem.Text = "Crea";
            this.creaToolStripMenuItem.Click += new System.EventHandler(this.creaToolStripMenuItem_Click);
            // 
            // movimentoToolStripMenuItem
            // 
            this.movimentoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prelievaToolStripMenuItem,
            this.depositaToolStripMenuItem});
            this.movimentoToolStripMenuItem.Name = "movimentoToolStripMenuItem";
            this.movimentoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.movimentoToolStripMenuItem.Text = "Movimento";
            this.movimentoToolStripMenuItem.Click += new System.EventHandler(this.movimentoToolStripMenuItem_Click);
            // 
            // prelievaToolStripMenuItem
            // 
            this.prelievaToolStripMenuItem.Name = "prelievaToolStripMenuItem";
            this.prelievaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.prelievaToolStripMenuItem.Text = "Prelieva";
            this.prelievaToolStripMenuItem.Click += new System.EventHandler(this.prelievaToolStripMenuItem_Click);
            // 
            // depositaToolStripMenuItem
            // 
            this.depositaToolStripMenuItem.Name = "depositaToolStripMenuItem";
            this.depositaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.depositaToolStripMenuItem.Text = "Deposita";
            this.depositaToolStripMenuItem.Click += new System.EventHandler(this.depositaToolStripMenuItem_Click);
            // 
            // visualizzaContiToolStripMenuItem
            // 
            this.visualizzaContiToolStripMenuItem.Name = "visualizzaContiToolStripMenuItem";
            this.visualizzaContiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.visualizzaContiToolStripMenuItem.Text = "Visualizza Conti";
            this.visualizzaContiToolStripMenuItem.Click += new System.EventHandler(this.visualizzaContiToolStripMenuItem_Click);
            // 
            // LBX_Conti
            // 
            this.LBX_Conti.FormattingEnabled = true;
            this.LBX_Conti.Location = new System.Drawing.Point(12, 196);
            this.LBX_Conti.Name = "LBX_Conti";
            this.LBX_Conti.Size = new System.Drawing.Size(289, 186);
            this.LBX_Conti.TabIndex = 1;
            // 
            // Tb_Nome
            // 
            this.Tb_Nome.AutoSize = true;
            this.Tb_Nome.Location = new System.Drawing.Point(305, 239);
            this.Tb_Nome.Name = "Tb_Nome";
            this.Tb_Nome.Size = new System.Drawing.Size(35, 13);
            this.Tb_Nome.TabIndex = 2;
            this.Tb_Nome.Text = "Nome";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(307, 255);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(307, 294);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(307, 333);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 5;
            // 
            // Tb_Cognome
            // 
            this.Tb_Cognome.AutoSize = true;
            this.Tb_Cognome.Location = new System.Drawing.Point(304, 278);
            this.Tb_Cognome.Name = "Tb_Cognome";
            this.Tb_Cognome.Size = new System.Drawing.Size(52, 13);
            this.Tb_Cognome.TabIndex = 6;
            this.Tb_Cognome.Text = "Cognome";
            // 
            // Lb_Saldo
            // 
            this.Lb_Saldo.AutoSize = true;
            this.Lb_Saldo.Location = new System.Drawing.Point(304, 317);
            this.Lb_Saldo.Name = "Lb_Saldo";
            this.Lb_Saldo.Size = new System.Drawing.Size(34, 13);
            this.Lb_Saldo.TabIndex = 7;
            this.Lb_Saldo.Text = "Saldo";
            // 
            // Tb_ID
            // 
            this.Tb_ID.AutoSize = true;
            this.Tb_ID.Location = new System.Drawing.Point(305, 200);
            this.Tb_ID.Name = "Tb_ID";
            this.Tb_ID.Size = new System.Drawing.Size(18, 13);
            this.Tb_ID.TabIndex = 8;
            this.Tb_ID.Text = "ID";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(307, 216);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.Tb_ID);
            this.Controls.Add(this.Lb_Saldo);
            this.Controls.Add(this.Tb_Cognome);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Tb_Nome);
            this.Controls.Add(this.LBX_Conti);
            this.Controls.Add(this.MS_Menu);
            this.MainMenuStrip = this.MS_Menu;
            this.Name = "Form1";
            this.Text = "Banca";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MS_Menu.ResumeLayout(false);
            this.MS_Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MS_Menu;
        private System.Windows.Forms.ToolStripMenuItem creaContoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creaToolStripMenuItem;
        private System.Windows.Forms.ListBox LBX_Conti;
        private System.Windows.Forms.ToolStripMenuItem movimentoToolStripMenuItem;
        private System.Windows.Forms.Label Tb_Nome;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label Tb_Cognome;
        private System.Windows.Forms.Label Lb_Saldo;
        private System.Windows.Forms.Label Tb_ID;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ToolStripMenuItem visualizzaContiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prelievaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem depositaToolStripMenuItem;
    }
}

