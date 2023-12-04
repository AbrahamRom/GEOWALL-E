﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEOWALL_E
{
    class Segment : ILugarGeometrico  //representa un segmento
    {
        public Segment(Point p1, Point p2)
        {
            P1 = p1;
            P2 = p2;
            Identificador = "Segment_" + p1.Identificador + p2.Identificador; // identificador por defecto
           CalcularDistancia();
        }
        public string Identificador { get; set; }
        public Point P1 { get; }
        public Point P2 { get; }

        public double Longitud { get; private set; }

        private void CalcularDistancia()  // Distancai entre dos puntos
        {
            double x1 = P1.Componente_x;
            double x2 = P2.Componente_x;
            double y1 = P1.Componente_y;
            double y2 = P2.Componente_y;
            double distancia = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            Longitud = distancia;
        }

        public void Draw() { }
    }
}
