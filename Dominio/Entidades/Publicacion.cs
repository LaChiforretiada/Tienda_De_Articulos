namespace Dominio.Entidades
{
    public abstract class Publicacion
    {
        private List<Articulo> _articulos = new List<Articulo>();

        public List<Articulo> Articulos
        {
            get
            {
                return _articulos;
            }
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Estado { get; set; }

        public DateTime Fecha { get; set; }


        public Cliente Cliente { get; set; }

        public Administrador Administrador { get; set; }

        private static int _ultimoId;

        
        public Publicacion(string nombre, string estado, DateTime fecha, Cliente cliente, Administrador administrador)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            Estado = estado;
            Fecha = fecha;
            Cliente = cliente;
            Administrador = administrador;
        }



        public override string ToString()
        {
            string respuesta = string.Empty;

            respuesta += $"Id: {Id} \n";
            respuesta += $"Nombre: {Nombre} \n";
            respuesta += $"Estado: {Estado} \n";
            respuesta += $"Fecha: {Fecha} \n";
            respuesta += $"Cliente: {Cliente.Nombre} \n";
            respuesta += $"Administrador: {Administrador.Nombre} \n";
            respuesta += $"Articulos: {Articulos} \n";

            return respuesta;
        }

    }
}
