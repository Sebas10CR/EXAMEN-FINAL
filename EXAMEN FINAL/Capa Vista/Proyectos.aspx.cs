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
    public partial class Proyectos : System.Web.UI.Page
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

        //METODO PARA INGRESAR PROYECTOS
        protected void bAgregar1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(tCodigo.Text) || 
                    string.IsNullOrWhiteSpace(tNombre.Text) || 
                    string.IsNullOrWhiteSpace(tFechaInicio.Text))
                {
                    MostrarAlerta(this, "Por favor complete todos los campos obligatorios");
                    return;
                }

                // Validate dates
                if (!DateTime.TryParse(tFechaInicio.Text, out DateTime fechaInicio))
                {
                    MostrarAlerta(this, "Por favor ingrese una fecha de inicio válida");
                    return;
                }

                if (!string.IsNullOrWhiteSpace(tFechaFin.Text))
                {
                    if (!DateTime.TryParse(tFechaFin.Text, out DateTime fechaFin))
                    {
                        MostrarAlerta(this, "Por favor ingrese una fecha de fin válida");
                        return;
                    }

                    if (fechaFin <= fechaInicio)
                    {
                        MostrarAlerta(this, "La fecha de fin debe ser posterior a la fecha de inicio");
                        return;
                    }
                }

                var proyecto = new clsProyectos(
                    tCodigo.Text.Trim(),
                    tNombre.Text.Trim(),
                    tFechaInicio.Text,
                    tFechaFin.Text
                );

                if (ProyectosL.IngresarProyecto(proyecto.Codigo, proyecto.Nombre, proyecto.FechaInicio, proyecto.FechaFin) > 0)
                {
                    MostrarAlerta(this, "Proyecto ingresado correctamente");
                    LimpiarCampos();
                    LlenarGrid();
                }
                else
                {
                    MostrarAlerta(this, "Error al ingresar proyecto. Verifique que el código y nombre sean únicos.");
                }
            }
            catch (Exception ex)
            {
                MostrarAlerta(this, "Error inesperado: " + ex.Message);
            }
        }
        //METODO PARA BORRAR PROYECTOS
        protected void bBorrar1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tID.Text))
                {
                    MostrarAlerta(this, "Por favor ingrese el ID del proyecto a eliminar");
                    return;
                }

                if (!int.TryParse(tID.Text, out int proyectoId))
                {
                    MostrarAlerta(this, "El ID debe ser un número válido");
                    return;
                }

                if (ProyectosL.BorrarProyecto(proyectoId) > 0)
                {
                    MostrarAlerta(this, "Proyecto eliminado correctamente");
                    LimpiarCampos();
                    LlenarGrid();
                }
                else
                {
                    MostrarAlerta(this, "Error al eliminar proyecto. Verifique que el ID exista y que no tenga asignaciones activas.");
                }
            }
            catch (Exception ex)
            {
                MostrarAlerta(this, "Error inesperado: " + ex.Message);
            }
        }

        // Helper method to clear form fields
        private void LimpiarCampos()
        {
            tID.Text = "";
            tCodigo.Text = "";
            tNombre.Text = "";
            tFechaInicio.Text = "";
            tFechaFin.Text = "";
        }

        // Button event handler for clearing fields
        protected void bLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Proyectos"))
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
    }
}