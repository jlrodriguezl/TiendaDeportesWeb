using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaDeportesWeb.Models;
using TiendaDeportesWeb.Models.DTOs;


namespace TiendaDeportesWeb.DAL
{
    public class categorías__padre_hijas
    {
        public List<CategoriasTiendaDTO> getCategoriasCompra()
        {
            //Obtener categorias para funcionalidad de compras
            List<CategoriasTiendaDTO> lstCategoriasTienda = new
           List<CategoriasTiendaDTO>();
            List<CategoriasDto> lstCategoriasPadre = null;
            List<CategoriasDto> lstCategoriasHijas = null;
            using (tiendaEntities db = new tiendaEntities())
            {
                //Obtener categorías padre
                lstCategoriasPadre = (from d in db.CATEGORIAS
                                      where d.ID_CATEGORIA_PADRE == null
                                      orderby d.NOM_CATEGORIA
                                      select new CategoriasDto
                                      {
                                          ID_CATEGORIA = d.ID_CATEGORIA,
                                          NOM_CATEGORIA = d.NOM_CATEGORIA
                                      }).ToList();
                foreach (CategoriasDto cp in lstCategoriasPadre)
                {
                    CategoriasTiendaDTO ct = new CategoriasTiendaDTO();
                    ct.categoriaPadre = cp;
                    //Obtener Categorias Hijas
                    lstCategoriasHijas = (from d in db.CATEGORIAS
                                          where d.ID_CATEGORIA_PADRE ==
                                         cp.ID_CATEGORIA
                                          orderby d.NOM_CATEGORIA
                                          select new CategoriasDto
                                          {
                                              ID_CATEGORIA = d.ID_CATEGORIA,
                                              NOM_CATEGORIA = d.NOM_CATEGORIA
                                          }).ToList();
                    ct.subCategorias = lstCategoriasHijas;
                    lstCategoriasTienda.Add(ct);
                }
            }
            return lstCategoriasTienda;
        }
    }
}