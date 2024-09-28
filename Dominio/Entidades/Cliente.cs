namespace Dominio.Entidades
{
    public class Cliente : Usuario
    {
        public decimal Saldo { get; set; }

        public Cliente(decimal saldo, string nombre, string apellido, string mail, string contrasenia) : base(nombre, apellido, mail, contrasenia)
        {
            Saldo = saldo;
        }

        public override void ValidarUsuario()
        {
            base.ValidarUsuario();
        }

        public override string ToString()
        {
            string respuesta = base.ToString();
            respuesta += $"Saldo: {Saldo} \n";
            return respuesta;
        }
    }
}
