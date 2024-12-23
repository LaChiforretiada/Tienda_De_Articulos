﻿using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filtros;

namespace WebApp.Controllers
{
    [Logueado]
    public class PublicacionController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;

        [EsCliente]
        public IActionResult Index(string mensaje)
        {
            ViewBag.mensaje = mensaje;
            ViewBag.Publicaciones = _sistema.Publicaciones; 
            ViewBag.Articulos = _sistema.Articulos; 
            var saldo =  HttpContext.Session.GetInt32("saldo"); 
            ////var mail = HttpContext.Session.GetString("mail");
            //Cliente unC = _sistema.ObtenerCliente(mail);
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
                    _sistema.VentaExitosa(unC, unaPublicacion);
                    HttpContext.Session.SetInt32("saldo", unC.Saldo);
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

        [EsCliente]
        [HttpGet]
        public IActionResult RealizarSubasta(int id)
        {
            ViewBag.Id = id;
            return View(new Oferta());
        }


        [EsCliente]
        [HttpPost]
        public IActionResult RealizarSubasta(Oferta oferta, int id)
        {
         
            Publicacion unaPublicacion = _sistema.ObtenerPublicacionPorId(id);
            string nombreSub = unaPublicacion.Nombre;
            string mail = HttpContext.Session.GetString("mail");
            DateTime fecha = DateTime.Now;
            oferta.UsuarioMail = mail;
            oferta.Fecha = fecha;
            try
            {
                _sistema.AgregarOfertaASubasta(mail, nombreSub, oferta);
                return RedirectToAction("index", new { mensaje = "Oferta Exitosa" });
                
            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
            }
            ViewBag.Id = id;
            return View(oferta);
        }

        [EsAdmin]
        public IActionResult VistaAdmin(string mensaje) 
        {
            ViewBag.mensaje = mensaje;
            ViewBag.PublicacionesOrdenadas = _sistema.SubastasOrdenadas();
            ViewBag.Articulos = _sistema.Articulos;
            return View();
        }

        [EsAdmin]
        public IActionResult CerrarSubasta(int id)
        {
            string mail = HttpContext.Session.GetString("mail");
            try
            {
                _sistema.CerrarSubasta(id, mail);
                return RedirectToAction("VistaAdmin", new { mensaje = "Subasta Cerrada Con EXITO" });

            }catch(Exception e)
            {
                ViewBag.mensaje = e.Message;
            }
            ViewBag.Id = id;
            return View();
        }
    }
}
