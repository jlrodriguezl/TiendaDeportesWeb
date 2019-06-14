using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaDeportesWeb.Models;

namespace TiendaDeportesWeb.Models.DTOs
{
    public class CompraDTO
    {
        //cliente
        public PersonasDto cliente {get; set;}

        //Productos
        public List<ProductoDto> lstProductos {get; set;}

        //categorias
        public List<CategoriasTiendaDTO> lstCategorias { get; set; }

        public List<CategoriasDto> lstCategoriasPadre { get; set; }

        //marcas
        public List<FabricantesDTO> lstFabricantes {get; set;}

                
    }
}