using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaDeportesWeb.Models;
using TiendaDeportesWeb.Models.DTOs;

namespace TiendaDeportesWeb.Controllers
{
    public class DominiosController : Controller
    {
        // GET: Dominios
        public ActionResult Index()
        {
            List<DominiosDTO> lstDominios = null;
            using (tiendaEntities db = new tiendaEntities())
            {
                lstDominios = (from d in db.DOMINIOS
                               orderby d.TIPO_DOMINIO
                               select new DominiosDTO
                               {
                                   ID_DOMINIO = d.ID_DOMINIO,
                                   TIPO_DOMINIO = d.TIPO_DOMINIO,
                                   VLR_DOMINIO = d.VLR_DOMINIO
                               }).ToList();
            }
            return View(lstDominios);

        }
        public ActionResult Add()
        {
            DominiosDTO DominiosDTO = new DominiosDTO();
            return View(DominiosDTO);
        }

        [HttpPost]
        public ActionResult Add(DominiosDTO model)
        {

            //Insertar en la BD
            using (tiendaEntities db = new tiendaEntities())
            {
                DOMINIOS d = new DOMINIOS();
                d.TIPO_DOMINIO = model.TIPO_DOMINIO;
                d.ID_DOMINIO = model.ID_DOMINIO;
                d.VLR_DOMINIO = model.VLR_DOMINIO;

                db.DOMINIOS.Add(d);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Dominios/"));

        }
        public ActionResult Edit(string id)
        {
            DominiosDTO model = new DominiosDTO();
            using (tiendaEntities db = new tiendaEntities())
            {
                DOMINIOS d = new DOMINIOS();
                d.TIPO_DOMINIO = model.TIPO_DOMINIO;
                d.ID_DOMINIO = model.ID_DOMINIO;
                d.VLR_DOMINIO = model.VLR_DOMINIO;
            }
            
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(DominiosDTO model)
        {
            //Actualizar en la BD
            using (tiendaEntities db = new tiendaEntities())
            {
                DOMINIOS d = new DOMINIOS();
                d.TIPO_DOMINIO = model.TIPO_DOMINIO;
                d.ID_DOMINIO = model.ID_DOMINIO;
                d.VLR_DOMINIO = model.VLR_DOMINIO;

                db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Dominios/"));
        }
    }
}