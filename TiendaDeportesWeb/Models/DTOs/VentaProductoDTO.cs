using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaDeportesWeb.Models.DTOs
{
    public class VentaProductoDTO
    {
        public int ID_VENTA_PROD { get; set; }
        public int ID_VENTA { get; set; }
        public int ID_PRODUCTO { get; set; }
        public decimal PRECIO_VENTA { get; set; }
        public int CANTIDAD { get; set; }
    }
}
