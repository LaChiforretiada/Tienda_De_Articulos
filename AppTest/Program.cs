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
                        "3-Agregar Empleado\n" +
                        "4-Listar Usuarios\n" +
                        "5-Listar Empleados\n" +
                        "6-Agregar Telefono\n" +
                        "0-salir");
                    switch (opcion)
                    {
                        case 1:
                            AgregarUsuarioCliente();
                            break;
                        case 2:
                            //AgregarCargoJornalero();
                            break;
                        case 3:
                            //AgregarEmpleado();
                            break;
                        case 4:
                        ListarClientes();
                            break;
                        case 5:
                            //ListarEmpleado();
                            break;
                        case 6:
                            //AgregarTelefono();
                            break;
                        default:
                            break;
                    }
                }
                while (opcion != 0);
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
                Cliente unCliente = new Cliente(saldo, nombre, apellido, mail, contrasenia);
                
                _sistema.AgregarUsuario(unCliente);
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
                    if(cliente != null)
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
