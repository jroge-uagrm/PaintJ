using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintJ
{
    [Serializable]
    public class Punto
    {
        public float x, y, z;
        public Punto(float a,float b,float c)
        {
            this.x = a;this.y = b;this.z = c;
        }
        public override string ToString()
        {
            return "("+x.ToString() + " , " + y.ToString()+" , "+z.ToString()+")";
        }
    }
}
