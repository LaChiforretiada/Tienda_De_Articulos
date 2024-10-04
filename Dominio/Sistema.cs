using Dominio.Entidades;
using System.Net.Mail;

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

        public Sistema()
        {
            //PrecargarDatos();
        }

        public void PrecargarDatos()
        {
            PrecargarArticulos();
            PrecargarUsuarios();
            PrecargarPublicaciones();
        }


        private void PrecargarUsuarios()
        {
            Usuario unUsuario = null;

            unUsuario = new Cliente(4000, "Lucas", "Sosa", "lucassmj@", "Lukitas1");
            AgregarUsuario(unUsuario);
        }

        private void PrecargarArticulos()
        {
            Articulo unArticulo = null;

            unArticulo = new Articulo("pelota", "deporte", 504);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("auto", "juguete", 504);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("gorra", "deporte", 504);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("campera", "deporte", 504);
            AgregarArticulo(unArticulo);
        }

        private void PrecargarPublicaciones()
        {
            Publicacion unaPublicacion = null;

            unaPublicacion = new Venta("para jugar tenis", new DateTime(2024, 11, 1), true);
            AgregarPublicacion(unaPublicacion);
            List<Articulo> lis = new List<Articulo> { ObtenerArticulo("pelota"), ObtenerArticulo("gorra"), ObtenerArticulo("campera") };
            AgregarArticulosAPublicacion(unaPublicacion, lis);
        }


        //Metodos Agregar
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

        public void AgregarArticulo(Articulo articulo)
        {
            if (articulo == null)
            {
                throw new Exception("No se recibieron valores");
            }
            articulo.Validar();
            _articulos.Add(articulo);
        }

        public void AgregarPublicacion(Publicacion publicacion)
        {
            if (publicacion == null)
            {
                throw new Exception("No se recibieron valores");
            }
            if (_publicaciones.Contains(publicacion))
            {
                throw new Exception("Ya existe esa publicacion");
            }
            publicacion.Validar();
            _publicaciones.Add(publicacion);
        }



        public Articulo ObtenerArticulo(string nombre)
        {
            foreach (Articulo unArticulo in _articulos)
            {
                if (unArticulo.Nombre == nombre)
                {
                    return unArticulo;
                }
            }
            return null;
        }

        public void AgregarArticulosAPublicacion(Publicacion publicacion, List<Articulo> articulos)
        {
            
            if (publicacion == null)
            {
                throw new Exception($"La publicacion no existe");
            }
            foreach (Articulo item in articulos)
            {
                publicacion.AgregarArticulo(item);
            }
        }

        public void AgregarOfertaASubasta(string mail,string subasta, Oferta oferta)
        {
            Usuario unU = ObtenerUsuario(mail);
            Publicacion subas = ObtenerPublicacion(subasta);
            if(subas == null)
            {
                throw new Exception("No existe esa subasta");
            }
            if (unU == null)
            {
                throw new Exception("No existe Usuario");
            }
            subas.AgregarOferta(oferta);
        }

        public Publicacion ObtenerPublicacion(string nombre)
        {
            foreach (Publicacion unaPublicacion in _publicaciones)
            {
                if (unaPublicacion.Nombre == nombre)
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
