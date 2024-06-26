using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SharedModels.Dto
{
    public class DeduccionUpdateDto
    {
        [Required]
        public decimal EmpleadoId { get; set; }
        
        [Required]
        public decimal InssLaboral { get; set; }
        [Required]
        public decimal IR { get; set; }
        [Required]
        public decimal OtrasDeduccion { get; set; }
        [Required]
        public decimal Inatec { get; set; }
        [Required]
        public decimal InssPatronal { get; set; }

    }
}
