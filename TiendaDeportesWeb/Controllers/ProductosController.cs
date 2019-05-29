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
        public List<FabricantesDTO> GetFabricantes()
        {
            List<FabricantesDTO> lstfabricantes = null;
            using (tiendaEntities db = new tiendaEntities())
            {
                lstfabricantes = (from d in db.FABRICANTES
                                  orderby d.NOM_FABRICANTE
                                  select new FabricantesDTO
                                  {
                                      IdFabricante = d.ID_FABRICANTE,
                                      NomFabricante = d.NOM_FABRICANTE
                                  }).ToList();
            }
            return lstfabricantes;
        }

        public ActionResult Add()
        {
            ProductoDto productoDto = new ProductoDto();
            productoDto.lstFabricantes = GetFabricantes();
            return View(productoDto);
        }
        [HttpPost]
        public ActionResult Add(ProductoDto model)
        {
            //Validar los datos del formulario
            if (!ModelState.IsValid)
            {
                model.lstFabricantes = GetFabricantes();
                return View(model);
            }
            //Insertar en la BD
            using (tiendaEntities db = new tiendaEntities())
            {
                PRODUCTOS f = new PRODUCTOS();
                f.NOM_PRODUCTO = model.NOM_PRODUCTO;
                f.ID_PRODUCTO = model.ID_PRODUCTO;

                db.PRODUCTOS.Add(f);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Producto/"));
        }

        public ActionResult Edit(int id)
        {
            FabricantesDTO model = new FabricantesDTO();
            using (tiendaEntities db = new tiendaEntities())
            {
                FABRICANTES f = db.FABRICANTES.Find(id);
                model.IdFabricante = f.ID_FABRICANTE;
                model.NomFabricante = f.NOM_FABRICANTE;
                model.PaisFabricante = f.PAIS_FABRICANTE;
            }
            model.lstPaises = GetFabricantes();
            return View(model);
        }
    }
}