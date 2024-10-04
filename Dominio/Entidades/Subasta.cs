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

        public override void AgregarOferta(Oferta oferta)
        {
            if (oferta == null) 
            {
                throw new Exception("No se recibieron valores");
            }
            oferta.Validar();
            _ofertas.Add(oferta);
        }


        public override string ToString()
        {
            string respuesta = base.ToString();

            foreach (Oferta item in _ofertas)
            {
                if (_ofertas.Count <= 0)
                {
                    respuesta += $"No contiene articulos";
                }
                else
                {
                    respuesta += $"Ofertas --> {item.UsuarioMail} Monto: {item.Monto}\n";
                }
            }
            return respuesta;
           
        }
    }
}
