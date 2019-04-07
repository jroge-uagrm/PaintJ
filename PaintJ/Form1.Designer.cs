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
            this.dibujar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.guardar = new System.Windows.Forms.Button();
            this.texto = new System.Windows.Forms.Label();
            this.abrir = new System.Windows.Forms.Button();
            this.nuevo = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.areaDibujo = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.areaDibujo)).BeginInit();
            this.SuspendLayout();
            // 
            // dibujar
            // 
            this.dibujar.AutoSize = true;
            this.dibujar.CausesValidation = false;
            this.dibujar.Location = new System.Drawing.Point(235, 502);
            this.dibujar.Name = "dibujar";
            this.dibujar.Size = new System.Drawing.Size(63, 23);
            this.dibujar.TabIndex = 0;
            this.dibujar.Text = "DIBUJAR";
            this.dibujar.UseVisualStyleBackColor = true;
            this.dibujar.Click += new System.EventHandler(this.dibujar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(23, 502);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(129, 503);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(235, 532);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(227, 33);
            this.guardar.TabIndex = 5;
            this.guardar.Text = "GUARDAR";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // texto
            // 
            this.texto.AutoSize = true;
            this.texto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texto.Location = new System.Drawing.Point(399, 9);
            this.texto.Name = "texto";
            this.texto.Size = new System.Drawing.Size(73, 25);
            this.texto.TabIndex = 6;
            this.texto.Text = "PAINT";
            // 
            // abrir
            // 
            this.abrir.Location = new System.Drawing.Point(468, 532);
            this.abrir.Name = "abrir";
            this.abrir.Size = new System.Drawing.Size(204, 33);
            this.abrir.TabIndex = 7;
            this.abrir.Text = "ABRIR";
            this.abrir.UseVisualStyleBackColor = true;
            this.abrir.Click += new System.EventHandler(this.abrir_Click);
            // 
            // nuevo
            // 
            this.nuevo.Location = new System.Drawing.Point(597, 502);
            this.nuevo.Name = "nuevo";
            this.nuevo.Size = new System.Drawing.Size(75, 21);
            this.nuevo.TabIndex = 8;
            this.nuevo.Text = "NUEVO";
            this.nuevo.UseVisualStyleBackColor = true;
            this.nuevo.Click += new System.EventHandler(this.nuevo_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(129, 528);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 10;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(23, 527);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 9;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(678, 501);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 12;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(784, 499);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 13;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(678, 524);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 20);
            this.textBox7.TabIndex = 14;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(784, 524);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 20);
            this.textBox8.TabIndex = 15;
            // 
            // areaDibujo
            // 
            this.areaDibujo.Dock = System.Windows.Forms.DockStyle.Top;
            this.areaDibujo.Location = new System.Drawing.Point(0, 0);
            this.areaDibujo.Name = "areaDibujo";
            this.areaDibujo.Size = new System.Drawing.Size(927, 485);
            this.areaDibujo.TabIndex = 11;
            this.areaDibujo.TabStop = false;
            this.areaDibujo.SizeChanged += new System.EventHandler(this.areaDibujo_SizeChanged);
            this.areaDibujo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.areaDibujo_MouseClick);
            this.areaDibujo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.areaDibujo_MouseDoubleClick);
            this.areaDibujo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.areaDibujo_MouseMove_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(304, 502);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 21);
            this.button1.TabIndex = 16;
            this.button1.Text = "ROTAR POLIGONO";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(468, 503);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 21);
            this.button2.TabIndex = 17;
            this.button2.Text = "ROTAR PARTE";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(927, 567);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.texto);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.areaDibujo);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.nuevo);
            this.Controls.Add(this.abrir);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dibujar);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.areaDibujo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.Label texto;
        private System.Windows.Forms.Button abrir;
        private System.Windows.Forms.Button nuevo;
        public System.Windows.Forms.Button dibujar;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.PictureBox areaDibujo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

