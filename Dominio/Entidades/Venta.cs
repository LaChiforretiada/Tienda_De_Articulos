namespace Dominio.Entidades
{
    public class Venta : Publicacion
    {
        public bool OfertaRelampago { get; set; }
 
        public Venta(string nombre, string estado, DateTime fecha, Cliente cliente, Administrador administrador, bool ofertaRelampago)
          : base(nombre, estado, fecha, cliente, administrador)
        {
            OfertaRelampago = ofertaRelampago;
        }


        public override string ToString()
        {
            string respuesta = base.ToString();
            respuesta += $"Es Oferta? {OfertaRelampago} \n";
            return respuesta;
        }



    }
}
