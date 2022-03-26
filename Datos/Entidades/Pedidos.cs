using System;

namespace Datos.Entidades
{
    public class Pedidos
    {
        public int Id { get; set; }
        public string IdentidadCliente { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }

        public Pedidos()
        {
        }

        public Pedidos(int id, string identidadCliente, string cliente, DateTime fecha, decimal subTotal, decimal impuesto, decimal total)
        {
            Id = id;
            IdentidadCliente = identidadCliente;
            Cliente = cliente;
            Fecha = fecha;
            SubTotal = subTotal;
            Impuesto = impuesto;
            Total = total;
        }

    }
}
