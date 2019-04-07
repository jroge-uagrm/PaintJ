using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PaintJ
{
    [Serializable]
    public partial class Form1 : Form
    {
        Painter dibujador;
        int a, b;
        public Form1()
        {
            InitializeComponent();
            dibujador = new Painter(
                areaDibujo.CreateGraphics(),
                areaDibujo.Width,
                areaDibujo.Height);
            texto.Text = dibujador.puedeDibujar();
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            texto.Text=dibujador.guardar();
        }

        private void abrir_Click(object sender, EventArgs e)
        {
            areaDibujo.Image = null;
            texto.Text=dibujador.abrir();   
        }

        private void nuevo_Click(object sender, EventArgs e)
        {
            areaDibujo.Image = null;
            dibujador = new Painter(areaDibujo.CreateGraphics(), Width, Height);
            dibujador.dibujar = true;
            texto.Text = dibujador.puedeDibujar();
        }

        private void areaDibujo_MouseMove_1(object sender, MouseEventArgs e)
        {
            base.OnMouseHover(e);
            a = e.X;
            b = e.Y;
            int H = areaDibujo.Width;
            int V = areaDibujo.Height;
            dibujador.x = ((float)((float)(a * 100) / H)-50)*2;
            dibujador.y = (((float)((float)(V / 2) - b) * 100) / H)*2;
            dibujador.a = (int)((float)((float)((float)(dibujador.x/2)+50)*H)/100);
            dibujador.b = (V / 2) - (int)((float)((float)(dibujador.y / 2) * H) / 100);
            textBox1.Text = a.ToString();
            textBox2.Text = b.ToString();

            textBox5.Text = dibujador.x.ToString();
            textBox6.Text = dibujador.y.ToString();
            textBox7.Text = dibujador.a.ToString();
            textBox8.Text = dibujador.b.ToString();
        }

        private void areaDibujo_MouseClick(object sender, MouseEventArgs e)
        {
            dibujador.dibujarLinea(a, b);
        }

        private void areaDibujo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dibujador.finalizarPoligono();
        }

        private void areaDibujo_SizeChanged(object sender, EventArgs e)
        {
            dibujador.H = areaDibujo.Width;
            dibujador.V = areaDibujo.Height;
            dibujador.pintar();
        }

        private void dibujar_Click(object sender, EventArgs e)
        {
            dibujador.vaADibujar();
            texto.Text = dibujador.puedeDibujar();
        }
    }
}
