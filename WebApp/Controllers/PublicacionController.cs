using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class PublicacionController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;
        public IActionResult Index(string mensaje)
        {
            ViewBag.mensaje = mensaje;
            ViewBag.Publicaciones = _sistema.Publicaciones;
            ViewBag.Articulos = _sistema.Articulos; 
            var saldo =  HttpContext.Session.GetInt32("saldo"); 
            ViewBag.Saldo = saldo;  
            return View();
        }

		public IActionResult FiltroPublicaciones(int idPubli)
		{
			ViewBag.Publicaciones = _sistema.Publicaciones;
			ViewBag.Publicaciones = _sistema.ObtenerPublicacionPorId(idPubli);
			return View("index");
		}


		public IActionResult FinalizarVenta(int id)
        {
            try
            {      
                Publicacion unaPublicacion = _sistema.ObtenerPublicacionPorId(id);
                string mail = HttpContext.Session.GetString("mail");
                Cliente unC = _sistema.ObtenerCliente(mail);
                var saldo = HttpContext.Session.GetInt32("saldo");
                int precioDePublicacion = unaPublicacion.PrecioPubli();
                int saldoDeCliente = unC.Saldo;

                if (unaPublicacion == null || unC == null)
                {
                    throw new Exception("La publicacion o el cliente no existe");
                }
                if (saldoDeCliente >= precioDePublicacion)
                {
                    unC.Saldo = saldoDeCliente-precioDePublicacion;
                    HttpContext.Session.SetInt32("saldo", unC.Saldo);
                    unaPublicacion.Estado = "CERRADA";
                    ViewBag.Saldo = unC.Saldo;
                    return RedirectToAction("index", new { mensaje = "Compra Exitosa" });
                }
                else
                {
                    ViewBag.mensaje = "Saldo Insuficiente";
                    ViewBag.Saldo = unC.Saldo;
                }
            }
            catch(Exception e)
            {
                ViewBag.mensaje = e.Message;
            }
            ViewBag.Publicaciones = _sistema.Publicaciones;
            return View("index");
        }
	}
}
