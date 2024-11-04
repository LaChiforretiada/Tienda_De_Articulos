﻿using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;


    namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;

        [HttpGet]
        public IActionResult Ingresar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ingresar(string mail, string contra)
        {
            try
            {
                Usuario usuario = _sistema.ObtenerUsuarioConContrasenia(mail, contra);

                if (usuario != null)
                {
                HttpContext.Session.SetString("mail", mail);
                HttpContext.Session.SetString("contra", contra);
                HttpContext.Session.SetString("rol", _sistema.ObtenerUsuarioConContrasenia(mail, contra).Rol);
                    return Redirect("/Usuario/index");
                }
                else
                {
                    ViewBag.mensaje = "Ingreso erróneo, verifique sus credenciales";
                }
            }
            catch (Exception)
            {
                ViewBag.mensaje = "Ingreso erróneo, verifique sus credenciales";
            }
            return View();
        }
    }
}