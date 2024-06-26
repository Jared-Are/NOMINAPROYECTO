using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class Nomina
    {
        public decimal EmpleadoId { get; set; }
        public string? Nombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? Apellido { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Salario { get; set; }
        public decimal HoraExtra { get; set; }
        public decimal? Bono { get; set; }
        public decimal? OtrosIngresos { get; set; }
        public decimal Comision { get; set; }
        public decimal RiesgoNocturnidad { get; set; }
        public decimal RemuneracionBruta { get; set; }
        public decimal InssLaboral { get; set; }
        public decimal IR { get; set; }
        public decimal OtrasDeduccion { get; set; }
        public decimal RemuneracionNeta { get; set; }
        public decimal Inatec { get; set; }
        public decimal InssPatronal { get; set; }
        public decimal RemuneracionEmpresaarial { get; set; }

        public Empleado? Empleado { get; set; }
    }
}
