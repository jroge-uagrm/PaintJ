using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintJ
{
    public class Efecto
    {
        public string nombre = "";
        public Poligono poligono = null;
        public Punto punto =null;
        public float numero =0;
        public int indice=-1;

        public Efecto(string efecto, Punto punto,int indice)
        {
            this.nombre = efecto;
            this.punto = punto;
            this.indice = indice;
        }
        public Efecto(string efecto, float numero,int indice)
        {
            this.nombre = efecto;
            this.numero = numero;
            this.indice = indice;
        }
        public Efecto(string nombre, Poligono poligono,int indice)
        {
            this.nombre = nombre;
            this.poligono = poligono;
            this.indice = indice;
        }

        public override string ToString()
        {
            if (punto != null)
            {
                return nombre +" i"+ indice+" P" + punto.ToString();
            }
            return nombre +" - "+ numero.ToString();
        }
    }
}
