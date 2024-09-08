namespace Dominio.Entidades
{
    public class Subasta : Publicacion
    {

       private List<Oferta> _ofertas = new List<Oferta>();

        public List<Oferta> Ofertas
        {
            get
            {
                return _ofertas;
            }
        }
        public Subasta(List<Articulo> articulos, string nombre, string estado, DateTime fecha, Cliente cliente, Administrador administrador)
        : base(articulos, nombre, estado, fecha, cliente, administrador)
        {



        }
    }
}
