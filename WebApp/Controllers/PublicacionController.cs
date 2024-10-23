using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class PublicacionController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;
        public IActionResult Index()
        {
            ViewBag.Publicaciones = _sistema.Publicaciones;
			ViewBag.Articulos = _sistema.Articulos;
			return View();
        }

		public IActionResult FiltroPublicaciones(int idPubli)
		{
			ViewBag.Publicaciones = _sistema.Publicaciones;
			ViewBag.Publicaciones = _sistema.ObtenerPublicacionPorId(idPubli);
			return View("index");
		}


	}
}
