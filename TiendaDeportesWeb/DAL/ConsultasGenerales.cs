using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaDeportesWeb.Models.DTOs;
using TiendaDeportesWeb.Models;

namespace TiendaDeportesWeb.DAL
{
    public class ConsultasGenerales
    {
        public List<FabricantesDTO> getListaFabricantes()
        {
            List<FabricantesDTO> lstFabricantes = null;
            using (tiendaEntities db = new tiendaEntities())
            {
                lstFabricantes = (from f in db.FABRICANTES
                                  orderby f.NOM_FABRICANTE
                                  select new FabricantesDTO
                                  {
                                      IdFabricante = f.ID_FABRICANTE,
                                      NomFabricante = f.NOM_FABRICANTE,
                                      PaisFabricante = f.PAIS_FABRICANTE
                                  }).ToList();
            }
            return lstFabricantes;
        }

        public List<ProductoDto> getProductos()
        {
            List<ProductoDto> lstProducto = null;
            using (tiendaEntities db = new tiendaEntities())
            {
                lstProducto = (from f in db.PRODUCTOS
                               orderby f.NOM_PRODUCTO
                               select new ProductoDto
                               {
                                   ID_PRODUCTO = f.ID_PRODUCTO,
                                   NOM_PRODUCTO = f.NOM_PRODUCTO,
                                   DET_PRODUCTO = f.DET_PRODUCTO,
                                   PRECIO_ACTUAL = f.PRECIO_ACTUAL

                               }).ToList();
            }
            return lstProducto;
        }

        public List<CategoriasDto> getCategorias()
        {
            List<CategoriasDto> lstCategorias = null;
            using (tiendaEntities db = new tiendaEntities())
            {
                lstCategorias = (from d in db.CATEGORIAS
                                 orderby d.NOM_CATEGORIA
                                 select new CategoriasDto
                                 {
                                     ID_CATEGORIA = d.ID_CATEGORIA,
                                     NOM_CATEGORIA = d.NOM_CATEGORIA
                                 }).ToList();
            }
            return lstCategorias;
        }
    }
}