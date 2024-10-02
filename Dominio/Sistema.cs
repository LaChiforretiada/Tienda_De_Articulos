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
            usuario.Validar();
            _usuarios.Add(usuario);
        }

        public void AgregarArticulo(Articulo articulo) { 
            if (articulo == null)
            {
                throw new Exception("No se recibieron valores");
            }
            articulo.Validar();
            _articulos.Add(articulo);
        }

        public void AgregarPublicacion(Publicacion publicacion)
        {
            if(publicacion == null)
            {
                throw new Exception("No se recibieron valores");
            }
            publicacion.Validar();
            _publicaciones.Add(publicacion);    
        }


        public Articulo ObtenerArticulo(string nombre)
        {
            foreach (Articulo unArticulo in _articulos)
            {
                if(unArticulo.Nombre == nombre)
                {
                    return unArticulo;
                }
            }
            return null;
        }

        public void AgregarArticuloAPublicacion(string nombre, Articulo articulo)
        {
            Publicacion unaP = ObtenerPublicacion(nombre);
            if(unaP == null)
            {
                throw new Exception($"La publicacion {nombre} no existe");
            }
            unaP.AgregarArticulo(articulo);
        }

        public Publicacion ObtenerPublicacion(string nombre)
        {
            foreach (Publicacion unaPublicacion in _publicaciones)
            {
                if(unaPublicacion.Nombre == nombre)
                {
                    return unaPublicacion;
                }
            }
            return null;
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
