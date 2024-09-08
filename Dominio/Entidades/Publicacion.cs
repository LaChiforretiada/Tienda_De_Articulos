namespace Dominio.Entidades
{
    public class Publicacion
    {
        private List<Articulo> _articulos = new List<Articulo>();

        public List<Articulo> Articulos { get { return _articulos; } }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Estado { get; set; }

        public DateTime Fecha { get; set; }


        public Cliente Cliente { get; set; }

        public Administrador Administrador { get; set; }

        private static int _ultimoId;


        public Publicacion(List<Articulo> articulos, string nombre, string estado, DateTime fecha, Cliente cliente, Administrador administrador)
        {
            _articulos = articulos;
            Id = _ultimoId++;
            Nombre = nombre;
            Estado = estado;
            Fecha = fecha;
            Cliente = cliente;
            Administrador = administrador;
        }
    }
}
