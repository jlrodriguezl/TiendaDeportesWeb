using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaDeportesWeb.Models.DTOs
{
    public class CategoriasDto
    {

        public int ID_CATEGORIA { get; set; }
        public string NOM_CATEGORIA { get; set; }
        public Nullable<int> ID_CATEGORIA_PADRE { get; set; }
    }
}