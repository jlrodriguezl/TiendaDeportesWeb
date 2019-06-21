using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaDeportesWeb.Models.DTOs;

namespace TiendaDeportesWeb.Models.DTOs
{
    public class CarritoDTo
    {
        public PERSONAS cliente { get; set; }
        public List<VentaProductosDTO> lstVentaProductos { get; set; }

        public VentaDTo venta { get; set; }

    }
}