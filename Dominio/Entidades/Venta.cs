using static System.Runtime.InteropServices.JavaScript.JSType;

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

        //public override void EsOfertaRelampago()
        //{
        //    int numero = PrecioPubli();
        //    if (OfertaRelampago == true)
        //    {
        //        Precio -= (numero * 0.20);
        //    }
        //}



        public override bool EstadoPublicacion()
        {
            bool esT = false;
            if (Estado == "ABIERTA")
            {
                esT = true;
            }
            return esT;
        }

        public override string ToString()
        {
            string respuesta = base.ToString();
            respuesta += $"Es Oferta? {OfertaRelampago} \n";
            return respuesta;
        }

        public override int PrecioPubli()
        {
            int precioBase = base.PrecioPubli();
            if (OfertaRelampago)
            {
                return precioBase -= (int)(precioBase * 0.20);
            }
            else
            {
                return base.PrecioPubli();
            }
        }


    }
}
