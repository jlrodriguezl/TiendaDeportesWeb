using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaDeportesWeb.Models.DTOs;
namespace TiendaDeportesWeb.Models.DTOs
{
    public class CompraDTO
    {
        //Cliente
        public PersonasDto cliente { get; set; }
        //productos disponibles
        public List <ProductoDto> lstroductos { get; set; }

        //categorias
        public List<CategoriasDto> lstCategorias { get; set; }

        //marcas
        public List<FabricantesDTO> lstFabricantes { get; set; }
    }
}