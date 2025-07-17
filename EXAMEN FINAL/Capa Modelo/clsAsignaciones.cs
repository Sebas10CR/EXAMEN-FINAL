using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EXAMEN_FINAL.Capa_Modelo
{
    public class clsAsignaciones
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public int ProyectoId { get; set; }
        public string FechaAsignacion { get; set; }

        // Constructor with default values
        public clsAsignaciones()
        {
        }

        // Constructor with parameters
        public clsAsignaciones(int empleadoId, int proyectoId, string fechaAsignacion)
        {
            EmpleadoId = empleadoId;
            ProyectoId = proyectoId;
            FechaAsignacion = fechaAsignacion;
        }
    }
}