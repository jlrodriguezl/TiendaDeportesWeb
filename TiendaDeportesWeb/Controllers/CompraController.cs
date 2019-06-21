using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaDeportesWeb.Models;
using TiendaDeportesWeb.Models.DTOs;
using TiendaDeportesWeb.DAL;

namespace TiendaDeportesWeb.Controllers
{
    public class CompraController : Controller
    {
        public Consultas_Generales con;
        // GET: Compra


        public ActionResult Index()
        {
            con = new Consultas_Generales();
            CompraDTO compra = new CompraDTO();
            compra.lstFabricantes = con.GetListaFabricantes();
            compra.lstProductos = con.getProductos(null);
            compra.lstCategorias = con.getCategoriasCompra();
            return View(compra);
        }
        [HttpGet]
        [Route("compra/Index/{idcat:int}")]
        public ActionResult Index(int? idCat)
        {
            con = new Consultas_Generales();
            CompraDTO compra = new CompraDTO();
            compra.lstFabricantes = con.GetListaFabricantes();
            compra.lstProductos = con.getProductos(idCat);
            compra.lstCategorias = con.getCategoriasCompra();
            return View(compra);
        }

        [HttpPost]
        public ActionResult Add(int id)
        {
            try
            {
                var oPersona = (PERSONAS)System.Web.HttpContext.Current.Session["User"];
                using (tiendaEntities db = new tiendaEntities())
                {
                    db.Prc_Add_Carrito(id, oPersona.ID_PERSONA, oPersona.TIPO_PERSONA);
                }
                return Content("1");
            }
            catch (Exception e)
            {
                return Content(e.GetBaseException().ToString());
            }
        }
    }
}