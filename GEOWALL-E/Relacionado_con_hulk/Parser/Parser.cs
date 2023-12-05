using GEOWALL_E.Relacionado_con_hulk.Geometria.Draw_Functions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;

namespace GEOWALL_E
{
    //Aqui a partir de los token qu saque en el analizador voy a
    // ir viendo que es cada uno y que puedo hcer con ellos 
    class Parser
    {
        private readonly Token[] _tokens;// todos los tokens se guardan aqui
        private int _posicion;
        public List<string> errores = new List<string>();


        public List<Expresion> Lista = new List<Expresion>();

        public Parser(string texto)
        {
            var tokens = new List<Token>();
            var Analizador = new Analizador_lexico(texto);
            Token token;
            do
            {
                token = Analizador.Proximo_Token();
                if (token.Tipo != Tipo_De_Token.Espacio && token.Tipo != Tipo_De_Token.Malo && token.Tipo != Tipo_De_Token.Final && token.Tipo != Tipo_De_Token.la_nada && token.Tipo != Tipo_De_Token.salto_de_linea) tokens.Add(token);
            }
            while (token.Tipo != Tipo_De_Token.Final);
            _tokens = tokens.ToArray();
            if (tokens[_tokens.Length - 1].Tipo != Tipo_De_Token.salto_de_linea && tokens.Count > 0 && tokens[_tokens.Length - 1].Tipo != Tipo_De_Token.punto_y_coma) errores.Add($"! SYNTAX ERROR : Expected in the end off line <{";"}> not <{tokens[_tokens.Length - 1].Texto}>");
            errores.AddRange(Analizador.Error);
        }

        private Token Tomar(int offset)
        {
            int index = _posicion + offset;
            if (index >= _tokens.Length) return _tokens[_tokens.Length - 1];
            else return _tokens[index];
        }
        private Token Verificandose => Tomar(0);

        public Token Proximo_Token()
        {
            var token = Verificandose;
            _posicion++;
            return token;
        }
        public Token Match(Tipo_De_Token tipo)
        {
            if (Verificandose.Tipo == tipo) return Proximo_Token();
            else if (_tokens.Length == 1) errores.Add($"! SYNTAX ERROR : Not find <{tipo}> in <{_posicion}>");
            else throw new Exception($"! SYNTAX ERROR : Not find <{tipo}> after <{Tomar(-1).Texto}> in position <{_posicion}>");
            return new Token(tipo, Verificandose.Posicion, null, null);

        }
        public Arbol Parse()
        {
            if (_tokens.Length == 0) return new Arbol(errores, null);
            var expresion = Parse_Expresion();
            Lista.Add(expresion);

            Match(Tipo_De_Token.punto_y_coma);
            if(_posicion < _tokens.Length - 1 )
            {
                return Parse();
            }          
            return new Arbol(errores, Lista);
        }
        public Expresion Parse_Expresion()
        {
            if (Verificandose.Tipo is Tipo_De_Token.function_Keyword)
            {
                return Parse_Declaracion_Funcion();
            }
            return Parse_Expresion_Binaria();
        }
        private Declaracion_Funcion Parse_Declaracion_Funcion()
        {
            var keyword = Match(Tipo_De_Token.function_Keyword);
            var nombre = Match(Tipo_De_Token.Identificador);
            var parametros = Parseo_parametros();
            var implicacion = Match(Tipo_De_Token.Implicacion);
            var cuerpo = Parse_Expresion();
            var declaracion_Funcion = new Declaracion_Funcion(nombre.Texto, parametros, cuerpo);

            if (!Biblioteca.Functions.ContainsKey(nombre.Texto) && errores.Count == 0 && nombre.Texto != "sen(x)" && nombre.Texto != "cos(x)" && nombre.Texto != "log(x)")
            {
                Biblioteca.Functions.Add(nombre.Texto, declaracion_Funcion);
            }
            else
            {
                errores.Add($"! FUNCTION ERROR : Function <{nombre.Texto}> is already defined");
            }

            return declaracion_Funcion;
        }
        public List<string> Parseo_parametros()
        {
            Match(Tipo_De_Token.Parentesis_Abierto);
            var parametros = new List<string>();
            if (Verificandose.Tipo is Tipo_De_Token.Parentesis_Cerrado)
            {
                Proximo_Token();
                return parametros;
            }
            parametros.Add(Verificandose.Texto);
            Proximo_Token();
            while (Verificandose.Tipo == Tipo_De_Token.coma)
            {
                Proximo_Token();
                if (Verificandose.Tipo is not Tipo_De_Token.Identificador)
                {
                    errores.Add($"! SEMANTIC ERROR : Parameters must be a valid identifier");
                }
                if (parametros.Contains(Verificandose.Texto))
                {
                    errores.Add($"! SEMANTIC ERROR : A parameter with the name <'{Verificandose.Texto}'> already exists insert another parameter name");

                }
                parametros.Add(Verificandose.Texto);
                Proximo_Token();
            }
            Proximo_Token();
            return parametros;
        }
        private Expresion Parse_LLamada_Funcion(string identificador)
        {
            Proximo_Token();
            var parametros = new List<Expresion>();

            Match(Tipo_De_Token.Parentesis_Abierto);

            int evitar_bucle = 0;
            while (true)
            {

                if (Verificandose.Tipo == Tipo_De_Token.Parentesis_Cerrado)
                {
                    break;
                }
                var expresion = Parse_Expresion();
                parametros.Add(expresion);
                if (Verificandose.Tipo == Tipo_De_Token.coma)
                {
                    Proximo_Token();
                }
                if (evitar_bucle == _posicion)
                {
                    errores.Add($"! SYNTAX ERROR : Expected <{")"}> in position <{_posicion}> after the expresion");
                    break;
                }
                evitar_bucle = _posicion;
            }

