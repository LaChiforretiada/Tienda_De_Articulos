namespace Dominio.Entidades
{
    public class Oferta 
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public int Monto { get; set; }
        public DateTime Fecha { get; set; }
        
        private static int _ultimoId;

        public Oferta(string usuario, int monto, DateTime fecha)
        {
            Id = _ultimoId++;
            Usuario = usuario;
            Monto = monto;
            Fecha = fecha;
        }


    }
}
