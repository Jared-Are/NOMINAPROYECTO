using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SharedModels.Dto
{
    public class IngresoUpdateDto
    {
        [Required]
        public int EmpleadoId { get; set; }
        [Required]
        public decimal Salario { get; set; }
        [Required]
        public decimal HoraExtra { get; set; }
        [Required]
        public decimal? Bono { get; set; }
        [Required]
        public decimal? Antiguedad { get; set; }
        [Required]
        public decimal? OtrosIngresos { get; set; }
        [Required]
        public decimal Comision { get; set; }
        [Required]
        public decimal RiesgoNocturnidad { get; set; }
    }
}
