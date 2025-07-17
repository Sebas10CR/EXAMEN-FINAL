using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EXAMEN_FINAL.Capa_Modelo
{
    public class clsProyectos
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }

        // Constructor with default values
        public clsProyectos()
        {
        }

        // Constructor with parameters
        public clsProyectos(string codigo, string nombre, string fechaInicio, string fechaFin)
        {
            Codigo = codigo;
            Nombre = nombre;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }
    }
}