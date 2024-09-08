namespace Dominio.Entidades
{
    public class Cliente
    {

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Mail { get; set; }

        public string Contrasenia { get; set; }

        public Decimal Saldo { get; set; }

        private static int _ultimoId;

        public Cliente( string nombre, string apellido, string mail, string contrasenia, decimal saldo)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            Apellido = apellido;
            Mail = mail;
            Contrasenia = contrasenia;
            Saldo = saldo;
        }
    }
}
