using System.Security.Principal;

namespace Dominio.Entidades
{
    public class Cliente : Usuario
    {
        public int Saldo { get; set; }

        public override string Rol
        {
            get { return "Cliente"; }
        }


        public Cliente() { }

        public Cliente(int saldo, string nombre, string apellido, string mail, string contrasenia) : base(nombre, apellido, mail, contrasenia)
        {
            Saldo = saldo;
        }

        public override void Validar()
        {
            base.Validar();
          
        }

        private void ValidarSaldo()
        {
            if (Saldo <= 0 || Saldo == null)
            {
                throw new Exception("No puedes tener saldo negativo");
            } 
        }

        public void RecargaSaldo(int montoCarga)
        {
            if (montoCarga <= 0 || montoCarga == null)
            {
                throw new Exception("No puedes recargar saldo negativo");
            }
            else
            {
                Saldo = Saldo + montoCarga;
            }
           
        }

        public override string ToString()
        {
            string respuesta = base.ToString();
            respuesta += $"Saldo: {Saldo} \n";
            return respuesta;
        }
    }
}
