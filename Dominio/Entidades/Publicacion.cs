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

        public DateTime FechaPublicacion { get; set; }

        public DateTime FechaFinalizacion { get; set; }
        public Cliente Cliente { get; set; }

        public Administrador Administrador { get; set; }

        private static int _ultimoId;


        public Publicacion(string nombre, DateTime fechaPublicacion)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            Estado = "ABIERTA";
            FechaPublicacion = fechaPublicacion;
        }

        public virtual void Validar()
        {
            ValidarNombre();
            ValidarFecha();
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("Nombre debe contener caracteres");
            }
        }

        private void ValidarFecha()
        {
            DateTime fechaHoy = DateTime.Now;
            if (FechaPublicacion < fechaHoy)
            {
                throw new Exception("No se puede publicar en fecha anteriroes.");
            }
        }


        public void AgregarArticulo(Articulo articulo)
        {
            if(articulo == null)
            {
                throw new Exception("No se recibieron valores");
            }
            articulo.Validar();
            _articulos.Add(articulo);
        }


        public override string ToString()
        {
            string respuesta = string.Empty;

            respuesta += $"Id: {Id} \n";
            respuesta += $"Nombre: {Nombre} \n";
            respuesta += $"Estado: {Estado} \n";
            respuesta += $"FechaPublicacion: {FechaPublicacion} \n";
            respuesta += $"FechaFinalizacion: {FechaFinalizacion} \n";
            //respuesta += $"Cliente: {Cliente.Nombre} \n";

            foreach (Articulo item in _articulos)
            {
                if(_articulos.Count <= 0)
                {
                    respuesta += $"No contiene articulos";
                }
                else
                {
                    respuesta += $"Articulos -->{item.Nombre}\n";
                }
            }
            return respuesta;
        }

    }
}
