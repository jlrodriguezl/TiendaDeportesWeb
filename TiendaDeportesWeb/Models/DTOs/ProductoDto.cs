using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaDeportesWeb.Models.DTOs
{
    public class ProductoDto
    {
        public int ID_PRODUCTO { get; set; }
        public string NOM_PRODUCTO { get; set; }
        public string DET_PRODUCTO { get; set; }
        public decimal PRECIO_ACTUAL { get; set; }
        public int UND_DISPONIBLES { get; set; }
        public int ID_CATEGORIA { get; set; }
        public int ID_FABRICANTE { get; set; }

        public virtual CATEGORIAS CATEGORIAS { get; set; }
        public virtual FABRICANTES FABRICANTES { get; set; }

        public List<FabricantesDTO> lstFabricantes { get; set; }
    }
}