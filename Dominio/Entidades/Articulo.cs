
namespace Dominio.Entidades
{
    public class Articulo
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Categoria { get; set; }

        public int Precio { get; set; }

        private static int _ultimoId;

        public Articulo(string nombre, string categoria, int precio)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            Categoria = categoria;
            Precio = precio;
        }

        public void Validar()
        {
            ValidarNombre();
            ValidarCategoria();
            ValidarPrecio();
        }

        private void ValidarPrecio()
        {
            if (Precio <= 0) 
            {
                throw new Exception("Precio debe ser mayor a 0");
            }
        }

        private void ValidarCategoria()
        {
            if (string.IsNullOrEmpty(Categoria))
            {
                throw new Exception("No se recibieron valores");
            }
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("No se recibieron valores");
            }

        }

        public override string ToString()
        {
            string respuesta = string.Empty;

            respuesta += $"Id: {Id} \n";
            respuesta += $"Nombre: {Nombre} \n";
            respuesta += $"Categoria: {Categoria} \n";
            respuesta += $"Precio: {Precio} \n";
            return respuesta;
        }
    }
}
