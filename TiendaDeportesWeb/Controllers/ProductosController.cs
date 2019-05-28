using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaDeportesWeb.Models;
using TiendaDeportesWeb.Models.DTOs;

namespace TiendaDeportesWeb.Controllers
{
    public class ProductosController : Controller
    {
        public ActionResult Index()
        {
            List<ProductoDto> lstProducto = null;
            using (tiendaEntities db = new tiendaEntities())
            {
                lstProducto = (from f in db.PRODUCTOS
                               orderby f.NOM_PRODUCTO
                               select new ProductoDto
                               {
                                   ID_PRODUCTO = f.ID_PRODUCTO,
                                   NOM_PRODUCTO = f.NOM_PRODUCTO,
                                   UND_DISPONIBLES = f.UND_DISPONIBLES
                               }).ToList();
            }
            return View(lstProducto);
        }
    }
}