using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEOWALL_E.Relacionado_con_hulk.Geometria.Intersections
{
    public static class Intersections
    {
        static Secuencias<object> IntersectionBetween(ILugarGeometrico fig1, ILugarGeometrico fig2)
        {
            switch (fig1)
            {
                case Punto a:
                    return PointInFigure(a, fig2);
                case Line a:
                    return LineInFigure(a, fig2);
                case Segment a:
                    return SegmentInFigure(a, fig2);
                case Arc a:
                    return ArcInFigure(a, fig2);
                case Circle a:
                    return CircleInFigure(a, fig2);
                case Ray a:
                    return RayInFigure(a, fig2);
                default: return new Secuencias<object>();
            }
        }

        #region PuntoEnFiguras
        static Secuencias<object> PointInFigure(Punto punto, ILugarGeometrico figura)
        {
            switch (figura)
            {
                case Punto a:
                    return PuntoIntPunto(punto, a);
                case Line a:
                    return PuntoIntLine(punto, a);
                case Segment a:
                    return PuntoIntSegment(punto, a);
                case Arc a:
                    return PuntoIntArc(punto, a);
                case Circle a:
                    return PuntoIntCircle(punto, a);
                case Ray a:
                    return PuntoIntRay(punto, a);
                default: return new Secuencias<object>();
            }

        }
        static Secuencias<object> PuntoIntPunto(Punto p1, Punto p2)
        {
            if (p1.valor_x == p2.valor_x && p1.valor_y == p2.valor_y)
            {
                var x = new Secuencias<object>();
                x.Add(p1);
                return x;//secuencia con un punto
            }
            else
            {
                return new Secuencias<object>();//secuencia vacia
            }
        }
        static Secuencias<object> PuntoIntLine(Punto p1, Line line)
        {
            Func<double, double> recta = EcuacionRecta(line);
            if (PointInLine(p1, recta))
            {
                var x = new Secuencias<object>();
                x.Add(p1);
                return x;
            }
            else return new Secuencias<object>();
        }
        static bool PointInLine(Punto p1, Func<double, double> recta)
        {
            var Y = recta(p1.valor_x); // evalua en la recta
            if (Y == p1.valor_y) return true;//aqui puede que halla que agragarle un casteo a int o utilzar double.epsilon//OJO
            return false;
        }
        static Func<double, double> EcuacionRecta(Line line)
        {
            Punto P1 = (Punto)line.P1;//REVISA ESTOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
            Punto P2 = (Punto)line.P2;
            // Calcular la pendiente y el término independiente
            double pendiente = (P2.valor_y - P1.valor_y) / (P2.valor_x - P1.valor_x);
            double terminoIndependiente = P1.valor_y - pendiente * P1.valor_x;

            // Devolver la función de la recta
            return x => pendiente * x + terminoIndependiente;
        } // devuelve la ecuacion de una recta a partir de dos puntos
        static Secuencias<object> PuntoIntSegment(Punto p1, Segment segment)
        {
            Func<double, double> recta = EcuacionRecta(new Line(segment.P1, segment.P2));
            if (PointInLine(p1, recta))
            {
                Punto P1 = (Punto)segment.P1;//REVISA ESTOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                Punto P2 = (Punto)segment.P2;
                if (P1.valor_x <= P2.valor_x)
                {
                    if (p1.valor_x >= P1.valor_x && p1.valor_x <= P2.valor_x)
                    {
                        var x = new Secuencias<object>();
                        x.Add(p1);
                        return x;
                    }
                    else
                    {
                        return new Secuencias<object>();//secuencia vacia
                    }
                }
                else
                {
                    if (p1.valor_x >= P2.valor_x && p1.valor_x <= P1.valor_x)
                    {
                        var x = new Secuencias<object>();
                        x.Add(p1);
                        return x;
                    }
                    else
                    {
                        return new Secuencias<object>();//secuencia vacia
                    }
                }

            }
            else
            {
                return new Secuencias<object>();//secuencia vacia
            }
        }
        static Secuencias<object> PuntoIntArc(Punto p1, Arc arc)//falta
        {
            bool _PointInCircle = PointIntCircle(p1, new Circle(arc.P1, arc._Measure));
            Punto P1 = (Punto)arc.P1;
            Punto P2 = (Punto)arc.P2;
            Punto P3 = (Punto)arc.P3;
            double M1 = (P2.valor_y - P1.valor_y) / (P2.valor_x - P1.valor_x);
            double angulo_final = Math.Atan(M1) * 180 / Math.PI;

            double M2 = (P3.valor_y - P1.valor_y) / (P3.valor_x - P1.valor_x);
            double angulo_inicial = Math.Atan(M2) * 180 / Math.PI;

            double pendienteP = (p1.valor_y - P1.valor_y) / (p1.valor_x - P1.valor_x);
            double anguloPunto = Math.Atan(pendienteP) * 180 / Math.PI;

            bool PuntoEnAngulos = anguloPunto >= angulo_inicial && anguloPunto <= angulo_final;
            if (_PointInCircle && PuntoEnAngulos)
            {
                var x = new Secuencias<object>();
                x.Add(p1);
                return x;
            }
            else return new Secuencias<object>();//secuencia vacia
        }
        static Secuencias<object> PuntoIntCircle(Punto p1, Circle circle)
        {
            if (PointIntCircle(p1, circle))
            {
                var x = new Secuencias<object>();
                x.Add(p1);
                return x;
            }
            else return new Secuencias<object>();//secuencia vacia
        }
        static bool PointIntCircle(Punto p1, Circle circle)
        {
            Punto Centro = (Punto)circle.Centro;
            Measure radio = (Measure)circle.Radio;
            double DistanciaCentroPunto = DistanciaEPuntos(p1, Centro);
            if (DistanciaCentroPunto == radio.Valor) return true; // revisar precision con double.epsilon
            return false;
        }
        static double DistanciaEPuntos(Punto p1, Punto p2)
        {
            double distancia = Math.Sqrt((p1.valor_x - p2.valor_x) * (p1.valor_x - p2.valor_x) + (p1.valor_y - p2.valor_y) * (p1.valor_y - p2.valor_y));
            return distancia;
        }
        static Secuencias<object> PuntoIntRay(Punto p1, Ray ray)
        {
            Func<double, double> recta = EcuacionRecta(new Line(ray.P1, ray.P2));
            if (PointInLine(p1, recta))
            {
                Punto P1 = (Punto)ray.P1;//REVISA ESTOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                Punto P2 = (Punto)ray.P2;
                if (P1.valor_x <= P2.valor_x)
                {
                    if (p1.valor_x >= P1.valor_x)
                    {
                        var x = new Secuencias<object>();
                        x.Add(p1);
                        return x;
                    }
                    else return new Secuencias<object>();
                }
                else
                {
                    if (p1.valor_x <= P1.valor_x)
                    {
                        var x = new Secuencias<object>();
                        x.Add(p1);
                        return x;
                    }
                    else return new Secuencias<object>();
                }

            }
            else return new Secuencias<object>();
        }
        #endregion

        #region LineInFigure
        static Secuencias<object> LineInFigure(Line line, ILugarGeometrico fig)
        {
            switch (fig)
            {
                case Punto a:
                    return PointInFigure(a, line);
                case Line a:
                    return LineInLine(line,a);
                case Segment a:
                    return new Secuencias<object>();
                case Arc a:
                    return new Secuencias<object>();
                case Circle a:
                    return new Secuencias<object>();
                case Ray a:
                    return new Secuencias<object>();
                default: return new Secuencias<object>();
            }
        }
        static Secuencias<object> LineInLine(Line line1,Line line2)
        {
            switch (LinesInterceptions(line1, line2))
            {
                case 1:
                    {
                        var x = new Secuencias<object>();
                        x.Add(IntersectionOfLines(line1,line2));
                        return x;
                    }
                case 0:
                    return new Secuencias<object>();
                case -1:
                    {
                        var x = new Secuencias<object>();
                        x.Add(new undefined());
                        return x;
                    }
                    default: return new Secuencias<object>();
            }
        }
        static Punto IntersectionOfLines(Line line1,Line line2)
        {
            var recta1 = EcuacionRecta(line1);// y = mx+n
            var recta2 = EcuacionRecta(line2);// y = tx+k
            double n = recta1(0);
            double k = recta2(0);
            double m = (recta1(1)-n);
            double t = (recta2(1)-n);
            double x = (k - n) / (m - t);
            double y = recta1(x);
            return new Punto(x, y);
        }
        static int LinesInterceptions(Line line1, Line line2)
        {
            bool RectasCoincidentes(Line line1, Line line2)
            {
                if (MismaPendiente(line1, line2))
                {
                    Func<double, double> recta1 = EcuacionRecta(line1);
                    Func<double, double> recta2 = EcuacionRecta(line2);
                    return recta1(1) == recta2(1);
                }
                else return false;
            }
            bool MismaPendiente(Line line1, Line line2)
            {
                Punto P1 = (Punto)line1.P1;
                Punto P2 = (Punto)line1.P2;
                Punto P3 = (Punto)line2.P1;
                Punto P4 = (Punto)line2.P2;
                double M1 = (P2.valor_y - P1.valor_y) / (P2.valor_x - P1.valor_x);

                double M2 = (P3.valor_y - P4.valor_y) / (P3.valor_x - P4.valor_x);
                return M1 == M2;// revisar con math.epsilon
            }
            if (RectasCoincidentes(line1, line2)) return -1; // retorna -1 si la rectas son coincidentes,hay q devolver undefined
            if(MismaPendiente(line1 , line2)) return 0; //retorna 0 si la rectas son paralelas, hay que devolver una secuencia vacia
            return 1; // retorna 1 , devuelve una secuencia con un punto
        }
        //static Secuencias<object> LineIntSegment(Line line, Segment segment)
        //{
        //    switch (LinesInterceptions(line, new Line(segment.P1,segment.P2)))
        //    {
                
        //    }
        //}
        
            #endregion

            #region SegmentInFigure
            static Secuencias<object> SegmentInFigure(Segment segment, ILugarGeometrico fig)
        {
            switch (fig)
            {
                case Punto a:
                    return PointInFigure(a, fig);
                case Line a:
                    return new Secuencias<object>();
                case Segment a:
                    return new Secuencias<object>();
                case Arc a:
                    return new Secuencias<object>();
                case Circle a:
                    return new Secuencias<object>();
                case Ray a:
                    return new Secuencias<object>();
                default: return new Secuencias<object>();
            }
        }
        #endregion

        #region ArcInFigure
        static Secuencias<object> ArcInFigure(Arc arc, ILugarGeometrico fig)
        {
            switch (fig)
            {
                case Punto a:
                    return PointInFigure(a, fig);
                case Line a:
                    return new Secuencias<object>();
                case Segment a:
                    return new Secuencias<object>();
                case Arc a:
                    return new Secuencias<object>();
                case Circle a:
                    return new Secuencias<object>();
                case Ray a:
                    return new Secuencias<object>();
                default: return new Secuencias<object>();
            }
        }
        #endregion

        #region CircleInFigure
        static Secuencias<object> CircleInFigure(Circle circle, ILugarGeometrico fig)
        {
            switch (fig)
            {
                case Punto a:
                    return PointInFigure(a, fig);
                case Line a:
                    return new Secuencias<object>();
                case Segment a:
                    return new Secuencias<object>();
                case Arc a:
                    return new Secuencias<object>();
                case Circle a:
                    return new Secuencias<object>();
                case Ray a:
                    return new Secuencias<object>();
                default: return new Secuencias<object>();
            }
        }
        #endregion

        #region RayInFigure
        static Secuencias<object> RayInFigure(Ray ray, ILugarGeometrico fig)
        {
            switch (fig)
            {
                case Punto a:
                    return PointInFigure(a, fig);
                case Line a:
                    return new Secuencias<object>();
                case Segment a:
                    return new Secuencias<object>();
                case Arc a:
                    return new Secuencias<object>();
                case Circle a:
                    return new Secuencias<object>();
                case Ray a:
                    return new Secuencias<object>();
                default: return new Secuencias<object>();
            }

        }
        #endregion

    }

}
