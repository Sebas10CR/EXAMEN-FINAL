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
            clsAsignaciones.EmpleadoId = int.Parse(tEmpleadoID.Text);
            clsAsignaciones.ProyectoId = int.Parse(tProyectoID.Text);
            clsAsignaciones.FechaAsignacion = tFechaAsig.Text;
            

            if (AsignacionesL.IngresarAsignacion(clsAsignaciones.EmpleadoId, clsAsignaciones.ProyectoId, clsAsignaciones.FechaAsignacion) > 0)
            {

                MostrarAlerta(this, "----Asignacion Ingresada Correctamente----");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al ingresar Asignacion :(...");
            }
        }
        //METODO PARA BORRAR ASIGNACIONES
        protected void bBorrar1_Click(object sender, EventArgs e)
        {

            clsAsignaciones.Id = int.Parse(tID.Text);
            if (AsignacionesL.BorrarAsignacion(clsAsignaciones.Id) > 0)
            {
                MostrarAlerta(this, "----Asignacion Eliminada Correctamente----");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al Eliminar Asignacion :(...");
            }
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Asignaciones"))
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