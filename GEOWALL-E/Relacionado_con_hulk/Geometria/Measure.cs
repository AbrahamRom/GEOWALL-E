using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEOWALL_E
{
    class Measure : Expresion
    {
        public Measure(double valor)
        {
            Valor = valor;
        }
        public Measure(Expresion p1, Expresion p2)
        {
            P1 = p1;
            P2 = p2;
            //Punto x = (Punto)P1;
            //Punto y = (Punto)P2;
            //Valor = DistanciaEPuntos(x, y);
        }
        public override Tipo_De_Token Tipo => Tipo_De_Token.measure_Expresion;
        public Expresion P1 { get; }
        public Expresion P2 { get; }
        public double Valor { get; }
        double DistanciaEPuntos(Punto p1, Punto p2)
        {
            double distancia = Math.Sqrt((p1.valor_x - p2.valor_x) * (p1.valor_x - p2.valor_x) + (p1.valor_y - p2.valor_y) * (p1.valor_y - p2.valor_y));
            return distancia;
        }
    }
}
