
namespace GEOWALL_E
{
    class Circle 
    {
        public Circle(string identificador, Points punto, object radio)
        {
            Identificador = identificador;
            Punto = punto;
            Radio = radio;
        }
       // public override Tipo_De_Token Tipo => Tipo_De_Token.circle_Expresion;
        public string Identificador { get; }
        public Points Punto { get; }
        public object Radio { get; }
    }
}
