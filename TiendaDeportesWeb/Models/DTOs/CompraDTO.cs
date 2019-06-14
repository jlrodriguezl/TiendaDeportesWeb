using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaDeportesWeb.Models;

namespace TiendaDeportesWeb.Models.DTOs
{
    public class CompraDTO
    {
        //Cliente
        public PersonasDto cliente { get; set; }
        //Productos disponibles
        public List<ProductoDto> lstProductos { get; set; }
        //Categorias
        public List<CategoriasTiendaDTO> lstCategorias { get; set; }
        //Marcas
        public List<FabricantesDTO> lstFabricantes { get; set; }
    }
}