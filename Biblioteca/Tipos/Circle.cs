using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEOWALL_E
{
    class Circle:ILugarGeometrico
    {
        public Circle(Point centro, Measure radio)
        {
            Identificador = "Circunferencia_"+centro.Identificador+radio.Identificador; //nombre por defecto para el ambito local
            Centro = centro;
            Radio = radio;
        }
      //  public override Tipo_De_Token Tipo => Tipo_De_Token.circle_Expresion;
        public string Identificador { get; set; }
        public Point Centro { get; }
        public Measure Radio { get; }

        public void Draw() { }
    }
}
