namespace AppTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                int opcion = 0;
                do
                {
                    MostrarTitulo("Menu");
                    opcion = PedirNumero(
                        "Ingrese la opción\n" +
                        "1-Alta cargo mensual\n" +
                        "2-Alta cargo jornalero\n" +
                        "3-Agregar Empleado\n" +
                        "4-Listar Cargos\n" +
                        "5-Listar Empleados\n" +
                        "6-Agregar Telefono\n" +
                        "0-salir");
                    switch (opcion)
                    {
                        case 1:
                            //AgregarCargoMensual();
                            break;
                        case 2:
                            //AgregarCargoJornalero();
                            break;
                        case 3:
                            //AgregarEmpleado();
                            break;
                        case 4:
                            //ListarCargo();
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
