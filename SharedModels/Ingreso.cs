using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class Ingreso
    {
        public int EmpleadoId { get; set; }
        public decimal Nombre { get; set; }
        public decimal Salario { get; set; }
        public decimal HoraExtra { get; set; }
        public decimal? Bono { get; set; }

        public decimal? Antiguedad { get; set; }
        public decimal? OtrosIngresos { get; set; }
        public decimal Comision { get; set; }
        public decimal RiesgoNocturnidad { get; set; }

        public Empleado? Empleado { get; set; }
    }
}
