using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DTOs.ProducOUCRDTOs
{
    public class SearchResultProductsDTO
    {
        public int CountRow { get; set; }

        public List<ProductoOUCRDTO> Data { get; set; }

        public class ProductoOUCRDTO
        {
            public int Id { get; set; }

            [Display(Name = "Nombre")]
            public string NombreOUCR { get; set; }

            [Display(Name = "Descripcion")]
            public string DescripcionOUCR { get; set; }

            [Display(Name = "Precio")]
            public double PrecioOUCR { get; set; }
        }
    }
}
