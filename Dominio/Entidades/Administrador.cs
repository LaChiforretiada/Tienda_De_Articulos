namespace Dominio.Entidades
{
    public class Administrador : Usuario
    {
        public override string Rol
        {
            get { return "Administrador"; }
        }
        public Administrador(string nombre,
                             string apellido,
                             string mail,
                             string contrasenia) : base(nombre, apellido, mail, contrasenia)


        {

        }

        public override void Validar()
        {
            base.Validar();
        }

        public override string ToString()
        {
            string respuesta = base.ToString();
            return respuesta;
        }
   
        
    
    
    }
}
