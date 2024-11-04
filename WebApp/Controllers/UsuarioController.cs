using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;

        [HttpGet]
        public IActionResult Index(string mensaje)
        {
            string mail = HttpContext.Session.GetString("mail");
            string contra = HttpContext.Session.GetString("contra");
            string rol = HttpContext.Session.GetString("rol");
            string nombre = HttpContext.Session.GetString("nombre");
            var saldo = HttpContext.Session.GetInt32("saldo");
            ViewBag.nombre = nombre;    
            ViewBag.mensaje = mensaje;
            ViewBag.Rol = rol;
            ViewBag.Mail = mail;
			ViewBag.Usuarios = _sistema.Usuarios;
			return View();
        }

        public IActionResult Ver(int id)
        {
            return View();
        }

		[HttpGet]
		public IActionResult IrARegistro(string mensaje)
        {
			ViewBag.Usuarios = _sistema.Usuarios;
			// Redirige a la vista Registro
			return View(new Cliente());
        }

		[HttpPost]
		public IActionResult IrARegistro(Cliente cliente)
        {
			ViewBag.Usuarios = _sistema.Usuarios;
			try
			{
				_sistema.AgregarUsuario(cliente);
                HttpContext.Session.SetString("nombre", cliente.Nombre);
                HttpContext.Session.SetString("mail", cliente.Mail);
                HttpContext.Session.SetString("rol", cliente.Rol);
                HttpContext.Session.SetInt32("saldo", cliente.Saldo);
                return RedirectToAction("index", new { mensaje = "Registro exitoso" });
            }
			catch (Exception e)
			{
				ViewBag.mensaje = e.Message;
			}
            return View(cliente);
		}


    }
}
