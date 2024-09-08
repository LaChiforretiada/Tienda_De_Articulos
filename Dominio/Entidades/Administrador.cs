using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Administrador
    {
        public int Id { get; set; }
        public int Nombre { get; set; }
        public int Apellido { get; set; }
        public int Mail { get; set; }
        public int Contrasenia { get; set; }

        private static int _ultimoId;

        public Administrador(int nombre, int apellido, int mail, int contrasenia)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            Apellido = apellido;
            Mail = mail;
            Contrasenia = contrasenia;
            
        }
    }
}
