namespace Dominio.Entidades
{
    public abstract class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Mail { get; set; }

        public string Contrasenia { get; set; }

        private static int _ultimoId;

        public Usuario(string nombre, string apellido, string mail, string contrasenia)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            Apellido = apellido;
            Mail = mail;
            Contrasenia = contrasenia;
        }




        public override string ToString() 
        { 
          string respuesta = string.Empty;

            respuesta += $"Id: {Id} \n";
            respuesta += $"Nombre: {Nombre} \n";
            respuesta += $"Apellido: {Apellido} \n";
            respuesta += $"Mail: {Mail} \n";
            respuesta += $"Contrasenia: {Contrasenia} \n";
            return respuesta;
        }


    }
}
