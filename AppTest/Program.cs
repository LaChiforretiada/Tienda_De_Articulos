using Dominio;
using Dominio.Entidades;

namespace AppTest
{
    internal class Program
    {
        static Sistema _sistema = new Sistema();

        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                MostrarTitulo("Menu");
                opcion = PedirNumero(
                    "Ingrese la opción\n" +
                    "1- Alta Usuario Cliente\n" +
                    "2- Alta Usuario Administrador\n" +
                    "3- Agregar Articulos\n" +
                    "4- Listar Clientes\n" +
                    "5- Listar Articulos por Categoria\n" +
                    "6- Agregar Venta\n" +
                    "7- Agregar Subasta\n" +
                    "8- Listar Publicacion\n" +
                    "9- Listar Publicacion por fechas\n" +
                    "10- Agregar Oferta\n" +
                    "11- Precargar Datos\n" +
                    "0- Salir");
                switch (opcion)
                {
                    case 1:
                        AgregarUsuarioCliente();
                        break;
                    case 2:
                        AgregarUsuarioAdministrador();
                        break;
                    case 3:
                        AgregarArticulo();
                        break;
                    case 4:
                        ListarClientes();
                        break;
                    case 5:
                        ListarArticulosPorCategoria();
                        break;
                    case 6:
                        AgregarVenta();
                        break;
                    case 7:
                        AgregarSubasta();
                        break;
                    case 8:
                        ListarPublicaciones();
                        break;
                    case 9:
                        ListarPublicacionesPorFecha();
                        break;
                    case 10:
                        AgregarOferta();
                        break;
                    case 11:
                        PrecargarDatos();
                        break;
                    default:
                        break;
                }
            }
            while (opcion != 0);
        }

        private static void PrecargarDatos()
        {
            try
            {
                _sistema.PrecargarDatos();
            }
            catch (Exception e)
            {
                MostrarError(e.Message);
            }
        }


        private static void AgregarOferta()
        {
            try
            {
                MostrarTitulo("Agregar Oferta");
                string mail = PedirString("Ingrese mail Usuario");
                Usuario unUsuario = _sistema.ObtenerUsuario(mail);
                string subasta = PedirString("Ingrese nombre Subasta");
                if (unUsuario == null) 
                {
                    MostrarError("No existe usuario");
                }
                int monto = PedirNumero("Ingrese monto");
                Oferta unaOferta = new Oferta(mail, monto, new DateTime(2024, 11, 12));
                _sistema.AgregarOfertaASubasta(mail,subasta, unaOferta);
            }
            catch (Exception e)
            {

                MostrarError(e.Message);
            }
        }

        private static void AgregarVenta()
        {
            try
            {
                MostrarTitulo("Agregar Venta");
                string nombre = PedirString("Ingrese nombre de la venta");
                List<Articulo> aux = PedirArticulos();
                if(aux.Count != 0)
                {
                Publicacion unaVenta = new Venta(nombre, new DateTime(2024, 11, 20), true);
                _sistema.AgregarPublicacion(unaVenta);
                _sistema.AgregarArticulosAPublicacion(unaVenta, aux);
                }     
            }
            catch (Exception e)
            {
                MostrarError(e.Message);
            }
        }

        private static void AgregarSubasta()
        {
            try
            {
                MostrarTitulo("Agregar Subasta");
                string nombre = PedirString("Ingrese nombre de la subasta");
                List<Articulo> aux = PedirArticulos();
                if (aux.Count != 0) 
                {
                Publicacion unaSubasta = new Subasta(nombre, new DateTime(2024, 10, 20));
                _sistema.AgregarPublicacion(unaSubasta);
                _sistema.AgregarArticulosAPublicacion(unaSubasta, aux);
                }
            }
            catch (Exception e)
            {
                MostrarError(e.Message);
            }
        }
        private static List<Articulo> PedirArticulos()
        {
                List<Articulo> aux = new List<Articulo>();
            try
            {
                bool bandera = true;
                while (bandera)
                {
                    string nombreArticulo = PedirString("Ingrese nombre del articulo");
                    Articulo unA = _sistema.ObtenerArticulo(nombreArticulo);
                    if (unA == null)
                    {
                        MostrarError("No existe el articulo");
               
                    }
                    else
                    {
                        aux.Add(unA);
                    }
                    bandera = Seguir("¿Desea agregar otro artículo? (s/n)");
                }
            }
            catch (Exception e)
            {

                MostrarError(e.Message);
            }
                return aux;
        }

        private static bool Seguir(string mensaje)
        {
            Console.WriteLine(mensaje);
            string respuesta = Console.ReadLine()?.ToLower();
            return respuesta == "s";
        }
        private static void ListarPublicaciones()
        {
            MostrarTitulo("Publicaciones");
            List<Publicacion> publicaciones = _sistema.Publicaciones;
            if (publicaciones.Count == 0)
            {
                MostrarError("No hay publicaciones disponibles");
            }
            foreach (Publicacion unaP in publicaciones)
            {
                Console.WriteLine($"{unaP}");
            }
        }

        private static void ListarPublicacionesPorFecha()
        {
            MostrarTitulo("Publicaciones");
            List<Publicacion> publicaciones = _sistema.Publicaciones;
            if (publicaciones.Count == 0)
            {
                MostrarError("No hay publicaciones disponibles");
            }
            Console.Write("Ingrese la fecha de inicio (formato: aaaa-mm-dd): ");
            DateTime fechaInicio = DateTime.Parse(Console.ReadLine());
            Console.Write("Ingrese la fecha de fin (formato: aaaa-mm-dd): ");
            DateTime fechaFinal = DateTime.Parse(Console.ReadLine());
            foreach (Publicacion unaP in publicaciones)
            {
                if (unaP.FechaPublicacion >= fechaInicio && unaP.FechaPublicacion <= fechaFinal)
                {
                    Console.WriteLine($" Id:{unaP.Id} \n Nombre: {unaP.Nombre} \n Estado: {unaP.Estado} \n Fecha: {unaP.FechaPublicacion}");
                }
                else
                {
                    MostrarError("No hay publicaciones disponibles entre esas fechas");
                }
            }
        }

        private static void ListarArticulosPorCategoria()
        {
            string categoria = PedirString("Ingrese categoria");
            List<Articulo> articulos = _sistema.Articulos;
            if (articulos.Count == 0)
            {
                MostrarError("No hay articulos disponibles");
            }
            bool verificar = false;
            foreach (Articulo unArticulo in articulos)
            {
                if (TextoIgualado(categoria) == unArticulo.Categoria)
                {
                    verificar = true;
                    Console.WriteLine($"{unArticulo.Nombre}");
                }
            }
            if (verificar == false)
            {
                MostrarError("No hay articulos de esa categoria");
            }

        }

        private static void AgregarArticulo()
        {
            try
            {
                MostrarTitulo("Agregue Articulo");
                string nombre = PedirString("Ingrese el nombre del articulo");
                string categoria = PedirString("Ingrese la categoria del articulo");

                int precio = int.Parse(PedirString("Ingrese precio del articulo"));

                Articulo unArticulo = new Articulo(nombre, TextoIgualado(categoria), precio);
                _sistema.AgregarArticulo(unArticulo);
            }
            catch (Exception e)
            {
                MostrarError(e.Message);
            }
        }

        private static void AgregarUsuarioAdministrador()
        {
            try
            {
                MostrarTitulo("Agregar Usuario");
                string nombre = PedirString("Ingrese nombre");
                string apellido = PedirString("Ingrese apellido");
                string mail = PedirString("Ingrese mail");
                string contrasenia = PedirString("Ingrese contrasenia");
                Usuario usuario = new Administrador(nombre, apellido, mail, contrasenia);

                _sistema.AgregarUsuario(usuario);
            }
            catch (Exception e)
            {
                MostrarError(e.Message);
            }
        }


        private static void AgregarUsuarioCliente()
        {
            try
            {
                MostrarTitulo("Agregar Usuario");
                string nombre = PedirString("Ingrese nombre");
                string apellido = PedirString("Ingrese apellido");
                string mail = PedirString("Ingrese mail");
                string contrasenia = PedirString("Ingrese contrasenia");
                decimal saldo = PedirNumero("Ingrese Saldo");
                Usuario usuario = new Cliente(saldo, nombre, apellido, mail, contrasenia);

                _sistema.AgregarUsuario(usuario);
            }
            catch (Exception e)
            {
                MostrarError(e.Message);
            }
        }
        private static void ListarClientes()
        {
            List<Cliente> clientes = _sistema.UsuariosClientes();
            if (clientes.Count == 0)
            {
                Console.WriteLine("No hay clientes disponibles");
            }
            else
            {
                foreach (Cliente item in clientes)
                {
                    Console.WriteLine(item);
                }
            }
        }
        private static int PedirNumero(string mensaje)
        {
            int numero = 0;
            bool seguir = false;
            do
            {
                try
                {
                    Console.WriteLine(mensaje);
                    numero = int.Parse(Console.ReadLine());
                    seguir = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Solo debe ingresar numeros.");
                    seguir = true;
                }

            } while (seguir);
            return numero;
        }

        private static string TextoIgualado(string texto)
        {
            string lower = texto.ToLower();
            return lower;
        }




        private static string PedirString(string mensaje)
        {
            Console.WriteLine(mensaje);
            return Console.ReadLine();
        }

        private static void MostrarError(string mensaje)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(mensaje);
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        private static void MostrarTitulo(string mensaje)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("");
            Console.WriteLine(mensaje);
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
