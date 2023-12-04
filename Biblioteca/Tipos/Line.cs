using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEOWALL_E
{
     class Line:ILugarGeometrico  //representa una recta
    {
        public Line(Point p1,Point p2)
        {
            P1 = p1;
            P2 = p2;
            Identificador = "Line_" + p1.Identificador + p2.Identificador; // identificador por defecto
        }
        public string Identificador { get; set; }
        public Point P1 { get; }
        public Point P2 { get; }

        public void Draw() { }
    }
}
