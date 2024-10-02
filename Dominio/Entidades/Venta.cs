namespace Dominio.Entidades
{
    public class Venta : Publicacion
    {
        public bool OfertaRelampago { get; set; }
 
        public Venta(string nombre, DateTime fechaPublicacion, bool ofertaRelampago)
          : base(nombre, fechaPublicacion)
        {
            OfertaRelampago = ofertaRelampago;
        }

        public override void Validar()
        {
            base.Validar();
        }

        //private void ValidarOferta()
        //{
        //    if (OfertaRelampago) { }
        //}

        public override string ToString()
        {
            string respuesta = base.ToString();
            respuesta += $"Es Oferta? {OfertaRelampago} \n";
            return respuesta;
        }



    }
}
