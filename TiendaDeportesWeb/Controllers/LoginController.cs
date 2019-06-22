using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaDeportesWeb.Models;

namespace TiendaDeportesWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string pwd)
        {
            try
            {
                using (tiendaEntities db = new tiendaEntities())
                {
                    decimal idUser;
                    decimal.TryParse(user,out idUser);

                    var usuarios = from p in db.PERSONAS
                                   where p.ID_PERSONA == idUser &&
                                   p.CONTRASENA == pwd && p.TIPO_PERSONA == "CLI"
                                   select p;
                    if(usuarios.Count() > 0)
                    {
                        PERSONAS oPersonas = usuarios.First();
                        Session["User"] = oPersonas;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario o contraseña incorrectos");
                    }
                }
            }
            catch(Exception e)
            {
                return Content("Error: " + e.Message);
            }
        }
    }
}