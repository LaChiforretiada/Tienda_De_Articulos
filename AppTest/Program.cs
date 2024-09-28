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
                    //"6-Agregar Telefono\n" +
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

                        break;
                    default:
                        break;
                }
            }
            while (opcion != 0);
        }

        private static void ListarArticulosPorCategoria()
        {
            string categoria = PedirString("Ingrese categoria");
            List<Articulo> articulos = _sistema.Articulos;
            if(articulos.Count == 0) 
            {
                Console.WriteLine("No hay articulos disponibles");
            }   
            foreach (Articulo unArticulo in articulos)
            {
                if (TextoIgualado(categoria) == unArticulo.Categoria)
                {
                    Console.WriteLine($"{unArticulo.Nombre}");
                }
                else
                {
                    Console.WriteLine("No hay articulos de esa categoria");
                }
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

        private static string TextoIgualado(string texto)
        {
            string lower = texto.ToLower();
            return lower;
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

        private static void AgregarUsuarioCliente()
        {
            try
            {
                MostrarTitulo("Agregar Usuario");
                decimal saldo = 4000;
                string nombre = PedirString("Ingrese nombre");
                string apellido = PedirString("Ingrese apellido");
                string mail = PedirString("Ingrese mail");
                string contrasenia = PedirString("Ingrese contrasenia");
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
            List<Usuario> usuarios = _sistema.Usuarios;
            if (usuarios.Count == 0)
            {
                Console.WriteLine("No hay clientes disponibles");
            }
            else
            {
                foreach (Usuario item in usuarios)
                {
                    Cliente cliente = item as Cliente;
                    if (cliente != null)
                    {
                        Console.WriteLine($"{item.Nombre}");
                    }
                }
            }
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
