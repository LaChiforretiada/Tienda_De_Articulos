

namespace Dominio.Entidades
{
    public class Administrador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Contrasenia { get; set; }

        private static int _ultimoId;

        public Administrador(string nombre, string apellido, string mail, string contrasenia)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            Apellido = apellido;
            Mail = mail;
            Contrasenia = contrasenia;
            
        }
    }
}
