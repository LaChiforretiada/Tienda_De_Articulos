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
            PrecargarOfertas();
        }


        private void PrecargarUsuarios()
        {
            Usuario unUsuario = null;

            unUsuario = new Cliente(4000, "Lucas", "Sosa", "lucassmj@mail.com", "Lukitas1");
            AgregarUsuario(unUsuario);

            unUsuario = new Cliente(4001, "Ana", "García", "anagarcia@mail.com", "AnaPass");
            AgregarUsuario(unUsuario);

            unUsuario = new Cliente(4002, "Carlos", "Martínez", "carlosm@mail.com", "CarlosPass");
            AgregarUsuario(unUsuario);

            unUsuario = new Cliente(4003, "María", "López", "marialopez@mail.com", "MariaPass");
            AgregarUsuario(unUsuario);

            unUsuario = new Cliente(4004, "Javier", "Fernández", "javierf@mail.com", "JavierPass");
            AgregarUsuario(unUsuario);

            unUsuario = new Cliente(4005, "Lorena", "Pérez", "lorenap@mail.com", "LorenaPass");
            AgregarUsuario(unUsuario);

            unUsuario = new Cliente(4006, "Santiago", "Ramírez", "santiagor@mail.com", "SantiagoPass");
            AgregarUsuario(unUsuario);

            unUsuario = new Cliente(4007, "Valentina", "Sánchez", "valentinas@mail.com", "ValentinaPass");
            AgregarUsuario(unUsuario);

            unUsuario = new Cliente(4008, "Ignacio", "Castro", "ignacioc@mail.com", "IgnacioPass");
            AgregarUsuario(unUsuario);

            unUsuario = new Cliente(4009, "Camila", "Morales", "camilam@mail.com", "CamilaPass");
            AgregarUsuario(unUsuario);

            // Administradores
            unUsuario = new Administrador("Admin1", "Pérez", "admin1@mail.com", "AdminPass1");
            AgregarUsuario(unUsuario);

            unUsuario = new Administrador("Admin2", "Rodríguez", "admin2@mail.com", "AdminPass2");
            AgregarUsuario(unUsuario);

            //--------------------------------------------------------------------------------//
            // PRECARGAS DE USUARIOS ERRONEAS

            //Mensaje de Error - Saldo tiene que ser mayor a 0
            //unUsuario = new Cliente(0, "Lucas", "Sosa", "lucassmj@mail.com", "Lukitas1");
            //AgregarUsuario(unUsuario);

            //Mensaje de Error - El formato de mail es incorrecto
            //unUsuario = new Cliente(440, "Lucas", "Sosa", "lucassmjmail.com", "Lukitas1");
            //AgregarUsuario(unUsuario);

            //Mensaje de Error - La contrasenia debe contener al menos una Mayuscula
            //unUsuario = new Cliente(440, "Lucas", "Sosa", "lucassmjmail.com", "lukitas1");
            //AgregarUsuario(unUsuario);

            //------------------------------------------------------------------------------//


        }

        private void PrecargarArticulos()
        {
            Articulo unArticulo = null;

            unArticulo = new Articulo("pelota", "deporte", 504);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("auto", "juguete", 600);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("gorra", "deporte", 300);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("campera", "deporte", 1500);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("zapatillas", "calzado", 1200);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("remera", "ropa", 450);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("raqueta", "deporte", 2000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("muñeca", "juguete", 800);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("bicicleta", "deporte", 3000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("auriculares", "tecnología", 1100);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("raqueta", "deporte", 1200);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("bicicleta", "vehículo", 5000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("zapatillas", "deporte", 3500);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("laptop", "tecnología", 80000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("tablet", "tecnología", 30000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("cámara", "fotografía", 20000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("reloj", "accesorio", 15000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("mochila", "accesorio", 2000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("teléfono", "tecnología", 40000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("escritorio", "mueble", 10000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("silla", "mueble", 3500);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("monitor", "tecnología", 25000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("teclado", "tecnología", 5000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("mouse", "tecnología", 2000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("impresora", "tecnología", 15000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("coche", "vehículo", 1000000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("moto", "vehículo", 500000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("smartwatch", "tecnología", 20000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("altavoz", "tecnología", 7000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("auriculares", "tecnología", 5000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("parlantes", "tecnología", 12000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("smart tv", "tecnología", 60000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("microondas", "electrodoméstico", 10000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("ventilador", "electrodoméstico", 5000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("heladera", "electrodoméstico", 80000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("lavarropas", "electrodoméstico", 50000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("tostadora", "electrodoméstico", 3000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("licuadora", "electrodoméstico", 7000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("plancha", "electrodoméstico", 2000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("cocina", "electrodoméstico", 40000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("freidora", "electrodoméstico", 12000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("cafetera", "electrodoméstico", 8000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("licuadora", "electrodoméstico", 5000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("tijeras", "herramienta", 500);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("taladro", "herramienta", 7000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("llave inglesa", "herramienta", 1500);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("destornillador", "herramienta", 1000);
            AgregarArticulo(unArticulo);

            unArticulo = new Articulo("martillo", "herramienta", 2000);
            AgregarArticulo(unArticulo);


            //--------------------------------------------------------------------------------//           
            // PRECARGAS DE ARTICULOS ERRONEAS

            //Mensaje de Error - Precio tiene que ser mayor a 0
            //unArticulo = new Articulo("pelota", "deporte", 0);
            //AgregarArticulo(unArticulo);

            //Mensaje de Error - No se ingresaron valores
            //unArticulo = new Articulo("", "deporte", 0);
            //AgregarArticulo(unArticulo);

            //--------------------------------------------------------------------------------//

        }

        private void PrecargarPublicaciones()
        {
            Publicacion unaPublicacion = null;

            // Ventas
            unaPublicacion = new Venta("para jugar tenis", new DateTime(2024, 11, 1), true);
            AgregarPublicacion(unaPublicacion);
            List<Articulo> articulosVenta1 = new List<Articulo> { ObtenerArticulo("pelota"), ObtenerArticulo("raqueta"), ObtenerArticulo("zapatillas") };
            AgregarArticulosAPublicacion(unaPublicacion, articulosVenta1);

            unaPublicacion = new Venta("ropa deportiva", new DateTime(2024, 11, 2), true);
            AgregarPublicacion(unaPublicacion);
            List<Articulo> articulosVenta2 = new List<Articulo> { ObtenerArticulo("remera"), ObtenerArticulo("gorra"), ObtenerArticulo("campera") };
            AgregarArticulosAPublicacion(unaPublicacion, articulosVenta2);

            unaPublicacion = new Venta("Venta de deportes", new DateTime(2024, 11, 1), true);
            AgregarPublicacion(unaPublicacion);
            List<Articulo> listaArticulosVenta1 = new List<Articulo> { ObtenerArticulo("pelota"), ObtenerArticulo("gorra"), ObtenerArticulo("campera") };
            AgregarArticulosAPublicacion(unaPublicacion, listaArticulosVenta1);

            unaPublicacion = new Venta("Venta de tecnología", new DateTime(2024, 11, 1), true);
            AgregarPublicacion(unaPublicacion);
            List<Articulo> listaArticulosVenta2 = new List<Articulo> { ObtenerArticulo("laptop"), ObtenerArticulo("teléfono"), ObtenerArticulo("tablet") };
            AgregarArticulosAPublicacion(unaPublicacion, listaArticulosVenta2);

            unaPublicacion = new Venta("Venta de juguetes", new DateTime(2024, 11, 5), true);
            AgregarPublicacion(unaPublicacion);
            AgregarArticulosAPublicacion(unaPublicacion, new List<Articulo> { ObtenerArticulo("auto"), ObtenerArticulo("bicicleta") });

            unaPublicacion = new Venta("Venta de muebles", new DateTime(2024, 11, 8), true);
            AgregarPublicacion(unaPublicacion);
            AgregarArticulosAPublicacion(unaPublicacion, new List<Articulo> { ObtenerArticulo("escritorio"), ObtenerArticulo("silla") });

            unaPublicacion = new Venta("Venta de electrodomésticos", new DateTime(2024, 11, 15), true);
            AgregarPublicacion(unaPublicacion);
            AgregarArticulosAPublicacion(unaPublicacion, new List<Articulo> { ObtenerArticulo("microondas"), ObtenerArticulo("ventilador") });

            unaPublicacion = new Venta("Venta de accesorios", new DateTime(2024, 11, 18), true);
            AgregarPublicacion(unaPublicacion);
            AgregarArticulosAPublicacion(unaPublicacion, new List<Articulo> { ObtenerArticulo("reloj"), ObtenerArticulo("mochila") });

            unaPublicacion = new Venta("Venta de electrodomésticos grandes", new DateTime(2024, 11, 20), true);
            AgregarPublicacion(unaPublicacion);
            AgregarArticulosAPublicacion(unaPublicacion, new List<Articulo> { ObtenerArticulo("heladera"), ObtenerArticulo("lavarropas") });

            unaPublicacion = new Venta("Venta de herramientas", new DateTime(2024, 11, 25), true);
            AgregarPublicacion(unaPublicacion);
            AgregarArticulosAPublicacion(unaPublicacion, new List<Articulo> { ObtenerArticulo("taladro"), ObtenerArticulo("martillo") });

            // Subastas
            unaPublicacion = new Subasta("subasta juguetes", new DateTime(2024, 11, 5));
            AgregarPublicacion(unaPublicacion);
            List<Articulo> articulosSubasta1 = new List<Articulo> { ObtenerArticulo("muñeca"), ObtenerArticulo("auto") };
            AgregarArticulosAPublicacion(unaPublicacion, articulosSubasta1);

            unaPublicacion = new Subasta("subasta tecnología", new DateTime(2024, 11, 10));
            AgregarPublicacion(unaPublicacion);
            List<Articulo> articulosSubasta2 = new List<Articulo> { ObtenerArticulo("auriculares"), ObtenerArticulo("bicicleta") };
            AgregarArticulosAPublicacion(unaPublicacion, articulosSubasta2);

            unaPublicacion = new Subasta("Subasta de vehículos", new DateTime(2024, 11, 2));
            AgregarPublicacion(unaPublicacion);
            List<Articulo> listaArticulosSubasta2 = new List<Articulo> { ObtenerArticulo("coche"), ObtenerArticulo("moto") };
            AgregarArticulosAPublicacion(unaPublicacion, listaArticulosSubasta2);

            unaPublicacion = new Subasta("Subasta de electrodomésticos", new DateTime(2024, 11, 10));
            AgregarPublicacion(unaPublicacion);
            AgregarArticulosAPublicacion(unaPublicacion, new List<Articulo> { ObtenerArticulo("microondas"), ObtenerArticulo("heladera") });

            unaPublicacion = new Subasta("Subasta de herramientas", new DateTime(2024, 11, 12));
            AgregarPublicacion(unaPublicacion);
            AgregarArticulosAPublicacion(unaPublicacion, new List<Articulo> { ObtenerArticulo("taladro"), ObtenerArticulo("martillo") });

            unaPublicacion = new Subasta("Subasta de electrodomésticos pequeños", new DateTime(2024, 11, 14));
            AgregarPublicacion(unaPublicacion);
            AgregarArticulosAPublicacion(unaPublicacion, new List<Articulo> { ObtenerArticulo("tostadora"), ObtenerArticulo("licuadora") });

            unaPublicacion = new Subasta("Subasta de accesorios", new DateTime(2024, 11, 16));
            AgregarPublicacion(unaPublicacion);
            AgregarArticulosAPublicacion(unaPublicacion, new List<Articulo> { ObtenerArticulo("mochila"), ObtenerArticulo("reloj") });

            unaPublicacion = new Subasta("Subasta de tecnología avanzada", new DateTime(2024, 11, 18));
            AgregarPublicacion(unaPublicacion);
            AgregarArticulosAPublicacion(unaPublicacion, new List<Articulo> { ObtenerArticulo("smartwatch"), ObtenerArticulo("laptop") });

            unaPublicacion = new Subasta("Subasta de vehículos de lujo", new DateTime(2024, 11, 25));
            AgregarPublicacion(unaPublicacion);
            AgregarArticulosAPublicacion(unaPublicacion, new List<Articulo> { ObtenerArticulo("coche"), ObtenerArticulo("moto") });

            //--------------------------------------------------------------------------------//
            // PRECARGAS DE PUBLICACIONES ERRONEAS

            //Mensaje de Error - Nombre debe contener caracteres
            //unaPublicacion = new Venta("", new DateTime(2024, 11, 1), true);
            //AgregarPublicacion(unaPublicacion);
            //List<Articulo> articulosVenta1 = new List<Articulo> { ObtenerArticulo("pelota"), ObtenerArticulo("raqueta"), ObtenerArticulo("zapatillas") };
            //AgregarArticulosAPublicacion(unaPublicacion, articulosVenta1);

            //Mensaje de Error - No se puede publicar en fecha anteriores.
            //unaPublicacion = new Venta("Subasta de vehículos de lujo", new DateTime(2023, 11, 1), true);
            //AgregarPublicacion(unaPublicacion);
            //List<Articulo> articulosVenta1 = new List<Articulo> { ObtenerArticulo("pelota"), ObtenerArticulo("raqueta"), ObtenerArticulo("zapatillas") };
            //AgregarArticulosAPublicacion(unaPublicacion, articulosVenta1);

            //Mensaje de Error - Publicacion debe contener articulos
            //unaPublicacion = new Venta("Subasta de vehículos de lujo", new DateTime(2023, 11, 1), true);
            //AgregarPublicacion(unaPublicacion);
            //List<Articulo> articulosVenta1 = new List<Articulo> {};
            //AgregarArticulosAPublicacion(unaPublicacion, articulosVenta1);

            //------------------------------------------------------------------------------//
        }

        private void PrecargarOfertas()
        {
            Publicacion primeraSubasta = ObtenerPublicacion("subasta juguetes");
            Usuario primerCliente = ObtenerUsuario("lucassmj@mail.com");
            string mailPrimerCliente = primerCliente.Mail;

            Oferta unaOferta = new Oferta(mailPrimerCliente, 550, DateTime.Now);
            primeraSubasta.AgregarOferta(unaOferta);

            // Obtener la segunda subasta: "subasta tecnología"
            Publicacion segundaSubasta = ObtenerPublicacion("subasta tecnología");
            Usuario segundoCliente = ObtenerUsuario("anagarcia@mail.com");
            string mailSegundoCliente = segundoCliente.Mail;

            unaOferta = new Oferta(mailSegundoCliente, 600, DateTime.Now);
            segundaSubasta.AgregarOferta(unaOferta);

            //--------------------------------------------------------------------------------//
            // PRECARGAS DE OFERTAS ERRONEAS

            //Mensaje de Error - El monto debe ser mayor a 0
            //Publicacion terceraSubasta = ObtenerPublicacion("subasta juguetes");
            //Usuario terceraCliente = ObtenerUsuario("lucassmj@mail.com");
            //string mailTercerCliente = primerCliente.Mail;


            //unaOferta = new Oferta(mailSegundoCliente, 0, DateTime.Now);
            //terceraSubasta.AgregarOferta(unaOferta);

            //------------------------------------------------------------------------------//
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

        public List<Cliente> UsuariosClientes()
        {
            List<Cliente> aux = new List<Cliente>();

            foreach (Usuario unUsuario in _usuarios)
            {
                // aplico downCast a la lista
                if (unUsuario is Cliente)
                {
                    Cliente unCliente = (Cliente)unUsuario;
                    aux.Add(unCliente);
                }
            }

            return aux;
        }

    }
}
