﻿using Domain.Entities;
using Domain.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Productos
{
    public class ProductoModel
    {
        private Producto[] productos;
        #region CRUD
        public void Add(Producto p)
        {
            Add(p, ref productos);
        }
        public Producto[] GetAll()
        {
            return productos;
        }
        public int Update(Producto p)
        {
            int index = GetIndexByID(p);
            if (index < 0)
            {
                throw new Exception($"El producto con Id: {p.Id} no se encontro");
            }
            productos[index] = p;
            return index;
        }
        public bool Delete(Producto p)
        {
            int index = GetIndexByID(p);
            Producto[] temp = new Producto[productos.Length - 1];
            if (index != -1)
            {
                
                Array.Copy(productos, temp, index);
                if (index != productos.Length - 1)
                {
                    for (int i = index; i < productos.Length - 1; i++)
                    {
                        temp[i] = productos[i + 1];
                    }
                }
                productos = temp;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
            return productos.Length == temp.Length;
        }
        #endregion
        #region Queries
        public Producto GetProductoByID(int id)
        {
            //revisar aqui
            if (productos != null)
            {
                Array.Sort(productos, new Producto.ProductoIDCompare());
                Producto p = new Producto { Id = id };
                int index = Array.BinarySearch(productos, p, new Producto.ProductoIDCompare());
                return index < 0 ? null : productos[index];
            }
            return null;
        }
        public Producto[] GetProductosByUnidadMedida(UnidadMedida um)
        {
            Producto[] tmp = null;
            if (productos == null)
            {
                return tmp;
            }
            foreach(Producto pr in productos)
            {
                if(pr.UnidadMedida == um)
                {
                    Add(pr, ref tmp);
                }
            }
            return tmp;
        }
        public Producto[] GetProductosByFechaVencimiento(DateTime dt)
        {
            Producto[] tmp = null;
            if (productos == null)
            {
                return tmp;
            }
            foreach (Producto pr in productos)
            {
                if (pr.Caducidad.CompareTo(dt)<=0)
                {
                    Add(pr, ref tmp);
                }
            }
            return tmp;
        }
        public Producto[] GetProductosOrderByPrecio()
        {
            if (productos == null)
            {
                throw new ArgumentException("ERROR. No hay productos");
            }
            Array.Sort(productos, new Producto.ProductoOrderByPrecio());
            return productos;
        }
        public Producto[] GetProductosByRangoPrecio(decimal start, decimal end)
        {
            Producto[] tmp = null;
            if (productos == null)
            {
                return tmp;
            }
            foreach (Producto pr in productos)
            {
                if (pr.Precio>=start && pr.Precio<=end)
                {
                    Add(pr, ref tmp);
                }
            }
            return tmp;
        }
        public String ConvertAsJSON()
        {
            return ConvertASJSON(productos);
        }
        public string ConvertASJSON(Producto[] prods)
        {
            return JsonConvert.SerializeObject(prods, Formatting.Indented);
        }
        public int GetLastProductoID()
        {
            return productos == null ? 0 : productos[productos.Length-1].Id;
        }
        #endregion
        #region private method
        private void Add(Producto p, ref Producto[] pds)
        {
            if (pds == null)
            {
                pds = new Producto[1];
                pds[pds.Length - 1] = p;
                return;
            }
            Producto[] tmp = new Producto[pds.Length + 1];
            Array.Copy(pds,tmp,pds.Length);
            tmp[tmp.Length - 1] = p;
            pds = tmp;
        }
        private int GetIndexByID(Producto p)
        {
            if(p == null)
            {
                throw new ArgumentException("El producto no puede ser null");
            }
            int index = int.MinValue;
            if (productos == null)
            {
                return index;
            }
            int i = 0;
            foreach(Producto pr in productos)
            {
                if (pr.Id ==p.Id)
                {
                    index = i;
                    break;
                }
                i++;
            }
            return index;
        }
        #endregion
    }
}
