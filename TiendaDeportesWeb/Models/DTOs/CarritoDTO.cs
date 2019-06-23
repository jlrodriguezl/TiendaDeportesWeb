using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaDeportesWeb.Models.DTOs
{
    public class CarritoDTO
    {
      public List<VentaProductoDTO> LstVentaProductos { get; set; }
      public VentaDTO venta { get; set; }
    }
}