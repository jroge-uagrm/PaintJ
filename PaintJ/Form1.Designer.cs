namespace PaintJ
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.másToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trasladarPoligonoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotarPoligonoAnguloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotarPoligonoAnguloPuntoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.aviso = new System.Windows.Forms.Label();
            this.areaDibujo = new System.Windows.Forms.PictureBox();
            this.avisoTxt = new System.Windows.Forms.TextBox();
            this.avisoBtn = new System.Windows.Forms.Button();
            this.avisoCheck = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.areaDibujo)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.másToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(804, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // másToolStripMenuItem
            // 
            this.másToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trasladarPoligonoToolStripMenuItem,
            this.rotarPoligonoAnguloToolStripMenuItem,
            this.rotarPoligonoAnguloPuntoToolStripMenuItem});
            this.másToolStripMenuItem.Name = "másToolStripMenuItem";
            this.másToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.másToolStripMenuItem.Text = "Más";
            // 
            // trasladarPoligonoToolStripMenuItem
            // 
            this.trasladarPoligonoToolStripMenuItem.Name = "trasladarPoligonoToolStripMenuItem";
            this.trasladarPoligonoToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.trasladarPoligonoToolStripMenuItem.Text = "Trasladar Poligono";
            this.trasladarPoligonoToolStripMenuItem.Click += new System.EventHandler(this.trasladarPoligonoToolStripMenuItem_Click);
            // 
            // rotarPoligonoAnguloToolStripMenuItem
            // 
            this.rotarPoligonoAnguloToolStripMenuItem.Name = "rotarPoligonoAnguloToolStripMenuItem";
            this.rotarPoligonoAnguloToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.rotarPoligonoAnguloToolStripMenuItem.Text = "Rotar Poligono-Angulo";
            this.rotarPoligonoAnguloToolStripMenuItem.Click += new System.EventHandler(this.rotarPoligonoAnguloToolStripMenuItem_Click);
            // 
            // rotarPoligonoAnguloPuntoToolStripMenuItem
            // 
            this.rotarPoligonoAnguloPuntoToolStripMenuItem.Name = "rotarPoligonoAnguloPuntoToolStripMenuItem";
            this.rotarPoligonoAnguloPuntoToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.rotarPoligonoAnguloPuntoToolStripMenuItem.Text = "Rotar Poligono-Angulo-Punto";
            this.rotarPoligonoAnguloPuntoToolStripMenuItem.Click += new System.EventHandler(this.rotarPoligonoAnguloPuntoToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(360, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Coordenadas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(530, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Convertido";
            // 
            // textBox1
            // 
            this.textBox1.CausesValidation = false;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(266, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(41, 20);
            this.textBox1.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Tamaño";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(313, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(41, 20);
            this.textBox2.TabIndex = 27;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(436, 6);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(41, 20);
            this.textBox3.TabIndex = 28;
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(483, 6);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(41, 20);
            this.textBox4.TabIndex = 29;
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(594, 6);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(65, 20);
            this.textBox5.TabIndex = 30;
            // 
            // textBox6
            // 
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(665, 6);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(65, 20);
            this.textBox6.TabIndex = 31;
            // 
            // aviso
            // 
            this.aviso.AutoSize = true;
            this.aviso.Dock = System.Windows.Forms.DockStyle.Left;
            this.aviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aviso.ForeColor = System.Drawing.Color.Red;
            this.aviso.Location = new System.Drawing.Point(0, 24);
            this.aviso.Name = "aviso";
            this.aviso.Size = new System.Drawing.Size(0, 25);
            this.aviso.TabIndex = 32;
            // 
            // areaDibujo
            // 
            this.areaDibujo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.areaDibujo.Location = new System.Drawing.Point(0, 30);
            this.areaDibujo.Name = "areaDibujo";
            this.areaDibujo.Size = new System.Drawing.Size(804, 387);
            this.areaDibujo.TabIndex = 33;
            this.areaDibujo.TabStop = false;
            this.areaDibujo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.areaDibujo_MouseClick);
            this.areaDibujo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.areaDibujo_MouseDoubleClick);
            this.areaDibujo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.areaDibujo_MouseMove);
            // 
            // avisoTxt
            // 
            this.avisoTxt.Location = new System.Drawing.Point(704, 397);
            this.avisoTxt.Name = "avisoTxt";
            this.avisoTxt.Size = new System.Drawing.Size(100, 20);
            this.avisoTxt.TabIndex = 34;
            // 
            // avisoBtn
            // 
            this.avisoBtn.Location = new System.Drawing.Point(623, 395);
            this.avisoBtn.Name = "avisoBtn";
            this.avisoBtn.Size = new System.Drawing.Size(75, 23);
            this.avisoBtn.TabIndex = 35;
            this.avisoBtn.Text = "button1";
            this.avisoBtn.UseVisualStyleBackColor = true;
            this.avisoBtn.Click += new System.EventHandler(this.avisoBtn_Click);
            // 
            // avisoCheck
            // 
            this.avisoCheck.AutoSize = true;
            this.avisoCheck.Location = new System.Drawing.Point(537, 397);
            this.avisoCheck.Name = "avisoCheck";
            this.avisoCheck.Size = new System.Drawing.Size(80, 17);
            this.avisoCheck.TabIndex = 36;
            this.avisoCheck.Text = "checkBox1";
            this.avisoCheck.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(804, 417);
            this.Controls.Add(this.avisoCheck);
            this.Controls.Add(this.avisoBtn);
            this.Controls.Add(this.avisoTxt);
            this.Controls.Add(this.aviso);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.areaDibujo);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "PAINT";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.areaDibujo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label aviso;
        private System.Windows.Forms.PictureBox areaDibujo;
        private System.Windows.Forms.ToolStripMenuItem másToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trasladarPoligonoToolStripMenuItem;
        private System.Windows.Forms.TextBox avisoTxt;
        private System.Windows.Forms.Button avisoBtn;
        private System.Windows.Forms.ToolStripMenuItem rotarPoligonoAnguloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotarPoligonoAnguloPuntoToolStripMenuItem;
        private System.Windows.Forms.CheckBox avisoCheck;
    }
}

