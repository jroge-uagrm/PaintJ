using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintJ
{
    [Serializable]
    class Objeto
    {
        public LinkedList<Poligono> listaDePoligonos;
        public bool poligonoTerminado;

        public Objeto()
        {
            listaDePoligonos = new LinkedList<Poligono>();
            poligonoTerminado=true;
        }

        public void añadirPoligono(Poligono poligono)
        {
            poligono.setPuntoReferenciaEnCentro();
            listaDePoligonos.AddLast(poligono);
            poligonoTerminado = false;
        }

        public void añadirPunto(Punto punto)
        {
            if (poligonoTerminado)
            {
                this.añadirPoligono(new Poligono());
                this.añadirPunto(punto);
            }
            else
            {
                listaDePoligonos.Last().añadirPunto(punto);
            }
        }

        public void AñadirPuntoFinal(Punto punto)
        {
            this.añadirPunto(punto);
            poligonoTerminado = true;
        }

        public Punto ultimoPunto()
        {
            return poligonoTerminado ? null :
                listaDePoligonos.Last().
                    listaDePuntos.Last();
        }

        public void trasladarPoligono(Punto punto)
        {
            listaDePoligonos.Last().trasladar(punto);
        }

        public void rotar(double angulo)
        {
            listaDePoligonos.Last().setPuntoReferenciaEnCentro();
            listaDePoligonos.Last().rotar(angulo);
        }

        public void rotarPunto(Punto punto,double angulo)
        {
            listaDePoligonos.Last().setPuntoReferencia(punto);
            listaDePoligonos.Last().rotar(angulo);
        }

        public void rotarOrigen(double angulo)
        {
            listaDePoligonos.Last().setPuntoReferenciaEnOrigen();
            listaDePoligonos.Last().rotar(angulo);
        }

        public void borrarUltimoPunto()
        {
            listaDePoligonos.Last().listaDePuntos.RemoveLast();
            if (poligonoTerminado)
            {
                poligonoTerminado = false;
            }
            if (listaDePoligonos.Last().listaDePuntos.Count == 0)
            {
                listaDePoligonos.RemoveLast();
                poligonoTerminado = true;
            }
        }

        public void escalarOrigenPoligono(float constante)
        {
            listaDePoligonos.Last().setPuntoReferenciaEnOrigen();
            listaDePoligonos.Last().escalar(constante);
        }

        public void escalarPoligono(float constante)
        {
            listaDePoligonos.Last().setPuntoReferenciaEnCentro();
            listaDePoligonos.Last().escalar(constante);
        }

        public void reflexion(Punto a,Punto b)
        {

        }
    }
}
