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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.másToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traslacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarPuntoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puntoAleatorioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mismoEjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.respectoAlOrigenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.respectoAUnPuntoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reflexionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.origenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.origenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reflexionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ejeXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejeYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarLineaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menu = new System.Windows.Forms.ComboBox();
            this.poligonoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.areaDibujo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.poligonoBindingSource)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
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
            this.traslacionToolStripMenuItem,
            this.rotacionToolStripMenuItem,
            this.reflexionToolStripMenuItem,
            this.reflexionToolStripMenuItem1,
            this.borrarLineaToolStripMenuItem});
            this.másToolStripMenuItem.Name = "másToolStripMenuItem";
            this.másToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.másToolStripMenuItem.Text = "Más";
            // 
            // traslacionToolStripMenuItem
            // 
            this.traslacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seleccionarPuntoToolStripMenuItem,
            this.puntoAleatorioToolStripMenuItem});
            this.traslacionToolStripMenuItem.Name = "traslacionToolStripMenuItem";
            this.traslacionToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.traslacionToolStripMenuItem.Text = "Traslacion";
            // 
            // seleccionarPuntoToolStripMenuItem
            // 
            this.seleccionarPuntoToolStripMenuItem.Name = "seleccionarPuntoToolStripMenuItem";
            this.seleccionarPuntoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.seleccionarPuntoToolStripMenuItem.Text = "Seleccionar Punto";
            this.seleccionarPuntoToolStripMenuItem.Click += new System.EventHandler(this.seleccionarPuntoToolStripMenuItem_Click);
            // 
            // puntoAleatorioToolStripMenuItem
            // 
            this.puntoAleatorioToolStripMenuItem.Name = "puntoAleatorioToolStripMenuItem";
            this.puntoAleatorioToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.puntoAleatorioToolStripMenuItem.Text = "Punto Aleatorio";
            this.puntoAleatorioToolStripMenuItem.Click += new System.EventHandler(this.puntoAleatorioToolStripMenuItem_Click);
            // 
            // rotacionToolStripMenuItem
            // 
            this.rotacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mismoEjeToolStripMenuItem,
            this.respectoAlOrigenToolStripMenuItem,
            this.respectoAUnPuntoToolStripMenuItem});
            this.rotacionToolStripMenuItem.Name = "rotacionToolStripMenuItem";
            this.rotacionToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.rotacionToolStripMenuItem.Text = "Rotacion";
            // 
            // mismoEjeToolStripMenuItem
            // 
            this.mismoEjeToolStripMenuItem.Name = "mismoEjeToolStripMenuItem";
            this.mismoEjeToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.mismoEjeToolStripMenuItem.Text = "Mismo Eje";
            this.mismoEjeToolStripMenuItem.Click += new System.EventHandler(this.mismoEjeToolStripMenuItem_Click);
            // 
            // respectoAlOrigenToolStripMenuItem
            // 
            this.respectoAlOrigenToolStripMenuItem.Name = "respectoAlOrigenToolStripMenuItem";
            this.respectoAlOrigenToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.respectoAlOrigenToolStripMenuItem.Text = "Origen";
            this.respectoAlOrigenToolStripMenuItem.Click += new System.EventHandler(this.respectoAlOrigenToolStripMenuItem_Click);
            // 
            // respectoAUnPuntoToolStripMenuItem
            // 
            this.respectoAUnPuntoToolStripMenuItem.Name = "respectoAUnPuntoToolStripMenuItem";
            this.respectoAUnPuntoToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.respectoAUnPuntoToolStripMenuItem.Text = "Punto Cualquiera";
            this.respectoAUnPuntoToolStripMenuItem.Click += new System.EventHandler(this.respectoAUnPuntoToolStripMenuItem_Click);
            // 
            // reflexionToolStripMenuItem
            // 
            this.reflexionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.origenToolStripMenuItem,
            this.origenToolStripMenuItem1});
            this.reflexionToolStripMenuItem.Name = "reflexionToolStripMenuItem";
            this.reflexionToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.reflexionToolStripMenuItem.Text = "Escalacion";
            // 
            // origenToolStripMenuItem
            // 
            this.origenToolStripMenuItem.Name = "origenToolStripMenuItem";
            this.origenToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.origenToolStripMenuItem.Text = "Mismo Eje";
            this.origenToolStripMenuItem.Click += new System.EventHandler(this.origenToolStripMenuItem_Click);
            // 
            // origenToolStripMenuItem1
            // 
            this.origenToolStripMenuItem1.Name = "origenToolStripMenuItem1";
            this.origenToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.origenToolStripMenuItem1.Text = "Origen";
            this.origenToolStripMenuItem1.Click += new System.EventHandler(this.origenToolStripMenuItem1_Click);
            // 
            // reflexionToolStripMenuItem1
            // 
            this.reflexionToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ejeXToolStripMenuItem,
            this.ejeYToolStripMenuItem});
            this.reflexionToolStripMenuItem1.Name = "reflexionToolStripMenuItem1";
            this.reflexionToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.reflexionToolStripMenuItem1.Text = "Reflexion";
            // 
            // ejeXToolStripMenuItem
            // 
            this.ejeXToolStripMenuItem.Name = "ejeXToolStripMenuItem";
            this.ejeXToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.ejeXToolStripMenuItem.Text = "Eje X";
            this.ejeXToolStripMenuItem.Click += new System.EventHandler(this.ejeXToolStripMenuItem_Click);
            // 
            // ejeYToolStripMenuItem
            // 
            this.ejeYToolStripMenuItem.Name = "ejeYToolStripMenuItem";
            this.ejeYToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.ejeYToolStripMenuItem.Text = "Eje Y";
            this.ejeYToolStripMenuItem.Click += new System.EventHandler(this.ejeYToolStripMenuItem_Click);
            // 
            // borrarLineaToolStripMenuItem
            // 
            this.borrarLineaToolStripMenuItem.Name = "borrarLineaToolStripMenuItem";
            this.borrarLineaToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.borrarLineaToolStripMenuItem.Text = "Borrar Linea";
            this.borrarLineaToolStripMenuItem.Click += new System.EventHandler(this.borrarLineaToolStripMenuItem_Click);
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
            this.areaDibujo.Location = new System.Drawing.Point(0, 32);
            this.areaDibujo.Name = "areaDibujo";
            this.areaDibujo.Size = new System.Drawing.Size(684, 654);
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
            this.avisoCheck.Location = new System.Drawing.Point(537, 395);
            this.avisoCheck.Name = "avisoCheck";
            this.avisoCheck.Size = new System.Drawing.Size(80, 17);
            this.avisoCheck.TabIndex = 36;
            this.avisoCheck.Text = "checkBox1";
            this.avisoCheck.UseVisualStyleBackColor = true;
            this.avisoCheck.CheckedChanged += new System.EventHandler(this.avisoCheck_CheckedChanged);
            // 
            // menu
            // 
            this.menu.DataSource = this.poligonoBindingSource;
            this.menu.FormattingEnabled = true;
            this.menu.Location = new System.Drawing.Point(12, 53);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(149, 21);
            this.menu.TabIndex = 37;
            // 
            // poligonoBindingSource
            // 
            this.poligonoBindingSource.DataSource = typeof(PaintJ.Poligono);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(684, 686);
            this.Controls.Add(this.menu);
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
            this.Controls.Add(this.avisoCheck);
            this.Controls.Add(this.avisoBtn);
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
            ((System.ComponentModel.ISupportInitialize)(this.poligonoBindingSource)).EndInit();
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
        private System.Windows.Forms.TextBox avisoTxt;
        private System.Windows.Forms.Button avisoBtn;
        private System.Windows.Forms.CheckBox avisoCheck;
        private System.Windows.Forms.ToolStripMenuItem traslacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleccionarPuntoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puntoAleatorioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mismoEjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem respectoAlOrigenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem respectoAUnPuntoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reflexionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem origenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem origenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reflexionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ejeXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejeYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarLineaToolStripMenuItem;
        private System.Windows.Forms.ComboBox menu;
        private System.Windows.Forms.BindingSource poligonoBindingSource;
    }
}

