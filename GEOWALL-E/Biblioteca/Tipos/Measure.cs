using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEOWALL_E
{
    class Measure
    {
        public Measure(Punto p1, Punto p2)
        {
            P1 = p1;
            P2 = p2;
            CalcularDistancia();
        }
        
        //  public override Tipo_De_Token Tipo => Tipo_De_Token.circle_Expresion;
       // public string Identificador { get; }
        public Punto P1 { get; }
        public Punto P2 { get; }

        public double Value { get; private set; }

        private void CalcularDistancia()  // Distancai entre dos puntos
        {
            double x1 = P1.Componente_x;
            double x2 = P2.Componente_x;
            double y1 = P1.Componente_y;
            double y2 = P2.Componente_y;
            double distancia = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            Value = distancia;
        }
    }
}
