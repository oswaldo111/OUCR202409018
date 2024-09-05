using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DTOs.ProducOUCRDTOs
{
    public class CreateProducDTO
    {
        [Display(Name = "nombre")]
        [Required(ErrorMessage = "el campo es obligatorio")]
        [MaxLength(30, ErrorMessage = "son 30 caracteres max")]
        public string NombreOUCR { get; set; }

        [Display(Name = "Descripcion")]
        [MaxLength(100, ErrorMessage = "son 100 caracteres max")]
        public string DescripcionoOUCR { get; set; }

        [Display(Name = "Preicio")]
        [Required(ErrorMessage = "el campo es obligatorio")]
        public double PrecioOUCR { get; set; }
    
    }
}
