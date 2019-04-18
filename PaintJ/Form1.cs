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
            areaDibujo.Refresh();
            Objeto obj = dibujador.objeto;
            dibujador.nuevoObjeto(
                    dondeDibujar(),
                    tamañoHDondeDibujar(),
                    tamañoVDondeDibujar());
            dibujador.setObjeto(obj);
            if (dibujador.noEstaVacio())
            {
                dibujador.pintar();
            }
            dibujador.pintarEje();
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
            textBox3.Text = e.X.ToString();
            textBox4.Text = e.Y.ToString();
            dibujador.coordenadas(e.X, e.Y);
            textBox5.Text = dibujador.x.ToString();
            textBox6.Text = dibujador.y.ToString();
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
            String resultado="";
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
                            nuevoToolStripMenuItem_Click(sender, e);
                            dibujador.setObjeto(obj);
                            dibujador.pintar();
                            dibujador.pintarEje();
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
                resultado = "ERROR AL ABRIR EL ARCHIVO";
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
                    dibujador.terminarPoligono();
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
                resultado = "ERROR AL GUARDAR EL ARCHIVO";
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

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Refresh();
            switch (efecto)
            {
                case "trasladar":
                    dibujador.trasladarPoligono();
                    dibujador.pintar();
                    aviso.Text = "Poligono trasladado, puede seguir dibujando";
                    break;
                case "rotarPunto":
                    //dibujador.rotarPuntoPoligono();
                    //rotarPoligonoAnguloToolStripMenuItem_Click(sender, e);
                    break;
                default:
                    if (puedeDibujar)
                    {
                        dibujador.añadirPunto();
                        dibujador.pintar();
                    }
                    break;
            }
            efecto = "nada";
        }

        private void avisoBtn_Click(object sender, EventArgs e)
        {
            switch (efecto)
            {
                case "rotarMismoEje":
                    try
                    {
                        Double angulo = Convert.ToDouble(avisoTxt.Text.ToString());
                        angulo = avisoCheck.Checked == false ? angulo*(-1) : angulo;
                        Refresh();
                        dibujador.rotarPoligono(angulo);
                        aviso.Text = "Poligono rotado, puede seguir dibujando";
                        efecto = "nada";
                    }
                    catch (FormatException es)
                    {
                        MessageBox.Show("DATO INCORRECTO");
                    }
                    catch (OverflowException ex)
                    {
                        MessageBox.Show("NUMERO DEMASIADO GRANDE");
                    }
                    break;
                case "escalarOrigen":
                    try
                    {
                        double escala = Convert.ToDouble(avisoTxt.Text);
                        dibujador.escalarOrigen(escala);
                        aviso.Text = "Poligono escalado, puede seguir dibujando";
                        efecto = "nada";
                    }
                    catch (Exception ex)
                    {
                        aviso.Text = "DATO INCORRECTO";
                    }
                    break;
                case "escalar":
                    try
                    {
                        double escala = Convert.ToDouble(avisoTxt.Text);
                        dibujador.escalar(escala);
                        aviso.Text = "Poligono escalado, puede seguir dibujando";
                        efecto = "nada";
                    }
                    catch (Exception ex)
                    {
                        aviso.Text = "DATO INCORRECTO";
                    }
                    break;
                case "reflexionEje":
                    if (avisoCheck.Checked)
                    {
                        dibujador.reflexion(new Punto(-1, 0, 1), new Punto(1, 0, 1));
                    }
                    else
                    {
                        dibujador.reflexion(new Punto(0, -1, 1), new Punto(0, 1, 1));
                    }
                    aviso.Text = "Poligono escalado, puede seguir dibujando";
                    puedeDibujar = true;
                    efecto = "nada";
                    break;
                default:
                    break;
            }
            Objeto obj = dibujador.objeto;
            nuevoToolStripMenuItem_Click(sender, e);
            dibujador.nuevoObjeto(
                dondeDibujar(),
                tamañoHDondeDibujar(),
                    tamañoVDondeDibujar());
                dibujador.setObjeto(obj);
                dibujador.pintar();
                modificarElementos(false, false, false, "", "", "");
            puedeDibujar = true;
        }

        private void seleccionarPuntoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (esPosible())
            {
                aviso.Text = "Seleccione donde trasladar";
                efecto = "trasladar";
            }
        }

        private void puntoAleatorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (esPosible())
            {
                dibujador.trasladarAleatorioPoligono();
                aviso.Text = "Poligono trasladado";
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
    }
}

