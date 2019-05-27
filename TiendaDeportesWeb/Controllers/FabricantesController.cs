using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaDeportesWeb.Models;
using TiendaDeportesWeb.Models.DTOs;

namespace TiendaDeportesWeb.Controllers
{
    public class FabricantesController : Controller
    {
        // GET: Fabricantes
        public ActionResult Index()
        {
            List<FabricantesDTO> lstFabricantes = null;
            using (tiendaEntities db = new tiendaEntities())
            {
                lstFabricantes = (from f in db.FABRICANTES
                                  orderby f.NOM_FABRICANTE
                                  select new FabricantesDTO
                                  {
                                      IdFabricante = f.ID_FABRICANTE,
                                      NomFabricante = f.NOM_FABRICANTE,
                                      PaisFabricante = f.PAIS_FABRICANTE
                                  }).ToList();
            }
            return View(lstFabricantes);
        }

        public List<DominiosDTO> getPaises()
        {
            List<DominiosDTO> lstPaises = null;
            using (tiendaEntities db = new tiendaEntities())
            {
                lstPaises = (from d in db.DOMINIOS
                             where d.TIPO_DOMINIO == "PAISES"
                             orderby d.VLR_DOMINIO
                             select new DominiosDTO
                             {
                                 ID_DOMINIO = d.ID_DOMINIO,
                                 VLR_DOMINIO = d.VLR_DOMINIO
                             }).ToList();                
            }
            return lstPaises;
        }

        public ActionResult Add()
        {
            FabricantesDTO fabricantesDTO = new FabricantesDTO();
            fabricantesDTO.lstPaises = getPaises();
            return View(fabricantesDTO);
        }
        [HttpPost]
        public ActionResult Add(FabricantesDTO model)
        {
            //Validar los datos del formulario
            if (!ModelState.IsValid)
            {
                model.lstPaises = getPaises();
                return View(model);
            }
            //Insertar en la BD
            using (tiendaEntities db = new tiendaEntities())
            {
                FABRICANTES f = new FABRICANTES();
                f.NOM_FABRICANTE = model.NomFabricante;
                f.PAIS_FABRICANTE = model.PaisFabricante;

                db.FABRICANTES.Add(f);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Fabricantes/"));
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
            model.lstPaises = getPaises();
            return View(model);                
        }

        [HttpPost]
        public ActionResult Edit(FabricantesDTO model)
        {
            //Validar los datos del formulario
            if (!ModelState.IsValid)
            {
                model.lstPaises = getPaises();
                return View(model);
            }
            //Actualizar en la BD
            using (tiendaEntities db = new tiendaEntities())
            {
                FABRICANTES f = new FABRICANTES();
                f.ID_FABRICANTE = model.IdFabricante;
                f.NOM_FABRICANTE = model.NomFabricante;
                f.PAIS_FABRICANTE = model.PaisFabricante;

                db.Entry(f).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Fabricantes/"));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (tiendaEntities db = new tiendaEntities())
            {
                FABRICANTES f = db.FABRICANTES.Find(id);
                db.FABRICANTES.Remove(f);
                db.SaveChanges();
            }
            return Content("1");
        }
    }
}