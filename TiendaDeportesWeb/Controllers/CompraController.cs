using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaDeportesWeb.Models;
using TiendaDeportesWeb.Models.DTOs;
using TiendaDeportesWeb.DAL;
using System.Data.SqlClient;


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
            con = new ConsultasGenerales();
            VistaVentaDTO vistaVentaDTO = new VistaVentaDTO();
            var oPersona = (PERSONAS)System.Web.HttpContext.Current.Session["User"];
            vistaVentaDTO.carrito = con.getVenta(Decimal.ToInt32(oPersona.ID_PERSONA));

            return View(vistaVentaDTO);
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
                    /*
                    SqlParameter[] param = new SqlParameter[]
                    {
                        new SqlParameter("@IdProducto", id),
                        new SqlParameter("@IdPersona", oPersona.ID_PERSONA),
                        new SqlParameter("@TipoPersona", oPersona.TIPO_PERSONA)

                    };

                    //db.Get_Prc_Add_Carrito(id, oPersona.ID_PERSONA, oPersona.TIPO_PERSONA);
                    var res = db.Database.SqlQuery<HttpPostAttribute>("Prc_Add_Carrito @IdProducto, " +
                        "@IdPersona, @TipoPersona", param);*/
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