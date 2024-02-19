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
            this.LBX_Conti = new System.Windows.Forms.ListBox();
            this.lblSaldoTotale = new System.Windows.Forms.Label();
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
            this.movimentoToolStripMenuItem});
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
            this.movimentoToolStripMenuItem.Name = "movimentoToolStripMenuItem";
            this.movimentoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.movimentoToolStripMenuItem.Text = "Movimento";
            this.movimentoToolStripMenuItem.Click += new System.EventHandler(this.movimentoToolStripMenuItem_Click);
            // 
            // LBX_Conti
            // 
            this.LBX_Conti.FormattingEnabled = true;
            this.LBX_Conti.Location = new System.Drawing.Point(12, 196);
            this.LBX_Conti.Name = "LBX_Conti";
            this.LBX_Conti.Size = new System.Drawing.Size(289, 186);
            this.LBX_Conti.TabIndex = 1;
            // 
            // lblSaldoTotale
            // 
            this.lblSaldoTotale.AutoSize = true;
            this.lblSaldoTotale.Location = new System.Drawing.Point(327, 368);
            this.lblSaldoTotale.Name = "lblSaldoTotale";
            this.lblSaldoTotale.Size = new System.Drawing.Size(0, 13);
            this.lblSaldoTotale.TabIndex = 2;
            this.lblSaldoTotale.Click += new System.EventHandler(this.lblSaldoTotale_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSaldoTotale);
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
        private System.Windows.Forms.Label lblSaldoTotale;
    }
}

