﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEOWALL_E.Relacionado_con_hulk.Geometria
{
    class Samples : Expresion, IEnumerable<Punto>
    {
        public override Tipo_De_Token Tipo => Tipo_De_Token.samples_Expresion;

        public IEnumerator<Punto> GetEnumerator()
        {
            Random _random = new Random();
            int tope = _random.Next(0, 4000);

            for (int i = 0; i < tope; i++)
            {
                yield return new Punto();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
