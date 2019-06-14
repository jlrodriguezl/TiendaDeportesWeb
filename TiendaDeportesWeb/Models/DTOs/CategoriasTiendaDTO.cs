using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaDeportesWeb.Models.DTOs
{
    public class CategoriasTiendaDTO
    {
     
        
            public CategoriasDto categoriaPadre { get; set; }
            public List<CategoriasDto> subCategorias { get; set; }
        
    }
}