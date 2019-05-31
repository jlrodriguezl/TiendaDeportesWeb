using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TiendaDeportesWeb.Models.DTOs
{
    public class DominiosDTO
    {
        [Required]
        [Display(Name = "Tipo de Dominio")]
        public string TIPO_DOMINIO { get; set; }

        [Required]
        [Display(Name = "Id Dominio")]
        public string ID_DOMINIO { get; set; }

        [Required]
        [Display(Name = "Valor del Dominio")]
        public string VLR_DOMINIO { get; set; }

        public List<DominiosDTO> lstDominios { get; set; }
    }
}