            Match(Tipo_De_Token.Parentesis_Cerrado);

            return new LLamada_Funcion(identificador, parametros);
        }
        private Expresion Parse_Variable_O_LLamada_Funcion()
        {
            if (Verificandose.Tipo == Tipo_De_Token.Identificador
            && Tomar(1).Tipo == Tipo_De_Token.Parentesis_Abierto)
            {
                return Parse_LLamada_Funcion(Verificandose.Texto);
            }
            else
            {
                var identificador = Proximo_Token();
                return new Literal(identificador, identificador.Texto);
            }
        }
        public Expresion Parse_Let_in_Expresion()
        {
            var let_id = Match(Tipo_De_Token.let_Keyword);
            var let_Expresion = Parse_Let_Expresion();
            var in_id = Match(Tipo_De_Token.in_Keyword);
            var in_Expresion = Parse_Expresion();
            return new Let_in(let_Expresion, in_Expresion);
        }
        public Let Parse_Let_Expresion()
        {
            var keyword = Match(Tipo_De_Token.Identificador);
            var igual = Match(Tipo_De_Token.Igual);
            var asignar = Parse_Expresion();

            if (Verificandose.Tipo == Tipo_De_Token.coma)
            {
                var coma = Match(Tipo_De_Token.coma);
                var otras_variables = Parse_Let_Expresion();
                return new Let(keyword, asignar, otras_variables);
            }
            else
            {
                return new Let(keyword, asignar);
            }
        }
        private Expresion Parse_Expresion_Binaria(int parentPrecedence = 0)
        {
            Expresion left;
            var expresion_unaria = Verificandose.Tipo.Prioridad_Operadores_Unarios();

            if (expresion_unaria != 0 && expresion_unaria >= parentPrecedence)
            {
                var operador = Proximo_Token();
                var right = Parse_Expresion_Binaria(expresion_unaria);
                left = new Expresion_Unaria(operador, right);
            }
            else left = Parseo_Fundamental_Expresion();

            while (true)
            {
                var precedence = Verificandose.Tipo.Prioridad_Operadores_Binarios();
                if (precedence == 0 || precedence <= parentPrecedence) break;

                var operador = Proximo_Token();
                var right = Parse_Expresion_Binaria(precedence);
                left = new Expresion_Binaria(left, operador, right);
            }
            return left;
        }
        private Expresion Parseo_Fundamental_Expresion()
        {
            switch (Verificandose.Tipo)
            {
                case Tipo_De_Token.clean_keyword:
                    {
                        var keyword = Proximo_Token();
                        return new Clean(keyword);
                    }
                case Tipo_De_Token.Parentesis_Abierto:
                    {
                        var left = Proximo_Token();
                        var expresion = Parse_Expresion();
                        var right = Match(Tipo_De_Token.Parentesis_Cerrado);
                        return new Parentesis(left, expresion, right);
                    }
                case Tipo_De_Token.Identificador:
                    {
                        return Parse_Variable_O_LLamada_Funcion();
                    }
                case Tipo_De_Token.if_Keyword:
                    {
                        var keyword = Proximo_Token();
                        if (Verificandose.Tipo != Tipo_De_Token.Parentesis_Abierto)
                        {
                            errores.Add($"! SYNTAX ERROR : Expected <{"("}>  in  position <{_posicion}> before the expresion");
                        }
                        var op_parentesis = Proximo_Token();
                        var parentesis = Parse_Expresion();
                        if (Verificandose.Tipo != Tipo_De_Token.Parentesis_Cerrado)
                        {
                            errores.Add($"! SYNTAX ERROR : Expected <{")"}> in position <{_posicion}> after the expresion");
                        }
                        var cl_parentesis = Proximo_Token();
                        Match(Tipo_De_Token.then_Keyword);
                        var expresion = Parse_Expresion();
                        var _else = Parse_Expresion();
                        if (_else.Tipo != Tipo_De_Token.else_Expresion)
                            errores.Add($" SEMANTIC ERROR : Invalid expresion <{_else.Tipo}> in position <{_posicion}> expected <{"else_Expresion"}>");
                        return new IF(keyword, op_parentesis, parentesis, cl_parentesis, expresion, _else);
                    }
                case Tipo_De_Token.else_Keyword:
                    {
                        var keyword = Proximo_Token();
                        var expresion = Parse_Expresion();
                        return new Else(keyword, expresion);
                    }
                case Tipo_De_Token.let_Keyword:
                    {
                        return Parse_Let_in_Expresion();
                    }
                case Tipo_De_Token.in_Keyword:
                    {
                        var keyword = Match(Tipo_De_Token.in_Keyword);
                        var expresion = Parse_Expresion();
                        return new In(expresion);
                    }
                case Tipo_De_Token.PI_Keyword:
                    {
                        var PI = Match(Tipo_De_Token.PI_Keyword);
                        var valor = Math.PI;
                        return new Literal(PI, valor);
                    }
                case Tipo_De_Token.String:
                    {
                        var keyword = Match(Tipo_De_Token.String);
                        var valor = keyword.Texto;
                        return new Literal(keyword, valor);
                    }
                case Tipo_De_Token.sen_Keyword:
                    {
                        var keyword = Proximo_Token();
                        if (Verificandose.Tipo != Tipo_De_Token.Parentesis_Abierto)
                        {
                            errores.Add($"! SYNTAX ERROR : Expected <{"("}> in position <{_posicion}> before the expresion");
                        }
                        var op_parentesis = Proximo_Token();
                        var expresion = Parse_Expresion();
                        if (Verificandose.Tipo != Tipo_De_Token.Parentesis_Cerrado)
                        {
                            errores.Add($"! SYNTAX ERROR : Expected <{")"}> in position <{_posicion}> after the expresion");
                        }
                        var cl_parentesis = Proximo_Token();
                        return new Sen(keyword, op_parentesis, expresion, cl_parentesis);
                    }
                case Tipo_De_Token.cos_Keyword:
                    {
                        var keyword = Proximo_Token();
                        if (Verificandose.Tipo != Tipo_De_Token.Parentesis_Abierto)
                        {
                            errores.Add($"! SYNTAX ERROR : Expected <{"("}> in position <{_posicion}> before the expresion");
                        }
                        var op_parentesis = Proximo_Token();
                        var expresion = Parse_Expresion();
                        if (Verificandose.Tipo != Tipo_De_Token.Parentesis_Cerrado)
                        {
                            errores.Add($"! SYNTAX ERROR : Expected <{")"}> in position <{_posicion}> after the expresion");
                        }
                        var cl_parentesis = Proximo_Token();
                        return new Cos(keyword, op_parentesis, expresion, cl_parentesis);
                    }
                case Tipo_De_Token.logaritmo_Keyword:
                    {
                        var keyword = Proximo_Token();
                        if (Verificandose.Tipo != Tipo_De_Token.Parentesis_Abierto)
                        {
                            errores.Add($"! SYNTAX ERROR : Expected <{"("}> in position <{_posicion}> before the expresion");
                        }
                        var op_parentesis = Proximo_Token();
                        var expresion = Parse_Expresion();
                        if (Verificandose.Tipo != Tipo_De_Token.Parentesis_Cerrado)
                        {
                            errores.Add($"! SYNTAX ERROR : Expected <{")"}> in position <{_posicion}> after the expresion");
                        }
                        var cl_parentesis = Proximo_Token();
                        return new Logaritmo(keyword, op_parentesis, expresion, cl_parentesis);
                    }

                //Geometria-------------------------------------------------------------------------------------------------

                case Tipo_De_Token.draw_Keyword:
                    {
                        Proximo_Token();
                        var _expresion = Parse_Expresion();
                        return new Dibujar(_expresion);
                    }


                case Tipo_De_Token.point_Keyword:
                    {
                        Proximo_Token();
                        string identificador = Match(Tipo_De_Token.Identificador).Texto;
                        if (Verificandose.Tipo != Tipo_De_Token.Parentesis_Abierto)
                        {
                            return new Punto(identificador);
                        }
                        else
                        {
                            //ver con imbert y si me pasan una expresion como parametro?
                            Match(Tipo_De_Token.Parentesis_Abierto);
                            var componente_x = Parse_Expresion();
                            Match(Tipo_De_Token.coma);
                            var componente_y = Parse_Expresion();
                            Match(Tipo_De_Token.Parentesis_Cerrado);
                            return new Punto(identificador, componente_x, componente_y);
                        }
                    }
                case Tipo_De_Token.measure_Keyword:
                    {
                        Proximo_Token();
                        Match(Tipo_De_Token.Parentesis_Abierto);
                        var P1 = Parse_Expresion();
                        Match(Tipo_De_Token.coma);
                        var P2 = Parse_Expresion();
                        Match(Tipo_De_Token.Parentesis_Cerrado);
                        return new Measure(P1,P2);
                    }

                case Tipo_De_Token.circle_Keyword:
                    {
                        Proximo_Token();
                        if(Verificandose.Tipo == Tipo_De_Token.Identificador)
                        {
                            var identificador = Proximo_Token();
                            if(Verificandose.Tipo == Tipo_De_Token.Parentesis_Abierto)
                            {
                                Proximo_Token();
                                var centro = Parse_Expresion();
                                Match(Tipo_De_Token.coma);
                                var radio = Parse_Expresion();
                                Match(Tipo_De_Token.Parentesis_Cerrado);
                                return new Circle(identificador.Texto, centro, radio);
                            }
                            else
                            {
                                return new Circle(identificador.Texto);
                            }

                        }
                        else
                        {
                            Match(Tipo_De_Token.Parentesis_Abierto);
                            var centro = Parse_Expresion();
                            Match(Tipo_De_Token.coma);
                            var radio = Parse_Expresion();
                            Match(Tipo_De_Token.Parentesis_Cerrado);
                            return new Circle(centro, radio);
                        }

                    }
                case Tipo_De_Token.segment_Keyword:
                    {
                        Proximo_Token();
                        if (Verificandose.Tipo == Tipo_De_Token.Identificador)
                        {
                            var identificador = Proximo_Token();
                            if (Verificandose.Tipo == Tipo_De_Token.Parentesis_Abierto)
                            {
                                Proximo_Token();
                                var P1 = Parse_Expresion();
                                Match(Tipo_De_Token.coma);
                                var P2 = Parse_Expresion();
                                Match(Tipo_De_Token.Parentesis_Cerrado);
                                return new Segment(identificador.Texto, P1, P2);
                            }
                            else
                            {
                                return new Segment(identificador.Texto);
                            }

                        }
                        else
                        {
                            Match(Tipo_De_Token.Parentesis_Abierto);
                            var P1 = Parse_Expresion();
                            Match(Tipo_De_Token.coma);
                            var P2 = Parse_Expresion();
                            Match(Tipo_De_Token.Parentesis_Cerrado);
                            return new Segment(P1, P2);
                        }

                    }
                case Tipo_De_Token.line_Keyword:
                    {
                        Proximo_Token();
                        if (Verificandose.Tipo == Tipo_De_Token.Identificador)
                        {
                            var identificador = Proximo_Token();
                            if (Verificandose.Tipo == Tipo_De_Token.Parentesis_Abierto)
                            {
                                Proximo_Token();
                                var P1 = Parse_Expresion();
                                Match(Tipo_De_Token.coma);
                                var P2 = Parse_Expresion();
                                Match(Tipo_De_Token.Parentesis_Cerrado);
                                return new Segment(identificador.Texto, P1, P2);
                            }
                            else
                            {
                                return new Line(identificador.Texto);
                            }

                        }
                        else
                        {
                            Match(Tipo_De_Token.Parentesis_Abierto);
                            var P1 = Parse_Expresion();
                            Match(Tipo_De_Token.coma);
                            var P2 = Parse_Expresion();
                            Match(Tipo_De_Token.Parentesis_Cerrado);
                            return new Line(P1, P2);
                        }
                    }
                //case Tipo_De_Token.arc_Keyword:
                //    {

                //    }
                //case Tipo_De_Token.ray_Keyword:
                //    {

                //    }

                default:
                    {
                        var token_num = Match(Tipo_De_Token.Numero);
                        var valor = token_num.Valor;
                        return new Literal(token_num, valor);
                    }
            }
        }
    }
}
