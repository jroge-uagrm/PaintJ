using System;
using System.Collections.Generic;
using System.Linq;
namespace PaintJ
{
    [Serializable]
    public class Objeto
    {
        #region variablesGlobales
        public LinkedList<Poligono> listaDePoligonos;
        public bool poligonoTerminado;
        public Punto puntoCentral;
        public LinkedList<int> indices;
        #endregion

        #region inicializadores
        public Objeto()
        {
            listaDePoligonos = new LinkedList<Poligono>();
            poligonoTerminado=true;
            indices = new LinkedList<int>();
        }
        public Objeto(Objeto obj)
        {
            listaDePoligonos = new LinkedList<Poligono>();
            poligonoTerminado = true;
            indices = new LinkedList<int>();
            for (int i = 1; i <= obj.listaDePoligonos.Count; i++)
            {
                Poligono pol = obj.listaDePoligonos.ElementAt(i-1);
                for(int j = 1; j <= pol.listaDePuntos.Count; j++)
                {
                    Punto pun = pol.listaDePuntos.ElementAt(j - 1);
                    float x = pun.x;
                    float y = pun.y;
                    float z = pun.z;
                    añadirPunto(new Punto(x, y, z));
                }
                terminarPoligono();
                listaDePoligonos.Last().setNombre(pol.nombre);
            }
        }
        public void nuevaListaDeIndices()=> indices = new LinkedList<int>();
        #endregion

