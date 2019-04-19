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
using static System.Windows.Forms.CheckedListBox;

namespace PaintJ
{
    [Serializable]
    public partial class Form1 : Form
    {
        Painter dibujador;
        String efecto;
        bool puedeDibujar;
        public Form1()
        {
            InitializeComponent();
        }

        public int tamañoHDondeDibujar()
        {
            return areaDibujo.Width;
        }
        public int tamañoVDondeDibujar()
        {
            return areaDibujo.Height;
        }
        public Graphics dondeDibujar()
        {
            return areaDibujo.CreateGraphics();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = tamañoHDondeDibujar().ToString();
            textBox2.Text = tamañoVDondeDibujar().ToString();
            areaDibujo.Height = Height - menuStrip1.Height - 45;
            dibujador = new Painter(
                tamañoHDondeDibujar(),
                tamañoVDondeDibujar());
            puedeDibujar = false;
            efecto = "nada";
            avisoTxt.Visible = false;
            avisoBtn.Visible = false;
            avisoCheck.Visible = false;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            areaDibujo.Height = Height - menuStrip1.Height - 45;
            Refresh();
            Objeto obj = dibujador.objeto;
            if (dibujador.noEstaVacio())
            {
                dibujador.nuevoObjeto(
                    dondeDibujar(),
                    tamañoHDondeDibujar(),
                    tamañoVDondeDibujar());
                dibujador.setObjeto(obj);
                dibujador.pintar();
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            textBox1.Text = tamañoHDondeDibujar().ToString();
            textBox2.Text = tamañoVDondeDibujar().ToString();
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (puedeDibujar)
            {
                dibujador.terminarPoligono();
            }
        }

        private void areaDibujo_MouseMove(object sender, MouseEventArgs e)
        {
            dibujador.coordenadas(e.X, e.Y);
            textBox5.Text = dibujador.x.ToString();
            textBox6.Text = dibujador.y.ToString();
            textBox3.Text = dibujador.a.ToString();
            textBox4.Text = dibujador.b.ToString();
        }

        private void areaDibujo_MouseClick(object sender, MouseEventArgs e)
        {
            Form1_MouseClick(sender, e);
        }

        private void areaDibujo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1_MouseDoubleClick(sender, e);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            areaDibujo.Refresh();
            dibujador.nuevoObjeto(
                dondeDibujar(),
                tamañoHDondeDibujar(),
                tamañoVDondeDibujar());
            dibujador.pintarEje();
            puedeDibujar = true;
            aviso.Text = "Puede empezar a dibujar";
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String resultado = "";
            try
            {
                using (System.Windows.Forms.OpenFileDialog dialogo =
                    new System.Windows.Forms.OpenFileDialog())
                {
                    if (dialogo.ShowDialog() ==
                        System.Windows.Forms.DialogResult.OK)
                    {
                        using (Stream st = File.Open(
                            dialogo.FileName, FileMode.Open))
                        {
                            var binfor = new System.Runtime.
                                Serialization.Formatters.
                                Binary.BinaryFormatter();
                            Objeto obj = (Objeto)binfor.Deserialize(st);
                            Refresh();
                            nuevoToolStripMenuItem_Click(sender, e);
                            dibujador.setObjeto(obj);
                            dibujador.pintar();
                            resultado = "ABIERTO CORRECTAMENTE";
                        }
                    }
                    else
                    {
                        resultado = "OPERACION CANCELADA";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = "ERROR AL ABRIR EL ARCHIVO : "+ex.Message;
            }
            finally
            {
                aviso.Text = resultado;
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String resultado = "";
            try
            {
                if (dibujador.noEstaVacio())
                {
                    using (System.Windows.Forms.SaveFileDialog dialogo =
                    new System.Windows.Forms.SaveFileDialog())
                    {
                        if (dialogo.ShowDialog() ==
                            System.Windows.Forms.DialogResult.OK)
                        {
                            using (Stream st = File.Open(
                                dialogo.FileName, FileMode.Create))
                            {
                                var binfor = new System.Runtime.
                                    Serialization.Formatters.
                                    Binary.BinaryFormatter();
                                binfor.Serialize(st, dibujador.objeto);
                                resultado = "GUARDADO CORRECTAMENTE";
                            }
                        }
                        else
                        {
                            resultado = "OPERACION CANCELADA";
                        }
                    }
                }
                else
                {
                    resultado = "NADA PARA GUARDAR";
                }
            }
            catch (Exception ex)
            {
                resultado = "ERROR AL GUARDAR EL ARCHIVO : "+ex.Message;
            }
            finally
            {
                aviso.Text = resultado;
            }
        }

        private void modificarElementos(
            bool a, bool b, bool c,
            string a1, string b1, string c1)
        {
            avisoTxt.Visible = a;
            if (a) { avisoTxt.BringToFront(); } else { avisoTxt.SendToBack(); }
            avisoTxt.Text = a1;
            avisoTxt.Location = new Point(
                        aviso.Width + 1,
                        menuStrip1.Height + menuStrip1.Location.Y);

            avisoBtn.Visible = b;
            if (b) { avisoBtn.BringToFront(); } else { avisoBtn.SendToBack(); }
            avisoBtn.Text = b1;
            avisoBtn.Location = new Point(
                avisoTxt.Width + avisoTxt.Location.X + 1,
                menuStrip1.Height + menuStrip1.Location.Y);

            avisoCheck.Visible = c;
            if (c) { avisoCheck.BringToFront(); } else { avisoCheck.SendToBack(); }
            avisoCheck.Text = c1;
            avisoCheck.Checked = false;
            avisoCheck.Location = new Point(
                avisoBtn.Width + avisoBtn.Location.X + 1,
                menuStrip1.Height + menuStrip1.Location.Y);
        }

        private bool esPosible()
        {
            if (dibujador.noEstaVacio())
            {
                if (dibujador.objeto.poligonoTerminado)
                {
                    return true;
                }
                else
                {
                    aviso.Text = "Debe terminar el poligono";
                }
            }
            else
            {
                aviso.Text = "No hay dibujo";
            }
            return false;
        }

        private void borrarLineaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dibujador.borrarUltimoPunto())
            {
                Refresh();
                dibujador.pintar();
            }
        }

        private void avisoCheck_CheckedChanged(object sender, EventArgs e)
        {
            switch (efecto)
            {
                case "escalarOrigen":
                    if (avisoCheck.Checked)
                    {
                        avisoCheck.Text = "Veces mas Pequeño";
                    }
                    else
                    {
                        avisoCheck.Text = "Veces mas Grande";
                    }
                    break;
                case "escalarEje":
                    if (avisoCheck.Checked)
                    {
                        avisoCheck.Text = "Veces mas Pequeño";
                    }
                    else
                    {
                        avisoCheck.Text = "Veces mas Grande";
                    }
                    break;
                default:
                    break;
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Refresh();
            switch (efecto)
            {
                case "trasladar":
                    dibujador.trasladarPoligono(
                        new Punto(dibujador.x, dibujador.y, 1));
                    aviso.Text = "Poligono trasladado, puede seguir dibujando";
                    break;
                case "rotarPunto":
                    dibujador.setPuntoParaRotarPunto(new Punto(
                        dibujador.x,dibujador.y,1));
                    break;
                default:
                    if (puedeDibujar)
                    {
                        dibujador.añadirPunto();
                    }
                    break;
            }
            if (dibujador.noEstaVacio())
            {
                dibujador.pintar();
            }
            if (efecto.CompareTo("rotarPunto") == 0)
            {
                aviso.Text = "Introducir grados a rotar :";
                modificarElementos(true, true, true, "", "ROTAR", "Sentido HORARIO");
            }
            else
            {
                efecto = "nada";
                modificarElementos(false, false, false, "", "", "");
            }
            
        }

        private void avisoBtn_Click(object sender, EventArgs e)
        {
            Refresh();
            try
            {
                double numero = Convert.ToDouble(avisoTxt.Text.ToString());
                numero = avisoCheck.Checked ? numero * (-1) : numero;
                switch (efecto)
                {
                    case "rotarMismoEje":
                        dibujador.rotarEje(numero);
                        aviso.Text = "Poligono rotado, puede seguir dibujando";
                        break;
                    case "rotarOrigen":
                        dibujador.rotarOrigenPoligono(numero);
                        aviso.Text = "Poligono rotado, puede seguir dibujando";
                        break;
                    case "rotarPunto":
                        dibujador.rotarPunto(numero);
                        aviso.Text = "Poligono rotado, puede seguir dibujando";
                        break;
                    case "escalarEje":
                        dibujador.escalarEje(numero);
                        aviso.Text = "Poligono escalado, puede seguir dibujando";
                        break;
                    case "escalarOrigen":
                        dibujador.escalarOrigen(numero);
                        aviso.Text = "Poligono escalado, puede seguir dibujando";
                        break;
                    default:
                        break;
                }
                dibujador.pintar();
                modificarElementos(false, false, false, "", "", "");
                efecto = "nada";
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR : "+ex.Message);
            }
        }

        private void seleccionarPuntoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (esPosible())
            {
                aviso.Text = "Seleccione donde trasladar";
                efecto = "trasladar";
                modificarElementos(false, false, false, "", "", "");
            }
        }

        private void puntoAleatorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (esPosible())
            {
                Refresh();
                dibujador.trasladarAleatorioPoligono();
                dibujador.pintar();
                aviso.Text = "Poligono trasladado";
                modificarElementos(false, false, false, "", "", "");
            }
        }

