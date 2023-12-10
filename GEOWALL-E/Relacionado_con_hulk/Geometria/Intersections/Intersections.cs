using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEOWALL_E.Relacionado_con_hulk.Geometria.Intersections
{
    public class Intersections
    {
        #region PuntoEnFiguras
        Secuencia PointInFigure(Punto punto, ILugarGeometrico figura)
        {
            switch (figura)
            {
                case Punto a:
                        return PuntoIntPunto(punto,a);
                case Line a:
                        return PuntoIntLine(punto,a);
                case Segment a:
                    {
                        return new Secuencia();
                    }
                case Arc a:
                    {
                        return new Secuencia();
                    }
                case Circle a:
                    {
                        return new Secuencia();
                    }
                case Ray a:
                    {
                        return new Secuencia();
                    }
                default: return new Secuencia();
            }
            Secuencia PuntoIntPunto(Punto p1,Punto p2)
            {
                if (p1.valor_x == p2.valor_x && p1.valor_y == p2.valor_y)
                {
                    return new Secuencia();//secuencia con un punto
                }
                else
                {
                    return new Secuencia();//secuencia vacia
                }
            }
            Secuencia PuntoIntLine(Punto p1,Line line)
            {
                Func<double, double> recta = EcuacionRecta(line);
                var Y = recta(p1.valor_x); // evalua en la recta
                if (Y == p1.valor_y)
                {
                    return new Secuencia();//secuencia con un punto p1
                }
                else
                {
                    return new Secuencia();//secuencia vacia
                }
            }
            Func<double,double> EcuacionRecta(Line line)
            {
                // Calcular la pendiente y el término independiente
                double pendiente = (line.P2.valor_y - line.P1.valor_y) / (line.P2.valor_x - line.P1.valor_x);
                double terminoIndependiente = line.P1.valor_y - pendiente * line.P1.valor_x;

                // Devolver la función de la recta
                return x => pendiente * x + terminoIndependiente;
            } // devuelve la ecuacion de una recta a partir de dos puntos
        }
        #endregion
        public class Secuencia
        {

        }
    }
}
