using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace PaintJ
{
    [Serializable]
    public partial class Form1 : Form{

        #region variablesGlobales
        Painter dibujador;
        Objeto objetoInicial;
        string efecto;
        bool puedeDibujar,grabando;
        int i;
        #endregion

        #region inicializadores
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
        #endregion

        #region clicks
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
                        dibujador.añadirACola(efecto, punto);
                        actualizarListaDeEfectos();
                    }
                    break;
                case "rotarPunto":
                    punto = new Punto(dibujador.x, dibujador.y, 1);
                    dibujador.setPuntoParaRotarPunto(punto);
                    if (grabando)
                    {
                        dibujador.añadirACola(efecto, punto);
                        actualizarListaDeEfectos();
                    }
                    break;
                case "escalarPunto":
                    punto = new Punto(dibujador.x, dibujador.y, 1);
                    dibujador.escalarPunto(punto);
                    if (grabando)
                    {
                        dibujador.añadirACola(efecto, punto);
                        actualizarListaDeEfectos();
                    }
                    break;
                case "reflexionRecta":
                    if (dibujador.puntoReflexionRecta(false))
                    {
                        modificarElementos(false, true, false, "1", "REFLEXION", "");
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
                desmarcarlistaDeEfectos();
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
            listaDeEfectos.Items.Clear();
            puedeDibujar = true;
            grabando = false;
            timer.Enabled = false;
            aviso.Text = "Puede empezar a dibujar";
            //ANIMACION
            listaDePoligonos.Items.Clear();
            listaDeEfectos.Items.Clear();
            puedeDibujar = true;
            grabando = false;
            timer.Enabled = false;
            aviso.Text = "Puede empezar a dibujar";
            //CABEZA    (0)
            dibujador.objeto.añadirPunto(new Punto(-90, 50, 1));
            dibujador.objeto.añadirPunto(new Punto(-80, 50, 1));
            dibujador.objeto.añadirPunto(new Punto(-80, 40, 1));
            dibujador.objeto.añadirPunto(new Punto(-90, 40, 1));
            dibujador.objeto.añadirPunto(new Punto(-90, 50, 1));
            dibujador.terminarPoligono();
            dibujador.setNombre(0,"CABEZA");
            //CUERPO    (1)
            dibujador.objeto.añadirPunto(new Punto(-85, 40, 1));
            dibujador.objeto.añadirPunto(new Punto(-85, 20, 1));
            dibujador.terminarPoligono();
            dibujador.setNombre(1,"CUERPO");
            //PIERNA 1  (2)
            dibujador.objeto.añadirPunto(new Punto(-85, 20, 1));
            dibujador.objeto.añadirPunto(new Punto(-87, 11, 1));
            dibujador.terminarPoligono();
            dibujador.setNombre(2,"PIERNA 1");
            //PIE 1     (3)
            dibujador.objeto.añadirPunto(new Punto(-87, 11, 1));
            dibujador.objeto.añadirPunto(new Punto(-91, 3, 1));
            dibujador.objeto.añadirPunto(new Punto(-88, (float)1.5, 1));
            dibujador.terminarPoligono();
            dibujador.setNombre(3,"PIE 1");
            //PIERNA 2  (4)
            dibujador.objeto.añadirPunto(new Punto(-85, 20, 1));
            dibujador.objeto.añadirPunto(new Punto(-83, 11, 1));
            dibujador.terminarPoligono();
            dibujador.setNombre(4,"PIERNA 2");
            //PIE 2     (5)
            dibujador.objeto.añadirPunto(new Punto(-83, 11, 1));
            dibujador.objeto.añadirPunto(new Punto(-81, 1, 1));
            dibujador.objeto.añadirPunto(new Punto(-78, (float)1.5, 1));
            dibujador.terminarPoligono();
            dibujador.setNombre(5,"PIE 2");
            //BRAZO 1   (6)
            dibujador.objeto.añadirPunto(new Punto(-85, 35, 1));
            dibujador.objeto.añadirPunto(new Punto(-87, 26, 1));
            dibujador.objeto.añadirPunto(new Punto(-86, 21, 1));
            dibujador.terminarPoligono();
            dibujador.setNombre(6,"BRAZO 1");
            //BRAZO 2   (7)
            dibujador.objeto.añadirPunto(new Punto(-85, 35, 1));
            dibujador.objeto.añadirPunto(new Punto(-84, 25, 1));
            dibujador.objeto.añadirPunto(new Punto(-82, 21, 1));
            dibujador.terminarPoligono();
            dibujador.setNombre(07,"BRAZO 2");
            dibujador.pintar();
            actualizarListaDePoligonos();
            
            //BASE TERMINADA

            dibujador.nuevaListaDeEfectos();
            dibujador.nuevaListaDeIndices();
            dibujador.addIndice(0);dibujador.addIndice(1);dibujador.addIndice(2);
            dibujador.addIndice(4);dibujador.addIndice(6);dibujador.addIndice(7);
            Punto centro = dibujador.objeto.getCentroDeListas();
            //ROTAR PIE DELANTERO PARA ENRECTAR 1
            dibujador.nuevaListaDeIndices();
            dibujador.addIndice(5);
            dibujador.añadirACola("rotarPunto",dibujador.objeto.listaDePoligonos.ElementAt(5).listaDePuntos.ElementAt(1));
            dibujador.añadirACola("rotarPunto",-4);
            //ROTAR PIERNA DELANTERA PARA IGUALAR AL PIE DELANTERO 1
            dibujador.nuevaListaDeIndices();
            dibujador.addIndice(4);
            dibujador.añadirACola("rotarPunto",dibujador.objeto.listaDePoligonos.ElementAt(4).listaDePuntos.ElementAt(0));
            dibujador.añadirACola("rotarPunto",3);
            //   MOVER 1
            dibujador.nuevaListaDeIndices();
            dibujador.addIndice(0);dibujador.addIndice(1);dibujador.addIndice(2);
            dibujador.addIndice(4);dibujador.addIndice(6);dibujador.addIndice(7);
            dibujador.añadirACola("trasladar",new Punto(centro.x+(float)0.1,centro.y-(float)0.1,1));
            //ROTAR PIE TRASERO PARA AVANZAR 1
            dibujador.nuevaListaDeIndices();
            dibujador.addIndice(3);
            dibujador.añadirACola("rotarPunto",dibujador.objeto.listaDePoligonos.ElementAt(3).listaDePuntos.ElementAt(1));
            dibujador.añadirACola("rotarPunto",-3);
            //ROTAR PIERNA TRASERA PARA IGUALAR AL PIE TRASERO 1
            dibujador.nuevaListaDeIndices();
            dibujador.addIndice(2);
            dibujador.añadirACola("rotarPunto",dibujador.objeto.listaDePoligonos.ElementAt(2).listaDePuntos.ElementAt(0));
            dibujador.añadirACola("rotarPunto",2);
            //ROTAR BRAZO TRASERO 1
            dibujador.nuevaListaDeIndices();
            dibujador.addIndice(6);
            dibujador.añadirACola("rotarPunto",dibujador.objeto.listaDePoligonos.ElementAt(6).listaDePuntos.ElementAt(0));
            dibujador.añadirACola("rotarPunto",(float)-0.5);
            //ROTAR BRAZO DELANTERO 1
            dibujador.nuevaListaDeIndices();
            dibujador.addIndice(7);
            dibujador.añadirACola("rotarPunto",dibujador.objeto.listaDePoligonos.ElementAt(7).listaDePuntos.ElementAt(0));
            dibujador.añadirACola("rotarPunto",5);

            //ROTAR PIE DELANTERO PARA ENRECTAR 2
            dibujador.nuevaListaDeIndices();
            dibujador.addIndice(5);
            dibujador.añadirACola("rotarPunto",dibujador.objeto.listaDePoligonos.ElementAt(5).listaDePuntos.ElementAt(1));
            dibujador.añadirACola("rotarPunto",-4);
            //ROTAR PIERNA DELANTERA PARA IGUALAR AL PIE DELANTERO 2
            dibujador.nuevaListaDeIndices();
            dibujador.addIndice(4);
            dibujador.añadirACola("rotarPunto",dibujador.objeto.listaDePoligonos.ElementAt(4).listaDePuntos.ElementAt(0));
            dibujador.añadirACola("rotarPunto",4);
            //   MOVER 2
            dibujador.nuevaListaDeIndices();
            dibujador.addIndice(0);dibujador.addIndice(1);dibujador.addIndice(2);
            dibujador.addIndice(4);dibujador.addIndice(6);dibujador.addIndice(7);
            dibujador.añadirACola("trasladar",new Punto(centro.x+(float)0.3,centro.y-(float)0.3,1));
            //ROTAR PIE TRASERO PARA AVANZAR 2
            dibujador.nuevaListaDeIndices();
            dibujador.addIndice(3);
            dibujador.añadirACola("rotarPunto",dibujador.objeto.listaDePoligonos.ElementAt(3).listaDePuntos.ElementAt(1));
            dibujador.añadirACola("rotarPunto",-4);
            //ROTAR PIERNA TRASERA PARA IGUALAR AL PIE TRASERO 2
            dibujador.nuevaListaDeIndices();
            dibujador.addIndice(2);
            dibujador.añadirACola("rotarPunto",dibujador.objeto.listaDePoligonos.ElementAt(2).listaDePuntos.ElementAt(0));
            dibujador.añadirACola("rotarPunto",2);
            //ROTAR BRAZO TRASERO 2
            dibujador.nuevaListaDeIndices();
            dibujador.addIndice(6);
            dibujador.añadirACola("rotarPunto",dibujador.objeto.listaDePoligonos.ElementAt(6).listaDePuntos.ElementAt(0));
            dibujador.añadirACola("rotarPunto",(float)-0.5);
            //ROTAR BRAZO DELANTERO 2
            dibujador.nuevaListaDeIndices();
            dibujador.addIndice(7);
            dibujador.añadirACola("rotarPunto",dibujador.objeto.listaDePoligonos.ElementAt(7).listaDePuntos.ElementAt(0));
            dibujador.añadirACola("rotarPunto",5);

            //ROTAR PIE DELANTERO PARA ENRECTAR 3
            dibujador.nuevaListaDeIndices();
            dibujador.addIndice(5);
            dibujador.añadirACola("rotarPunto",dibujador.objeto.listaDePoligonos.ElementAt(5).listaDePuntos.ElementAt(1));
            dibujador.añadirACola("rotarPunto",-4);
            //ROTAR PIERNA DELANTERA PARA IGUALAR AL PIE DELANTERO 3
            dibujador.nuevaListaDeIndices();
            dibujador.addIndice(4);
            dibujador.añadirACola("rotarPunto",dibujador.objeto.listaDePoligonos.ElementAt(4).listaDePuntos.ElementAt(0));
            dibujador.añadirACola("rotarPunto",3);
            //   MOVER 3
            dibujador.nuevaListaDeIndices();
            dibujador.addIndice(0);dibujador.addIndice(1);dibujador.addIndice(2);
            dibujador.addIndice(4);dibujador.addIndice(6);dibujador.addIndice(7);
            dibujador.añadirACola("trasladar",new Punto(centro.x+(float)0.5,centro.y-(float)0.5,1));
            //ROTAR PIE TRASERO PARA AVANZAR 3
            dibujador.nuevaListaDeIndices();
            dibujador.addIndice(3);
            dibujador.añadirACola("rotarPunto",dibujador.objeto.listaDePoligonos.ElementAt(3).listaDePuntos.ElementAt(1));
            dibujador.añadirACola("rotarPunto",-3);
            //ROTAR PIERNA TRASERA PARA IGUALAR AL PIE TRASERO 3
            dibujador.nuevaListaDeIndices();
            dibujador.addIndice(2);
            dibujador.añadirACola("rotarPunto",dibujador.objeto.listaDePoligonos.ElementAt(2).listaDePuntos.ElementAt(0));
            dibujador.añadirACola("rotarPunto",2);
            //ROTAR BRAZO TRASERO 3
            dibujador.nuevaListaDeIndices();
            dibujador.addIndice(6);
            dibujador.añadirACola("rotarPunto",dibujador.objeto.listaDePoligonos.ElementAt(6).listaDePuntos.ElementAt(0));
            dibujador.añadirACola("rotarPunto",(float)-0.5);
            //ROTAR BRAZO DELANTERO 3
            dibujador.nuevaListaDeIndices();
            dibujador.addIndice(7);
            dibujador.añadirACola("rotarPunto",dibujador.objeto.listaDePoligonos.ElementAt(7).listaDePuntos.ElementAt(0));
            dibujador.añadirACola("rotarPunto",5);
            
            timer.Enabled=true;i=1;
            actualizarListaDeEfectos();
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
                            dibujador.addIndice(-1);
                            dibujador.pintar();
                            actualizarListaDePoligonos();
                            resultado = "ABIERTO CORRECTAMENTE";
                            grabando = false;
                            timer.Enabled = false;
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
        private void avisoCheck_CheckedChanged(object sender, EventArgs e)
        {
            switch (efecto)
            {
                case "escalarOrigen":
                    avisoCheck.Text = avisoCheck.Checked ? "Veces mas Pequeño" : "Veces mas Grande";
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
            double numero = 0;
            try
            {
                if (efecto.CompareTo("nuevoNombre") != 0 && efecto.CompareTo("reproducir") != 0)
                {
                    numero = Convert.ToDouble(avisoTxt.Text.ToString());
                }
                switch (efecto)
                {
                    case "rotarEje":
                        numero = avisoCheck.Checked ? numero * (-1) : numero;
                        dibujador.rotarEje(numero);
                        aviso.Text = "Poligono rotado";
                        if (grabando)
                        {
                            dibujador.añadirACola(efecto, (float)numero);
                            actualizarListaDeEfectos();
                        }
                        break;
                    case "rotarOrigen":
                        numero = avisoCheck.Checked ? numero * (-1) : numero;
                        dibujador.rotarOrigenPoligono(numero);
                        aviso.Text = "Poligono rotado";
                        if (grabando)
                        {
                            dibujador.añadirACola(efecto, (float)numero);
                            actualizarListaDeEfectos();
                        }
                        break;
                    case "rotarPunto":
                        numero = avisoCheck.Checked ? numero * (-1) : numero;
                        dibujador.rotarPunto(numero);
                        aviso.Text = "Poligono rotado";
                        if (grabando)
                        {
                            dibujador.añadirACola(efecto, (float)numero);
                            actualizarListaDeEfectos();
                        }
                        break;
                    case "escalarEje":
                        numero = avisoCheck.Checked ? 1 / numero : numero;
                        dibujador.escalarEje(numero);
                        aviso.Text = "Poligono escalado";
                        if (grabando)
                        {
                            dibujador.añadirACola(efecto, (float)numero);
                            actualizarListaDeEfectos();
                        }
                        break;
                    case "escalarOrigen":
                        numero = avisoCheck.Checked ? 1 / numero : numero;
                        dibujador.escalarOrigen(numero);
                        aviso.Text = "Poligono escalado";
                        if (grabando)
                        {
                            dibujador.añadirACola(efecto, (float)numero);
                            actualizarListaDeEfectos();
                        }
                        break;
                    case "reflexionRecta":
                        dibujador.puntoReflexionRecta(true);
                        aviso.Text = "Reflexion completa";
                        if (grabando)
                        {
                            dibujador.añadirACola(efecto, dibujador.poligonoAux);
                            actualizarListaDeEfectos();
                        }
                        break;
                    case "escalarPunto":
                        numero = avisoCheck.Checked ? 1 / numero : numero;
                        dibujador.escalarPunto(numero);
                        aviso.Text = "Poligono escalado";
                        if (grabando)
                        {
                            dibujador.añadirACola(efecto, (float)numero);
                            actualizarListaDeEfectos();
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
                    case "reproducir":
                        aviso.Text = "Deteniendo...";
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
                MessageBox.Show("ERROR : " + ex.Message);
            }
            finally
            {
                dibujador.pintar();
            }
        }
        private void listaDePoligonos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dibujador.addIndice(-1);
            foreach (int indexChecked in listaDePoligonos.CheckedIndices)
            {
                listaDePoligonos.SetItemChecked(indexChecked, false);
            }
        }
        private void guardarAnimacionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            String resultado = "";
            try
            {
                if (dibujador.listaDeEfectos.Count > 0)
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
                                binfor.Serialize(st, dibujador.listaDeEfectos);
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
                resultado = "ERROR AL GUARDAR EL ARCHIVO : " + ex.Message;
                MessageBox.Show("ERROR AL GUARDAR EL ARCHIVO : " + ex.Message);
            }
            finally
            {
                aviso.Text = resultado;
            }
        }
        private void abrirAnimacionToolStripMenuItem_Click(object sender, EventArgs e)
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
                            LinkedList<Efecto> obj = (LinkedList<Efecto>)binfor.Deserialize(st);
                            dibujador.listaDeEfectos = obj;
                            actualizarListaDeEfectos();
                            resultado = "ABIERTO CORRECTAMENTE";
                            objetoInicial = new Objeto(dibujador.objeto);
                            grabando = false;
                            timer.Enabled = false;
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
                resultado = "ERROR AL ABRIR EL ARCHIVO : " + ex.Message;
                MessageBox.Show("ERROR AL ABRIR EL ARCHIVO : " + ex.Message);
            }
            finally
            {
                aviso.Text = resultado;
            }
        }
        #endregion

        #region modificadores
        private void modificarElementos(bool a, bool b, bool c,string a1, string b1, string c1)
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
        private void actualizarListaDePoligonos()
        {
            listaDePoligonos.Items.Clear();
            int cantidadDePoligonos = dibujador.getCantidadDePoligonos();
            for (int i = 1; i <= cantidadDePoligonos; i++)
            {
                listaDePoligonos.Items.Add(dibujador.objeto.getPoligono(i - 1));
            }
        }
        private void actualizarListaDeEfectos()
        {
            listaDeEfectos.Items.Clear();
            int cantidadDeEfectos = dibujador.listaDeEfectos.Count;
            for (int i = 1; i <= cantidadDeEfectos; i++)
            {
                listaDeEfectos.Items.Add(dibujador.listaDeEfectos.ElementAt(i - 1));
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            Efecto efecto;
            aviso.Text = "Detenido";//---------
            if (i > dibujador.listaDeEfectos.Count
                && aviso.Text.CompareTo("Detenido") == 0)//-----
            {
                i = 0;
                //dibujador.setObjeto(objetoInicial);
                //if (aviso.Text.CompareTo("Deteniendo...") == 0){
                    aviso.Text = "Detenido";
                    timer.Enabled = false;
                //}
            }
            else
            {
                efecto = dibujador.getEfecto(i - 1);
                dibujador.objeto.indices = efecto.indices;
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
                    case "ejeX":
                        dibujador.objeto.reflexionX();
                        break;
                    case "ejeY":
                        dibujador.objeto.reflexionY();
                        break;
                    case "reflexionRecta":
                        dibujador.objeto.reflexionRecta(efecto.poligono);
                        break;
                    case "escalarEje":
                        dibujador.objeto.escalarEje(efecto.numero);
                        break;
                    case "escalarOrigen":
                        dibujador.objeto.escalarOrigen(efecto.numero);
                        break;
                    case "escalarPunto":
                        dibujador.objeto.escalarPunto(efecto.punto);
                        i++;
                        efecto = dibujador.getEfecto(i - 1);
                        dibujador.objeto.escalarPunto(efecto.numero);
                        break;
                    default:
                        break;
                }
            }
            areaDibujo.Refresh();
            dibujador.pintar();
            i++;
        }
        private void desmarcarlistaDeEfectos()
        {
            foreach (int indice in listaDeEfectos.SelectedIndices)
            {
                listaDeEfectos.SetItemChecked(indice, false);
            }
        }
        #endregion

        #region condiciones
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
        #endregion

        #region efectos
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
                Random rnd = new Random();
                Punto aleatorio=new Punto(
                    (float)rnd.Next(-100, 100), (float)rnd.Next(-100, 100), 1);
                dibujador.trasladarPoligono(aleatorio);
                if (grabando)
                {
                    dibujador.añadirACola("trasladar",aleatorio);
                    actualizarListaDeEfectos();
                }
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
                efecto = "rotarEje";
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
                if (grabando)
                {
                    dibujador.añadirACola("reflexionX",true);
                }
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
                listaDeEfectos.Items.Clear();
                dibujador.nuevaListaDeEfectos();
                dibujador.setObjetoAnterior();
                objetoInicial = new Objeto();
                objetoInicial = new Objeto(dibujador.objeto);
            }
        }
        private void terminarGrabacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (esPosible()&&grabando)
            {
                Refresh();
                grabando = false;
                aviso.Text = "Grabacion terminada";
                aviso.Text = dibujador.listaDeEfectos.Count.ToString();
                dibujador.setObjeto(objetoInicial);
                dibujador.pintar();
            }
        }
        private void listaDePoligonos_MouseClick(object sender, MouseEventArgs e)
        {
            dibujador.nuevaListaDeIndices();
            int indiceDePoligonoSeleccionado = listaDePoligonos.SelectedIndex;
            if (indiceDePoligonoSeleccionado >= 0)
            {
                listaDePoligonos.SetItemChecked(indiceDePoligonoSeleccionado, true);
            }
            foreach (int indiceChekeado in listaDePoligonos.CheckedIndices)
            {
                dibujador.addIndice(indiceChekeado);
            }
        }
        private void borrarUltimaAnimacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grabando)
            {
                dibujador.listaDeEfectos.RemoveLast();
                actualizarListaDeEfectos();
                aviso.Text = "Movimiento eliminado";
            }
        }

        private void listaDeEfectos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dibujador.nuevaListaDeEfectos();
        }

        private void reproducirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!grabando)
            {
                if (dibujador.listaDeEfectos.Count != 0)
                {
                    modificarElementos(false, true, false, "", "Detener", "");
                    i = 1;
                    efecto = "reproducir";
                    aviso.Text = "Reproduciendo...";
                    timer.Enabled = true;
                }
                else
                {
                    aviso.Text = "Nada para reproducir";
                }
            }
            else
            {
                aviso.Text = "Debe dejar de grabar";
            }
        }
        #endregion
    }
}