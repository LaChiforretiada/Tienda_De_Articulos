

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

        public virtual void ValidarUsuario()
        {
            ValidarNombre();
            ValidarApellido();
            ValidarContrasenia();

        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre)) 
            {
                throw new Exception("Nombre debe contener caracteres");
            }
        }
        private void ValidarApellido()
        {
            if (string.IsNullOrEmpty(Apellido))
            {
                throw new Exception("Apellido debe contener caracteres");
            }
        }

        private void ValidarContrasenia()
        {
            if (!string.IsNullOrEmpty(Contrasenia))
            {
                ValidarFormato(Contrasenia);
            }
            else
            {
                throw new Exception("Contrasenia debe contener caracteres");
            }
        }

        private void ValidarFormato(string contra)
        {
            bool valid = false;
            for (int i = 0; i < contra.Length; i++)
            {
                if (char.IsUpper(contra[i]))
                {
                valid = true;
                }
            }
            if (valid == false)
            {
                throw new Exception("La contrasenia debe contener al menos una Mayuscula");
            }
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
