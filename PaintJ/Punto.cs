using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintJ
{
    [Serializable]
    class Punto
    {
        public float x, y;
        public Punto(float a,float b)
        {
            this.x = a;this.y = b;
        }
        public override string ToString()
        {
            return "("+x.ToString() + " , " + y.ToString()+")";
        }
    }
}
