using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filtros;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;



        [Logueado]
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
            ViewBag.Saldo = saldo;
			ViewBag.Usuarios = _sistema.Usuarios;
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
                return RedirectToAction("index", new { mensaje = "Registro exitoso" });
            }
			catch (Exception e)
			{
				ViewBag.mensaje = e.Message;
			}
            return View(cliente);
		}

        [EsCliente]
        [HttpGet]
        public IActionResult RecargarSaldo(string mensaje)
        {
            string mail = HttpContext.Session.GetString("mail");
            ViewBag.Usuarios = _sistema.Usuarios;
            return View();
        }

        [EsCliente]
        [HttpPost]
        public IActionResult RecargarSaldo(int montoRecarga)
  {
            ViewBag.Usuarios = _sistema.Usuarios;
            try
           {
                string mail = HttpContext.Session.GetString("mail");
                Cliente unC = _sistema.ObtenerCliente(mail);
                var saldo = HttpContext.Session.GetInt32("saldo");
                unC.RecargaSaldo(montoRecarga);
                HttpContext.Session.SetInt32("saldo", unC.Saldo);
                ViewBag.Saldo = unC.Saldo;
                return RedirectToAction("index", new { mensaje = "Recarga exitosa" });
            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
            }
            return View("index");
        }
    }
}
