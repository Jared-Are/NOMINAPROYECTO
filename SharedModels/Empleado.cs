
using System.ComponentModel.DataAnnotations;

namespace SharedModels
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string? Nombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? Apellido { get; set; }
        public string? SegundoApellido { get; set; }    
        public string? NInss { get; set; }
        public string? Sexo { get; set; }
        public string? Cedula { get; set; }
        public string? EstadoCivil { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaContratacion { get; set; }
        public DateTime cierradeContrato { get; set; }
        public string? Direccion { get; set; }
        public bool Estado { get; set; }
        public string Telefono { get; set; }

        public ICollection<Nomina> Nominas { get; set; }
        public ICollection<Deduccion> Deducciones { get; set; }
        public ICollection<Ingreso> Ingresos { get; set; }
    }
}
