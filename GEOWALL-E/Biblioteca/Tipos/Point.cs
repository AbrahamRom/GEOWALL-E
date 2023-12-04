namespace GEOWALL_E
{
    public class Punto:ILugarGeometrico
    {
        public Punto(string identificador) // constructor de punto para expression tipo "point p1"
        {
            Identificador = identificador;
            Random rd = new Random();

            Componente_x = rd.Next(1, 100);
            Componente_y = rd.Next(1, 100);
        }
        public Punto(double componentex,double componentey)// ctor para expressiones tipo "intersec" donde el punto no es aleatorio
        {
            Componente_x=componentex;
            Componente_y=componentey;
        }
        public Punto()
        {
            Random rd = new Random();

            Componente_x = rd.Next(1, 100);
            Componente_y = rd.Next(1, 100);
        }
        // public override Tipo_De_Token Tipo => Tipo_De_Token.point_Expresion;
        public string Identificador { get; } // revisar nombres en secuencias
        public double Componente_x { get; }
        public double Componente_y { get; }

        public void Draw() { }
    }
    public interface ILugarGeometrico { 
     void Draw() { }
    }
}
