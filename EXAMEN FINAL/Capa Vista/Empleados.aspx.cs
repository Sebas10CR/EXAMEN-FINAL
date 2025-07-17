using EXAMEN_FINAL.Capa_Logica;
using EXAMEN_FINAL.Capa_Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EXAMEN_FINAL.Capa_Vista
{
    public partial class Empleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }



        //METODO PARA MOSTRAR ALERTA
        public static void MostrarAlerta(Page page, string message)
        {
            string script = $"<script type='text/javascript'>alert('{message}');</script>";
            ClientScriptManager cs = page.ClientScript;
            cs.RegisterStartupScript(page.GetType(), "AlertScript", script);
        }

        //METODO PARA INGRESAR EMPLEADOS
        protected void bAgregar1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(tNumeroCarnet.Text) || 
                    string.IsNullOrWhiteSpace(tNombre.Text) || 
                    string.IsNullOrWhiteSpace(tFechaNaci.Text) ||
                    string.IsNullOrWhiteSpace(tSalario.Text) ||
                    string.IsNullOrWhiteSpace(tCorreo.Text))
                {
                    MostrarAlerta(this, "Por favor complete todos los campos obligatorios");
                    return;
                }

                // Validate salary
                if (!decimal.TryParse(tSalario.Text, out decimal salario) || salario < 250000 || salario > 500000)
                {
                    MostrarAlerta(this, "El salario debe ser un número entre ₡250,000 y ₡500,000");
                    return;
                }

                // Validate email format
                if (!IsValidEmail(tCorreo.Text))
                {
                    MostrarAlerta(this, "Por favor ingrese un correo electrónico válido");
                    return;
                }

                var empleado = new clsEmpleados(
                    tNumeroCarnet.Text.Trim(),
                    tNombre.Text.Trim(),
                    tFechaNaci.Text,
                    DropDownList1.SelectedValue,
                    salario,
                    string.IsNullOrWhiteSpace(tDireccion.Text) ? "San José" : tDireccion.Text.Trim(),
                    tTelefono.Text.Trim(),
                    tCorreo.Text.Trim()
                );

                if (EmpleadosL.IngresarEmpleado(empleado.NumeroCarnet, empleado.Nombre, empleado.FechaNacimiento, 
                    empleado.Categoria, empleado.Salario, empleado.Direccion, empleado.Telefono, empleado.Correo) > 0)
                {
                    MostrarAlerta(this, "Empleado ingresado correctamente");
                    LimpiarCampos();
                    LlenarGrid();
                }
                else
                {
                    MostrarAlerta(this, "Error al ingresar empleado. Verifique que el número de carnet y correo sean únicos.");
                }
            }
            catch (Exception ex)
            {
                MostrarAlerta(this, "Error inesperado: " + ex.Message);
            }
        }
        //METODO PARA BORRAR EMPLEADOS
        protected void bBorrar1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tID.Text))
                {
                    MostrarAlerta(this, "Por favor ingrese el ID del empleado a eliminar");
                    return;
                }

                if (!int.TryParse(tID.Text, out int empleadoId))
                {
                    MostrarAlerta(this, "El ID debe ser un número válido");
                    return;
                }

                if (EmpleadosL.BorrarEmpleado(empleadoId) > 0)
                {
                    MostrarAlerta(this, "Empleado eliminado correctamente");
                    LimpiarCampos();
                    LlenarGrid();
                }
                else
                {
                    MostrarAlerta(this, "Error al eliminar empleado. Verifique que el ID exista y que no tenga asignaciones activas.");
                }
            }
            catch (Exception ex)
            {
                MostrarAlerta(this, "Error inesperado: " + ex.Message);
            }
        }





        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Empleados"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();//Refrescar
                        }
                    }
                }
            }
        }

        //METODO PARA CONSULTAR
        protected void bConsultar1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tID.Text))
                {
                    MostrarAlerta(this, "Por favor ingrese el ID del empleado a consultar");
                    return;
                }

                if (!int.TryParse(tID.Text, out int empleadoId))
                {
                    MostrarAlerta(this, "El ID debe ser un número válido");
                    return;
                }

                string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Empleados WHERE Id = @Id", con))
                    {
                        cmd.Parameters.AddWithValue("@Id", empleadoId);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridView2.DataSource = dt;
                                GridView2.DataBind();
                                
                                if (dt.Rows.Count == 0)
                                {
                                    MostrarAlerta(this, "No se encontró ningún empleado con ese ID");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarAlerta(this, "Error inesperado: " + ex.Message);
            }
        }

        // Helper method to validate email format
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Helper method to clear form fields
        private void LimpiarCampos()
        {
            tID.Text = "";
            tNumeroCarnet.Text = "";
            tNombre.Text = "";
            tFechaNaci.Text = "";
            tSalario.Text = "";
            tDireccion.Text = "";
            tTelefono.Text = "";
            tCorreo.Text = "";
            DropDownList1.SelectedIndex = 0;
        }

        // Button event handler for clearing fields
        protected void bLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            GridView2.DataSource = null;
            GridView2.DataBind();
        }

        // Button event handler for search functionality
        protected void bBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tBuscar.Text))
                {
                    MostrarAlerta(this, "Por favor ingrese un término de búsqueda");
                    return;
                }

                string termino = tBuscar.Text.Trim();
                string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = @"SELECT * FROM Empleados 
                                   WHERE NumeroCarnet LIKE @termino 
                                   OR Nombre LIKE @termino 
                                   OR Correo LIKE @termino";
                    
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@termino", "%" + termino + "%");

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridView2.DataSource = dt;
                                GridView2.DataBind();
                                
                                if (dt.Rows.Count == 0)
                                {
                                    MostrarAlerta(this, "No se encontraron empleados con ese término de búsqueda");
                                }
                                else
                                {
                                    MostrarAlerta(this, $"Se encontraron {dt.Rows.Count} empleado(s)");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarAlerta(this, "Error inesperado en la búsqueda: " + ex.Message);
            }
        }
    }
}
