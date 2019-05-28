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

    }
}
