﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filtros
{
    public class Logueado : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("rol") == null)
            {
                context.Result = new RedirectResult("/Login/Ingresar");
            }
        }
    }
}
