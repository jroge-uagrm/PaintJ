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
    public class Painter
    {
        public Pen lapiz = new Pen(Color.Black);
        public Graphics papel;
        public Objeto objeto;
        public float x, y;
        public int a,b,H,V;

        public Painter(int nuevaH, int nuevaY)
        {
            H = nuevaH;V = nuevaY;
        }

        public void nuevoObjeto(Graphics nuevoPapel,int nuevaH,int nuevaY)
        {
            papel = nuevoPapel;
            H = nuevaH;
            V = nuevaY;
            objeto = new Objeto();
        }

        public void setObjeto(Objeto nuevoObjeto) => objeto = nuevoObjeto;

        public void pintar()
        {
            pintarEje();
            Punto punto, puntoAnterior;
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

        public Punto puntoEnDescoordenadas(float xa, float yb)
        {
            int ax = (int)((float)((float)((float)(xa / 2) + 50) * H) / 100);
            int by = (int)((float)((float)((float)(yb / -2) + 50) * V) / 100);
            return new Punto(ax, by, 1);
        }

        public Punto puntoEnCoordenadas(int ax, int by)
        {
            float xa = (int)((float)((float)((float)(ax / 2) + 50) * H) / 100);
            float yb = (int)((float)((float)((float)(by / -2) + 50) * V) / 100);
            return new Punto(xa, yb, 1);
        }

        public void añadirPunto() => objeto.añadirPunto(new Punto(x, y, 1));

        public void terminarPoligono() => objeto.terminarPoligono();

        public void coordenadas(int a1,int b1)
        {
            a = a1;
            b = b1;
            x = (((float)(a * 100) / H) - 50) * 2;
            y = ((float)(b * 100) / V - 50) * -2;
        }

        public void descoordenadas(float x1,float y1)
        {
            x = x1;
            y = y1;
            float aux = ((x / 2) + 50) * H / 100;
            a = (int)aux;
            aux = ((y / -2) + 50) * V / 100;
            b = (int)aux;
        }

        public bool noEstaVacio() => objeto == null ? false : objeto.listaDePoligonos.Count == 0 ? false : true;

        public int cantidadDePoligonos() => objeto.listaDePoligonos.Count;

        public void trasladarPoligono(Punto puntoATrasladar) => objeto.trasladarPoligono(puntoATrasladar);

        public void trasladarAleatorioPoligono()
        {
            Random rnd = new Random();
            objeto.trasladarPoligono(new Punto(
                (float)rnd.Next(-100,100), (float)rnd.Next(-100, 100),1));
        }

        public void rotarEje(double angulo) => objeto.rotarEje(angulo);

        public void rotarOrigenPoligono(double angulo) => objeto.rotarOrigen(angulo);

        public void setPuntoParaRotarPunto(Punto punto)=> objeto.setPuntoParaRotarPunto(punto);

        public void rotarPunto(double angulo) => objeto.rotarPunto(angulo);

        public bool borrarUltimoPunto()
        {
            if (noEstaVacio())
            {
                objeto.borrarUltimoPunto();
                return true;
            }
            return false;
        }

        public void escalarEje(double constante) => objeto.escalarEje((float)constante);

        public void escalarOrigen(double constante) => objeto.escalarOrigen((float)constante);

        public void reflexionX() => objeto.reflexionX();

        public void reflexionY() => objeto.reflexionY();
        //Se cambio en coordenadas
    }
}
