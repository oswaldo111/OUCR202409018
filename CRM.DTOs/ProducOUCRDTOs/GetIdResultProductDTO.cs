using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.DTOs.ProducOUCRDTOs
{
    public class GetIdResultProductDTO
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string NombreOUCR{ get; set; }

        [Display(Name = "Descripcion")]
        public string DescripcionOUCR { get; set; }

        [Display(Name = "Precio")]
        public decimal PrecioOUCR { get; set; }
    }
}
