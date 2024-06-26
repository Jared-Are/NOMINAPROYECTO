using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dto
{
    public class EmpleadoCreateDto
    {
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
        [StringLength(20)]
        public string? SegundoApellido { get; set; }
        [Required]
        public string? NInss { get; set; }
        [Required]
        public string? Sexo { get; set; }
        [Required]
        [EmailAddress]
        public string? Cedula { get; set; }
        [Required]
        public string? EstadoCivil { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public DateTime FechaContratacion { get; set; }
        [Required]
        public DateTime CierradeContrato { get; set; }
        [Required]
        public string? Direccion { get; set; }
        [Required]
        public bool Estado { get; set; }
        [Required]
        public string Telefono { get; set; }
    }
}
