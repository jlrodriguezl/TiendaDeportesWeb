using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TiendaDeportesWeb.Models.DTOs
{
    public class ProductoDto
    {
        public int ID_PRODUCTO { get; set; }

        [Required]
        [Display(Name = "Nombre Producto")]
        public string NOM_PRODUCTO { get; set; }

        [Required]
        [Display(Name = "Detalle Producto")]
        public string DET_PRODUCTO { get; set; }

        [Required]
        [Display(Name = "Precio Actual")]
        public decimal PRECIO_ACTUAL { get; set; }

        [Required]
        [Display(Name = "Unidades Disponibles")]
        public int UND_DISPONIBLES { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int ID_CATEGORIA { get; set; }

        [Required]
        [Display(Name = "Fabricante")]
        public int ID_FABRICANTE { get; set; }
        [Display(Name = "Foto Producto")]
        public String FOTO_PRODUCTO { get; set; }

        public List<CategoriasDto> lstCategorias { get; set; }

        public List<FabricantesDTO> lstFabricantes { get; set; }
    }
}