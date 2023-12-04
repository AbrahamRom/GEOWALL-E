using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEOWALL_E
{
    class Measure : Expresion
    {
        public Measure(Punto p1, Punto p2)
        {
            P1 = p1;
            P2 = p2;
        }
        public override Tipo_De_Token Tipo => Tipo_De_Token.measure_Expresion;
        public Punto P1 { get; }
        public Punto P2 { get; }

    }
}
