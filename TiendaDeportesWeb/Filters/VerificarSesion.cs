using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaDeportesWeb.Controllers;
using TiendaDeportesWeb.Models;

namespace TiendaDeportesWeb.Filters
{
    public class VerificarSesion : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Obtener de la sesión los datos de la persona logueada
            var oPersona = (PERSONAS)HttpContext.Current.Session["User"];
            //Si la sesión no existe redireccionamos al login
            if(oPersona == null)
            {
                if(filterContext.Controller is LoginController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }
            else
            {
                if(filterContext.Controller is LoginController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}