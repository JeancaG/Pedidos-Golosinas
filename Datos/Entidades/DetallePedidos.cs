﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class DetallePedidos
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int CodigoProducto { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }

        public DetallePedidos()
        {
        }

        public DetallePedidos(int id, int idPedido, int codigoProducto, string descripcion, int cantidad, decimal precio, decimal total)
        {
            Id = id;
            IdPedido = idPedido;
            CodigoProducto = codigoProducto;
            Descripcion = descripcion;
            Cantidad = cantidad;
            Precio = precio;
            Total = total;
        }
    }
}
