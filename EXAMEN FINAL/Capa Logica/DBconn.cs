using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EXAMEN_FINAL.Capa_Logica
{
    public class DBconn
    {
        public static SqlConnection obtenerConexion()
        {
            try
            {
                string s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                if (string.IsNullOrEmpty(s))
                {
                    throw new InvalidOperationException("La cadena de conexión no está configurada correctamente.");
                }
                
                SqlConnection conexion = new SqlConnection(s);
                conexion.Open();
                return conexion;
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException($"Error al conectar con la base de datos: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error inesperado al establecer la conexión: {ex.Message}", ex);
            }
        }
    }
}