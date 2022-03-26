using Datos.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Datos.Accesos
{
    public class PedidosDA
    {
        readonly string cadena = "Server=localhost; Port=3306; Database=NegocioGolosinas; Uid=root; Pwd=Ranson_007;";

        MySqlConnection conn;
        MySqlCommand cmd;


        public int InsertarPedido(Pedidos pedidos)
        {
            int idPedido = 0;

            try
            {
                string sql = "INSERT INTO Pedidos VALUES (@IdentidadCliente, @Cliente, @Fecha, @SubTotal, @Impuesto, @Total); select last_insert_id();";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@IdentidadCliente", pedidos.IdentidadCliente);
                cmd.Parameters.AddWithValue("@Cliente", pedidos.Cliente);
                cmd.Parameters.AddWithValue("@Fecha", pedidos.Fecha);
                cmd.Parameters.AddWithValue("@SubTotal", pedidos.SubTotal);
                cmd.Parameters.AddWithValue("@Impuesto", pedidos.Impuesto);
                cmd.Parameters.AddWithValue("@Total", pedidos.Total);
                idPedido = Convert.ToInt32(cmd.ExecuteScalar());


                conn.Close();
            }
            catch (Exception ex)
            {
            }
            return idPedido;

        }

        public bool InsertarDetalle(DetallePedidos detallePedido)
        {
            bool inserto = false;
            try
            {
                string sql = "INSERT INTO DetallePedidos (IdPedido, CodigoProducto, Descripcion, Cantidad, Precio, Total) VALUES (@IdPedido, @CodigoProducto, @Descripcion, @Cantidad, @Precio, @Total);";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@IdPedido", detallePedido.IdPedido);
                cmd.Parameters.AddWithValue("@CodigoProducto", detallePedido.CodigoProducto);
                cmd.Parameters.AddWithValue("@Descripcion", detallePedido.Descripcion);
                cmd.Parameters.AddWithValue("@Cantidad", detallePedido.Cantidad);
                cmd.Parameters.AddWithValue("@Precio", detallePedido.Precio);
                cmd.Parameters.AddWithValue("@Total", detallePedido.Total);
                cmd.ExecuteNonQuery();

                inserto = true;
                conn.Close();
            }
            catch (Exception ex)
            {
            }
            return inserto;
        }

    }
}
