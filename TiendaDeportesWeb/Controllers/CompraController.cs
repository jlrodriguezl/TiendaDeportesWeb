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
        public ConsultasGenerales con;


        // GET: Compra
        
        public ActionResult Index()
        {
            con = new ConsultasGenerales();
            CompraDTO compra = new CompraDTO();
            compra.lstFabricantes = con.GetListaFabricantes();
            compra.lstProductos = con.getProductos(null);
            compra.lstCategorias = con.getCategoriasCompra();
            return View(compra);
        }

        [HttpGet]
        [Route("Compra/Index/{idCat:int")]
        public ActionResult Index(int? idCat)
        {
            con = new ConsultasGenerales();
            CompraDTO compra = new CompraDTO();
            compra.lstFabricantes = con.GetListaFabricantes();
            compra.lstProductos = con.getProductos(idCat);
            compra.lstCategorias = con.getCategoriasCompra();
            return View(compra);
        }

        public ActionResult listarVenta()
        {

        }
    }
}