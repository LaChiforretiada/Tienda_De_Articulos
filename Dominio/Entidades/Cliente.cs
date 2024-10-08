﻿namespace Dominio.Entidades
{
    public class Cliente : Usuario
    {
        public decimal Saldo { get; set; }

        public Cliente(decimal saldo, string nombre, string apellido, string mail, string contrasenia) : base(nombre, apellido, mail, contrasenia)
        {
            Saldo = saldo;
        }

        public override void Validar()
        {
            base.Validar();
            ValidarSaldo();
        }

        private void ValidarSaldo()
        {
            if (Saldo < 0)
            {
                throw new Exception("No puedes tener saldo negativo");
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
