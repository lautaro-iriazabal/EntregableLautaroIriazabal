using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregableLautaroIriazabal
{
    internal static class VentaData
    {
        private static string connectionString = "Server=localhost;Database=CoderHouse50285C#;Trusted_Connection=True";

        public static Venta ObtenerVenta(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Venta WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Venta venta = new Venta
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Comentarios = reader["Comentarios"].ToString(),
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"])
                        };

                        return venta;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener venta: {ex.Message}");
            }

            return null;
        }

        public static List<Venta> ListarVentas()
        {
            List<Venta> ventas = new List<Venta>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Venta", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Venta venta = new Venta
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Comentarios = reader["Comentarios"].ToString(),
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"])
                        };

                        ventas.Add(venta);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar ventas: {ex.Message}");
            }

            return ventas;
        }

        public static void CrearVenta(Venta venta)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO Venta (Comentarios, IdUsuario) VALUES (@Comentarios, @IdUsuario)", connection);
                    command.Parameters.AddWithValue("@Comentarios", venta.Comentarios);
                    command.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear venta: {ex.Message}");
            }
        }

        public static void ModificarVenta(int id, Venta venta)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE Venta SET Comentarios = @Comentarios, IdUsuario = @IdUsuario WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Comentarios", venta.Comentarios);
                    command.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar venta: {ex.Message}");
            }
        }

        public static void EliminarVenta(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM Venta WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar venta: {ex.Message}");
            }
        }
    }

}
