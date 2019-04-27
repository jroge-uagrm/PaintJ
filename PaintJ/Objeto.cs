using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintJ
{
    [Serializable]
    public class Objeto
    {
        public LinkedList<Poligono> listaDePoligonos;
        public bool poligonoTerminado;
        public int indice;

        public Objeto()
        {
            listaDePoligonos = new LinkedList<Poligono>();
            poligonoTerminado=true;
            indice = 0;
        }

        public void añadirPoligono(Poligono poligono) => listaDePoligonos.AddLast(poligono);

        public Poligono getPoligono(int indice) => listaDePoligonos.ElementAt(indice);

        public void setNombre(int indice, string nuevoNombre) => listaDePoligonos.ElementAt(indice).setNombre(nuevoNombre);

        public void setIndice(int nuevoIndice) => indice = nuevoIndice;

        public int getIndice() => indice;

        public void eliminarPoligono(int indice)
        {
            Poligono pol = listaDePoligonos.ElementAt(indice);
            listaDePoligonos.Remove(pol);
        }

        public void añadirPunto(Punto punto)
        {
            if (poligonoTerminado)
            {
                añadirPoligono(new Poligono());
                poligonoTerminado = false;
                añadirPunto(punto);
            }
            else
            {
                listaDePoligonos.Last().añadirPunto(punto);
            }
        }

        public void terminarPoligono()
        {
            poligonoTerminado = true;
            Poligono pol = listaDePoligonos.Last();
            pol.setNombre("poligono" + listaDePoligonos.Count.ToString());
        }

        public Punto ultimoPunto() => poligonoTerminado ? null : listaDePoligonos.Last().listaDePuntos.Last();

        public void borrarUltimoPunto()
        {
            if (listaDePoligonos.Count > 0)
            {
                listaDePoligonos.Last().borrarUltimoPunto();
                if (listaDePoligonos.Last().listaDePuntos.Count <= 1)
                {
                    listaDePoligonos.RemoveLast();
                    poligonoTerminado = true;
                }
                else
                {
                    poligonoTerminado = false;
                }
            }
        }

        public void trasladarPoligono(Punto punto)
        {
            Poligono pol = listaDePoligonos.ElementAt(indice);
            pol.trasladar(punto);
        }

        public void rotarEje(double angulo)
        {
            Poligono pol = listaDePoligonos.ElementAt(indice);
            pol.setPuntoReferenciaEnCentro();
            pol.rotar(angulo);
        }

        public void setPuntoParaRotarPunto(Punto punto)
        {
            Poligono pol = listaDePoligonos.ElementAt(indice);
            pol.setPuntoReferencia(punto);
        }

        public void rotarPunto(double angulo)
        {
            Poligono pol = listaDePoligonos.ElementAt(indice);
            pol.rotar(angulo);
        }

        public void rotarOrigen(double angulo)
        {
            Poligono pol = listaDePoligonos.ElementAt(indice);
            pol.setPuntoReferenciaEnOrigen();
            pol.rotar(angulo);
        }

        public void escalarEje(float constante)
        {
            Poligono pol = listaDePoligonos.ElementAt(indice);
            pol.setPuntoReferenciaEnCentro();
            pol.escalar(constante);
        }

        public void escalarOrigen(float constante)
        {
            Poligono pol = listaDePoligonos.ElementAt(indice);
            pol.setPuntoReferenciaEnOrigen();
            pol.escalar(constante);
        }

        public void escalarPunto(Punto punto)
        {
            Poligono pol = listaDePoligonos.ElementAt(indice);
            pol.setPuntoReferencia(punto);
        }

        public void escalarPunto(float constante)
        {
            Poligono pol = listaDePoligonos.ElementAt(indice);
            pol.escalar(constante);
        }

        public void reflexionX()
        {
            Poligono pol = listaDePoligonos.ElementAt(indice);
            pol.reflexion(true);
        }

        public void reflexionY()
        {
            Poligono pol = listaDePoligonos.ElementAt(indice);
            pol.reflexion(false);
        }

        public void reflexionRecta(Poligono recta)
        {
            Poligono pol = listaDePoligonos.ElementAt(indice);
            pol.reflexionRecta(recta);
        }
    }
}
