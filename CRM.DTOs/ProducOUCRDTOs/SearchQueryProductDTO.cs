using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DTOs.ProducOUCRDTOs
{
    public class SearchQueryProductDTO
    {
        [Display(Name = " Nombre")]
        public string Nombre_Like { get; set; }

        [Display(Name = "pagina")]
        public int Skip { get; set; }

        [Display(Name = "cantreg x pagina")]
        public int Take { get; set; }

        public byte SendRowCount { get; set; }


    }
}
