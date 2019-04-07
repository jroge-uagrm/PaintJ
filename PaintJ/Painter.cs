using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintJ
{
    class Painter
    {
        public Pen lapiz = new Pen(Color.Black);
        public Graphics papel;
        public Objeto objeto;
        public Poligono poligono;
        public Punto puntoAnterior, punto;
        public bool dibujar, poligonoTerminado;
        public float x, y;
        public int a, b,H,V;

        public Painter(Graphics nuevoPapel,int nuevaH,int nuevaV)
        {
            this.papel = nuevoPapel;
            this.objeto = new Objeto();
            this.poligono = new Poligono();
            this.dibujar = false;
            this.x = this.y = this.a=this.b=0;
            this.H = nuevaH;this.V = nuevaV;
            this.punto = null;
            this.puntoAnterior = null;
        }

        public String puedeDibujar()
        {
            return dibujar ? "PUEDE DIBUJAR" : "NO PUEDE DIBUJAR";
        }

        public void pintar()
        {
            papel.DrawLine(new Pen(Color.Red), H/2, 0, H/2, V);
            papel.DrawLine(new Pen(Color.Red), 0, V/2, H, V/2);
            int cantidadPoligonos = objeto.listaDePoligonos.Count;
            for (int i = 1; i <= cantidadPoligonos; i++)
            {
                poligono = objeto.listaDePoligonos.First();
                objeto.listaDePoligonos.RemoveFirst();
                objeto.listaDePoligonos.AddLast(poligono);
                int cantidadPuntos = poligono.listaDePuntos.Count;
                for (int j = 2; j <= cantidadPuntos; j++)
                {
                    puntoAnterior = (Punto)poligono.listaDePuntos.First();
                    poligono.listaDePuntos.RemoveFirst();
                    poligono.listaDePuntos.AddLast(puntoAnterior);
                    punto = (Punto)poligono.listaDePuntos.First();
                    int x1, x2, y1, y2; x1 = x2 = y1 = y2 = 0;
                    descoordenadas(puntoAnterior.x, puntoAnterior.y);
                    x1 = (int)a;
                    y1 = (int)b;
                    descoordenadas(punto.x, punto.y);
                    x2 = (int)a;
                    y2 = (int)b;
                    papel.DrawLine(lapiz, x1, y1, x2, y2);
                }
                puntoAnterior = (Punto)poligono.listaDePuntos.First();
                poligono.listaDePuntos.RemoveFirst();
                poligono.listaDePuntos.AddLast(puntoAnterior);
                punto = null;
                puntoAnterior = null;
            }
        }

        public void dibujarLinea(int a1,int b1)
        {
            if (dibujar)
            {
                coordenadas(a1, b1);
                punto = new Punto(x,y);
                if (puntoAnterior != null)
                {
                    descoordenadas(puntoAnterior.x, puntoAnterior.y);
                    int x1 = a;
                    int y1 = b;
                    descoordenadas(punto.x, punto.y);
                    int x2 = a;
                    int y2 = b;
                    papel.DrawLine(lapiz,
                        x1,y1,
                        x2,y2);
                    poligonoTerminado = false;
                }
                poligono.añadirPunto(punto);
                puntoAnterior=punto;
            }
        }

        public void finalizarPoligono()
        {
            objeto.añadirPoligono(poligono);
            poligono = new Poligono();
            poligonoTerminado = true;
            punto = null;
            puntoAnterior = null;
        }

        public String abrir()
        {
            String resultado = "ABIERTO CORRECTAMENTE";
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
                            objeto = (Objeto)binfor.Deserialize(st);
                            pintar();
                            poligono = new Poligono();
                            punto = null;
                            puntoAnterior = null;
                            poligonoTerminado = true;
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
            return resultado;
        }

        public String guardar()
        {
            String resultado = "GUARDADO CORRECTAMENTE";
            if (!poligonoTerminado)
            {
                objeto.añadirPoligono(poligono);
                poligono = new Poligono();
                poligonoTerminado = true;
                punto = null;
                puntoAnterior = null;
            }
            try
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
                            binfor.Serialize(st, this.objeto);
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
                resultado= "ERROR AL GUARDAR EL ARCHIVO";
            }
            return resultado;
        }

        public void coordenadas(int a1,int b1)
        {
            a = a1;
            b = b1;
            if (H > V)
            {
                x = ((float)((float)(a * 100) / H) - 50) * 2;
                y = (((float)((float)(V / 2) - b) * 100) / H) * 2;
            } 
            else
            {
                //INSERTAR FORMULAS
            }
        }

        public void descoordenadas(float x1,float y1)
        {
            x = x1;
            y = y1;
            if (H > V)
            {
                a = (int)((float)((float)((float)(x / 2) + 50) * H) / 100);
                b = (V / 2) - (int)((float)((float)(y / 2) * H) / 100);
            }
            else
            {
                //INSERTAR FORMULAS
            }
        }

        public void vaADibujar(){dibujar = !dibujar;}


    }
}
