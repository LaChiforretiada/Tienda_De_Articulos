using Dominio.Entidades;

namespace Dominio
{
    //VERIFICAR MAIL
    //PREGUNTAR SOBRE LA LISTA DE ARTICULOS EN PUBLICACIONES TODO
    public class Sistema
    {
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Articulo> _articulos = new List<Articulo>();
        private List<Publicacion> _publicaciones = new List<Publicacion>();

        public List<Usuario> Usuarios
        {
            get
            {
                return _usuarios;
            }
        }

        public List<Articulo> Articulos
        {
            get
            {
                return _articulos;
            }
        }

        public List<Publicacion> Publicaciones
        {
            get
            {
                return _publicaciones;
            }
        }

        public void AgregarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new Exception("No se recibieron los valores");
            }
            if (_usuarios.Contains(usuario))
            {
                throw new Exception($"El usuario con el mail seleccionado {usuario.Mail} ya existe");
            }
            usuario.ValidarUsuario();
            _usuarios.Add(usuario);
        }

        public Usuario ObtenerUsuario(string email)
        {
            foreach (Usuario unUsuario in _usuarios)
            {
                if (unUsuario.Mail == email)
                {
                    return unUsuario;
                }
            }
            return null;
        }
        
       

    }
}
