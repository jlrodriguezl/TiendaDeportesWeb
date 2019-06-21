using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaDeportesWeb.Models.DTOs
{
    public class VentaDTo
    {
        public int ID_VENTA { get; set; }
        public System.DateTime FECHA_VENTA { get; set; }
        public decimal VLR_IVA { get; set; }
        public decimal ID_PERSONA { get; set; }
        public string TIPO_PERSONA { get; set; }
        public string ESTADO_VENTA { get; set; }

    }
}