namespace Dominio.Entidades
{
    public class Venta : Publicacion
    {
        public bool OfertaRelampago { get; set; }
 
        public Venta(List<Articulo> articulos, string nombre, string estado, DateTime fecha, Cliente cliente, Administrador administrador, bool ofertaRelampago)
          : base(articulos, nombre, estado, fecha, cliente, administrador)
        {
            OfertaRelampago = ofertaRelampago;
        }
    }
}
