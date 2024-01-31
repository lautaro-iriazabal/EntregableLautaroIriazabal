using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregableLautaroIriazabal
{
    internal static class ProductoVendidoData
    {
        private static string connectionString = "tu_cadena_de_conexion";

        public static ProductoVendido ObtenerProductoVendido(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM ProductoVendido WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        ProductoVendido productoVendido = new ProductoVendido
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdProducto = Convert.ToInt32(reader["IdProducto"]),
                            Stock = Convert.ToInt32(reader["Stock"]),
                            IdVenta = Convert.ToInt32(reader["IdVenta"])
                        };

                        return productoVendido;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener producto vendido: {ex.Message}");
            }

            return null;
        }

        public static List<ProductoVendido> ListarProductosVendidos()
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM ProductoVendido", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ProductoVendido productoVendido = new ProductoVendido
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdProducto = Convert.ToInt32(reader["IdProducto"]),
                            Stock = Convert.ToInt32(reader["Stock"]),
                            IdVenta = Convert.ToInt32(reader["IdVenta"])
                        };

                        productosVendidos.Add(productoVendido);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar productos vendidos: {ex.Message}");
            }

            return productosVendidos;
        }

        public static void CrearProductoVendido(ProductoVendido productoVendido)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO ProductoVendido (IdProducto, Stock, IdVenta) VALUES (@IdProducto, @Stock, @IdVenta)", connection);
                    command.Parameters.AddWithValue("@IdProducto", productoVendido.IdProducto);
                    command.Parameters.AddWithValue("@Stock", productoVendido.Stock);
                    command.Parameters.AddWithValue("@IdVenta", productoVendido.IdVenta);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear producto vendido: {ex.Message}");
            }
        }

        public static void ModificarProductoVendido(int id, ProductoVendido productoVendido)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE ProductoVendido SET IdProducto = @IdProducto, Stock = @Stock, IdVenta = @IdVenta WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@IdProducto", productoVendido.IdProducto);
                    command.Parameters.AddWithValue("@Stock", productoVendido.Stock);
                    command.Parameters.AddWithValue("@IdVenta", productoVendido.IdVenta);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar producto vendido: {ex.Message}");
            }
        }

        public static void EliminarProductoVendido(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM ProductoVendido WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar producto vendido: {ex.Message}");
            }
        }
    }

}
