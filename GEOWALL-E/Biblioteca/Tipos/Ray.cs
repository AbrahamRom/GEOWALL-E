using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEOWALL_E
{
    class Ray : ILugarGeometrico  //representa una rayo
    {
        public Ray(Punto p1, Punto p2)
        {
            P1 = p1;
            P2 = p2;
            Identificador = "Ray_" + p1.Identificador + p2.Identificador; // identificador por defecto
        }
        public string Identificador { get; set; }
        public Punto P1 { get; }
        public Punto P2 { get; }

        public void Draw() { }
    }
}