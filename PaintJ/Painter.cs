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
        public bool poligonoTerminado;
        public float x, y;
        public int a,b,H,V;

        public Painter(int nuevaH,int nuevaY)
        {
            this.H = nuevaH;
            this.V = nuevaY;
            this.punto = null;
            this.puntoAnterior = null;
        }

        public void nuevoObjeto(Graphics nuevoPapel,int nuevaH,int nuevaY)
        {
            this.papel = nuevoPapel;
            this.H = nuevaH;
            this.V = nuevaY;
            this.objeto = new Objeto();
            this.poligono = new Poligono();
            punto = puntoAnterior = null;
        }

        public void pintarEje()
        {
            papel.DrawLine(new Pen(Color.Red), H/2, 0, H/2, V);
            papel.DrawLine(new Pen(Color.Red), 0, V/2, H, V/2);
        }

        public void pintar()
        {
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
                    Punto nuevoPA = puntoEnDescoordenadas(puntoAnterior.x, puntoAnterior.y);
                    Punto nuevoP = puntoEnDescoordenadas(punto.x, punto.y);
                    papel.DrawLine(
                        lapiz,
                        nuevoPA.x,nuevoPA.y,
                        nuevoP.x,nuevoP.y);
                }
                puntoAnterior = (Punto)poligono.listaDePuntos.First();
                poligono.listaDePuntos.RemoveFirst();
                poligono.listaDePuntos.AddLast(puntoAnterior);
                punto = null;
                puntoAnterior = null;
            }
        }

        public Punto puntoEnDescoordenadas(float x1, float y1)
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
            return new Punto(a, b);
        }

        public void dibujarLinea()
        {
            if (poligonoTerminado)
            {
                poligono = new Poligono();
                poligonoTerminado = false;

            }
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
                }
                poligono.añadirPunto(punto);
                puntoAnterior=punto;
        }

        public void setObjeto(Objeto nuevoObjeto)
        {
            poligonoTerminado = true;
            this.objeto = nuevoObjeto;
        }

        public void terminarPoligono()
        {
                objeto.añadirPoligono(poligono);
                //poligono = new Poligono();
                poligonoTerminado = true;
                punto = null;
                puntoAnterior = null;
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

        public bool isObjetoVacio()
        {
            return objeto.listaDePoligonos.Count==0;
        }

        public void trasladarPoligono()
        {
            poligono.trasladar(new Punto(x, y));
        }

        public bool noEstaVacio()
        {
            if (objeto == null)
            {
                return false;
            }
            else if(objeto.listaDePoligonos.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void rotarPoligono(double angulo)
        {
            poligono.puntoDeReferenciaPredeterminado();
            poligono.rotar(angulo);
        }

        public void rotarPuntoPoligono()
        {
            poligono.setPuntoReferencia(new Punto(x, y));
        }
    }
}
