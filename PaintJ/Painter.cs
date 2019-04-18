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
        public Punto puntoAnterior, punto;
        public float x, y;
        public int a,b,H,V;

        public Painter(int nuevaH,int nuevaY)
        {
            this.H = nuevaH;
            this.V = nuevaY;
            this.puntoAnterior = null;
        }

        public void nuevoObjeto(Graphics nuevoPapel,int nuevaH,int nuevaY)
        {
            this.papel = nuevoPapel;
            this.H = nuevaH;
            this.V = nuevaY;
            this.objeto = new Objeto();
            puntoAnterior = null;
        }

        public void setObjeto(Objeto nuevoObjeto)
        {
            this.objeto = nuevoObjeto;
            puntoAnterior = this.objeto.ultimoPunto();
        }

        public void pintar()
        {
            pintarEje();
            int cantidadPoligonos = objeto.listaDePoligonos.Count;
            for (int i = 1; i <= cantidadPoligonos; i++)
            {
                Poligono poligono = objeto.listaDePoligonos.First();
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

        public void pintarEje()
        {
            papel.DrawLine(new Pen(Color.Red), H / 2, 0, H / 2, V);
            papel.DrawLine(new Pen(Color.Red), 0, V / 2, H, V / 2);
        }

        public Punto puntoEnDescoordenadas(float x1, float y1)
        {
            x = x1;
            y = y1;
            a = (int)((float)((float)((float)(x / 2) + 50) * H) / 100);
            b = (int)((float)((float)((float)(y / 2) + 50) * V) / 100);
            return new Punto(a, b, 1);
        }

        public void añadirPunto()
        {
            objeto.añadirPunto(new Punto(x, y, 1));
        }

        public void terminarPoligono()
        {
            objeto.AñadirPuntoFinal(new Punto(x, y,1));
            puntoAnterior = null;
        }

        public void coordenadas(int a1,int b1)
        {
            a = a1;
            b = b1;
            x = ((float)((float)(a * 100) / H) - 50) * 2;
            y = ((float)((float)(b * 100) / V) - 50) * 2;
        }

        public void descoordenadas(float x1,float y1)
        {
            x = x1;
            y = y1;
            a = (int)((float)((float)((float)(x / 2) + 50) * H) / 100);
            b = (int)((float)((float)((float)(y / 2) + 50) * V) / 100);
        }

        public bool noEstaVacio()
        {
            if (objeto == null)
            {
                return false;
            }
            else if (objeto.listaDePoligonos.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void trasladarPoligono()
        {
            objeto.trasladarPoligono(new Punto(x,y,1));
        }

        public void trasladarAleatorioPoligono()
        {
    
        }

        public void rotarPoligono(double angulo)
        {
            objeto.rotar(angulo);
        }

        public void rotarPuntoPoligono(Punto punto,double angulo)
        {
            objeto.rotarPunto(punto,angulo);
        }

        public void rotarOrigenPoligono(double angulo)
        {
            objeto.rotarOrigen(angulo);
        }

        public bool borrarUltimaLinea()
        {
            if (noEstaVacio())
            {
                if (objeto.poligonoTerminado)
                {
                    objeto.borrarUltimoPunto();
                }
                objeto.borrarUltimoPunto();
                return true;
            }
            return false;
        }

        public void escalarOrigen(double constante)
        {
            objeto.escalarOrigenPoligono((float)constante);
        }

        public void escalar(double constante)
        {
            objeto.escalarPoligono((float)constante);
        }

        public void reflexion(Punto a,Punto b)
        {
            objeto.reflexion(a, b);
        }
    }
}
