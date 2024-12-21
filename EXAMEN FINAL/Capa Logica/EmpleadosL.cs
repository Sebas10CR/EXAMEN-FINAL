using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace EXAMEN_FINAL.Capa_Logica
{
    public class EmpleadosL
    {
        
        
            public static int IngresarEmpleado(string NumeroCarnet, string Nombre, string FechaNacimiento, string Categoria, decimal Salario, string Direccion, string Telefono, string Correo)
            {
                int retorno = 0;

                SqlConnection Conn = new SqlConnection();
                try
                {
                    using (Conn = DBconn.obtenerConexion())
                    {
                        SqlCommand cmd = new SqlCommand("IngresarEmpleado", Conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        cmd.Parameters.Add(new SqlParameter("@NumeroCarnet", NumeroCarnet));
                        cmd.Parameters.Add(new SqlParameter("@Nombre", Nombre));
                        cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", FechaNacimiento));
                        cmd.Parameters.Add(new SqlParameter("@Categoria", Categoria));
                        cmd.Parameters.Add(new SqlParameter("@Salario", Salario));
                        cmd.Parameters.Add(new SqlParameter("@Direccion", Direccion));
                        cmd.Parameters.Add(new SqlParameter("@Telefono", Telefono));
                        cmd.Parameters.Add(new SqlParameter("@Correo", Correo));





                        retorno = cmd.ExecuteNonQuery();
                    }
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    retorno = -1;
                }
                finally
                {
                    Conn.Close();
                }

                return retorno;
            }

            public static int BorrarEmpleado(int codigo)
            {
                int retorno = 0;

                SqlConnection Conn = new SqlConnection();
                try
                {
                    using (Conn = DBconn.obtenerConexion())
                    {
                        SqlCommand cmd = new SqlCommand("BorrarEmpleado", Conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        cmd.Parameters.Add(new SqlParameter("@Id", codigo));



                        retorno = cmd.ExecuteNonQuery();
                    }
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    retorno = -1;
                }
                finally
                {
                    Conn.Close();
                }

                return retorno;
            }
        }
    }
