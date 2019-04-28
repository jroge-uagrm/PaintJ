using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        bool puedeDibujar,grabando;

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
            puedeDibujar = grabando = false;
            efecto = "nada";
            modificarElementos(false, false, false, "", "", "");
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            areaDibujo.Height = Height - menuStrip1.Height - 45 - menuStrip2.Height;
            areaDibujo.Width = Width - listaDePoligonos.Width;
            listaDePoligonos.Height = Height - menuStrip2.Height - menuStrip1.Height-50;
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
            Refresh();
            Punto punto;
            switch (efecto)
            {
                case "trasladar":
                    punto = new Punto(dibujador.x, dibujador.y, 1);
                    dibujador.trasladarPoligono(punto);
                    aviso.Text = "Poligono trasladado";
                    if (grabando)
                    {
                        dibujador.añadirACola(efecto,punto);
                        actualizarListDeEfectos();
                    }
                    break;
                case "rotarPunto":
                    punto = new Punto(dibujador.x, dibujador.y, 1);
                    dibujador.setPuntoParaRotarPunto(punto);
                    if (grabando)
                    {
                        dibujador.añadirACola(efecto, punto);
                        actualizarListDeEfectos();
                    }
                    break;
                case "escalarPunto":
                    punto = new Punto(dibujador.x, dibujador.y, 1);
                    dibujador.escalarPunto(punto);
                    if (grabando)
                    {
                        dibujador.añadirACola(efecto, punto);
                        actualizarListDeEfectos();
                    }
                    break;
                case "reflexionRecta":
                    if (dibujador.puntoReflexionRecta(false))
                    {
                        modificarElementos(false, true, false, "1", "REFLEXION", "");
                        if (grabando)
                        {
                            dibujador.añadirACola(efecto,dibujador.poligonoAux);
                            actualizarListDeEfectos();
                        }
                    }
                    dibujador.pintar();
                    break;
                default:
                    if (!grabando && puedeDibujar && efecto.CompareTo("nada") == 0)
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
            else if (efecto.CompareTo("escalarPunto") == 0)
            {
                aviso.Text = "Introducir constante :";
                modificarElementos(true, true, true, "", "ESCALAR", "Veces mas Grande");
            }
            else if (efecto.CompareTo("reflexionRecta") != 0)
            {
                efecto = "nada";
                modificarElementos(false, false, false, "", "", "");
            }
        }

        private void areaDibujo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (puedeDibujar)
            {
                dibujador.terminarPoligono();
                actualizarListaDePoligonos();
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            areaDibujo.Refresh();
            dibujador.nuevoObjeto(
                dondeDibujar(),
                tamañoHDondeDibujar(),
                tamañoVDondeDibujar());
            dibujador.pintarEje();
            listaDePoligonos.Items.Clear();
            puedeDibujar = true;
            grabando = false;
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
                            actualizarListaDePoligonos();
                            resultado = "ABIERTO CORRECTAMENTE";
                            grabando = false;
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
            if (a) { avisoTxt.BringToFront(); } else { avisoTxt.SendToBack(); }
            avisoTxt.Text = a1;
            avisoTxt.Location = new Point(
                    aviso.Location.X+aviso.Width,
                    avisoTxt.Location.Y);

            if (b) { avisoBtn.BringToFront(); } else { avisoBtn.SendToBack(); }
            avisoBtn.Text = b1;
            avisoBtn.Location = new Point(
                    avisoTxt.Location.X + avisoTxt.Width,
                    avisoBtn.Location.Y);

            if (c) { avisoCheck.BringToFront(); } else { avisoCheck.SendToBack(); }
            avisoCheck.Text = c1;
            avisoCheck.Checked = false;
            avisoCheck.Location = new Point(
                    avisoBtn.Location.X + avisoBtn.Width,
                    avisoCheck.Location.Y);
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

        private void borrarUltimaLineaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!grabando)
            {
                if (dibujador.borrarUltimoPunto())
                {
                    Refresh();
                    dibujador.pintar();
                    actualizarListaDePoligonos();
                }
            }
            else
            {
                aviso.Text = "Grabando, no puede borrar";
            }
        }

        private void avisoCheck_CheckedChanged(object sender, EventArgs e)
        {
            switch (efecto)
            {
                case "escalarOrigen":
                    avisoCheck.Text = avisoCheck.Checked ? "Veces mas Pequeño": "Veces mas Grande";
                    break;
                case "escalarEje":
                    avisoCheck.Text = avisoCheck.Checked ? "Veces mas Pequeño" : "Veces mas Grande";
                    break;
                case "escalarPunto":
                    avisoCheck.Text = avisoCheck.Checked ? "Veces mas Pequeño" : "Veces mas Grande";
                    break;
                default:
                    break;
            }
        }

        private void avisoBtn_Click(object sender, EventArgs e)
        {
            Refresh();
            Punto punto;
            double numero = 0;
            try
            {
                if (efecto.CompareTo("nuevoNombre") != 0)
                {
                    numero = Convert.ToDouble(avisoTxt.Text.ToString());
                }
                switch (efecto)
                {
                    case "rotarMismoEje":
                        numero = avisoCheck.Checked ? numero * (-1) : numero;
                        dibujador.rotarEje(numero);
                        aviso.Text = "Poligono rotado";
                        if (grabando)
                        {
                            dibujador.añadirACola(efecto, (float)numero);
                            actualizarListDeEfectos();
                        }
                        break;
                    case "rotarOrigen":
                        numero = avisoCheck.Checked ? numero * (-1) : numero;
                        dibujador.rotarOrigenPoligono(numero);
                        aviso.Text = "Poligono rotado";
                        if (grabando)
                        {
                            dibujador.añadirACola(efecto, (float)numero);
                            actualizarListDeEfectos();
                        }
                        break;
                    case "rotarPunto":
                        numero = avisoCheck.Checked ? numero * (-1) : numero;
                        dibujador.rotarPunto(numero);
                        aviso.Text = "Poligono rotado";
                        if (grabando)
                        {
                            dibujador.añadirACola(efecto, (float)numero);
                            actualizarListDeEfectos();
                        }
                        break;
                    case "escalarEje":
                        numero = avisoCheck.Checked ? 1 / numero : numero;
                        dibujador.escalarEje(numero);
                        aviso.Text = "Poligono escalado";
                        if (grabando)
                        {
                            dibujador.añadirACola(efecto, (float)numero);
                            actualizarListDeEfectos();
                        }
                        break;
                    case "escalarOrigen":
                        numero = avisoCheck.Checked ? 1 / numero : numero;
                        dibujador.escalarOrigen(numero);
                        aviso.Text = "Poligono escalado";
                        if (grabando)
                        {
                            dibujador.añadirACola(efecto, (float)numero);
                            actualizarListDeEfectos();
                        }
                        break;
                    case "reflexionRecta":
                        dibujador.puntoReflexionRecta(true);
                        aviso.Text = "Reflexion completa";
                        break;
                    case "escalarPunto":
                        numero = avisoCheck.Checked ? 1 / numero : numero;
                        dibujador.escalarPunto(numero);
                        aviso.Text = "Poligono escalado";
                        if (grabando)
                        {
                            dibujador.añadirACola(efecto, (float)numero);
                            actualizarListDeEfectos();
                        }
                        break;
                    case "nuevoNombre":
                        int indice = listaDePoligonos.SelectedIndex;
                        if (indice >= 0)
                        {
                            string nombre = avisoTxt.Text.ToString();
                            if (nombre.CompareTo("") == 0)
                            {
                                throw new Exception("Debe ingresar un nombre");
                            }
                            else
                            {
                                dibujador.setNombre(indice, nombre);
                                actualizarListaDePoligonos();
                                aviso.Text = "Cambio de nombre exitoso";
                            }
                        }
                        else
                        {
                            throw new Exception("Debe seleccionar un poligono");
                        }
                        break;
                    default:
                        aviso.Text = "NADA";
                        break;
                }
                modificarElementos(false, false, false, "", "", "");
                efecto = "nada";
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR : "+ex.Message);
            }
            finally
            {
                dibujador.pintar();
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

        private void puntoAleatorioToolStripMenuItem_Click_1(object sender, EventArgs e)
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

        private void mismoEjeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (esPosible())
            {
                aviso.Text = "Introducir grados a rotar :";
                modificarElementos(true, true, true, "", "ROTAR", "Sentido HORARIO");
                efecto = "rotarMismoEje";
            }
        }

        private void origenToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (esPosible())
            {
                aviso.Text = "Introducir grados a rotar :";
                modificarElementos(true, true, true, "", "ROTAR", "Sentido HORARIO");
                efecto = "rotarOrigen";
            }
        }

        private void cualquierPuntoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (esPosible())
            {
                aviso.Text = "Seleccionar punto base :";
                efecto = "rotarPunto";
                modificarElementos(false, false, false, "", "", "");
            }
        }

        private void ejeXToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void ejeYToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void rectaCualquieraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (esPosible())
            {
                aviso.Text = "Dibuje la recta";
                efecto = "reflexionRecta";
                modificarElementos(false, false, false, "", "", "");
            }
        }

        private void mismoEjeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (esPosible())
            {
                efecto = "escalarEje";
                aviso.Text = "Introducir una constante :";
                modificarElementos(true, true, true, "", "ESCALAR", "Veces mas Grande");
            }
        }

        private void origenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (esPosible())
            {
                aviso.Text = "Introducir una constante :";
                efecto = "escalarOrigen";
                modificarElementos(true, true, true, "", "ESCALAR", "Veces mas Grande");
            }
        }

        private void cualquierPuntoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (esPosible())
            {
                efecto = "escalarPunto";
                aviso.Text = "Seleccione un punto para escalar";
                modificarElementos(false, false, false, "", "", "");
            }
        }

        private void listaDePoligonos_SelectedIndexChanged(object sender, EventArgs e)
        {
            dibujador.objeto.setPuntoEnCentro();
            int indiceDePoligonoSeleccionado = listaDePoligonos.SelectedIndex;
            listaDePoligonos.SetItemChecked(indiceDePoligonoSeleccionado, true);
            dibujador.setIndice(indiceDePoligonoSeleccionado);
            foreach (int indexChecked in listaDePoligonos.CheckedIndices)
            {
                if (indexChecked != indiceDePoligonoSeleccionado)
                {
                    listaDePoligonos.SetItemChecked(indexChecked, false);
                }
            }
        }

        private void actualizarListaDePoligonos()
        {
            listaDePoligonos.Items.Clear();
            int cantidadDePoligonos = dibujador.cantidadDePoligonos();
            for(int i = 1; i <= cantidadDePoligonos; i++)
            {
                listaDePoligonos.Items.Add(dibujador.objeto.getPoligono(i-1));
            }
        }

        private void actualizarListDeEfectos()
        {
            listaDeEfectos.Items.Clear();
            int cantidadDeEfectos = dibujador.listDeEfectos.Count;
            for (int i = 1; i <= cantidadDeEfectos; i++)
            {
                listaDeEfectos.Items.Add(dibujador.listDeEfectos.ElementAt(i-1));
            }
        }

        private void renombrarPoligonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (esPosible())
            {
                aviso.Text = "Seleccione el poligono e ingrese nuevo nombre :";
                modificarElementos(true, true, false, "", "MODIFICAR", "");
                efecto = "nuevoNombre";
            }
        }

        private void iniciarGrabacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (esPosible())
            {
                grabando = true;
                aviso.Text = "Grabacion iniciada";
                dibujador.nuevaListaDeEfectos();
                dibujador.objeto.listaDePoligonos.Last().setPuntoReferenciaEnCentro();
                dibujador.añadirACola("trasladar",
                    dibujador.objeto.getPoligono(
                        dibujador.objeto.listaDePoligonos.Count-1).puntoReferencia);
            }
        }

        private void terminarGrabacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (esPosible())
            {
                grabando = false;
                aviso.Text = "Grabacion terminada";
            }
        }

        private void reproducirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 1;
            Efecto efecto;
            if (!grabando)
            {
                aviso.Text = "Detener: ";
                modificarElementos(false, true,false, "","Detener","");
                while (i <= dibujador.listDeEfectos.Count)
                {
                    Thread.Sleep(1000);
                    Refresh();
                    efecto = dibujador.getEfecto(i - 1);
                    dibujador.objeto.setIndice(efecto.indice);
                    switch (efecto.nombre)
                    {
                        case "trasladar":
                            dibujador.objeto.trasladarPoligono(efecto.punto);
                            break;
                        case "rotarEje":
                            dibujador.objeto.rotarEje(efecto.numero);
                            break;
                        case "rotarOrigen":
                            dibujador.objeto.rotarOrigen(efecto.numero);
                            break;
                        case "rotarPunto":
                            dibujador.objeto.setPuntoParaRotarPunto(efecto.punto);
                            i++;
                            efecto = dibujador.getEfecto(i - 1);
                            dibujador.objeto.rotarPunto(efecto.numero);
                            break;
                        default:
                            break;
                    }
                    if (i == dibujador.listDeEfectos.Count)
                    {
                        i = 0;
                    }
                    i++;
                    dibujador.pintar();
                }
            }
            else
            {
                aviso.Text = "Debe dejar de grabar";
            }
        }

        private void listaDePoligonos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dibujador.setIndice(-1);
            foreach (int indexChecked in listaDePoligonos.CheckedIndices)
            {
                    listaDePoligonos.SetItemChecked(indexChecked, false);
            }
        }
    }
}






