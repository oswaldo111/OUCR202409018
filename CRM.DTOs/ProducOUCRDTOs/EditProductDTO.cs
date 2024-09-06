using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DTOs.ProducOUCRDTOs
{
    public class EditProductDTO
    {
        public EditProductDTO(GetIdResultProductDTO getIdResultProduct)
        {
            Id = getIdResultProduct.Id;
            NombreOUCR = getIdResultProduct.NombreOUCR;
            DescripcionOUCR = getIdResultProduct.DescripcionOUCR;
            PrecioOUCR = getIdResultProduct.PrecioOUCR;
        }

        public EditProductDTO()
        {
            NombreOUCR = string.Empty;
            DescripcionOUCR= string.Empty;
            
        }

        [Required(ErrorMessage = "El campo id es obligatorio")]
        public int Id { get; set; }

        [Display(Name = "nombre")]
        [Required(ErrorMessage = "el campo es obligatorio")]
        [MaxLength(30, ErrorMessage = "son 30 caracteres max")]
        public string NombreOUCR { get; set; }

        [Display(Name = "Descripcion")]
        [MaxLength(100, ErrorMessage = "son 100 caracteres max")]
        public string DescripcionOUCR { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "el campo es obligatorio")]
        public decimal PrecioOUCR { get; set; }
        
    }   


}
