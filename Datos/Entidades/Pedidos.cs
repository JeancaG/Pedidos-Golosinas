using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class Pedidos
    {
        public int IdentidadCliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }

        public Pedidos()
        {
        }

        public Pedidos(int identidadCliente, DateTime fecha, decimal subTotal, decimal impuesto, decimal total)
        {
            IdentidadCliente = identidadCliente;
            Fecha = fecha;
            SubTotal = subTotal;
            Impuesto = impuesto;
            Total = total;
        }
    }
}
