using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EXAMEN_FINAL.Capa_Modelo
{
    public class clsEmpleados
    {
        public int Id { get; set; }
        public string NumeroCarnet { get; set; }
        public string Nombre { get; set; }
        public string FechaNacimiento { get; set; }
        public string Categoria { get; set; }
        public decimal Salario { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        // Constructor with default values
        public clsEmpleados()
        {
            Salario = 250000; // Default salary
            Direccion = "San José"; // Default address
        }

        // Constructor with parameters
        public clsEmpleados(string numeroCarnet, string nombre, string fechaNacimiento, 
                           string categoria, decimal salario, string direccion, string telefono, string correo)
        {
            NumeroCarnet = numeroCarnet;
            Nombre = nombre;
            FechaNacimiento = fechaNacimiento;
            Categoria = categoria;
            Salario = salario;
            Direccion = direccion;
            Telefono = telefono;
            Correo = correo;
        }
    }
}