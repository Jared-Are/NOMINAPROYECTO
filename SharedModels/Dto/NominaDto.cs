using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SharedModels.Dto
{
    public class NominaDto
    {
        [Required]
        public int EmpleadoId { get; set; }
        [Required]
        [StringLength(20)]
        public string? Nombre { get; set; }
        [Required]
        [StringLength(20)]
        public string? SegundoNombre { get; set; }
        [Required]
        [StringLength(20)]
        public string? Apellido { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
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
        [Required]
        public decimal RemuneracionBruta { get; set; }
        [Required]
        public decimal InssLaboral { get; set; }
        [Required]
        public decimal IR { get; set; }
        [Required]
        public decimal OtrasDeduccion { get; set; }
        [Required]
        public decimal RemuneracionNeta { get; set; }
        [Required]
        public decimal Inatec { get; set; }
        [Required]
        public decimal InssPatronal { get; set; }
        [Required]
        public decimal RemuneracionEmpresaarial { get; set; }
    }
}
