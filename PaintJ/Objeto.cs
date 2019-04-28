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
        public Punto puntoCentral;
        public int indice;

        public Objeto()
        {
            listaDePoligonos = new LinkedList<Poligono>();
            poligonoTerminado=true;
            indice = 0;
        }

        public void setPuntoEnCentro()
        {
            Punto punto;Poligono poligono;
            float menorEnX = float.MaxValue;
            float menorEnY = float.MaxValue;
            float menorEnZ = float.MaxValue;
            float mayorEnX = float.MinValue;
            float mayorEnY = float.MinValue;
            float mayorEnZ = float.MinValue;
            for (int j = 1; j <= listaDePoligonos.Count; j++)
            {
                poligono = listaDePoligonos.First();
                listaDePoligonos.RemoveFirst();
                listaDePoligonos.AddLast(poligono);
                for (int i = 1; i <= poligono.listaDePuntos.Count; i++)
                {
                    punto = poligono.listaDePuntos.First();
                    poligono.listaDePuntos.RemoveFirst();
                    poligono.listaDePuntos.AddLast(punto);
                    menorEnX = punto.x < menorEnX ? punto.x : menorEnX;
                    menorEnY = punto.y < menorEnY ? punto.y : menorEnY;
                    menorEnZ = punto.z < menorEnZ ? punto.z : menorEnZ;
                    mayorEnX = punto.x > mayorEnX ? punto.x : mayorEnX;
                    mayorEnY = punto.y > mayorEnY ? punto.y : mayorEnY;
                    mayorEnZ = punto.z > mayorEnZ ? punto.z : mayorEnZ;
                }
            }
            mayorEnX = (float)(((float)(mayorEnX + menorEnX)) / 2);
            mayorEnY = (float)(((float)(mayorEnY + menorEnY)) / 2);
            mayorEnZ = (float)(((float)(mayorEnZ + menorEnZ)) / 2);
            puntoCentral = new Punto(mayorEnX, mayorEnY, mayorEnZ);
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
            if (indice == -1)
            {
                foreach (Poligono pol  in listaDePoligonos)
                {
                    pol.setPuntoReferenciaEnCentro();
                    Punto anterior = pol.puntoReferencia;
                    Punto centroAnterior = puntoCentral;
                    pol.trasladar(puntoCentral);
                    pol.trasladar(punto);
                    pol.setPuntoReferenciaEnCentro();
                    Punto puntoCentralPol = pol.puntoReferencia;
                    Punto puntoAuxiliar = new Punto(
                        puntoCentralPol.x + (anterior.x - puntoCentral.x),
                        puntoCentralPol.y + (anterior.y - puntoCentral.y),
                        1);
                    pol.trasladar(puntoAuxiliar);
                }
            }
            else
            {
                Poligono pol = listaDePoligonos.ElementAt(indice);
                pol.setPuntoReferenciaEnCentro();
                pol.trasladar(punto);
            }
        }

        public void rotarEje(double angulo)
        {
            if (indice == -1)
            {
                foreach (Poligono pol in listaDePoligonos)
                {
                    pol.setPuntoReferencia(puntoCentral);
                    pol.rotar(angulo);
                }
            }
            else
            {
                Poligono pol = listaDePoligonos.ElementAt(indice);
                pol.setPuntoReferenciaEnCentro();
                pol.rotar(angulo);
            }
        }

        public void setPuntoParaRotarPunto(Punto punto)
        {
            if (indice == -1)
            {
                foreach (Poligono pol in listaDePoligonos)
                {
                    Punto nuevo = new Punto(
                        -puntoCentral.x + punto.x,
                        -puntoCentral.y + punto.y, 1);
                    pol.setPuntoReferencia(nuevo);
                }
            }
            else
            {
                Poligono pol = listaDePoligonos.ElementAt(indice);
                pol.setPuntoReferencia(punto);
            }
        }

        public void rotarPunto(double angulo)
        {
            if (indice == -1)
            {
                foreach (Poligono pol in listaDePoligonos)
                {
                    pol.rotar(angulo);
                }
            }
            else
            {
                Poligono pol = listaDePoligonos.ElementAt(indice);
                pol.rotar(angulo);
            }
        }

        public void rotarOrigen(double angulo)
        {
            if (indice == -1)
            {
                foreach (Poligono pol in listaDePoligonos)
                {
                    pol.setPuntoReferenciaEnOrigen();
                    pol.rotar(angulo);
                }
            }
            else
            {
                Poligono pol = listaDePoligonos.ElementAt(indice);
                pol.setPuntoReferenciaEnOrigen();
                pol.rotar(angulo);
            }
        }

        public void escalarEje(float constante)
        {
            if (indice == -1)
            {
                foreach (Poligono pol in listaDePoligonos)
                {
                    pol.setPuntoReferencia(puntoCentral);
                    pol.rotar(constante);
                }
            }
            else
            {
                Poligono pol = listaDePoligonos.ElementAt(indice);
                pol.setPuntoReferenciaEnCentro();
                pol.escalar(constante);
            }
        }

        public void escalarOrigen(float constante)
        {
            if (indice == -1)
            {
                foreach (Poligono pol in listaDePoligonos)
                {
                    pol.setPuntoReferenciaEnOrigen();
                    pol.rotar(constante);
                }
            }
            else
            {
                Poligono pol = listaDePoligonos.ElementAt(indice);
                pol.setPuntoReferenciaEnOrigen();
                pol.escalar(constante);
            }
        }

        public void escalarPunto(Punto punto)
        {
            if (indice == -1)
            {
                foreach (Poligono pol in listaDePoligonos)
                {
                    pol.setPuntoReferencia(punto);
                }
            }
            else
            {
                Poligono pol = listaDePoligonos.ElementAt(indice);
                pol.setPuntoReferencia(punto);
            }
        }

        public void escalarPunto(float constante)
        {
            if (indice == -1)
            {
                foreach (Poligono pol in listaDePoligonos)
                {
                    pol.rotar(constante);
                }
            }
            else
            {
                Poligono pol = listaDePoligonos.ElementAt(indice);
                pol.escalar(constante);
            }
        }

        public void reflexionX()
        {
            if (indice == -1)
            {
                foreach (Poligono pol in listaDePoligonos)
                {
                    pol.reflexion(true);
                }
            }
            else
            {
                Poligono pol = listaDePoligonos.ElementAt(indice);
                pol.reflexion(true);
            }
        }

        public void reflexionY()
        {
            if (indice == -1)
            {
                foreach (Poligono pol in listaDePoligonos)
                {
                    pol.reflexion(false);
                }
            }
            else
            {
                Poligono pol = listaDePoligonos.ElementAt(indice);
                pol.reflexion(false);
            }
        }

        public void reflexionRecta(Poligono recta)
        {
            if (indice == -1)
            {
                foreach (Poligono pol in listaDePoligonos)
                {
                    pol.reflexionRecta(recta);
                }
            }
            else
            {
                Poligono pol = listaDePoligonos.ElementAt(indice);
                pol.reflexionRecta(recta);
            }
        }
    }
}
