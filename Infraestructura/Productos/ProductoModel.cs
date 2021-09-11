using Domain.Entities;
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
            if (p == null)
            {
                throw new ArgumentException("El producto no puede ser null.");
            }
            int index = GetIndexByID(p);
            if (index < 0)
            {
                throw new Exception($"El producto con id:{p.Id} no existe.");
            }
            if (index != (productos.Length - 1))
            {
                productos[index] = productos[productos.Length - 1];
            }
            Producto[] tmp = new Producto[productos.Length - 1];
            Array.Copy(productos, tmp, tmp.Length);
            productos = tmp;
            return productos.Length == tmp.Length;
        }
        #endregion
        #region Queries
        public Producto GetProductoByID(int id)
        {
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
            try
            {
                return productos == null ? 0 : productos.Length;
            }
            catch (IndexOutOfRangeException)
            {
                return 0;
            }
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
