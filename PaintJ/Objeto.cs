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
        public Objeto()
        {
            listaDePoligonos = new LinkedList<Poligono>();
        }
        public void añadirPoligono(Poligono poligono)
        {
            listaDePoligonos.AddLast(poligono);
        }

    }
}
