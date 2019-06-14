using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaDeportesWeb.Models.DTOs;

namespace TiendaDeportesWeb.Models.DTOs
{
    public class CarritoDTo
    {
        
        //cliente
        public PersonasDto cliente { get; set; }
        // productos
        public List<ProductoDto> lstProductos { get; set; }

        //categorias 
        public List<CategoriasTiendaDTO> lstCategorias { get; set; }

        //marca 
        public List<FabricantesDTO> lstFabricantes { get; set; }
    }
}