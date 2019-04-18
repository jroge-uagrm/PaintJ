using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintJ
{
    [Serializable]
    class Poligono
    {
        public Punto puntoReferencia;
        public LinkedList<Punto> listaDePuntos;
        float[][] matriz;
        public Poligono()
        {
            listaDePuntos = new LinkedList<Punto>();
            puntoReferencia = null;
            matriz = new float[3][];
            matriz[0] = new float[3] { 1, 0, 0 };
            matriz[1] = new float[3] { 0, 1, 0 };
            matriz[2] = new float[3] { 0, 0, 1 };
        }

        public void añadirPunto(Punto punto)
        {
            listaDePuntos.AddLast(punto);
        }

        public void setPuntoReferencia(Punto nuevoPuntoDeReferencia)
        {
            puntoReferencia = nuevoPuntoDeReferencia;
        }

        public void setPuntoReferenciaEnCentro()
        {
            Punto punto;
            float menorEnX=float.MaxValue;
            float menorEnY= float.MaxValue;
            float menorEnZ = float.MaxValue;
            float mayorEnX = float.MinValue;
            float mayorEnY = float.MinValue;
            float mayorEnZ = float.MinValue;
            for (int i = 1; i <= listaDePuntos.Count; i++)
            {
                punto = listaDePuntos.First();
                listaDePuntos.RemoveFirst();
                listaDePuntos.AddLast(punto);
                menorEnX = punto.x < menorEnX ? punto.x : menorEnX;
                menorEnY = punto.y < menorEnY ? punto.y : menorEnY;
                menorEnZ = punto.z < menorEnZ ? punto.z : menorEnZ;
                mayorEnX = punto.x > mayorEnX ? punto.x : mayorEnX;
                mayorEnY = punto.y > mayorEnY ? punto.y : mayorEnY;
                mayorEnZ = punto.z > mayorEnZ ? punto.z : mayorEnZ;
            }
            mayorEnX = (float)(((float)(mayorEnX + menorEnX)) / 2);
            mayorEnY = (float)(((float)(mayorEnY + menorEnY)) / 2);
            mayorEnZ = (float)(((float)(mayorEnZ + menorEnZ)) / 2);
            puntoReferencia = new Punto(mayorEnX,mayorEnY,mayorEnZ);
        }

        public void setPuntoReferenciaEnOrigen()
        {
            puntoReferencia = new Punto(0, 0, 1);
        }
        
        public void trasladar(Punto puntoAMoverse)
        {
            setPuntoReferenciaEnCentro();
            float tx = puntoAMoverse.x - puntoReferencia.x;
            float ty = puntoAMoverse.y - puntoReferencia.y;
            matriz[0] = new float[3] { 1, 0, 0 };
            matriz[1] = new float[3] { 0, 1, 0 };
            matriz[2] = new float[3] { tx, ty, 1 };
            for (int i = 1; i <= listaDePuntos.Count; i++)
            {
                Punto p = listaDePuntos.First();
                listaDePuntos.RemoveFirst();
                Punto q = new Punto(
                    p.x + tx,
                    p.y + ty,
                    p.z);
                listaDePuntos.AddLast(q);
            }
        }

        public void rotar(Double angulo)
        {
            angulo = (angulo * Math.PI) / 180;
            Punto punto, nuevoPunto;
            for (int i = 1; i <= listaDePuntos.Count; i++)
            {
                punto = listaDePuntos.First();
                listaDePuntos.RemoveFirst();
                nuevoPunto = new Punto(
                    (float)(puntoReferencia.x)+
                    (float)((punto.x - puntoReferencia.x) * (Math.Cos(angulo))) -
                    (float)((punto.y - puntoReferencia.y) * (Math.Sin(angulo))),
                    (float)(puntoReferencia.y)+
                    (float)((punto.x - puntoReferencia.x) * (Math.Sin(angulo))) +
                    (float)((punto.y - puntoReferencia.y) * (Math.Cos(angulo))),
                    1);
                listaDePuntos.AddLast(nuevoPunto);
            }
        }

        public void borrarUltimoPunto()
        {
            if (listaDePuntos.Count > 0)
            {
                listaDePuntos.RemoveLast();
            }
        }

        public void escalar(float constante)
        {
            for (int i = 1; i <= listaDePuntos.Count; i++)
            {
                Punto puntoAux = listaDePuntos.First();
                listaDePuntos.RemoveFirst();
                Punto nuevoPunto = new Punto(
                    puntoReferencia.x + constante * (puntoAux.x - puntoReferencia.x),
                    puntoReferencia.y + constante * (puntoAux.y - puntoReferencia.y),
                    1);
                añadirPunto(nuevoPunto);
            }
        }
    }
}




