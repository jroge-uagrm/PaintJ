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
        #region variablesGLobales
        public Pen lapiz = new Pen(Color.Black);
        public Graphics papel;
        public Objeto objeto,objetoAnterior;
        public Poligono poligonoAux;
        public float x, y;
        public int a,b,H,V;
        public int cantidadDeDibujos;
        public LinkedList<Efecto> listaDeEfectos=new LinkedList<Efecto>();
        #endregion

        #region inicializadores
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
        public void nuevaListaDeEfectos()
        {
            cantidadDeDibujos = 60;
            objetoAnterior = new Objeto(objeto);
            listaDeEfectos = new LinkedList<Efecto>();
        }
        public void nuevaListaDeIndices() => objeto.nuevaListaDeIndices();
        #endregion

        #region agregaciones
        public void añadirACola(string efecto, Punto punto)
        {
            listaDeEfectos.AddLast(new Efecto(efecto, punto, objeto.indices));
            /*float distanciaX, distanciaY;
            foreach (int indice in objeto.indices)
            {
                distanciaX = punto.x - objetoAnterior.listaDePoligonos.
                    ElementAt(indice).puntoReferencia.x;
                distanciaY = punto.y - objetoAnterior.listaDePoligonos.
                    ElementAt(indice).puntoReferencia.y;
                distanciaX = distanciaX / cantidadDeDibujos;
                distanciaY = distanciaY / cantidadDeDibujos;
                for (int i = 1; i <= cantidadDeDibujos; i++)
                {
                    Punto aux = new Punto(
                        punto.x - (distanciaX * (cantidadDeDibujos - i)),
                        punto.y - (distanciaY * (cantidadDeDibujos - i)),1);
                    listaDeEfectos.AddLast(new Efecto(efecto, aux, objeto.indices));
                }
                objetoAnterior.listaDePoligonos.ElementAt(indice).setPuntoReferencia(punto);
            }*/
        }
        public void añadirACola(string efecto, float numero)
        {
            listaDeEfectos.AddLast(new Efecto(efecto, numero, objeto.indices));
        }
        public void añadirACola(string efecto, Poligono poligono)
        {
            listaDeEfectos.AddLast(new Efecto(efecto, poligono, objeto.indices));
        }
        public void añadirACola(string efecto, bool ejeX)
        {
            listaDeEfectos.AddLast(new Efecto(efecto, ejeX, objeto.indices));
        }
        public void añadirPunto()
        {
            objeto.añadirPunto(new Punto(x, y, 1));
        }
        #endregion

        #region getters
        public Efecto getEfecto(int i) => listaDeEfectos.ElementAt(i);
        public Objeto getObjeto() => objeto;
        public Graphics getPoligonoDibujado(int indice)
        {
            Punto punto, puntoAnterior;
            Poligono poligono = objeto.getPoligono(indice);
            int cantidadPuntos = poligono.listaDePuntos.Count;
            for (int j = 0; j < cantidadPuntos - 1; j++)
            {
                puntoAnterior = (Punto)poligono.listaDePuntos.ElementAt(j);
                punto = (Punto)poligono.listaDePuntos.ElementAt(j + 1);
                Punto nuevoPA = getPuntoEnDescoordenadas(puntoAnterior.x, puntoAnterior.y);
                Punto nuevoP = getPuntoEnDescoordenadas(punto.x, punto.y);
                papel.DrawLine(
                    lapiz,
                    nuevoPA.x, nuevoPA.y,
                    nuevoP.x, nuevoP.y);
            }
            return papel;
        }
        public Punto getPuntoEnDescoordenadas(float xa, float yb)
        {
            int ax = (int)((float)((float)((float)(xa / 2) + 50) * H) / 100);
            int by = (int)((float)((float)((float)(yb / -2) + 50) * V) / 100);
            return new Punto(ax, by, 1);
        }
        public Punto getPuntoEnCoordenadas(int ax, int by)
        {
            float xa = (int)((float)((float)((float)(ax / 2) + 50) * H) / 100);
            float yb = (int)((float)((float)((float)(by / -2) + 50) * V) / 100);
            return new Punto(xa, yb, 1);
        }
        public int getCantidadDePoligonos() => objeto.listaDePoligonos.Count;
        #endregion

        #region setters
        public void setObjeto(Objeto nuevoObjeto) => objeto = new Objeto(nuevoObjeto);
        public void setNombre(int indice, string nuevoNombre) => objeto.setNombre(indice, nuevoNombre);
        public void addIndice(int nuevoIndice)
        {
            objeto.añadirIndice(nuevoIndice);
        }
        public void setObjetoAnterior()
        {
            objetoAnterior = new Objeto(objeto);
            objetoAnterior.setPuntoEnCentro();
            foreach (Poligono pol in objetoAnterior.listaDePoligonos)
            {
                pol.setPuntoReferenciaEnCentro();
            }
        }
        #endregion

        #region procesos
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
                    Punto nuevoPA = getPuntoEnDescoordenadas(puntoAnterior.x, puntoAnterior.y);
                    Punto nuevoP = getPuntoEnDescoordenadas(punto.x, punto.y);
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
            objeto.setPuntoEnCentro();
        }
        public void pintarEje()
        {
            papel.DrawLine(new Pen(Color.Red), H / 2, 0, H / 2, V);
            papel.DrawLine(new Pen(Color.Red), 0, V / 2, H, V / 2);
        }
        public void terminarPoligono() => objeto.terminarPoligono();
        public void coordenadas(int a1, int b1)
        {
            a = a1;
            b = b1;
            x = (((float)(a * 100) / H) - 50) * 2;
            y = ((float)(b * 100) / V - 50) * -2;
        }
        public void descoordenadas(float x1, float y1)
        {
            x = x1;
            y = y1;
            float aux = ((x / 2) + 50) * H / 100;
            a = (int)aux;
            aux = ((y / -2) + 50) * V / 100;
            b = (int)aux;
        }
        public bool borrarUltimoPunto()
        {
            if (noEstaVacio())
            {
                objeto.borrarUltimoPunto();
                return true;
            }
            return false;
        }
        public void borrarIndice(int indiceB) => objeto.borrarIndice(indiceB);
        #endregion

        #region condiciones
        public bool noEstaVacio() => objeto == null ? false : objeto.listaDePoligonos.Count == 0 ? false : true;
        #endregion

        #region efectos
        public void trasladarPoligono(Punto puntoATrasladar)
        {
            objeto.trasladarPoligono(puntoATrasladar);
        }
        public void rotarEje(double angulo) => objeto.rotarEje(angulo);
        public void rotarOrigenPoligono(double angulo) => objeto.rotarOrigen(angulo);
        public void setPuntoParaRotarPunto(Punto punto)=> objeto.setPuntoParaRotarPunto(punto);
        public void rotarPunto(double angulo) => objeto.rotarPunto(angulo);
        public void escalarEje(double constante) => objeto.escalarEje((float)constante);
        public void escalarOrigen(double constante) => objeto.escalarOrigen((float)constante);
        public void escalarPunto(Punto punto) => objeto.escalarPunto(punto);
        public void escalarPunto(double constante) => objeto.escalarPunto((float)constante);
        public void reflexionX() => objeto.reflexionX();
        public void reflexionY() => objeto.reflexionY();
        public bool puntoReflexionRecta(bool ya)
        {
            objeto.añadirPunto(new Punto(x, y, 1));
            if (objeto.listaDePoligonos.Last().listaDePuntos.Count <= 2 || ya)
            {
                if (ya)
                {
                    borrarUltimoPunto();
                    poligonoAux = objeto.listaDePoligonos.Last();
                    poligonoAux.setNombre("recta");
                    objeto.eliminarPoligono(objeto.listaDePoligonos.Count-1);
                    objeto.poligonoTerminado = true;
                    objeto.reflexionRecta(poligonoAux);
                    return true;
                }
                return objeto.listaDePoligonos.Last().listaDePuntos.Count == 2;
            }
            else
            {
                borrarUltimoPunto();
                return true;
            }
        }
        #endregion
    }
}

