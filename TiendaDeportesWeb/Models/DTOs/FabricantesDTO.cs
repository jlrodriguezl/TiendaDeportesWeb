using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TiendaDeportesWeb.Models.DTOs
{
    public class FabricantesDTO
    {
        public int IdFabricante { get; set; }

        [Required]
        [Display(Name ="Nombre Fabricante")]
        public String NomFabricante { get; set; }

        [Required]
        [Display(Name = "Pais Fabricante")]
        public String PaisFabricante { get; set; }

        public List<DominiosDTO> lstPaises { get; set; }
    }
}