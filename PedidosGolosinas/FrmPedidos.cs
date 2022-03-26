using Datos.Accesos;
using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PedidosGolosinas
{
    public partial class FrmPedidos : Form
    {
        public FrmPedidos()
        {
            InitializeComponent();
        }

        ProductosDA productosDA = new ProductosDA();
        Pedidos pedidos = new Pedidos();
        Producto producto;
        PedidosDA pedidosDA = new PedidosDA();

        List<DetallePedidos> detallePedidosLista = new List<DetallePedidos>();

        decimal subTotal = decimal.Zero;
        decimal isv = decimal.Zero;
        decimal totalAPagar = decimal.Zero;

        private void FrmPedidos_Load(object sender, EventArgs e)
        {
            DetalleDataGridView.DataSource = detallePedidosLista;
        }

        private void CodigoProductoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                producto = new Producto();
                producto = productosDA.GetProductoPorCodigo(CodigoProductoTextBox.Text);
                DescripcionProductoTextBox.Text = producto.Descripcion;
                CantidadTextBox.Focus();
            }
            else
            {
                producto = null;
                DescripcionProductoTextBox.Clear();
                CantidadTextBox.Clear();
            }
        }

        private void CantidadTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(CantidadTextBox.Text))
            {
                DetallePedidos detallePedidos = new DetallePedidos();
                detallePedidos.CodigoProducto = producto.Codigo;
                detallePedidos.Descripcion = producto.Descripcion;
                detallePedidos.Cantidad = Convert.ToInt32(CantidadTextBox.Text);
                detallePedidos.Precio = producto.Precio;
                detallePedidos.Total = producto.Precio * Convert.ToInt32(CantidadTextBox.Text);

                subTotal += detallePedidos.Total;
                isv = subTotal * 0.15M;
                totalAPagar = subTotal + isv;

                SubTotalTextBox.Text = subTotal.ToString();
                ISVTextBox.Text = isv.ToString();
                TotalTextBox.Text = totalAPagar.ToString();

                detallePedidosLista.Add(detallePedidos);
                DetalleDataGridView.DataSource = null;
                DetalleDataGridView.DataSource = detallePedidosLista;


            }
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
              pedidos.IdentidadCliente = IdentidadMaskedTextBox.Text;
              pedidos.Cliente = NombreTextBox.Text;
              pedidos.Fecha = FechaDateTimePicker.Value;
              pedidos.SubTotal = Convert.ToDecimal(SubTotalTextBox.Text);
              pedidos.Impuesto = Convert.ToDecimal(ISVTextBox.Text);
              pedidos.Total = Convert.ToDecimal(TotalTextBox.Text);

              int idPedido = 0;
              idPedido = pedidosDA.InsertarPedido(pedidos);
              if (idPedido != 0)
              {
                    foreach (var item in detallePedidosLista)
                    {
                        item.IdPedido = idPedido;
                        pedidosDA.InsertarDetalle(item);
                    }
              }
        }      
    }
}
