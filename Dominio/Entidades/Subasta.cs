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

        public Subasta(string nombre, DateTime fechaPublicacion)
        : base(nombre, fechaPublicacion)
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
