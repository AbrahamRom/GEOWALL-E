namespace GEOWALL_E
{
    class Punto: Expresion, ILugarGeometrico
    {
        public Punto(string identificador) // constructor de punto para expression tipo "point p1"
        {
            Identificador = identificador;
            Random rd = new Random();

            double componete_x = rd.Next(300, 900);
            double componente_y = rd.Next(200, 600);

            Token x = new Token( Tipo_De_Token.Numero, 0, componete_x.ToString(), componete_x );
            Token y = new Token(Tipo_De_Token.Numero, 0, componente_y.ToString(), componente_y );

            Componente_x = new Literal(x, componete_x);
            Componente_y = new Literal(y, componente_y);
        }
        public Punto(string identificador, Expresion componentex,Expresion componentey)// ctor para expressiones tipo "intersec" donde el punto no es aleatorio
        {
            Identificador = identificador;
            Componente_x=componentex;
            Componente_y=componentey;
        }
        public override Tipo_De_Token Tipo => Tipo_De_Token.point_Expresion;
        public string Identificador { get; } // revisar nombres en secuencias
        public Expresion Componente_x { get; }
        public Expresion Componente_y { get; }

        public void Draw() 
        {
            Pen lapiz = new Pen(Color.Black, 4);
             
           
        }
    }
    public interface ILugarGeometrico 
    { 
        void Draw() 
        {
            
        }
    }
}
