namespace Dominio.Entidades
{
    public class Oferta
    {
        public int Id { get; set; }
        public string UsuarioMail { get; set; }
        public int Monto { get; set; }
        public DateTime Fecha { get; set; }

        private static int _ultimoId;

        public Oferta()
        {
            Id = ++_ultimoId;
        }

        public Oferta(string usuario, int monto, DateTime fecha)
        {
            Id = ++_ultimoId;
            UsuarioMail = usuario;
            Monto = monto;
            Fecha = fecha;
        }

        public void Validar()
        {
            ValidarMonto();
            ValidarMail();
        }

        private void ValidarMonto()
        {
            if (Monto <= 0)
            {
                throw new Exception("El monto debe ser mayor a 0");
            }
        }

        private void ValidarMail()
        {
            if (string.IsNullOrEmpty(UsuarioMail))
            {
                throw new Exception("El mail no puede ser nulo");
            }
        }
    }
}