        #region setters
        public void setPuntoEnCentro()
        {
            Punto punto;Poligono poligono;
            float menorEnX = float.MaxValue;
            float menorEnY = float.MaxValue;
            float menorEnZ = float.MaxValue;
            float mayorEnX = float.MinValue;
            float mayorEnY = float.MinValue;
            float mayorEnZ = float.MinValue;
            foreach(int j in indices)
            {
                poligono = listaDePoligonos.ElementAt(j);
                for (int i = 1; i <= poligono.listaDePuntos.Count; i++)
                {
                        punto = poligono.listaDePuntos.ElementAt(i - 1);
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
        public void setNombre(int indice, string nuevoNombre) => listaDePoligonos.ElementAt(indice).setNombre(nuevoNombre);
        #endregion

        #region getters
        public Poligono getPoligono(int indice) => listaDePoligonos.ElementAt(indice);
        public Punto getUltimoPunto() => poligonoTerminado ? null : listaDePoligonos.Last().listaDePuntos.Last();
        
        public Punto getCentroDeListas(){
            Punto punto;Poligono poligono;
            float menorEnX = float.MaxValue;
            float menorEnY = float.MaxValue;
            float menorEnZ = float.MaxValue;
            float mayorEnX = float.MinValue;
            float mayorEnY = float.MinValue;
            float mayorEnZ = float.MinValue;
            for (int j = 1; j <= indices.Count; j++)
            {
                poligono=listaDePoligonos.ElementAt(indices.ElementAt(j-1));
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
            return new Punto(mayorEnX, mayorEnY, mayorEnZ);
        }
        #endregion

        #region agregaciones
        public void añadirPoligono(Poligono poligono) => listaDePoligonos.AddLast(poligono);
        public void añadirIndice(int nuevoIndice) => indices.AddLast(nuevoIndice);
        #endregion

        #region procesos
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
        public void borrarIndice(int indiceB) => indices.Remove(indiceB);
        #endregion

        #region efectos
        public void trasladarPoligono(Punto punto)
        {
            Poligono pol;setPuntoEnCentro();
            foreach (int indice in indices)
            {
                pol = listaDePoligonos.ElementAt(indice);
                pol.setPuntoReferenciaEnCentro();
                Punto puntoAuxiliar = new Punto(
                    punto.x + (pol.puntoReferencia.x - puntoCentral.x),
                    punto.y + (pol.puntoReferencia.y - puntoCentral.y),
                    1);
                pol.trasladar(puntoAuxiliar);
            }
        }
        public void rotarEje(double angulo)
        {
            if (indices.Contains(-1))
            {
                foreach (Poligono pol in listaDePoligonos)
                {
                    pol.setPuntoReferencia(puntoCentral);
                    pol.rotar(angulo);
                }
            }
            else
            {
                foreach (int indice in indices)
                {
                    Poligono pol = listaDePoligonos.ElementAt(indice);
                    pol.setPuntoReferenciaEnCentro();
                    pol.rotar(angulo);
                }
            }
        }
        public void setPuntoParaRotarPunto(Punto punto)
        {
            if (indices.Contains(-1))
            {
                foreach (Poligono pol in listaDePoligonos)
                {
                    pol.setPuntoReferencia(punto);
                }
            }
            else
            {
                foreach (int indice in indices)
                {
                    Poligono pol = listaDePoligonos.ElementAt(indice);
                    pol.setPuntoReferencia(punto);
                }
            }
        }
        public void rotarPunto(double angulo)
        {
            if (indices.Contains(-1))
            {
                foreach (Poligono pol in listaDePoligonos)
                {
                    pol.rotar(angulo);
                }
            }
            else
            {
                foreach (int indice in indices)
                {
                    Poligono pol = listaDePoligonos.ElementAt(indice);
                    pol.rotar(angulo);
                }
            }
        }
        public void rotarOrigen(double angulo)
        {
            if (indices.Contains(-1))
            {
                foreach (Poligono pol in listaDePoligonos)
                {
                    pol.setPuntoReferenciaEnOrigen();
                    pol.rotar(angulo);
                }
            }
            else
            {
                foreach (int indice in indices)
                {
                    Poligono pol = listaDePoligonos.ElementAt(indice);
                    pol.setPuntoReferenciaEnOrigen();
                    pol.rotar(angulo);
                }
            }
        }
        public void escalarEje(float constante)
        {
            if (indices.Contains(-1))
            {
                foreach (Poligono pol in listaDePoligonos)
                {
                    pol.setPuntoReferencia(puntoCentral);
                    pol.escalar(constante);
                }
            }
            else
            {
                foreach (int indice in indices)
                {
                    Poligono pol = listaDePoligonos.ElementAt(indice);
                    pol.setPuntoReferenciaEnCentro();
                    pol.escalar(constante);
                }
            }
        }
        public void escalarOrigen(float constante)
        {
            if (indices.Contains(-1))
            {
                foreach (Poligono pol in listaDePoligonos)
                {
                    pol.setPuntoReferenciaEnOrigen();
                    pol.escalar(constante);
                }
            }
            else
            {
                foreach (int indice in indices)
                {
                    Poligono pol = listaDePoligonos.ElementAt(indice);
                    pol.setPuntoReferenciaEnOrigen();
                    pol.escalar(constante);
                }
            }
        }
        public void escalarPunto(Punto punto)
        {
            if (indices.Contains(-1))
            {
                foreach (Poligono pol in listaDePoligonos)
                {
                    pol.setPuntoReferencia(punto);
                }
            }
            else
            {
                foreach (int indice in indices)
                {
                    Poligono pol = listaDePoligonos.ElementAt(indice);
                    pol.setPuntoReferencia(punto);
                }
            }
        }
        public void escalarPunto(float constante)
        {
            if (indices.Contains(-1))
            {
                foreach (Poligono pol in listaDePoligonos)
                {
                    pol.escalar(constante);
                }
            }
            else
            {
                foreach (int indice in indices)
                {
                    Poligono pol = listaDePoligonos.ElementAt(indice);
                    pol.escalar(constante);
                }
            }
        }
        public void reflexionX()
        {
            if (indices.Contains(-1))
            {
                foreach (Poligono pol in listaDePoligonos)
                {
                    pol.reflexion(true);
                }
            }
            else
            {
                foreach (int indice in indices)
                {
                    Poligono pol = listaDePoligonos.ElementAt(indice);
                    pol.reflexion(true);
                }
            }
        }
        public void reflexionY()
        {
            if (indices.Contains(-1))
            {
                foreach (Poligono pol in listaDePoligonos)
                {
                    pol.reflexion(false);
                }
            }
            else
            {
                foreach (int indice in indices)
                {
                    Poligono pol = listaDePoligonos.ElementAt(indice);
                    pol.reflexion(false);
                }
            }
        }
        public void reflexionRecta(Poligono recta)
        {
            if (indices.Contains(-1))
            {
                foreach (Poligono pol in listaDePoligonos)
                {
                    pol.reflexionRecta(recta);
                }
            }
            else
            {
                foreach (int indice in indices)
                {
                    Poligono pol = listaDePoligonos.ElementAt(indice);
                    pol.reflexionRecta(recta);
                }
            }
        }
        #endregion
    }
}
