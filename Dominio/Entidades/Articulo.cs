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
    }
}
