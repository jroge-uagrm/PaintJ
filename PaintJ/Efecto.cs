using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintJ
{
    [Serializable]
    public class Efecto
    {
        public string nombre = "";
        public Poligono poligono = null;
        public Punto punto =null;
        public float numero =0;
        public LinkedList<int> indices=new LinkedList<int>();
        public bool ejeX;
        public Efecto(string nombre, Poligono poligono, Punto punto, float numero, LinkedList<int> indice, bool ejeX)
        {
            this.nombre = nombre;
            this.poligono = poligono;
            this.punto = punto;
            this.numero = numero;
            this.indices = indice;
            this.ejeX = ejeX;
        }
        public Efecto(string efecto, Punto punto,LinkedList<int> indice)
        {
            this.nombre = efecto;
            this.punto = punto;
            this.indices = indice;
        }
        public Efecto(string efecto, float numero, LinkedList<int>  indice)
        {
            this.nombre = efecto;
            this.numero = numero;
            this.indices = indice;
        }
        public Efecto(string nombre, Poligono poligono, LinkedList<int> indice)
        {
            this.nombre = nombre;
            this.poligono = poligono;
            this.indices = indice;
        }
        public Efecto(string nombre, bool ejeX, LinkedList<int> indice)
        {
            this.nombre = nombre;
            this.ejeX = ejeX;
            this.indices = indice;
        }

        public override string ToString()
        {
            if (punto != null)
            {
                return nombre + " i" + indices + " P" + punto.ToString();
            }
            else if (numero != 0)
            {
                return nombre + " i" + indices + " N" + numero.ToString();
            }else if (poligono != null)
            {
                return nombre + " i" + indices + " P " + poligono.nombre;
            }
            else
            {
                return "SSSS";
            }
        }
    }
}
