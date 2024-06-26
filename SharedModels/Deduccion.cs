using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class Deduccion
    {
        public decimal EmpleadoId { get; set; }
        public decimal Nombre { get; set; }
        public decimal InssLaboral { get; set; }
        public decimal IR { get; set; }
        public decimal OtrasDeduccion { get; set; }
        public decimal Inatec { get; set; }
        public decimal InssPatronal { get; set; }


        public Empleado? Empleado { get; set; }
    }
}
