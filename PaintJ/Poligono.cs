using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintJ
{
    [Serializable]
    public class Poligono
    {
        public Punto puntoReferencia;
        public LinkedList<Punto> listaDePuntos;
        string nombre;
        float[][] matriz;
        public Poligono()
        {
            listaDePuntos = new LinkedList<Punto>();
            puntoReferencia = null;
            matriz = new float[3][];
            matriz[0] = new float[3];
            matriz[1] = new float[3];
            matriz[2] = new float[3];
            nombre = "nombre";
            limpiarMatriz();
        }

        public override string ToString()
        {
            return nombre;
        }

        public void setNombre(string nuevoNombre) => nombre = nuevoNombre;

        public void añadirPunto(Punto punto)=> listaDePuntos.AddLast(punto);

        public void setPuntoReferencia(Punto nuevoPuntoDeReferencia) => puntoReferencia = nuevoPuntoDeReferencia;

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

        public void setPuntoReferenciaEnOrigen() => puntoReferencia = new Punto(0, 0, 1);

        private void limpiarMatriz()
        {
            matriz[0][0] = 1;
            matriz[0][1] = 0;
            matriz[0][2] = 0;
            matriz[1][0] = 0;
            matriz[1][1] = 1;
            matriz[1][2] = 0;
            matriz[2][0] = 0;
            matriz[2][1] = 0;
            matriz[2][2] = 1;
        }

        private void aplicarCambios()
        {
            Punto punto,nuevoPunto;
            for (int i = 1; i <= listaDePuntos.Count; i++)
            {
                punto = listaDePuntos.First();
                listaDePuntos.RemoveFirst();
                nuevoPunto = new Punto(
                    punto.x * matriz[0][0] + punto.y * matriz[0][1] + punto.z * matriz[0][2],
                    punto.x * matriz[1][0] + punto.y * matriz[1][1] + punto.z * matriz[1][2],
                    punto.x * matriz[2][0] + punto.y * matriz[2][1] + punto.z * matriz[2][2]);
                añadirPunto(nuevoPunto);
            }
            limpiarMatriz();
        }

        public void trasladar(Punto puntoAMoverse)
        {
            setPuntoReferenciaEnCentro();
            matriz[0][2] = puntoAMoverse.x - puntoReferencia.x;
            matriz[1][2] = puntoAMoverse.y - puntoReferencia.y;
            aplicarCambios();
        }

        public void rotar(double angulo)
        {
            float xc = puntoReferencia.x;
            float yc = puntoReferencia.y;
            angulo = (angulo * Math.PI) / 180;
            matriz[0][0] = (float)Math.Cos(angulo);
            matriz[0][1] = -(float)Math.Sin(angulo);
            matriz[0][2] = xc - (xc * (float)Math.Cos(angulo)) + 
                            (yc * (float)Math.Sin(angulo));
            matriz[1][0] = (float)Math.Sin(angulo);
            matriz[1][1] = (float)Math.Cos(angulo);
            matriz[1][2] = yc - (xc * (float)Math.Sin(angulo)) -
                            (yc * (float)Math.Cos(angulo));
            aplicarCambios();
        }

        public void borrarUltimoPunto() => listaDePuntos.RemoveLast();

        public void escalar(float constante)
        {
            Punto p = puntoReferencia;
            matriz[0][0] = constante;
            matriz[0][1] = 0;
            matriz[0][2] = p.x * (1 - constante);
            matriz[1][0] = 0;
            matriz[1][1] = constante;
            matriz[1][2] = p.y * (1 - constante);
            aplicarCambios();
        }

        public void reflexion(bool xy)
        {//true para reflexion en X
            matriz[0][0] =  xy ? 1 : -1;
            matriz[1][1] = matriz[0][0] * (-1);
            aplicarCambios();
        }

        public void reflexionRecta(Poligono recta)
        {
            float x1 = recta.listaDePuntos.First().x;
            float y1 = recta.listaDePuntos.First().y;
            float x2 = recta.listaDePuntos.Last().x;
            float y2 = recta.listaDePuntos.Last().y;
            setPuntoReferenciaEnCentro();
            float xc = puntoReferencia.x;
            float yc = puntoReferencia.y;
            float m = (y2 - y1) / (x2 - x1);
            float m2 = (-1) / m;
            float a = m2;
            float b = (m2 * xc) - yc;
            float c = m;
            float d = (m * x1) - y1;
            float x = (b - d) / (a - c);
            float y = (((a * b) - (a * d)) / (a - c)) - b;
            Punto punto, nuevoPunto;
            for (int i = 1; i <= listaDePuntos.Count; i++)
            {
                punto = listaDePuntos.First();
                listaDePuntos.RemoveFirst();
                nuevoPunto = new Punto(
                    punto.x - (2 * (punto.x - x)),//punto.x - x,
                    punto.y - (2 * (punto.y - y)),//punto.y - y,
                    1);
                listaDePuntos.AddLast(nuevoPunto);
            }
            /*reflexion(true);
            setPuntoReferenciaEnCentro();
            for (int i = 1; i <= listaDePuntos.Count; i++)
            {
                punto = listaDePuntos.First();
                listaDePuntos.RemoveFirst();
                nuevoPunto = new Punto(
                    punto.x + x,
                    punto.y + y,
                    1);
                listaDePuntos.AddLast(nuevoPunto);
            }*/
        }
        public string toString()
        {
            return nombre;
        }
    }
}





