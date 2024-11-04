

namespace Dominio.Entidades
{
    public abstract class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Mail { get; set; }

        public string Contrasenia { get; set; }

        public virtual string Rol { get; protected set; }

        private static int _ultimoId;

        public Usuario()
        {
            Id = ++_ultimoId;
        }

        public Usuario(string nombre, string apellido, string mail, string contrasenia)
        {
            Id = ++_ultimoId;
            Nombre = nombre;
            Apellido = apellido;
            Mail = mail;
            Contrasenia = contrasenia;
            Rol = "Usuario";
        }

        public virtual void Validar()
        {
            ValidarNombre();
            ValidarApellido();
            ValidarContrasenia();
            ValidarMailVacio();
        }

        private void ValidarMailVacio()       
        {
            if (!string.IsNullOrEmpty(Mail))
            {
                ValidarMailFormato(Mail);
            }
            else
            {
                throw new Exception("Mail no puede ser vacio");
            }
        }

        private void ValidarMailFormato(string mail)
        {
            bool valid = false;
            foreach (char c in mail)
            {
                if (c == '@')
                {
                    valid = true;
                }
            }
            if (valid == false)
            {
                throw new Exception("El formato del mail es incorrecto");
            }
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
            if (!string.IsNullOrEmpty(Contrasenia) && Contrasenia.Length >= 8)
            {
                ValidarFormato(Contrasenia);
            }
            else
            {
                throw new Exception("Contrasenia debe contener minimo 8 caracteres");
            }
        }

        private void ValidarFormato(string contra)
        {
            bool valid = false;
            bool valid2 = false;    
            for (int i = 0; i < contra.Length; i++)
            {
                if (char.IsUpper(contra[i]))
                {
                valid = true;
                }
                if (char.IsNumber(contra[i]))
                {
                valid2 = true;
                }
            }
            if (valid == false || valid2 == false)
            {
                throw new Exception("La contrasenia debe contener al menos una Mayuscula o Numero");
            }
        }


        public override string ToString() 
        { 
          string respuesta = string.Empty;

            respuesta += $"Id: {Id} \n";
            respuesta += $"Nombre: {Nombre} \n";
            respuesta += $"Apellido: {Apellido} \n";
            respuesta += $"Mail: {Mail} \n";
            //respuesta += $"Contrasenia: {Contrasenia} \n";
            return respuesta;
        }

        public override bool Equals(object? obj) 
        { 
            Usuario usuario = obj as Usuario;
            return usuario != null && Mail == usuario.Mail;

        }
    }
}
