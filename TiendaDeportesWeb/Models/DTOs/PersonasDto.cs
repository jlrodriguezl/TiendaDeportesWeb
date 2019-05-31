using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaDeportesWeb.Models.DTOs
{
    public class PersonasDto
    {
        public decimal ID_PERSONA { get; set; }
        public string NOM_PERSONA { get; set; }
        public string APE_PERSONA { get; set; }
        public decimal TEL_PERSONA { get; set; }
        public string EMAIL_PERSONA { get; set; }
        public string DIR_PERSONA { get; set; }
        public string CONTRASENA { get; set; }
        public string TIPO_PERSONA { get; set; }

        public List<DominiosDTO> lstPersonas { get; set; }
    }
}