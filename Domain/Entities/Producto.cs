
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Producto : IComparable<Producto>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public DateTime Caducidad { get; set; }
        public UnidadMedida UnidadMedida { get; set; }

        public class ProductoIDCompare : IComparer<Producto>
        {
            public int Compare(Producto x, Producto y)
            {
                if (x.Id > y.Id)
                {
                    return 1;
                }
                else if (x.Id < y.Id)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
        public int CompareTo(Producto other)
        {
            return new ProductoIDCompare().Compare(this, other);
        }
        public class ProductoOrderByPrecio : IComparer<Producto>
        {
            public int Compare(Producto x, Producto y)
            {
                if (x.Precio > y.Precio)
                {
                    return 1;
                }
                else if (x.Precio < y.Precio)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
