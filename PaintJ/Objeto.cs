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

        public Objeto()
        {
            listaDePoligonos = new LinkedList<Poligono>();
            poligonoTerminado=true;
        }

        public void añadirPoligono(Poligono poligono) => listaDePoligonos.AddLast(poligono);

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

        public void trasladarPoligono(Punto punto)
        {
            Poligono pol = listaDePoligonos.Last();
            pol.trasladar(punto);
        }

        public void rotarEje(double angulo)
        {
            Poligono pol = listaDePoligonos.Last();
            pol.setPuntoReferenciaEnCentro();
            pol.rotar(angulo);
        }

        public void setPuntoParaRotarPunto(Punto punto)
        {
            Poligono pol = listaDePoligonos.Last();
            pol.setPuntoReferencia(punto);
        }

        public void rotarPunto(double angulo)
        {
            Poligono pol = listaDePoligonos.Last();
            pol.rotar(angulo);
        }

        public void rotarOrigen(double angulo)
        {
            Poligono pol = listaDePoligonos.Last();
            pol.setPuntoReferenciaEnOrigen();
            pol.rotar(angulo);
        }

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

        public void escalarEje(float constante)
        {
            Poligono pol = listaDePoligonos.Last();
            pol.setPuntoReferenciaEnCentro();
            pol.escalar(constante);
        }

        public void escalarOrigen(float constante)
        {
            Poligono pol = listaDePoligonos.Last();
            pol.setPuntoReferenciaEnOrigen();
            pol.escalar(constante);
        }

        public void reflexionX()
        {
            Poligono pol = listaDePoligonos.Last();
            pol.reflexion(true);
        }

        public void reflexionY()
        {
            Poligono pol = listaDePoligonos.Last();
            pol.reflexion(false);
        }
    }
}
