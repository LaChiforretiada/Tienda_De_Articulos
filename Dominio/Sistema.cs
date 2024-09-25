using Dominio.Entidades;

namespace Dominio
{

    //PREGUNTAR SOBRE LA LISTA DE ARTICULOS EN PUBLICACIONES TODO
    internal class Sistema
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
    }
}
