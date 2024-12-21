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
            clsProyectos.Codigo = tCodigo.Text;
            clsProyectos.Nombre = tNombre.Text;
            clsProyectos.FechaInicio = tFechaInicio.Text;
            clsProyectos.FechaFin = tFechaFin.Text;
           
            if (ProyectosL.IngresarProyecto(clsProyectos.Codigo, clsProyectos.Nombre, clsProyectos.FechaInicio, clsProyectos.FechaFin) > 0)
            {

                MostrarAlerta(this, "----Proyecto Ingresado Correctamente----");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al ingresar Proyecto :(...");
            }
        }
        //METODO PARA BORRAR PROYECTOS
        protected void bBorrar1_Click(object sender, EventArgs e)
        {

            clsProyectos.Id = int.Parse(tID.Text);
            if (ProyectosL.BorrarProyecto(clsProyectos.Id) > 0)
            {
                MostrarAlerta(this, "----Proyecto Eliminado Correctamente----");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al Eliminar Proyecto :(...");
            }
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