        private void mismoEjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (esPosible())
            {
                aviso.Text = "Introducir grados a rotar :";
                modificarElementos(true, true, true, "", "ROTAR", "Sentido HORARIO");
                efecto = "rotarMismoEje";
            }
        }

        private void respectoAlOrigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (esPosible())
            {
                aviso.Text = "Introducir grados a rotar :";
                modificarElementos(true, true, true, "", "ROTAR", "Sentido HORARIO");
                efecto = "rotarOrigen";
            }
        }

        private void respectoAUnPuntoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (esPosible())
            {
                aviso.Text = "Seleccionar punto base :";
                efecto = "rotarPunto";
                modificarElementos(false, false, false, "", "", "");
            }
        }

        private void origenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (esPosible())
            {
                efecto = "escalarEje";
                aviso.Text = "Introducir una constante :";
                modificarElementos(true, true, true, "", "ESCALAR", "Veces mas Grande");
            }
        }

        private void origenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (esPosible())
            {
                aviso.Text = "Introducir una constante :";
                efecto = "escalarOrigen";
                modificarElementos(true, true, true, "", "ESCALAR", "Veces mas Grande");
            }
        }

        private void ejeXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (esPosible())
            {
                dibujador.reflexionX();
                Refresh();
                dibujador.pintar();
                aviso.Text = "Reflexion en X completa, puede seguir dibujando";
                modificarElementos(false, false, false, "", "", "");
            }
        }

        private void ejeYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (esPosible())
            {
                dibujador.reflexionY();
                Refresh();
                dibujador.pintar();
                aviso.Text = "Reflexion en Y completa, puede seguir dibujando";
                modificarElementos(false, false, false, "", "", "");
            }
        }

    }
}

