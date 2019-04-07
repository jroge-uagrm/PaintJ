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
        public LinkedList<Punto> listaDePuntos;
        public Poligono()
        {
            listaDePuntos = new LinkedList<Punto>();
        }
        public void añadirPunto(Punto punto)
        {
            listaDePuntos.AddLast(punto);
        }
    }
}
