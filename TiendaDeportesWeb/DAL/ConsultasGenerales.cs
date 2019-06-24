﻿using System;
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

        public List<ProductoDto> getProductos(int? idCat)
        {
            List<ProductoDto> lstProducto = null;
            using (tiendaEntities db = new tiendaEntities())
            {
                lstProducto = (from f in db.PRODUCTOS
                               where f.ID_CATEGORIA == (idCat == null ?
                              f.ID_CATEGORIA : idCat)
                               orderby f.NOM_PRODUCTO
                               select new ProductoDto
                               {
                                   ID_PRODUCTO = f.ID_PRODUCTO,
                                   NOM_PRODUCTO = f.NOM_PRODUCTO,
                                   DET_PRODUCTO = f.DET_PRODUCTO,
                                   PRECIO_ACTUAL = f.PRECIO_ACTUAL,
                                   FOTO_PRODUCTO = f.FOTO_PRODUCTO
                               }).ToList();
            }
            return lstProducto;
        }
        public List<CategoriasDto> GetCategorias()
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

        public CarritoDTO getVenta (int? idper)
        {
            CarritoDTO ca = null;
            List<VentaDTO> lstVenta = null;
            List<VentaProductoDTO> lstVentaProductos = null;

            using (tiendaEntities db = new tiendaEntities())
            {
                lstVenta = (from v in db.VENTAS
                            where v.ID_PERSONA == idper
                            select new VentaDTO
                            {
                                ID_VENTA = v.ID_VENTA,
                                FECHA_VENTA = v.FECHA_VENTA,
                                VLR_IVA = v.VLR_IVA,
                                ID_PERSONA = v.ID_PERSONA,
                                TIPO_PERSONA =v.TIPO_PERSONA,
                                ESTADO_VENTA = v.ESTADO_VENTA
                            
                            }).ToList();
                foreach (VentaDTO vd in lstVenta)
                {
                    ca = new CarritoDTO();
                    ca.venta = vd;
                    lstVentaProductos = (from vp in db.VENTA_PRODUCTOS
                                         where vp.ID_VENTA == vd.ID_VENTA
                                         orderby vp.ID_PRODUCTO
                                         select new VentaProductoDTO
                                         {
                                             ID_VENTA_PROD = vp.ID_VENTA_PROD,
                                             ID_VENTA = vp.ID_VENTA,
                                             ID_PRODUCTO = vp.ID_PRODUCTO,
                                             PRECIO_VENTA=vp.PRECIO_VENTA,
                                             CANTIDAD = vp.CANTIDAD
                                         
                                         }).ToList();
                    ca.LstVentaProductos = lstVentaProductos;
                }

            }
            return ca;
        }

    }
}