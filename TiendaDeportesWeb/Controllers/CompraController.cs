using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaDeportesWeb.Models.DTOs;
using TiendaDeportesWeb.DAL;
namespace TiendaDeportesWeb.Controllers
{
    public class CompraController : Controller
    {
        public ConsultasGenerales con;
        // GET: Compra
        public ActionResult Index()
        {
            CompraDTO compra = new CompraDTO();
            compra.lstFabricantes = con.getListaFabricantes();
            compra.lstroductos = con.getProductos();
            compra.lstCategorias = con.GetCategorias();
            return View();
        }
    }
}