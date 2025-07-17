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
    public partial class Asignaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEmpleados();
                CargarProyectos();
            }
            LlenarGrid();
        }
        //METODO PARA MOSTRAR ALERTA
        public static void MostrarAlerta(Page page, string message)
        {
            string script = $"<script type='text/javascript'>alert('{message}');</script>";
            ClientScriptManager cs = page.ClientScript;
            cs.RegisterStartupScript(page.GetType(), "AlertScript", script);
        }

        //METODO PARA INGRESAR ASIGNACIONES
        protected void bAgregar1_Click(object sender, EventArgs e)
        {
            try
            {
                // Use dropdown values if available, otherwise use text input
                string empleadoIdText = string.IsNullOrEmpty(ddlEmpleados.SelectedValue) ? tEmpleadoID.Text : ddlEmpleados.SelectedValue;
                string proyectoIdText = string.IsNullOrEmpty(ddlProyectos.SelectedValue) ? tProyectoID.Text : ddlProyectos.SelectedValue;

                // Validate required fields
                if (string.IsNullOrWhiteSpace(empleadoIdText) || 
                    string.IsNullOrWhiteSpace(proyectoIdText) || 
                    string.IsNullOrWhiteSpace(tFechaAsig.Text))
                {
                    MostrarAlerta(this, "Por favor complete todos los campos obligatorios");
                    return;
                }

                // Validate IDs are numeric
                if (!int.TryParse(empleadoIdText, out int empleadoId) || empleadoId <= 0)
                {
                    MostrarAlerta(this, "El ID del empleado debe ser un número válido mayor a 0");
                    return;
                }

                if (!int.TryParse(proyectoIdText, out int proyectoId) || proyectoId <= 0)
                {
                    MostrarAlerta(this, "El ID del proyecto debe ser un número válido mayor a 0");
                    return;
                }

                // Validate date
                if (!DateTime.TryParse(tFechaAsig.Text, out DateTime fechaAsignacion))
                {
                    MostrarAlerta(this, "Por favor ingrese una fecha válida");
                    return;
                }

                // Check if employee and project exist
                if (!EmpleadoExiste(empleadoId))
                {
                    MostrarAlerta(this, "El empleado con ID " + empleadoId + " no existe");
                    return;
                }

                if (!ProyectoExiste(proyectoId))
                {
                    MostrarAlerta(this, "El proyecto con ID " + proyectoId + " no existe");
                    return;
                }

                // Check if assignment already exists
                if (AsignacionExiste(empleadoId, proyectoId))
                {
                    MostrarAlerta(this, "Esta asignación ya existe para este empleado y proyecto");
                    return;
                }

                var asignacion = new clsAsignaciones(empleadoId, proyectoId, tFechaAsig.Text);

                if (AsignacionesL.IngresarAsignacion(asignacion.EmpleadoId, asignacion.ProyectoId, asignacion.FechaAsignacion) > 0)
                {
                    MostrarAlerta(this, "Asignación ingresada correctamente");
                    LimpiarCampos();
                    LlenarGrid();
                }
                else
                {
                    MostrarAlerta(this, "Error al ingresar la asignación");
                }
            }
            catch (Exception ex)
            {
                MostrarAlerta(this, "Error inesperado: " + ex.Message);
            }
        }
        //METODO PARA BORRAR ASIGNACIONES
        protected void bBorrar1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tID.Text))
                {
                    MostrarAlerta(this, "Por favor ingrese el ID de la asignación a eliminar");
                    return;
                }

                if (!int.TryParse(tID.Text, out int asignacionId))
                {
                    MostrarAlerta(this, "El ID debe ser un número válido");
                    return;
                }

                if (AsignacionesL.BorrarAsignacion(asignacionId) > 0)
                {
                    MostrarAlerta(this, "Asignación eliminada correctamente");
                    LimpiarCampos();
                    LlenarGrid();
                }
                else
                {
                    MostrarAlerta(this, "Error al eliminar la asignación. Verifique que el ID exista.");
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
                using (SqlCommand cmd = new SqlCommand(@"SELECT 
                    a.Id, 
                    a.EmpleadoId, 
                    e.Nombre as NombreEmpleado, 
                    a.ProyectoId, 
                    p.Nombre as NombreProyecto, 
                    a.FechaAsignacion 
                    FROM Asignaciones a 
                    LEFT JOIN Empleados e ON a.EmpleadoId = e.Id 
                    LEFT JOIN Proyectos p ON a.ProyectoId = p.Id", con))
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

        // Helper method to check if employee exists
        private bool EmpleadoExiste(int empleadoId)
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Empleados WHERE Id = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", empleadoId);
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // Helper method to check if project exists
        private bool ProyectoExiste(int proyectoId)
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Proyectos WHERE Id = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", proyectoId);
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // Helper method to check if assignment already exists
        private bool AsignacionExiste(int empleadoId, int proyectoId)
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Asignaciones WHERE EmpleadoId = @EmpleadoId AND ProyectoId = @ProyectoId", con))
                {
                    cmd.Parameters.AddWithValue("@EmpleadoId", empleadoId);
                    cmd.Parameters.AddWithValue("@ProyectoId", proyectoId);
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // Helper method to clear form fields
        private void LimpiarCampos()
        {
            tID.Text = "";
            tEmpleadoID.Text = "";
            tProyectoID.Text = "";
            tFechaAsig.Text = "";
            ddlEmpleados.SelectedIndex = 0;
            ddlProyectos.SelectedIndex = 0;
        }

        // Button event handler for clearing fields
        protected void bLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // Load employees dropdown
        protected void CargarEmpleados()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id, Nombre FROM Empleados ORDER BY Nombre", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            ddlEmpleados.DataTextField = "Nombre";
                            ddlEmpleados.DataValueField = "Id";
                            ddlEmpleados.DataSource = dt;
                            ddlEmpleados.DataBind();
                            ddlEmpleados.Items.Insert(0, new ListItem("Seleccione un empleado", ""));
                        }
                    }
                }
            }
        }

        // Load projects dropdown
        protected void CargarProyectos()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id, Nombre FROM Proyectos ORDER BY Nombre", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            ddlProyectos.DataTextField = "Nombre";
                            ddlProyectos.DataValueField = "Id";
                            ddlProyectos.DataSource = dt;
                            ddlProyectos.DataBind();
                            ddlProyectos.Items.Insert(0, new ListItem("Seleccione un proyecto", ""));
                        }
                    }
                }
            }
        }

        // Event handler for employee dropdown selection
        protected void ddlEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmpleados.SelectedValue != "")
            {
                tEmpleadoID.Text = ddlEmpleados.SelectedValue;
            }
        }

        // Event handler for project dropdown selection
        protected void ddlProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProyectos.SelectedValue != "")
            {
                tProyectoID.Text = ddlProyectos.SelectedValue;
            }
        }
    }
}