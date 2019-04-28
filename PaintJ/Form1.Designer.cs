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
            this.renombrarPoligonoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.areaDibujo = new System.Windows.Forms.PictureBox();
            this.avisoTxt = new System.Windows.Forms.TextBox();
            this.avisoBtn = new System.Windows.Forms.Button();
            this.avisoCheck = new System.Windows.Forms.CheckBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.traslacionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarPuntoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puntoAleatorioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mismoEjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.origenToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cualquierPuntoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reflexionToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ejeXToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ejeYToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rectaCualquieraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escalacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mismoEjeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.origenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cualquierPuntoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarUltimaLineaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarDetenerAnimacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aviso = new System.Windows.Forms.Label();
            this.listaDePoligonos = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.poligonoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.listaDeEfectos = new System.Windows.Forms.CheckedListBox();
            this.iniciarGrabacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminarGrabacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reproducirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.areaDibujo)).BeginInit();
            this.menuStrip2.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(737, 24);
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
            this.renombrarPoligonoToolStripMenuItem});
            this.másToolStripMenuItem.Name = "másToolStripMenuItem";
            this.másToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.másToolStripMenuItem.Text = "Más";
            // 
            // renombrarPoligonoToolStripMenuItem
            // 
            this.renombrarPoligonoToolStripMenuItem.Name = "renombrarPoligonoToolStripMenuItem";
            this.renombrarPoligonoToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.renombrarPoligonoToolStripMenuItem.Text = "Renombrar Poligono";
            this.renombrarPoligonoToolStripMenuItem.Click += new System.EventHandler(this.renombrarPoligonoToolStripMenuItem_Click);
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
            // areaDibujo
            // 
            this.areaDibujo.Location = new System.Drawing.Point(135, 56);
            this.areaDibujo.Name = "areaDibujo";
            this.areaDibujo.Size = new System.Drawing.Size(595, 454);
            this.areaDibujo.TabIndex = 33;
            this.areaDibujo.TabStop = false;
            this.areaDibujo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.areaDibujo_MouseClick);
            this.areaDibujo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.areaDibujo_MouseDoubleClick);
            this.areaDibujo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.areaDibujo_MouseMove);
            // 
            // avisoTxt
            // 
            this.avisoTxt.Location = new System.Drawing.Point(196, 57);
            this.avisoTxt.Name = "avisoTxt";
            this.avisoTxt.Size = new System.Drawing.Size(100, 20);
            this.avisoTxt.TabIndex = 34;
            // 
            // avisoBtn
            // 
            this.avisoBtn.Location = new System.Drawing.Point(302, 55);
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
            this.avisoCheck.Location = new System.Drawing.Point(383, 59);
            this.avisoCheck.Name = "avisoCheck";
            this.avisoCheck.Size = new System.Drawing.Size(80, 17);
            this.avisoCheck.TabIndex = 36;
            this.avisoCheck.Text = "checkBox1";
            this.avisoCheck.UseVisualStyleBackColor = true;
            this.avisoCheck.CheckedChanged += new System.EventHandler(this.avisoCheck_CheckedChanged);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.traslacionToolStripMenuItem1,
            this.rotacionToolStripMenuItem,
            this.reflexionToolStripMenuItem2,
            this.escalacionToolStripMenuItem,
            this.borrarUltimaLineaToolStripMenuItem,
            this.iniciarDetenerAnimacionToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(132, 28);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(604, 24);
            this.menuStrip2.TabIndex = 38;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // traslacionToolStripMenuItem1
            // 
            this.traslacionToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seleccionarPuntoToolStripMenuItem,
            this.puntoAleatorioToolStripMenuItem});
            this.traslacionToolStripMenuItem1.Name = "traslacionToolStripMenuItem1";
            this.traslacionToolStripMenuItem1.Size = new System.Drawing.Size(72, 20);
            this.traslacionToolStripMenuItem1.Text = "Traslacion";
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
            this.puntoAleatorioToolStripMenuItem.Click += new System.EventHandler(this.puntoAleatorioToolStripMenuItem_Click_1);
            // 
            // rotacionToolStripMenuItem
            // 
            this.rotacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mismoEjeToolStripMenuItem,
            this.origenToolStripMenuItem2,
            this.cualquierPuntoToolStripMenuItem1});
            this.rotacionToolStripMenuItem.Name = "rotacionToolStripMenuItem";
            this.rotacionToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.rotacionToolStripMenuItem.Text = "Rotacion";
            // 
            // mismoEjeToolStripMenuItem
            // 
            this.mismoEjeToolStripMenuItem.Name = "mismoEjeToolStripMenuItem";
            this.mismoEjeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.mismoEjeToolStripMenuItem.Text = "Mismo Eje";
            this.mismoEjeToolStripMenuItem.Click += new System.EventHandler(this.mismoEjeToolStripMenuItem_Click_1);
            // 
            // origenToolStripMenuItem2
            // 
            this.origenToolStripMenuItem2.Name = "origenToolStripMenuItem2";
            this.origenToolStripMenuItem2.Size = new System.Drawing.Size(160, 22);
            this.origenToolStripMenuItem2.Text = "Origen";
            this.origenToolStripMenuItem2.Click += new System.EventHandler(this.origenToolStripMenuItem2_Click);
            // 
            // cualquierPuntoToolStripMenuItem1
            // 
            this.cualquierPuntoToolStripMenuItem1.Name = "cualquierPuntoToolStripMenuItem1";
            this.cualquierPuntoToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.cualquierPuntoToolStripMenuItem1.Text = "Cualquier Punto";
            this.cualquierPuntoToolStripMenuItem1.Click += new System.EventHandler(this.cualquierPuntoToolStripMenuItem1_Click);
            // 
            // reflexionToolStripMenuItem2
            // 
            this.reflexionToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ejeXToolStripMenuItem1,
            this.ejeYToolStripMenuItem1,
            this.rectaCualquieraToolStripMenuItem});
            this.reflexionToolStripMenuItem2.Name = "reflexionToolStripMenuItem2";
            this.reflexionToolStripMenuItem2.Size = new System.Drawing.Size(67, 20);
            this.reflexionToolStripMenuItem2.Text = "Reflexion";
            // 
            // ejeXToolStripMenuItem1
            // 
            this.ejeXToolStripMenuItem1.Name = "ejeXToolStripMenuItem1";
            this.ejeXToolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
            this.ejeXToolStripMenuItem1.Text = "Eje X";
            this.ejeXToolStripMenuItem1.Click += new System.EventHandler(this.ejeXToolStripMenuItem1_Click);
            // 
            // ejeYToolStripMenuItem1
            // 
            this.ejeYToolStripMenuItem1.Name = "ejeYToolStripMenuItem1";
            this.ejeYToolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
            this.ejeYToolStripMenuItem1.Text = "Eje Y";
            this.ejeYToolStripMenuItem1.Click += new System.EventHandler(this.ejeYToolStripMenuItem1_Click);
            // 
            // rectaCualquieraToolStripMenuItem
            // 
            this.rectaCualquieraToolStripMenuItem.Name = "rectaCualquieraToolStripMenuItem";
            this.rectaCualquieraToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.rectaCualquieraToolStripMenuItem.Text = "Cualquier Recta";
            this.rectaCualquieraToolStripMenuItem.Click += new System.EventHandler(this.rectaCualquieraToolStripMenuItem_Click);
            // 
            // escalacionToolStripMenuItem
            // 
            this.escalacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mismoEjeToolStripMenuItem1,
            this.origenToolStripMenuItem,
            this.cualquierPuntoToolStripMenuItem});
            this.escalacionToolStripMenuItem.Name = "escalacionToolStripMenuItem";
            this.escalacionToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.escalacionToolStripMenuItem.Text = "Escalacion";
            // 
            // mismoEjeToolStripMenuItem1
            // 
            this.mismoEjeToolStripMenuItem1.Name = "mismoEjeToolStripMenuItem1";
            this.mismoEjeToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.mismoEjeToolStripMenuItem1.Text = "Mismo Eje";
            this.mismoEjeToolStripMenuItem1.Click += new System.EventHandler(this.mismoEjeToolStripMenuItem1_Click);
            // 
            // origenToolStripMenuItem
            // 
            this.origenToolStripMenuItem.Name = "origenToolStripMenuItem";
            this.origenToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.origenToolStripMenuItem.Text = "Origen";
            this.origenToolStripMenuItem.Click += new System.EventHandler(this.origenToolStripMenuItem_Click_1);
            // 
            // cualquierPuntoToolStripMenuItem
            // 
            this.cualquierPuntoToolStripMenuItem.Name = "cualquierPuntoToolStripMenuItem";
            this.cualquierPuntoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.cualquierPuntoToolStripMenuItem.Text = "Cualquier Punto";
            this.cualquierPuntoToolStripMenuItem.Click += new System.EventHandler(this.cualquierPuntoToolStripMenuItem_Click);
            // 
            // borrarUltimaLineaToolStripMenuItem
            // 
            this.borrarUltimaLineaToolStripMenuItem.Name = "borrarUltimaLineaToolStripMenuItem";
            this.borrarUltimaLineaToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.borrarUltimaLineaToolStripMenuItem.Text = "Borrar Ultima Linea";
            this.borrarUltimaLineaToolStripMenuItem.Click += new System.EventHandler(this.borrarUltimaLineaToolStripMenuItem_Click);
            // 
            // iniciarDetenerAnimacionToolStripMenuItem
            // 
            this.iniciarDetenerAnimacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarGrabacionToolStripMenuItem,
            this.terminarGrabacionToolStripMenuItem,
            this.reproducirToolStripMenuItem});
            this.iniciarDetenerAnimacionToolStripMenuItem.Name = "iniciarDetenerAnimacionToolStripMenuItem";
            this.iniciarDetenerAnimacionToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.iniciarDetenerAnimacionToolStripMenuItem.Text = "Animacion";
            // 
            // aviso
            // 
            this.aviso.AutoSize = true;
            this.aviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aviso.ForeColor = System.Drawing.Color.Red;
            this.aviso.Location = new System.Drawing.Point(135, 56);
            this.aviso.Name = "aviso";
            this.aviso.Size = new System.Drawing.Size(55, 18);
            this.aviso.TabIndex = 40;
            this.aviso.Text = "PAINT";
            // 
            // listaDePoligonos
            // 
            this.listaDePoligonos.FormatString = "formato";
            this.listaDePoligonos.FormattingEnabled = true;
            this.listaDePoligonos.Location = new System.Drawing.Point(9, 59);
            this.listaDePoligonos.Name = "listaDePoligonos";
            this.listaDePoligonos.Size = new System.Drawing.Size(124, 169);
            this.listaDePoligonos.TabIndex = 41;
            this.listaDePoligonos.SelectedIndexChanged += new System.EventHandler(this.listaDePoligonos_SelectedIndexChanged);
            this.listaDePoligonos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listaDePoligonos_MouseDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "LISTA DE POLIGONOS";
            // 
            // poligonoBindingSource
            // 
            this.poligonoBindingSource.DataSource = typeof(PaintJ.Poligono);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "LISTA DE EFECTOS";
            // 
            // listaDeEfectos
            // 
            this.listaDeEfectos.FormatString = "formato";
            this.listaDeEfectos.FormattingEnabled = true;
            this.listaDeEfectos.Location = new System.Drawing.Point(8, 310);
            this.listaDeEfectos.Name = "listaDeEfectos";
            this.listaDeEfectos.Size = new System.Drawing.Size(124, 199);
            this.listaDeEfectos.TabIndex = 43;
            // 
            // iniciarGrabacionToolStripMenuItem
            // 
            this.iniciarGrabacionToolStripMenuItem.Name = "iniciarGrabacionToolStripMenuItem";
            this.iniciarGrabacionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.iniciarGrabacionToolStripMenuItem.Text = "Iniciar Grabacion";
            this.iniciarGrabacionToolStripMenuItem.Click += new System.EventHandler(this.iniciarGrabacionToolStripMenuItem_Click);
            // 
            // terminarGrabacionToolStripMenuItem
            // 
            this.terminarGrabacionToolStripMenuItem.Name = "terminarGrabacionToolStripMenuItem";
            this.terminarGrabacionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.terminarGrabacionToolStripMenuItem.Text = "Terminar Grabacion";
            this.terminarGrabacionToolStripMenuItem.Click += new System.EventHandler(this.terminarGrabacionToolStripMenuItem_Click);
            // 
            // reproducirToolStripMenuItem
            // 
            this.reproducirToolStripMenuItem.Name = "reproducirToolStripMenuItem";
            this.reproducirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reproducirToolStripMenuItem.Text = "Reproducir";
            this.reproducirToolStripMenuItem.Click += new System.EventHandler(this.reproducirToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(737, 520);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listaDeEfectos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.avisoCheck);
            this.Controls.Add(this.avisoBtn);
            this.Controls.Add(this.aviso);
            this.Controls.Add(this.avisoTxt);
            this.Controls.Add(this.listaDePoligonos);
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
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.areaDibujo);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "PAINT";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.areaDibujo)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
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
        private System.Windows.Forms.PictureBox areaDibujo;
        private System.Windows.Forms.ToolStripMenuItem másToolStripMenuItem;
        private System.Windows.Forms.TextBox avisoTxt;
        private System.Windows.Forms.Button avisoBtn;
        private System.Windows.Forms.CheckBox avisoCheck;
        private System.Windows.Forms.BindingSource poligonoBindingSource;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem traslacionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem seleccionarPuntoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puntoAleatorioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mismoEjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem origenToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cualquierPuntoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reflexionToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ejeXToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ejeYToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rectaCualquieraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escalacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mismoEjeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem origenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cualquierPuntoToolStripMenuItem;
        private System.Windows.Forms.Label aviso;
        private System.Windows.Forms.ToolStripMenuItem borrarUltimaLineaToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox listaDePoligonos;
        private System.Windows.Forms.ToolStripMenuItem renombrarPoligonoToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem iniciarDetenerAnimacionToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox listaDeEfectos;
        private System.Windows.Forms.ToolStripMenuItem iniciarGrabacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminarGrabacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reproducirToolStripMenuItem;
    }
}

