using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;

        [HttpGet]
        public IActionResult Index()
        {
			ViewBag.Usuarios = _sistema.Usuarios;
			return View();
        }

        public IActionResult Ver(int id)
        {
            return View();
        }

		[HttpGet]
		public IActionResult IrARegistro()
        {
			ViewBag.Usuarios = _sistema.Usuarios;
			// Redirige a la vista Registro
			return View("IrARegistro");
        }

		[HttpPost]
		public IActionResult TomarDatos(string nombre, string apellido, string mail, string contrasenia, decimal saldo)
        {
			ViewBag.Usuarios = _sistema.Usuarios;
			try
			{
				Usuario usuario = new Cliente(saldo, nombre, apellido, mail, contrasenia);
				_sistema.AgregarUsuario(usuario);
				ViewBag.Nombre = nombre;
                return View("RegistroExitoso"); // Asegúrate de tener una vista RegistroExitoso.cshtml
			}
			catch (Exception e)
			{
				ViewBag.ErrorMessage = e.Message;
				return View("ErrorRegistro");
			}
		}


    }
}
