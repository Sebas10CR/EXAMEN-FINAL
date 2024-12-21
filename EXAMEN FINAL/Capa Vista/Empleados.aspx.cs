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
            clsEmpleados.NumeroCarnet = tNumeroCarnet.Text;
            clsEmpleados.Nombre = tNombre.Text;
            clsEmpleados.FechaNacimiento = tFechaNaci.Text;
            clsEmpleados.Categoria = DropDownList1.SelectedValue;
            clsEmpleados.Salario = decimal.Parse(tSalario.Text);
            clsEmpleados.Direccion = tDireccion.Text;
            clsEmpleados.Telefono = tTelefono.Text;
            clsEmpleados.Correo = tCorreo.Text;
            if (EmpleadosL.IngresarEmpleado(clsEmpleados.NumeroCarnet, clsEmpleados.Nombre, clsEmpleados.FechaNacimiento, clsEmpleados.Categoria, clsEmpleados.Salario, clsEmpleados.Direccion, clsEmpleados.Telefono, clsEmpleados.Correo) > 0)
            {

                MostrarAlerta(this, "----Empleado Ingresado Correctamente----");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al ingresar Empleado :(...");
            }
        }
        //METODO PARA BORRAR EMPLEADOS
        protected void bBorrar1_Click(object sender, EventArgs e)
        {

            clsEmpleados.Id = int.Parse(tID.Text);
            if (EmpleadosL.BorrarEmpleado(clsEmpleados.Id) > 0)
            {
                MostrarAlerta(this, "----Empleado Eliminado Correctamente----");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al Eliminar Empleado :(...");
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
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM Empleados WHERE Id = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", tID.Text);

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView2.DataSource = dt;
                            GridView2.DataBind();
                        }
                    }
                }
            }
        }
    }
}
