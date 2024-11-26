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

		public override int MontoMasAlto()
		{
			int masAlto = PrecioPubli();
			foreach (Oferta item in _ofertas)
			{
				if (_ofertas.Count != 0)
				{
                   masAlto = Ofertas.Max(item => item.Monto);
				}
			}
			return masAlto;
		}

       

        public override Oferta RetornarOfertaMasAlta()
        {
        
            if (_ofertas == null || _ofertas.Count == 0)
            {
                return null; 
            }

            int montoMasAlto = _ofertas.Max(oferta => oferta.Monto);
            return _ofertas.FirstOrDefault(oferta => oferta.Monto == montoMasAlto);
        }

        public override bool TieneOferta()
        {
            bool bandera = false;
            foreach (Oferta item in _ofertas)
            {
                if (_ofertas.Count != 0)
                {
                    bandera = true;
                }
            }
            return bandera;
        }


        public override bool EstadoPublicacion()
        {
            bool esT = false;
            if (Estado == "ABIERTA")
            {
                esT = true;
            }
            return esT;
        }


        public override int PrecioPubli()
        {
            return base.PrecioPubli();
       
        }
        public override string ToString()
        {
            string respuesta = base.ToString();

            foreach (Oferta item in _ofertas)
            {
                if (_ofertas.Count <= 0)
                {
                    respuesta += $"No contiene ofertas";
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
