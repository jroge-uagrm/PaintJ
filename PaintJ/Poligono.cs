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
        public Poligono()
        {
            listaDePuntos = new LinkedList<Punto>();
            puntoReferencia = null;
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
            float mayorEnX = float.MinValue;
            float mayorEnY = float.MinValue;
            for (int i = 1; i <= listaDePuntos.Count; i++)
            {
                punto = listaDePuntos.First();
                listaDePuntos.RemoveFirst();
                listaDePuntos.AddLast(punto);
                menorEnX = punto.x < menorEnX ? punto.x : menorEnX;
                menorEnY = punto.y < menorEnY ? punto.y : menorEnY;
                mayorEnX = punto.x > mayorEnX ? punto.x : mayorEnX;
                mayorEnY = punto.y > mayorEnY ? punto.y : mayorEnY;
            }
            mayorEnX = (float)(((float)(mayorEnX + menorEnX)) / 2);
            mayorEnY = (float)(((float)(mayorEnY + menorEnY)) / 2);
            puntoReferencia = new Punto(mayorEnX,mayorEnY);
        }
        public void enFuncionACentro()
        {
            Punto punto,nuevoPunto;
            setPuntoReferenciaEnCentro();
            for (int i = 1; i <= listaDePuntos.Count; i++)
            {
                punto = listaDePuntos.First();
                listaDePuntos.RemoveFirst();
                nuevoPunto = new Punto(
                    (float)(punto.x-this.puntoReferencia.x),
                    (float)(punto.y-this.puntoReferencia.y));
                listaDePuntos.AddLast(nuevoPunto);
            }
        }
        public void enFuncionANoCentro()
        {
            Punto punto,nuevoPunto;
            for (int i = 1; i <= listaDePuntos.Count; i++)
            {
                punto = listaDePuntos.First();
                listaDePuntos.RemoveFirst();
                nuevoPunto = new Punto(
                    (float)(punto.x + this.puntoReferencia.x),
                    (float)(punto.y + this.puntoReferencia.y));
                listaDePuntos.AddLast(nuevoPunto);
            }
        }

        public void trasladar(Punto nuevoPuntoReferencia)
        {
            enFuncionACentro();
            puntoReferencia = nuevoPuntoReferencia;
            enFuncionANoCentro();
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
                    (float)((punto.x - puntoReferencia.x) * (Math.Sin(angulo))) +
                    (float)((punto.y - puntoReferencia.y) * (Math.Cos(angulo))));
                listaDePuntos.AddLast(nuevoPunto);
            }
        }
    }
}




