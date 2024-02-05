namespace Mosca
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
            this.components = new System.ComponentModel.Container();
            this.area = new System.Windows.Forms.Panel();
            this.Bug = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Ragno = new System.Windows.Forms.RadioButton();
            this.Farfalla = new System.Windows.Forms.RadioButton();
            this.Mosca = new System.Windows.Forms.RadioButton();
            this.Ape = new System.Windows.Forms.RadioButton();
            this.Insetti = new System.Windows.Forms.GroupBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.area.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bug)).BeginInit();
            this.Insetti.SuspendLayout();
            this.SuspendLayout();
            // 
            // area
            // 
            this.area.BackgroundImage = global::Mosca.Properties.Resources.prato2;
            this.area.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.area.Controls.Add(this.Bug);
            this.area.Location = new System.Drawing.Point(1, 3);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(683, 406);
            this.area.TabIndex = 1;
            this.area.Paint += new System.Windows.Forms.PaintEventHandler(this.area_Paint);
            // 
            // Bug
            // 
            this.Bug.BackColor = System.Drawing.Color.Transparent;
            this.Bug.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Bug.Image = global::Mosca.Properties.Resources.mosca;
            this.Bug.Location = new System.Drawing.Point(481, 145);
            this.Bug.Name = "Bug";
            this.Bug.Size = new System.Drawing.Size(83, 84);
            this.Bug.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Bug.TabIndex = 0;
            this.Bug.TabStop = false;
            this.Bug.Click += new System.EventHandler(this.Bug_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Ragno
            // 
            this.Ragno.AutoSize = true;
            this.Ragno.Location = new System.Drawing.Point(11, 88);
            this.Ragno.Name = "Ragno";
            this.Ragno.Size = new System.Drawing.Size(57, 17);
            this.Ragno.TabIndex = 8;
            this.Ragno.TabStop = true;
            this.Ragno.Text = "Ragno";
            this.Ragno.UseVisualStyleBackColor = true;
            this.Ragno.CheckedChanged += new System.EventHandler(this.Mosca_CheckedChanged);
            // 
            // Farfalla
            // 
            this.Farfalla.AutoSize = true;
            this.Farfalla.Location = new System.Drawing.Point(11, 65);
            this.Farfalla.Name = "Farfalla";
            this.Farfalla.Size = new System.Drawing.Size(59, 17);
            this.Farfalla.TabIndex = 7;
            this.Farfalla.TabStop = true;
            this.Farfalla.Text = "Farfalla";
            this.Farfalla.UseVisualStyleBackColor = true;
            this.Farfalla.CheckedChanged += new System.EventHandler(this.Mosca_CheckedChanged);
            // 
            // Mosca
            // 
            this.Mosca.AutoSize = true;
            this.Mosca.Location = new System.Drawing.Point(11, 42);
            this.Mosca.Name = "Mosca";
            this.Mosca.Size = new System.Drawing.Size(57, 17);
            this.Mosca.TabIndex = 6;
            this.Mosca.TabStop = true;
            this.Mosca.Text = "Mosca";
            this.Mosca.UseVisualStyleBackColor = true;
            this.Mosca.CheckedChanged += new System.EventHandler(this.Mosca_CheckedChanged);
            // 
            // Ape
            // 
            this.Ape.AutoSize = true;
            this.Ape.Location = new System.Drawing.Point(11, 19);
            this.Ape.Name = "Ape";
            this.Ape.Size = new System.Drawing.Size(44, 17);
            this.Ape.TabIndex = 5;
            this.Ape.TabStop = true;
            this.Ape.Text = "Ape";
            this.Ape.UseVisualStyleBackColor = true;
            this.Ape.CheckedChanged += new System.EventHandler(this.Mosca_CheckedChanged);
            // 
            // Insetti
            // 
            this.Insetti.Controls.Add(this.Ape);
            this.Insetti.Controls.Add(this.Ragno);
            this.Insetti.Controls.Add(this.Mosca);
            this.Insetti.Controls.Add(this.Farfalla);
            this.Insetti.Location = new System.Drawing.Point(690, 196);
            this.Insetti.Name = "Insetti";
            this.Insetti.Size = new System.Drawing.Size(112, 155);
            this.Insetti.TabIndex = 9;
            this.Insetti.TabStop = false;
            this.Insetti.Text = "Insetti";
            this.Insetti.Enter += new System.EventHandler(this.Insetti_Enter);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_close.Location = new System.Drawing.Point(701, 415);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 0;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Insetti);
            this.Controls.Add(this.area);
            this.Controls.Add(this.btn_close);
            this.Name = "Form1";
            this.Text = "Tiro_a_Segno";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.area.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Bug)).EndInit();
            this.Insetti.ResumeLayout(false);
            this.Insetti.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel area;
        private System.Windows.Forms.PictureBox Bug;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton Ragno;
        private System.Windows.Forms.RadioButton Farfalla;
        private System.Windows.Forms.RadioButton Mosca;
        private System.Windows.Forms.RadioButton Ape;
        private System.Windows.Forms.GroupBox Insetti;
        private System.Windows.Forms.Button btn_close;
    }
}

