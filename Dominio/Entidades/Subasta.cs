namespace Dominio.Entidades
{
    public class Subasta : Publicacion
    {

       private List<Oferta> _ofertas = new List<Oferta>();

        public List<Oferta> Ofertas
        {
            get
            {
                return _ofertas;
            }
        }

        public Subasta(string nombre, string estado, DateTime fecha, Cliente cliente, Administrador administrador)
        : base(nombre, estado, fecha, cliente, administrador)
        {



        }


        public override string ToString()
        {
            string respuesta = base.ToString();
            return respuesta;
        }
    }
}
