using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TiendaDeportesWeb.Models;
using TiendaDeportesWeb.Models.DTOs;

namespace TiendaDeportesWeb.Controllers
{
    public class PersonasController : Controller
    {
        public ActionResult Index()
        {
            List<PersonasDto> lstPersonas = null;
            using (tiendaEntities db = new tiendaEntities())
            {
                lstPersonas = (from f in db.PERSONAS
                               orderby f.NOM_PERSONA
                               select new PersonasDto
                               {
                                   ID_PERSONA = f.ID_PERSONA,
                                   NOM_PERSONA = f.NOM_PERSONA,
                                   APE_PERSONA = f.APE_PERSONA,
                                   TEL_PERSONA = f.TEL_PERSONA,
                                   EMAIL_PERSONA = f.EMAIL_PERSONA,
                                   DIR_PERSONA = f.DIR_PERSONA,
                                   TIPO_PERSONA = f.TIPO_PERSONA

                                  }).ToList();
            }
            return View(lstPersonas);
        }

        public List<DominiosDTO> getPersonas()
        {
            List<DominiosDTO> lstPaises = null;
            using (tiendaEntities db = new tiendaEntities())
            {
                lstPaises = (from d in db.DOMINIOS
                             where d.TIPO_DOMINIO == "PERSONAS"
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
            PersonasDto personasDto = new PersonasDto();
            personasDto.lstPersonas = getPersonas();
            return View(personasDto);
        }

        [HttpPost]
        public ActionResult Add(PersonasDto model)
        {
            //Validar los datos del formulario
            if (!ModelState.IsValid)
            {
                model.lstPersonas = getPersonas();
                return View(model);
            }
            //Insertar en la BD
            using (tiendaEntities db = new tiendaEntities())
            {
                PERSONAS persona = new PERSONAS();
                persona.ID_PERSONA = model.ID_PERSONA;
                persona.NOM_PERSONA = model.NOM_PERSONA;
                persona.APE_PERSONA = model.APE_PERSONA;
                persona.TEL_PERSONA = model.TEL_PERSONA;
                persona.EMAIL_PERSONA = model.EMAIL_PERSONA;
                persona.DIR_PERSONA = model.DIR_PERSONA;
                persona.TIPO_PERSONA = model.TIPO_PERSONA;

                db.PERSONAS.Add(persona);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Personas/"));
        }

        public ActionResult Edit(int id, string tipoPersona)
        {
            PersonasDto model = new PersonasDto();
            using (tiendaEntities db = new tiendaEntities())
            {
                PERSONAS persona = db.PERSONAS.Find(id, tipoPersona);
                model.ID_PERSONA = persona.ID_PERSONA;
                model.NOM_PERSONA = persona.NOM_PERSONA;
                model.APE_PERSONA = persona.APE_PERSONA;
                model.TEL_PERSONA = persona.TEL_PERSONA;
                model.EMAIL_PERSONA = persona.EMAIL_PERSONA;
                model.DIR_PERSONA = persona.DIR_PERSONA;
                model.TIPO_PERSONA = persona.TIPO_PERSONA;
            }
            model.lstPersonas = getPersonas();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PersonasDto model)
        {
            //Validar los datos del formulario
            if (!ModelState.IsValid)
            {
                model.lstPersonas = getPersonas();
                return View(model);
            }
            //Actualizar en la BD
            using (tiendaEntities db = new tiendaEntities())
            {
                PERSONAS persona = new PERSONAS();
                persona.ID_PERSONA = model.ID_PERSONA;
                persona.NOM_PERSONA = model.NOM_PERSONA;
                persona.APE_PERSONA = model.APE_PERSONA;
                persona.TEL_PERSONA = model.TEL_PERSONA;
                persona.EMAIL_PERSONA = model.EMAIL_PERSONA;
                persona.DIR_PERSONA = model.DIR_PERSONA;
                persona.TIPO_PERSONA = model.TIPO_PERSONA;

                db.Entry(persona).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Personas/"));
        }
    }
}
