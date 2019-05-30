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
                                   DET_PRODUCTO = f.DET_PRODUCTO,
                                   PRECIO_ACTUAL =f.PRECIO_ACTUAL

                               }).ToList();
            }
            return View(lstProducto);
        }

        public List<CategoriasDto> GetCategorias()
        {
            List<CategoriasDto> lstCategorias = null;
            using (tiendaEntities db = new tiendaEntities())
            {
                lstCategorias = (from d in db.CATEGORIAS
                                  orderby d.NOM_CATEGORIA
                                  select new CategoriasDto
                                  {
                                      ID_CATEGORIA = d.ID_CATEGORIA,
                                      NOM_CATEGORIA = d.NOM_CATEGORIA
                                  }).ToList();
            }
            return lstCategorias;
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
            productoDto.lstCategorias = GetCategorias();
            return View(productoDto);
        }
        [HttpPost]
        public ActionResult Add(ProductoDto model)
        {
            //Validar los datos del formulario
            if (!ModelState.IsValid)
            {
                model.lstFabricantes = GetFabricantes();
                model.lstCategorias = GetCategorias();
                return View(model);
            }
            //Insertar en la BD
            using (tiendaEntities db = new tiendaEntities())
            {
                PRODUCTOS p = new PRODUCTOS();
                p.NOM_PRODUCTO = model.NOM_PRODUCTO;
                p.ID_PRODUCTO = model.ID_PRODUCTO;
                p.DET_PRODUCTO = model.DET_PRODUCTO;
                p.PRECIO_ACTUAL = model.PRECIO_ACTUAL;
                p.UND_DISPONIBLES = model.UND_DISPONIBLES;
                p.ID_FABRICANTE = model.ID_FABRICANTE;
                p.ID_CATEGORIA = model.ID_CATEGORIA;

                db.PRODUCTOS.Add(p);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Productos/"));
        }

        public ActionResult Edit(int id)
        {
            ProductoDto model = new ProductoDto();
            using (tiendaEntities db = new tiendaEntities())
            {
                PRODUCTOS p = db.PRODUCTOS.Find(id);
                model.ID_PRODUCTO = p.ID_PRODUCTO;
                model.NOM_PRODUCTO = p.NOM_PRODUCTO;
                model.DET_PRODUCTO = p.DET_PRODUCTO;
                model.PRECIO_ACTUAL = p.PRECIO_ACTUAL;
                model.ID_FABRICANTE = p.ID_FABRICANTE;
                model.ID_CATEGORIA = p.ID_CATEGORIA;
            }
            model.lstFabricantes = GetFabricantes();
            model.lstCategorias = GetCategorias();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ProductoDto model)
        {
            //Validar los datos del formulario
            if (!ModelState.IsValid)
            {
                model.lstFabricantes = GetFabricantes();
                model.lstCategorias = GetCategorias();
                return View(model);
            }
            //Actualizar en la BD
            using (tiendaEntities db = new tiendaEntities())
            {
                PRODUCTOS f = new PRODUCTOS();
                f.ID_PRODUCTO = model.ID_PRODUCTO;
                f.NOM_PRODUCTO = model.NOM_PRODUCTO;
                f.DET_PRODUCTO = model.DET_PRODUCTO;
                f.PRECIO_ACTUAL = model.PRECIO_ACTUAL;
                f.ID_FABRICANTE = model.ID_FABRICANTE;
                f.ID_CATEGORIA = model.ID_CATEGORIA;


                db.Entry(f).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Productos/"));
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (tiendaEntities db = new tiendaEntities())
            {
                PRODUCTOS f = db.PRODUCTOS.Find(id);
                db.PRODUCTOS.Remove(f);
                db.SaveChanges();
            }
            return Content("1");
        }
    }
}